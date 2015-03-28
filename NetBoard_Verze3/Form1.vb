Public Class Form1
    Dim grp As Drawing.Graphics ' nabízí provádìní grafickıch operací
	Dim TBitmap As Drawing.Bitmap ' uloistì grafického obsahu tabule

	Dim tcp As Net.Sockets.TcpClient ' TCP klient pouívanı pøi pøipojení
	Dim tcpListener As Net.Sockets.TcpListener ' dokáe poslouchat pøíchozí TCP pøipojení
	Dim networkStream As Net.Sockets.NetworkStream ' zprostøedkuje komunikaci pøes TcpClient
	Dim hostName As String = "localhost" ' poèítaè, na kterı se pøipojíme
	Const Port As Integer = 3556 ' budeme pouívat tento port

	Enum StatusPripojeni
		Server
		Klient
	End Enum
	Dim Status As StatusPripojeni ' urèuje, zda jsme klient nebo server

	Const BUFFER_SIZE As Integer = 512 ' velikost bufferu
	Dim Buffer(BUFFER_SIZE) As Byte	 ' buffer pro pøíchozí data
	Dim text_buffer As String ' buffer ze kterého budeme data rovnou èíst a odmazávat

	Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		TBitmap = New Bitmap(PicTabule.Width, PicTabule.Height)	' inicializujeme novı objekt Bitmap s velikostí tabule
		grp = Graphics.FromImage(TBitmap) ' naváeme na TBitmap objekt grp, kterı umoní vykreslování
		grp.Clear(Color.Black) ' nastavíme barvu tabule na èernou
		grp.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias ' aktivujeme vyhlazování èar

		' pøidáme do vıbìru tloušky štetce hodnoty
		For i As Integer = 1 To 10
			ToolStripComboSirkaStetce.Items.Add(i.ToString + "px")
		Next
		ToolStripComboSirkaStetce.SelectedIndex = drawWidth - 1	' aktuálnì vybraná šírka štetce bude defaultní vıbìr
	End Sub

	Dim PosledniBod As Point ' bude potøeba si pamatovat poslední bod, kam se kreslilo
	Dim drawWidth As Integer = 10 ' šíøka kreslené èáry
	Dim drawColor As Color = Color.White ' barva štìtce
	Dim Kresleni As Boolean	' aktivuje se stisknutím levého tlaèítka na kreslící tabuli a indikuje zaèátek kreslení

	Private Sub PicTabule_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicTabule.MouseDown
		If e.Button = Windows.Forms.MouseButtons.Left Then
			PosledniBod = e.Location ' poèátek kreslení je nyní nastaven jako pozice myši
			If JsemPripojenyKlient() = False Then
				Threading.Monitor.Enter(Me)	' uzamkneme vlákno
				grp.FillEllipse(New Pen(drawColor).Brush, New RectangleF(e.X - drawWidth / 2, e.Y - drawWidth / 2, drawWidth, drawWidth)) ' vykreslíme první bod (zakulacení poèátku èáry)
				PicTabule.Invalidate() ' necháme pøekreslit PicTabule
				Threading.Monitor.Exit(Me)	' odemkneme
			End If
			Kresleni = True	' aktivujeme kreslící mód
			PosliPrikaz("cara " + e.X.ToString + " " + e.Y.ToString + " " + e.X.ToString + " " + e.Y.ToString + " " + drawWidth.ToString + " " + drawColor.R.ToString + " " + drawColor.G.ToString + " " + drawColor.B.ToString + ";")
		End If
	End Sub

	Private Sub PicTabule_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicTabule.MouseMove
		If e.Button = Windows.Forms.MouseButtons.Left And Kresleni = True Then
			If JsemPripojenyKlient() = False Then
				Threading.Monitor.Enter(Me)	' uzamkneme vlákno
				grp.DrawLine(New Pen(drawColor, drawWidth), PosledniBod, e.Location) ' vykreslíme èáru z posledního bodu, kde byla myš
				grp.FillEllipse(New Pen(drawColor).Brush, New RectangleF(e.X - drawWidth / 2, e.Y - drawWidth / 2, drawWidth, drawWidth)) ' vykreslíme zakonèovací bod (zakulacení konce èáry)
				PicTabule.Invalidate() ' nechame pøekreslit PicTabule
				Threading.Monitor.Exit(Me)	' odemkneme
			End If
			' odeslat údaje serveru
			PosliPrikaz("cara " + PosledniBod.X.ToString + " " + PosledniBod.Y.ToString + " " + e.X.ToString + " " + e.Y.ToString + " " + drawWidth.ToString + " " + drawColor.R.ToString + " " + drawColor.G.ToString + " " + drawColor.B.ToString + ";")
			PosledniBod = e.Location ' poslední bod, ze kterého se kreslilo je nyní opìt aktuální pozice myši
		End If
	End Sub

	Private Sub PicTabule_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicTabule.MouseUp
		If e.Button = Windows.Forms.MouseButtons.Left Then
			Kresleni = False ' puštìním levého tlaèítka myši opouštíme kreslící mód
		End If
	End Sub

	Private Sub PicTabule_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PicTabule.Paint
		' vykreslíme obsah TBitmap na formuláø do PicTabule
		e.Graphics.DrawImage(TBitmap, 0, 0)
	End Sub

	Private Sub ToolStripMenuItem_SmazatTabuli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_SmazatTabuli.Click
		If JsemPripojenyKlient() = False Then
			Threading.Monitor.Enter(Me)	' uzamkneme vlákno
			grp.Clear(Color.Black) ' smaeme tabuli
			PicTabule.Invalidate() ' a pøekreslíme ji
			Threading.Monitor.Exit(Me)	' odemkneme
		End If
		PosliPrikaz("smazat;") ' smaeme i u druheho 
	End Sub

	Private Sub StripMenuItemKonec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StripMenuItemKonec.Click
		End	' klepnuli jsme na Konec
	End Sub

	Private Sub ToolStripMenuItemConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemConnect.Click
		Status = StatusPripojeni.Klient	' stáváme se klientem
		ZamkniPolozky()	' uzamkneme menu, probíha pøipojování, a skonèí, menu zase odemkneme
		hostName = InputBox("Zadejte adresu serveru:", "Pøipojit se", hostName)	' vloení jména serveru pøes dialogové okno
		If String.IsNullOrEmpty(hostName) = True Then Exit Sub ' stisknuto Storno
		StripInfo.Text = "Pøípojuji se k " + hostName + ":" + Port.ToString + "..."	' informace o pøipojování na spodní lištì 
		tcp = New Net.Sockets.TcpClient
		tcp.BeginConnect(hostName, Port, AddressOf Pripojit, Nothing) ' spustíme pøipojování do jiného vlákna
	End Sub
	Sub Pripojit(ByVal at As System.IAsyncResult)
		Try
			tcp.EndConnect(at) ' dokonèíme pøipojování
			networkStream = tcp.GetStream()	' stream pro pøenos dat
			networkStream.BeginRead(Buffer, 0, BUFFER_SIZE, AddressOf CtiData, Nothing)	' zaèínáme asynchronnì èíst
			StripInfo.Text = "Pøipojeno" ' informace o pøipojení
			grp.Clear(Color.Black) ' smaeme tabuli
			Kresleni = False ' zrušíme pøípadné aktivní kreslení
			PicTabule.Invalidate() ' a pøekreslíme tabuli
			OdemkniOdpojeniPolozky() ' jsme pøipojeni - odblokujeme tlaèítko "Odpojit"
		Catch e As ObjectDisposedException
			' probìhlo stornování pøipojení, ne chyba
		Catch
			' probìhla neoèekávaná chyba
			MsgBox("Pøipojení se nezdaøilo!", MsgBoxStyle.Information)
			StripInfo.Text = "Pøipojení se nezdaøilo!" ' informace o nezdaøilém pøipojení
			OdemkniPolozky() ' nakonec odemkneme znovu poloky v menu na pøipojení a vytvoøení spojení 
		End Try
	End Sub

	Private Sub ToolStripMenuItemCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemCreate.Click
		Status = StatusPripojeni.Server	' stáváme se klientem
		ZamkniPolozky()	' uzamkneme menu, probíha èekání na klienta
		ToolStripMenuItemDisconnect.Enabled = True ' odemkneme tlaèítko "Odpojit", tím bude moné zrušit èekání
		tcpListener = New Net.Sockets.TcpListener(System.Net.IPAddress.Any, Port)  ' vytvoøíme TCP Listener

		Try
			tcpListener.Start()	' zaèneme poslouchat
		Catch
			' nelze zaèít poslouchat
			MsgBox("Nelze poslouchat na portu " + Format(Port) + "!", MsgBoxStyle.Information)
			StripInfo.Text = "Pøipojení se nezdaøilo!" ' informace o nezdaøilém pøipojení
			OdemkniPolozky() ' nakonec odemkneme znovu poloky v menu na pøipojení a vytvoøení spojení
			Exit Sub
		End Try

		' zjistíme lokální IP adresu
		Dim h As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
		Dim lokalniIP As String = CType(h.AddressList.GetValue(0), Net.IPAddress).ToString

		StripInfo.Text = "Èekám na klienta. Server: " + lokalniIP + ":" + Port.ToString + "..."	 ' informace o èekání na spodní lištì 
		tcpListener.BeginAcceptTcpClient(AddressOf KlientSePripojuje, Nothing) ' pokud se nyní nìkdo pøipojí, zavolá se funkce KlientSePripojuje
	End Sub
	Sub KlientSePripojuje(ByVal at As System.IAsyncResult)
		Try
			tcp = tcpListener.EndAcceptTcpClient(at) ' pøijmeme klienta
			tcpListener.Stop() ' zastavíme poslouchání
			networkStream = tcp.GetStream()	' stream pro pøenos dat
			networkStream.BeginRead(Buffer, 0, BUFFER_SIZE, AddressOf CtiData, Nothing)	' zaèínáme asynchronnì èíst
			StripInfo.Text = "Pøipojeno" ' informace o pøipojení
			grp.Clear(Color.Black) ' smaeme tabuli
			Kresleni = False ' zrušíme pøípadné aktivní kreslení
			PicTabule.Invalidate() ' a pøekreslíme tabuli
			OdemkniOdpojeniPolozky() ' jsme pøipojeni - odblokujeme tlaèítko "Odpojit"
		Catch e As ObjectDisposedException
			' probìhlo zastavení poslouchání, ne chyba
		Catch
			' probìhla neoèekávaná chyba
			MsgBox("Pøipojení se nezdaøilo!", MsgBoxStyle.Information)
			StripInfo.Text = "Pøipojení se nezdaøilo!" ' informace o nezdaøilém pøipojení
			OdemkniPolozky() ' nakonec odemkneme znovu poloky v menu na pøipojení a vytvoøení spojení
		End Try
	End Sub

	Sub ZamkniPolozky()
		If Me.InvokeRequired Then
			Me.Invoke(New MethodInvoker(AddressOf ZamkniPolozky))
		Else
			' zamknutí poloek v menu
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
			' pokud odemikáme i napøíklad "Pøipojit se", je jisté, e nejsme pøipojeni a tlaèítko "Odpojit" mùeme tedy zamknout
			ToolStripMenuItemDisconnect.Enabled = False
		End If
	End Sub
	Sub OdemkniOdpojeniPolozky()
		If Me.InvokeRequired Then
			Me.Invoke(New MethodInvoker(AddressOf OdemkniOdpojeniPolozky))
		Else
			' odemknutí poloky "Odpojit"
			ToolStripMenuItemDisconnect.Enabled = True
		End If
	End Sub

	Private Sub ToolStripMenuItemDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemDisconnect.Click
		' pokud se chceme odpojit, musime zjistit zda jsme server nebo klient
		If Status = StatusPripojeni.Klient Then	' pokud jsme pøipojenı klient
			tcp.Close()	' uzavøeme spojení
			StripInfo.Text = "Spojení ukonèeno"	' informujeme uivatele
		ElseIf Status = StatusPripojeni.Server Then
			' zjistíme, zda objekt tcp existuje a zda je pøipojen
			Dim Connected As Boolean = False
			If Not tcp Is Nothing Then
				If Not tcp.Client Is Nothing Then
					Connected = tcp.Connected
				End If
			End If
			If Connected = False Then  ' pokud server zatím jen poslouchá a klient není pøipojen
				tcpListener.Stop() ' zastavíme poslouchání
				StripInfo.Text = "Poslouchání ukonèeno"	' informujeme uivatele
			Else ' pokud jsme server a klient se u pøipojil
				tcp.Close()	' uzavøeme spojení
				StripInfo.Text = "Spojení ukonèeno"	' informujeme uivatele
			End If
		End If

		OdemkniPolozky() ' nakonec odemkneme znovu poloky v menu na pøipojení a vytvoøení spojení
	End Sub
	Sub CtiData(ByVal at As System.IAsyncResult)
		Try
			Dim prijato As Integer = networkStream.EndRead(at) ' dokonèíme ètení dat a zjistíme kolik dat pøišlo
			If prijato < 1 Then Throw New Exception() ' spojení bylo ukonèeno (pøichází 0B dat)

			text_buffer += System.Text.Encoding.ASCII.GetString(Buffer, 0, prijato)	' pøidání pøijatıch dat

			Do While text_buffer.Contains(";") ' dokud máme pøíkazy, které mùeme parsovat
				Dim poziceStredniku As Integer = text_buffer.IndexOf(";") ' najdeme ukonèovací znak
				Dim prikaz As String = text_buffer.Substring(0, poziceStredniku) ' pøeèteme pøíkaz a ke støedníku
				text_buffer = text_buffer.Substring(poziceStredniku + 1) ' a prikaz odøízneme
				ProvedPrikaz(prikaz) ' pošleme pøíkaz ke zpracování
			Loop

			tcp.GetStream.BeginRead(Buffer, 0, BUFFER_SIZE, AddressOf CtiData, Nothing)		  ' pøeèetli jsme všechny pøíchozí data, proto budeme èekat a pøijdou další
		Catch e As ObjectDisposedException
			' probìhlo zrušení spojení
		Catch e As Exception
			' nastala chyba, spojení je ukonèeno
			StripInfo.Text = "Spojení bylo ukonèeno" ' informace pro uivatele
			MsgBox("Spojení ukonèeno!", MsgBoxStyle.Information)
			OdemkniPolozky() ' nakonec odemkneme znovu poloky v menu na pøipojení a vytvoøení spojení
		End Try
	End Sub
	Sub ProvedPrikaz(ByVal prikaz As String)
		Try
			Dim casti As String() = Split(prikaz, " ") ' rozdìlíme pøíkaz podle mezer
			Select Case casti(0) ' zjistíme druh pøíkazu
				Case "smazat" ' smaeme tabuli
					Threading.Monitor.Enter(Me)	' uzamkneme vlákno
					grp.Clear(Color.Black)
					PicTabule.Invalidate()
					Threading.Monitor.Exit(Me)	' odemkneme
					If Status = StatusPripojeni.Server Then PosliPrikaz(casti(0) + ";") ' server pøeposíla zpìt klientovi
				Case "cara"	' nakreslí èáru
					KresliCaru(Val(casti(1)), Val(casti(2)), Val(casti(3)), Val(casti(4)), _
					Val(casti(5)), _
					Color.FromArgb(Val(casti(6)), Val(casti(7)), Val(casti(8))))
					If Status = StatusPripojeni.Server Then	' server pøeposíla zpìt klientovi
						PosliPrikaz(casti(0) + " " + casti(1) + " " + casti(2) + " " + casti(3) + " " + casti(4) + " " + casti(5) + " " + casti(6) + " " + casti(7) + " " + casti(8) + ";")
					End If
				Case Else ' neznámı pøíkaz, ukonèení pøipojení
					Throw New Exception
			End Select
		Catch e As Exception  ' chyba pøi zpracování pøikazu, ukonèení spojení
			StripInfo.Text = "Spojení bylo ukonèeno" ' informace pro uivatele
			tcp.Close()	' uzavøeme spojení'
			MsgBox("Chybná syntaxe pøíkazù!", MsgBoxStyle.Information)
			OdemkniPolozky() ' nakonec odemkneme znovu poloky v menu na pøipojení a vytvoøení spojení
		End Try
	End Sub
	Sub KresliCaru(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal drawWidth As Integer, ByVal color As Color)
		Threading.Monitor.Enter(Me)	' uzamkneme vlákno
		grp.FillEllipse(New Pen(color).Brush, New RectangleF(x1 - drawWidth / 2, y1 - drawWidth / 2, drawWidth, drawWidth))	' vykreslíme prvnotní bod (zakulacení zaèátku èáry)
		grp.DrawLine(New Pen(color, drawWidth), x1, y1, x2, y2)	' vykreslíme èáru
		grp.FillEllipse(New Pen(color).Brush, New RectangleF(x2 - drawWidth / 2, y2 - drawWidth / 2, drawWidth, drawWidth))	' vykreslíme zakonèovací bod (zakulacení konce èáry)
		PicTabule.Invalidate() ' nechame pøekreslit PicTabule
		Threading.Monitor.Exit(Me) ' odemkneme vlákno
	End Sub
	Function JsemPripojenyKlient() As Boolean
		' zjistíme, zda jsme pøipojeni
		Dim Connected As Boolean = False
		If Not tcp Is Nothing Then
			If Not tcp.Client Is Nothing Then
				Connected = tcp.Connected
			End If
		End If
		Return Connected And (Status = StatusPripojeni.Klient)
	End Function
	Sub PosliPrikaz(ByVal prikaz As String)
		' zjistíme, zda jsme pøipojeni
		Dim Connected As Boolean = False
		If Not tcp Is Nothing Then
			If Not tcp.Client Is Nothing Then
				Connected = tcp.Connected
			End If
		End If
		If Connected = False Then Exit Sub ' pokud nejsme ještì pøipojeni, tak se nic neposíla
		Try
			Dim bfr(prikaz.Length - 1) As Byte ' pole presne pro prikaz
			bfr = System.Text.Encoding.ASCII.GetBytes(prikaz) ' pøevedeme pøíkaz na pole bytù
			networkStream.Write(bfr, 0, bfr.Length)	' odeslat prikaz
		Catch e As ObjectDisposedException
			' probìhlo zrušení spojení
		Catch ex As Exception
			StripInfo.Text = "Spojení bylo ukonèeno" ' informace pro uivatele
			tcp.Close()	' chyba - uzavøít spojení
			MsgBox("Spojení ukonèeno!", MsgBoxStyle.Information)
			OdemkniPolozky() ' nakonec odemkneme znovu poloky v menu na pøipojení a vytvoøení spojení
		End Try
	End Sub
	Private Sub ToolStripMenuItemBarvaStetce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemBarvaStetce.Click
		' nastavíme dialogu aktualni barvu
		ColorDialog1.Color = drawColor
		' zobrazíme dialog
		If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
			' nová barva kreslení
			drawColor = ColorDialog1.Color
		End If
	End Sub
	Private Sub ToolStripComboSirkaStetce_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripComboSirkaStetce.SelectedIndexChanged
		' byla vybrána nová šíøka štetce 
		drawWidth = ToolStripComboSirkaStetce.SelectedIndex + 1
	End Sub
End Class
