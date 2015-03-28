Public Class Form1
    Dim grp As Drawing.Graphics                         ' nabízí provádění grafických operací 
    Dim PosledniBod As Point                            ' bude potřeba si pamatovat poslední bod, kam se kreslilo 
    Dim drawWidth As Integer = 10                       ' šířka kreslené čáry 
    Dim drawColor As Color = Color.White                ' barva štětce 
    Dim Kresleni As Boolean                             ' aktivuje se stisknutím levého tlačítka na kreslící tabuli a indikuje začátek kreslení 
    Dim tcp As Net.Sockets.TcpClient                    ' TCP klient používaný při připojení 
    Dim tcpListener As Net.Sockets.TcpListener          ' dokáže poslouchat příchozí TCP připojení 
    Dim networkStream As Net.Sockets.NetworkStream      ' zprostředkuje komunikaci přes TcpClient 
    Dim hostName As String = "localhost"                ' počítač, na který se připojíme 
    Dim Status As StatusPripojeni                       ' určuje, zda jsme klient nebo server 
    Dim TBitmap As Drawing.Bitmap                       ' uložistě grafického obsahu tabule 
    Const BUFFER_SIZE As Integer = 512                  ' velikost bufferu 
    Dim Buffer(BUFFER_SIZE) As Byte                     ' buffer pro příchozí data 
    Dim text_buffer As String                           ' buffer ze kterého budeme data rovnou číst a odmazávat 
    Const Port As Integer = 3556                        ' budeme používat tento port 

    Enum StatusPripojeni
        Server
        Klient
    End Enum

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TBitmap = New Bitmap(PicTabule.Width, PicTabule.Height) ' inicializujeme nový objekt Bitmap s velikostí tabule 
        grp = Graphics.FromImage(TBitmap) ' navážeme na TBitmap objekt grp, který umožní vykreslování 
        grp.Clear(Color.Black) ' nastavíme barvu tabule na černou 
        ' přidáme do výběru tloušťky štětce hodnoty 
        For i As Integer = 1 To 10
            ToolStripComboSirkaStetce.Items.Add(i.ToString + "px")
        Next
        ToolStripComboSirkaStetce.SelectedIndex = drawWidth - 1 ' aktuálně vybraná šírka štětce bude defaultní výběr 
        grp.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias ' aktivujeme vyhlazování čar 
    End Sub

    Private Sub PicTabule_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pictabule.Paint
        ' vykreslíme obsah TBitmap na formulář do PicTabule 
        e.Graphics.DrawImage(TBitmap, 0, 0)
    End Sub

    Private Sub ToolStripMenuItemSmazatTabuli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemSmazatTabuli.Click
        grp.Clear(Color.Black) ' smažeme tabuli 
        Pictabule.Invalidate() ' a překreslíme ji 
    End Sub

    Private Sub StripMenuItemKonec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles konec.Click
        End ' klepnuli jsme na Konec 
    End Sub

    Private Sub ToolStripMenuItemConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemConnect.Click
        Status = StatusPripojeni.Klient    ' stáváme se klientem 
        ZamkniPolozky()    ' uzamkneme menu, probíha připojování, až skončí, menu zase odemkneme 
        hostName = InputBox("Zadejte adresu serveru:", "Připojit se", hostName)    ' vložení jména serveru přes dialogové okno 
        If String.IsNullOrEmpty(hostName) = True Then Exit Sub ' stisknuto Storno 
        StripInfo.Text = "Přípojuji se k " + hostName + ":" + Port.ToString + "..."    ' informace o připojování na spodní liště 
        tcp = New Net.Sockets.TcpClient
        tcp.BeginConnect(hostName, Port, AddressOf Pripojit, Nothing) ' spustíme připojování do jiného vlákna 
    End Sub

    Sub ZamkniPolozky()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf ZamkniPolozky))
        Else
            ' zamknutí položek v menu 
            ToolStripMenuItemCreate.Enabled = False
            ToolStripMenuItemConnect.Enabled = False
        End If
    End Sub

    Sub OdemkniPolozky()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf OdemkniPolozky))
        Else
            ToolStripMenuItemCreate.Enabled = True
            ToolStripMenuItemConnect.Enabled = True
            ' pokud odemikáme i například "Připojit se", je jisté, že nejsme připojeni a tlačítko "Odpojit" můžeme tedy zamknout 
            ToolStripMenuItemDisconnect.Enabled = False
        End If
    End Sub

    Sub OdemkniOdpojeniPolozky()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf OdemkniOdpojeniPolozky))
        Else
            ' odemknutí položky "Odpojit" 
            ToolStripMenuItemDisconnect.Enabled = True
        End If
    End Sub

    Sub Pripojit(ByVal at As System.IAsyncResult)
        Try
            tcp.EndConnect(at) ' dokončíme připojování
            networkStream = tcp.GetStream()    ' stream pro přenos dat
            StripInfo.Text = "Připojeno" ' informace o připojení
            grp.Clear(Color.Black) ' smažeme tabuli
            Kresleni = False ' zrušíme případné aktivní kreslení
            Pictabule.Invalidate() ' a překreslíme tabuli
            OdemkniOdpojeniPolozky() ' jsme připojeni - odblokujeme tlačítko "Odpojit"
        Catch e As ObjectDisposedException
            ' proběhlo stornování připojení, ne chyba
        Catch
            ' proběhla neočekávaná chyba
            MsgBox("Připojení se nezdařilo!", MsgBoxStyle.Information)
            StripInfo.Text = "Připojení se nezdařilo!" ' informace o nezdařilém připojení
            OdemkniPolozky() ' nakonec odemkneme znovu položky v menu na připojení a vytvoření spojení
        End Try
    End Sub

    Private Sub ToolStripMenuItemCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemCreate.Click
        Status = StatusPripojeni.Server    ' stáváme se klientem 
        ZamkniPolozky()    ' uzamkneme menu, probíha čekání na klienta 
        ToolStripMenuItemDisconnect.Enabled = True ' odemkneme tlačítko "Odpojit", tím bude možné zrušit čekání 
        tcpListener = New Net.Sockets.TcpListener(System.Net.IPAddress.Any, Port)  ' vytvoříme TCP Listener 

        Try
            tcpListener.Start()    ' začneme poslouchat 
        Catch
            ' nelze začít poslouchat 
            MsgBox("Nelze poslouchat na portu " + Format(Port) + "!", MsgBoxStyle.Information)
            StripInfo.Text = "Připojení se nezdařilo!" ' informace o nezdařilém připojení 
            OdemkniPolozky() ' nakonec odemkneme znovu položky v menu na připojení a vytvoření spojení 
            Exit Sub
        End Try

        ' zjistíme lokální IP adresu 
        Dim h As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
        Dim lokalniIP As String = CType(h.AddressList.GetValue(0), Net.IPAddress).ToString

        StripInfo.Text = "Čekám na klienta. Server: " + lokalniIP + ":" + Port.ToString + "..."     ' informace o čekání na spodní liště 
        tcpListener.BeginAcceptTcpClient(AddressOf KlientSePripojuje, Nothing) ' pokud se nyní někdo připojí, zavolá se funkce KlientSePripojuje 
    End Sub

    Sub KlientSePripojuje(ByVal at As System.IAsyncResult)
        Try
            tcp = tcpListener.EndAcceptTcpClient(at) ' přijmeme klienta 
            tcpListener.Stop() ' zastavíme poslouchání 
            networkStream = tcp.GetStream()    ' stream pro přenos dat 
            networkStream.BeginRead(Buffer, 0, BUFFER_SIZE, AddressOf CtiData, Nothing) ' začínáme asynchronně číst 
            StripInfo.Text = "Připojeno" ' informace o připojení 
            grp.Clear(Color.Black) ' smažeme tabuli 
            Kresleni = False ' zrušíme případné aktivní kreslení 
            Pictabule.Invalidate() ' a překreslíme tabuli 
            OdemkniOdpojeniPolozky() ' jsme připojeni - odblokujeme tlačítko "Odpojit" 
        Catch e As ObjectDisposedException
            ' proběhlo zastavení poslouchání, ne chyba 
        Catch
            ' proběhla neočekávaná chyba 
            MsgBox("Připojení se nezdařilo!", MsgBoxStyle.Information)
            StripInfo.Text = "Připojení se nezdařilo!" ' informace o nezdařilém připojení 
            OdemkniPolozky() ' nakonec odemkneme znovu položky v menu na připojení a vytvoření spojení 
        End Try
    End Sub

    Private Sub ToolStripMenuItemDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemDisconnect.Click
        ' pokud se chceme odpojit, musime zjistit zda jsme server nebo klient 
        If Status = StatusPripojeni.Klient Then    ' pokud jsme připojený klient 
            tcp.Close()    ' uzavřeme spojení 
            StripInfo.Text = "Spojení ukončeno"    ' informujeme uživatele 
        ElseIf Status = StatusPripojeni.Server Then
            ' zjistíme, zda objekt tcp existuje a zda je připojen 
            Dim Connected As Boolean = False
            If Not tcp Is Nothing Then
                If Not tcp.Client Is Nothing Then
                    Connected = tcp.Connected
                End If
            End If
            If Connected = False Then  ' pokud server zatím jen poslouchá a klient není připojen 
                tcpListener.Stop() ' zastavíme poslouchání 
                StripInfo.Text = "Poslouchání ukončeno"    ' informujeme uživatele 
            Else ' pokud jsme server a klient se už připojil 
                tcp.Close()    ' uzavřeme spojení 
                StripInfo.Text = "Spojení ukončeno"    ' informujeme uživatele 
            End If
        End If

        OdemkniPolozky() ' nakonec odemkneme znovu položky v menu na připojení a vytvoření spojení 
    End Sub

    Private Sub ZvolitBarvuŠtětceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZvolitBarvuŠtětceToolStripMenuItem.Click
        ' nastavíme dialogu aktuální barvu 
        ColorDialog1.Color = drawColor
        ' zobrazíme dialog 
        If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' nová barva kreslení 
            drawColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub ToolStripComboSirkaStetce_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripComboSirkaStetce.SelectedIndexChanged
        ' byla vybrána nová šířka štetce 
        drawWidth = ToolStripComboSirkaStetce.SelectedIndex + 1
    End Sub

    Sub CtiData(ByVal at As System.IAsyncResult)
        Try
            Dim prijato As Integer = networkStream.EndRead(at) ' dokončíme čtení dat a zjistíme kolik dat přišlo 
            If prijato < 1 Then Throw New Exception() ' spojení bylo ukončeno (přichází 0B dat) 

            text_buffer += System.Text.Encoding.ASCII.GetString(Buffer, 0, prijato)    ' přidání přijatých dat 

            Do While text_buffer.Contains(";") ' dokud máme příkazy, které můžeme parsovat 
                Dim poziceStredniku As Integer = text_buffer.IndexOf(";") ' najdeme ukončovací znak 
                Dim prikaz As String = text_buffer.Substring(0, poziceStredniku) ' přečteme příkaz až ke středníku 
                text_buffer = text_buffer.Substring(poziceStredniku + 1) ' a prikaz odřízneme 
                ProvedPrikaz(prikaz) ' pošleme příkaz ke zpracování 
            Loop


            tcp.GetStream.BeginRead(Buffer, 0, BUFFER_SIZE, AddressOf CtiData, Nothing)          ' přečetli jsme všechny příchozí data, proto budeme čekat až přijdou další 
        Catch e As ObjectDisposedException
            ' proběhlo zrušení spojení 
        Catch e As Exception
            MsgBox(e.Message)
            ' nastala chyba, spojení je ukončeno 
            StripInfo.Text = "Spojení bylo ukončeno" ' informace pro uživatele 
            MsgBox("Spojení ukončeno!", MsgBoxStyle.Information)
            OdemkniPolozky() ' nakonec odemkneme znovu položky v menu na připojení a vytvoření spojení 
        End Try
    End Sub

    Sub PosliPrikaz(ByVal prikaz As String)
        ' zjistíme, zda jsme připojeni 
        Dim Connected As Boolean = False
        If Not tcp Is Nothing Then
            If Not tcp.Client Is Nothing Then
                Connected = tcp.Connected
            End If
        End If
        If Connected = False Then Exit Sub ' pokud nejsme ještě připojeni, tak se nic neposíla 
        Try
            Dim bfr(prikaz.Length - 1) As Byte ' pole presne pro prikaz 
            bfr = System.Text.Encoding.ASCII.GetBytes(prikaz) ' převedeme příkaz na pole bytů 
            networkStream.Write(bfr, 0, bfr.Length) ' odeslat prikaz 
        Catch e As ObjectDisposedException
            ' proběhlo zrušení spojení 
        Catch ex As Exception
            StripInfo.Text = "Spojení bylo ukončeno" ' informace pro uživatele 
            tcp.Close() ' chyba - uzavřít spojení 
            MsgBox("Spojení ukončeno!", MsgBoxStyle.Information)
            OdemkniPolozky() ' nakonec odemkneme znovu položky v menu na připojení a vytvoření spojení 
        End Try
    End Sub

    Sub KresliCaru(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal drawWidth As Integer, ByVal color As Color)
        Threading.Monitor.Enter(Me)    ' uzamkneme vlákno 
        grp.FillEllipse(New Pen(color).Brush, New RectangleF(x1 - drawWidth / 2, y1 - drawWidth / 2, drawWidth, drawWidth))    ' vykreslíme prvnotní bod (zakulacení začátku čáry) 
        grp.DrawLine(New Pen(color, drawWidth), x1, y1, x2, y2)    ' vykreslíme čáru 
        grp.FillEllipse(New Pen(color).Brush, New RectangleF(x2 - drawWidth / 2, y2 - drawWidth / 2, drawWidth, drawWidth))    ' vykreslíme zakončovací bod (zakulacení konce čáry) 
        Pictabule.Invalidate() ' nechame překreslit PicTabule 
        Threading.Monitor.Exit(Me) ' odemkneme vlákno 
    End Sub

    Sub ProvedPrikaz(ByVal prikaz As String)
        Try
            Dim casti As String() = Split(prikaz, " ") ' rozdělíme příkaz podle mezer 
            Select Case casti(0) ' zjistíme druh příkazu 
                Case "smazat" ' smažeme tabuli 
                    Threading.Monitor.Enter(Me)    ' uzamkneme vlákno 
                    grp.Clear(Color.Black)
                    Pictabule.Invalidate()
                    Threading.Monitor.Exit(Me)    ' odemkneme 
                    If Status = StatusPripojeni.Server Then PosliPrikaz(casti(0) + ";") ' server přeposíla zpět klientovi 
                Case "cara"    ' nakreslí čáru 
                    KresliCaru(Val(casti(1)), Val(casti(2)), Val(casti(3)), Val(casti(4)), _
                    Val(casti(5)), _
                    Color.FromArgb(Val(casti(6)), Val(casti(7)), Val(casti(8))))
                    If Status = StatusPripojeni.Server Then    ' server přeposíla zpět klientovi 
                        PosliPrikaz(casti(0) + " " + casti(1) + " " + casti(2) + " " + casti(3) + " " + casti(4) + " " + casti(5) + " " + casti(6) + " " + casti(7) + " " + casti(8) + ";")
                    End If
                Case Else ' neznámý příkaz, ukončení připojení 
                    Throw New Exception
            End Select
        Catch e As Exception  ' chyba při zpracování přikazu, ukončení spojení 
            StripInfo.Text = "Spojení bylo ukončeno" ' informace pro uživatele 
            tcp.Close()    ' uzavřeme spojení' 
            MsgBox("Chybná syntaxe příkazů!", MsgBoxStyle.Information)
            OdemkniPolozky() ' nakonec odemkneme znovu položky v menu na připojení a vytvoření spojení 
        End Try
    End Sub

    Function JsemPripojenyKlient() As Boolean
        ' zjistíme, zda jsme připojeni 
        Dim Connected As Boolean = False
        If Not tcp Is Nothing Then
            If Not tcp.Client Is Nothing Then
                Connected = tcp.Connected
            End If
        End If
        Return Connected And (Status = StatusPripojeni.Klient)
    End Function

    Private Sub ToolStripMenuItem_SmazatTabuli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemSmazatTabuli.Click
        If JsemPripojenyKlient() = False Then
            Threading.Monitor.Enter(Me)    ' uzamkneme vlákno 
            grp.Clear(Color.Black) ' smažeme tabuli 
            Pictabule.Invalidate() ' a překreslíme ji 
            Threading.Monitor.Exit(Me)    ' odemkneme 
        End If
        PosliPrikaz("smazat;") ' smažeme i u druheho 
    End Sub

    Private Sub PicTabule_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pictabule.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            PosledniBod = e.Location ' počátek kreslení je nyní nastaven jako pozice myši 
            If JsemPripojenyKlient() = False Then
                Threading.Monitor.Enter(Me)    ' uzamkneme vlákno 
                grp.FillEllipse(New Pen(drawColor).Brush, New RectangleF(e.X - drawWidth / 2, e.Y - drawWidth / 2, drawWidth, drawWidth)) ' vykreslíme první bod (zakulacení počátku čáry) 
                Pictabule.Invalidate() ' necháme překreslit PicTabule 
                Threading.Monitor.Exit(Me)    ' odemkneme 
            End If
            Kresleni = True    ' aktivujeme kreslící mód 
            PosliPrikaz("cara " + e.X.ToString + " " + e.Y.ToString + " " + e.X.ToString + " " + e.Y.ToString + " " + drawWidth.ToString + " " + drawColor.R.ToString + " " + drawColor.G.ToString + " " + drawColor.B.ToString + ";")
        End If
    End Sub

    Private Sub PicTabule_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pictabule.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left And Kresleni = True Then
            If JsemPripojenyKlient() = False Then
                Threading.Monitor.Enter(Me)    ' uzamkneme vlákno 
                grp.DrawLine(New Pen(drawColor, drawWidth), PosledniBod, e.Location) ' vykreslíme čáru z posledního bodu, kde byla myš 
                grp.FillEllipse(New Pen(drawColor).Brush, New RectangleF(e.X - drawWidth / 2, e.Y - drawWidth / 2, drawWidth, drawWidth)) ' vykreslíme zakončovací bod (zakulacení konce čáry) 
                Pictabule.Invalidate() ' nechame překreslit PicTabule 
                Threading.Monitor.Exit(Me)    ' odemkneme 
            End If
            ' odeslat údaje serveru 
            PosliPrikaz("cara " + PosledniBod.X.ToString + " " + PosledniBod.Y.ToString + " " + e.X.ToString + " " + e.Y.ToString + " " + drawWidth.ToString + " " + drawColor.R.ToString + " " + drawColor.G.ToString + " " + drawColor.B.ToString + ";")
            PosledniBod = e.Location ' poslední bod, ze kterého se kreslilo je nyní opět aktuální pozice myši 
        End If
    End Sub

    Private Sub PicTabule_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pictabule.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Kresleni = False ' puštěním levého tlačítka myši opouštíme kreslící mód 
        End If
    End Sub
End Class
