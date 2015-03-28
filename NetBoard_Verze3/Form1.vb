Public Class Form1
    Dim grp As Drawing.Graphics ' nab�z� prov�d�n� grafick�ch operac�
	Dim TBitmap As Drawing.Bitmap ' ulo�ist� grafick�ho obsahu tabule

	Dim tcp As Net.Sockets.TcpClient ' TCP klient pou��van� p�i p�ipojen�
	Dim tcpListener As Net.Sockets.TcpListener ' dok�e poslouchat p��choz� TCP p�ipojen�
	Dim networkStream As Net.Sockets.NetworkStream ' zprost�edkuje komunikaci p�es TcpClient
	Dim hostName As String = "localhost" ' po��ta�, na kter� se p�ipoj�me
	Const Port As Integer = 3556 ' budeme pou��vat tento port

	Enum StatusPripojeni
		Server
		Klient
	End Enum
	Dim Status As StatusPripojeni ' ur�uje, zda jsme klient nebo server

	Const BUFFER_SIZE As Integer = 512 ' velikost bufferu
	Dim Buffer(BUFFER_SIZE) As Byte	 ' buffer pro p��choz� data
	Dim text_buffer As String ' buffer ze kter�ho budeme data rovnou ��st a odmaz�vat

	Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		TBitmap = New Bitmap(PicTabule.Width, PicTabule.Height)	' inicializujeme nov� objekt Bitmap s velikost� tabule
		grp = Graphics.FromImage(TBitmap) ' nav�eme na TBitmap objekt grp, kter� umo�n� vykreslov�n�
		grp.Clear(Color.Black) ' nastav�me barvu tabule na �ernou
		grp.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias ' aktivujeme vyhlazov�n� �ar

		' p�id�me do v�b�ru tlou��ky �tetce hodnoty
		For i As Integer = 1 To 10
			ToolStripComboSirkaStetce.Items.Add(i.ToString + "px")
		Next
		ToolStripComboSirkaStetce.SelectedIndex = drawWidth - 1	' aktu�ln� vybran� ��rka �tetce bude defaultn� v�b�r
	End Sub

	Dim PosledniBod As Point ' bude pot�eba si pamatovat posledn� bod, kam se kreslilo
	Dim drawWidth As Integer = 10 ' ���ka kreslen� ��ry
	Dim drawColor As Color = Color.White ' barva �t�tce
	Dim Kresleni As Boolean	' aktivuje se stisknut�m lev�ho tla��tka na kresl�c� tabuli a indikuje za��tek kreslen�

	Private Sub PicTabule_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicTabule.MouseDown
		If e.Button = Windows.Forms.MouseButtons.Left Then
			PosledniBod = e.Location ' po��tek kreslen� je nyn� nastaven jako pozice my�i
			If JsemPripojenyKlient() = False Then
				Threading.Monitor.Enter(Me)	' uzamkneme vl�kno
				grp.FillEllipse(New Pen(drawColor).Brush, New RectangleF(e.X - drawWidth / 2, e.Y - drawWidth / 2, drawWidth, drawWidth)) ' vykresl�me prvn� bod (zakulacen� po��tku ��ry)
				PicTabule.Invalidate() ' nech�me p�ekreslit PicTabule
				Threading.Monitor.Exit(Me)	' odemkneme
			End If
			Kresleni = True	' aktivujeme kresl�c� m�d
			PosliPrikaz("cara " + e.X.ToString + " " + e.Y.ToString + " " + e.X.ToString + " " + e.Y.ToString + " " + drawWidth.ToString + " " + drawColor.R.ToString + " " + drawColor.G.ToString + " " + drawColor.B.ToString + ";")
		End If
	End Sub

	Private Sub PicTabule_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicTabule.MouseMove
		If e.Button = Windows.Forms.MouseButtons.Left And Kresleni = True Then
			If JsemPripojenyKlient() = False Then
				Threading.Monitor.Enter(Me)	' uzamkneme vl�kno
				grp.DrawLine(New Pen(drawColor, drawWidth), PosledniBod, e.Location) ' vykresl�me ��ru z posledn�ho bodu, kde byla my�
				grp.FillEllipse(New Pen(drawColor).Brush, New RectangleF(e.X - drawWidth / 2, e.Y - drawWidth / 2, drawWidth, drawWidth)) ' vykresl�me zakon�ovac� bod (zakulacen� konce ��ry)
				PicTabule.Invalidate() ' nechame p�ekreslit PicTabule
				Threading.Monitor.Exit(Me)	' odemkneme
			End If
			' odeslat �daje serveru
			PosliPrikaz("cara " + PosledniBod.X.ToString + " " + PosledniBod.Y.ToString + " " + e.X.ToString + " " + e.Y.ToString + " " + drawWidth.ToString + " " + drawColor.R.ToString + " " + drawColor.G.ToString + " " + drawColor.B.ToString + ";")
			PosledniBod = e.Location ' posledn� bod, ze kter�ho se kreslilo je nyn� op�t aktu�ln� pozice my�i
		End If
	End Sub

	Private Sub PicTabule_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicTabule.MouseUp
		If e.Button = Windows.Forms.MouseButtons.Left Then
			Kresleni = False ' pu�t�n�m lev�ho tla��tka my�i opou�t�me kresl�c� m�d
		End If
	End Sub

	Private Sub PicTabule_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PicTabule.Paint
		' vykresl�me obsah TBitmap na formul�� do PicTabule
		e.Graphics.DrawImage(TBitmap, 0, 0)
	End Sub

	Private Sub ToolStripMenuItem_SmazatTabuli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_SmazatTabuli.Click
		If JsemPripojenyKlient() = False Then
			Threading.Monitor.Enter(Me)	' uzamkneme vl�kno
			grp.Clear(Color.Black) ' sma�eme tabuli
			PicTabule.Invalidate() ' a p�ekresl�me ji
			Threading.Monitor.Exit(Me)	' odemkneme
		End If
		PosliPrikaz("smazat;") ' sma�eme i u druheho 
	End Sub

	Private Sub StripMenuItemKonec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StripMenuItemKonec.Click
		End	' klepnuli jsme na Konec
	End Sub

	Private Sub ToolStripMenuItemConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemConnect.Click
		Status = StatusPripojeni.Klient	' st�v�me se klientem
		ZamkniPolozky()	' uzamkneme menu, prob�ha p�ipojov�n�, a� skon��, menu zase odemkneme
		hostName = InputBox("Zadejte adresu serveru:", "P�ipojit se", hostName)	' vlo�en� jm�na serveru p�es dialogov� okno
		If String.IsNullOrEmpty(hostName) = True Then Exit Sub ' stisknuto Storno
		StripInfo.Text = "P��pojuji se k " + hostName + ":" + Port.ToString + "..."	' informace o p�ipojov�n� na spodn� li�t� 
		tcp = New Net.Sockets.TcpClient
		tcp.BeginConnect(hostName, Port, AddressOf Pripojit, Nothing) ' spust�me p�ipojov�n� do jin�ho vl�kna
	End Sub
	Sub Pripojit(ByVal at As System.IAsyncResult)
		Try
			tcp.EndConnect(at) ' dokon��me p�ipojov�n�
			networkStream = tcp.GetStream()	' stream pro p�enos dat
			networkStream.BeginRead(Buffer, 0, BUFFER_SIZE, AddressOf CtiData, Nothing)	' za��n�me asynchronn� ��st
			StripInfo.Text = "P�ipojeno" ' informace o p�ipojen�
			grp.Clear(Color.Black) ' sma�eme tabuli
			Kresleni = False ' zru��me p��padn� aktivn� kreslen�
			PicTabule.Invalidate() ' a p�ekresl�me tabuli
			OdemkniOdpojeniPolozky() ' jsme p�ipojeni - odblokujeme tla��tko "Odpojit"
		Catch e As ObjectDisposedException
			' prob�hlo stornov�n� p�ipojen�, ne chyba
		Catch
			' prob�hla neo�ek�van� chyba
			MsgBox("P�ipojen� se nezda�ilo!", MsgBoxStyle.Information)
			StripInfo.Text = "P�ipojen� se nezda�ilo!" ' informace o nezda�il�m p�ipojen�
			OdemkniPolozky() ' nakonec odemkneme znovu polo�ky v menu na p�ipojen� a vytvo�en� spojen� 
		End Try
	End Sub

	Private Sub ToolStripMenuItemCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemCreate.Click
		Status = StatusPripojeni.Server	' st�v�me se klientem
		ZamkniPolozky()	' uzamkneme menu, prob�ha �ek�n� na klienta
		ToolStripMenuItemDisconnect.Enabled = True ' odemkneme tla��tko "Odpojit", t�m bude mo�n� zru�it �ek�n�
		tcpListener = New Net.Sockets.TcpListener(System.Net.IPAddress.Any, Port)  ' vytvo��me TCP Listener

		Try
			tcpListener.Start()	' za�neme poslouchat
		Catch
			' nelze za��t poslouchat
			MsgBox("Nelze poslouchat na portu " + Format(Port) + "!", MsgBoxStyle.Information)
			StripInfo.Text = "P�ipojen� se nezda�ilo!" ' informace o nezda�il�m p�ipojen�
			OdemkniPolozky() ' nakonec odemkneme znovu polo�ky v menu na p�ipojen� a vytvo�en� spojen�
			Exit Sub
		End Try

		' zjist�me lok�ln� IP adresu
		Dim h As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
		Dim lokalniIP As String = CType(h.AddressList.GetValue(0), Net.IPAddress).ToString

		StripInfo.Text = "�ek�m na klienta. Server: " + lokalniIP + ":" + Port.ToString + "..."	 ' informace o �ek�n� na spodn� li�t� 
		tcpListener.BeginAcceptTcpClient(AddressOf KlientSePripojuje, Nothing) ' pokud se nyn� n�kdo p�ipoj�, zavol� se funkce KlientSePripojuje
	End Sub
	Sub KlientSePripojuje(ByVal at As System.IAsyncResult)
		Try
			tcp = tcpListener.EndAcceptTcpClient(at) ' p�ijmeme klienta
			tcpListener.Stop() ' zastav�me poslouch�n�
			networkStream = tcp.GetStream()	' stream pro p�enos dat
			networkStream.BeginRead(Buffer, 0, BUFFER_SIZE, AddressOf CtiData, Nothing)	' za��n�me asynchronn� ��st
			StripInfo.Text = "P�ipojeno" ' informace o p�ipojen�
			grp.Clear(Color.Black) ' sma�eme tabuli
			Kresleni = False ' zru��me p��padn� aktivn� kreslen�
			PicTabule.Invalidate() ' a p�ekresl�me tabuli
			OdemkniOdpojeniPolozky() ' jsme p�ipojeni - odblokujeme tla��tko "Odpojit"
		Catch e As ObjectDisposedException
			' prob�hlo zastaven� poslouch�n�, ne chyba
		Catch
			' prob�hla neo�ek�van� chyba
			MsgBox("P�ipojen� se nezda�ilo!", MsgBoxStyle.Information)
			StripInfo.Text = "P�ipojen� se nezda�ilo!" ' informace o nezda�il�m p�ipojen�
			OdemkniPolozky() ' nakonec odemkneme znovu polo�ky v menu na p�ipojen� a vytvo�en� spojen�
		End Try
	End Sub

	Sub ZamkniPolozky()
		If Me.InvokeRequired Then
			Me.Invoke(New MethodInvoker(AddressOf ZamkniPolozky))
		Else
			' zamknut� polo�ek v menu
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
			' pokud odemik�me i nap��klad "P�ipojit se", je jist�, �e nejsme p�ipojeni a tla��tko "Odpojit" m��eme tedy zamknout
			ToolStripMenuItemDisconnect.Enabled = False
		End If
	End Sub
	Sub OdemkniOdpojeniPolozky()
		If Me.InvokeRequired Then
			Me.Invoke(New MethodInvoker(AddressOf OdemkniOdpojeniPolozky))
		Else
			' odemknut� polo�ky "Odpojit"
			ToolStripMenuItemDisconnect.Enabled = True
		End If
	End Sub

	Private Sub ToolStripMenuItemDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemDisconnect.Click
		' pokud se chceme odpojit, musime zjistit zda jsme server nebo klient
		If Status = StatusPripojeni.Klient Then	' pokud jsme p�ipojen� klient
			tcp.Close()	' uzav�eme spojen�
			StripInfo.Text = "Spojen� ukon�eno"	' informujeme u�ivatele
		ElseIf Status = StatusPripojeni.Server Then
			' zjist�me, zda objekt tcp existuje a zda je p�ipojen
			Dim Connected As Boolean = False
			If Not tcp Is Nothing Then
				If Not tcp.Client Is Nothing Then
					Connected = tcp.Connected
				End If
			End If
			If Connected = False Then  ' pokud server zat�m jen poslouch� a klient nen� p�ipojen
				tcpListener.Stop() ' zastav�me poslouch�n�
				StripInfo.Text = "Poslouch�n� ukon�eno"	' informujeme u�ivatele
			Else ' pokud jsme server a klient se u� p�ipojil
				tcp.Close()	' uzav�eme spojen�
				StripInfo.Text = "Spojen� ukon�eno"	' informujeme u�ivatele
			End If
		End If

		OdemkniPolozky() ' nakonec odemkneme znovu polo�ky v menu na p�ipojen� a vytvo�en� spojen�
	End Sub
	Sub CtiData(ByVal at As System.IAsyncResult)
		Try
			Dim prijato As Integer = networkStream.EndRead(at) ' dokon��me �ten� dat a zjist�me kolik dat p�i�lo
			If prijato < 1 Then Throw New Exception() ' spojen� bylo ukon�eno (p�ich�z� 0B dat)

			text_buffer += System.Text.Encoding.ASCII.GetString(Buffer, 0, prijato)	' p�id�n� p�ijat�ch dat

			Do While text_buffer.Contains(";") ' dokud m�me p��kazy, kter� m��eme parsovat
				Dim poziceStredniku As Integer = text_buffer.IndexOf(";") ' najdeme ukon�ovac� znak
				Dim prikaz As String = text_buffer.Substring(0, poziceStredniku) ' p�e�teme p��kaz a� ke st�edn�ku
				text_buffer = text_buffer.Substring(poziceStredniku + 1) ' a prikaz od��zneme
				ProvedPrikaz(prikaz) ' po�leme p��kaz ke zpracov�n�
			Loop

			tcp.GetStream.BeginRead(Buffer, 0, BUFFER_SIZE, AddressOf CtiData, Nothing)		  ' p�e�etli jsme v�echny p��choz� data, proto budeme �ekat a� p�ijdou dal��
		Catch e As ObjectDisposedException
			' prob�hlo zru�en� spojen�
		Catch e As Exception
			' nastala chyba, spojen� je ukon�eno
			StripInfo.Text = "Spojen� bylo ukon�eno" ' informace pro u�ivatele
			MsgBox("Spojen� ukon�eno!", MsgBoxStyle.Information)
			OdemkniPolozky() ' nakonec odemkneme znovu polo�ky v menu na p�ipojen� a vytvo�en� spojen�
		End Try
	End Sub
	Sub ProvedPrikaz(ByVal prikaz As String)
		Try
			Dim casti As String() = Split(prikaz, " ") ' rozd�l�me p��kaz podle mezer
			Select Case casti(0) ' zjist�me druh p��kazu
				Case "smazat" ' sma�eme tabuli
					Threading.Monitor.Enter(Me)	' uzamkneme vl�kno
					grp.Clear(Color.Black)
					PicTabule.Invalidate()
					Threading.Monitor.Exit(Me)	' odemkneme
					If Status = StatusPripojeni.Server Then PosliPrikaz(casti(0) + ";") ' server p�epos�la zp�t klientovi
				Case "cara"	' nakresl� ��ru
					KresliCaru(Val(casti(1)), Val(casti(2)), Val(casti(3)), Val(casti(4)), _
					Val(casti(5)), _
					Color.FromArgb(Val(casti(6)), Val(casti(7)), Val(casti(8))))
					If Status = StatusPripojeni.Server Then	' server p�epos�la zp�t klientovi
						PosliPrikaz(casti(0) + " " + casti(1) + " " + casti(2) + " " + casti(3) + " " + casti(4) + " " + casti(5) + " " + casti(6) + " " + casti(7) + " " + casti(8) + ";")
					End If
				Case Else ' nezn�m� p��kaz, ukon�en� p�ipojen�
					Throw New Exception
			End Select
		Catch e As Exception  ' chyba p�i zpracov�n� p�ikazu, ukon�en� spojen�
			StripInfo.Text = "Spojen� bylo ukon�eno" ' informace pro u�ivatele
			tcp.Close()	' uzav�eme spojen�'
			MsgBox("Chybn� syntaxe p��kaz�!", MsgBoxStyle.Information)
			OdemkniPolozky() ' nakonec odemkneme znovu polo�ky v menu na p�ipojen� a vytvo�en� spojen�
		End Try
	End Sub
	Sub KresliCaru(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal drawWidth As Integer, ByVal color As Color)
		Threading.Monitor.Enter(Me)	' uzamkneme vl�kno
		grp.FillEllipse(New Pen(color).Brush, New RectangleF(x1 - drawWidth / 2, y1 - drawWidth / 2, drawWidth, drawWidth))	' vykresl�me prvnotn� bod (zakulacen� za��tku ��ry)
		grp.DrawLine(New Pen(color, drawWidth), x1, y1, x2, y2)	' vykresl�me ��ru
		grp.FillEllipse(New Pen(color).Brush, New RectangleF(x2 - drawWidth / 2, y2 - drawWidth / 2, drawWidth, drawWidth))	' vykresl�me zakon�ovac� bod (zakulacen� konce ��ry)
		PicTabule.Invalidate() ' nechame p�ekreslit PicTabule
		Threading.Monitor.Exit(Me) ' odemkneme vl�kno
	End Sub
	Function JsemPripojenyKlient() As Boolean
		' zjist�me, zda jsme p�ipojeni
		Dim Connected As Boolean = False
		If Not tcp Is Nothing Then
			If Not tcp.Client Is Nothing Then
				Connected = tcp.Connected
			End If
		End If
		Return Connected And (Status = StatusPripojeni.Klient)
	End Function
	Sub PosliPrikaz(ByVal prikaz As String)
		' zjist�me, zda jsme p�ipojeni
		Dim Connected As Boolean = False
		If Not tcp Is Nothing Then
			If Not tcp.Client Is Nothing Then
				Connected = tcp.Connected
			End If
		End If
		If Connected = False Then Exit Sub ' pokud nejsme je�t� p�ipojeni, tak se nic nepos�la
		Try
			Dim bfr(prikaz.Length - 1) As Byte ' pole presne pro prikaz
			bfr = System.Text.Encoding.ASCII.GetBytes(prikaz) ' p�evedeme p��kaz na pole byt�
			networkStream.Write(bfr, 0, bfr.Length)	' odeslat prikaz
		Catch e As ObjectDisposedException
			' prob�hlo zru�en� spojen�
		Catch ex As Exception
			StripInfo.Text = "Spojen� bylo ukon�eno" ' informace pro u�ivatele
			tcp.Close()	' chyba - uzav��t spojen�
			MsgBox("Spojen� ukon�eno!", MsgBoxStyle.Information)
			OdemkniPolozky() ' nakonec odemkneme znovu polo�ky v menu na p�ipojen� a vytvo�en� spojen�
		End Try
	End Sub
	Private Sub ToolStripMenuItemBarvaStetce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemBarvaStetce.Click
		' nastav�me dialogu aktualni barvu
		ColorDialog1.Color = drawColor
		' zobraz�me dialog
		If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
			' nov� barva kreslen�
			drawColor = ColorDialog1.Color
		End If
	End Sub
	Private Sub ToolStripComboSirkaStetce_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripComboSirkaStetce.SelectedIndexChanged
		' byla vybr�na nov� ���ka �tetce 
		drawWidth = ToolStripComboSirkaStetce.SelectedIndex + 1
	End Sub
End Class
