Public Class Form1
    Dim g As Graphics           'objekt, na kter� vykreslujeme

    Enum POLE
        Volno = 0
        Had = 1
        Bonus = 2
    End Enum

    Enum SMERY
        Nahoru = 1
        Dolu = 2
        Doleva = 3
        Doprava = 4
    End Enum

    Structure XY
        Dim x As Integer
        Dim y As Integer
    End Structure

    Dim Plocha(10, 10) As POLE  'status pol��ek hrac� plochy
    Dim Had(100) As XY          'pozice jednotliv�ch �l�nk� hada
    Dim Delka As Integer        'po�et �l�nk� hada
    Dim Smer As SMERY           'sm�r hada

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'zm�ny sm�ru hada
        Select Case e.KeyCode
            Case Keys.Up
                Smer = SMERY.Nahoru
            Case Keys.Down
                Smer = SMERY.Dolu
            Case Keys.Left
                Smer = SMERY.Doleva
            Case Keys.Right
                Smer = SMERY.Doprava
        End Select
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        PictureBox1.Image = New Bitmap(420, 420)
        g = Graphics.FromImage(PictureBox1.Image)

        'nakreslit zdi ar�ny
        g.Clear(Color.White)        'celou plochu vybarv� b�le
        Dim i As Integer
        For i = 1 To 10             'nakreslit ze� naho�e a dole
            g.DrawImage(ImageList1.Images(6), i * 35, 0)
            g.DrawImage(ImageList1.Images(6), i * 35, 385)
        Next
        For i = 0 To 11             'nakreslit ze� na boc�ch
            g.DrawImage(ImageList1.Images(6), 0, i * 35)
            g.DrawImage(ImageList1.Images(6), 385, i * 35)
        Next

        'nastaven� po��te�n� pozice hada
        Had(0).x = 5 : Had(0).y = 5
        Had(1).x = 5 : Had(1).y = 6
        Had(2).x = 5 : Had(2).y = 7
        g.DrawImage(ImageList1.Images(4), 5 * 35, 5 * 35)
        g.DrawImage(ImageList1.Images(5), 5 * 35, 6 * 35)
        g.DrawImage(ImageList1.Images(5), 5 * 35, 7 * 35)
        Plocha(5, 5) = POLE.Had
        Plocha(5, 6) = POLE.Had
        Plocha(5, 7) = POLE.Had
        Delka = 3
        Smer = SMERY.Nahoru

        'nastavit n�hodu a vytvo�it bonusy
        Randomize()
        Bonus() : Bonus() : Bonus() : Bonus() : Bonus()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'smazat konec hada
        g.FillRectangle(Brushes.White, Had(Delka - 1).x * 35, Had(Delka - 1).y * 35, 35, 35)
        Plocha(Had(Delka - 1).x, Had(Delka - 1).y) = POLE.Volno

        'posun �l�nk� hada na pozici p�edchoz�ho
        Dim i As Integer
        For i = Delka To 1 Step -1
            Had(i).x = Had(i - 1).x
            Had(i).y = Had(i - 1).y
        Next

        'na m�sto, kde je te� hlava, nakreslit norm�ln� �l�nek
        g.DrawImage(ImageList1.Images(5), Had(0).x * 35, Had(0).y * 35)

        ''================================================================
        ''BONUS: Um�l� inteligence - odkomentujte tento blok a sni�te
        '' interval �asova�e na 30. Pak se jen m��ete d�vat, jak had
        '' leze s�m a poj�d� v�echny bonusy.
        Select Case Had(0).x & " " & Had(0).y
            Case "5 1" : Smer = SMERY.Doleva
            Case "1 1" : Smer = SMERY.Dolu
            Case "1 2" : Smer = SMERY.Doprava
            Case "9 2" : Smer = SMERY.Dolu
            Case "9 3" : Smer = SMERY.Doleva
            Case "1 3" : Smer = SMERY.Dolu
            Case "1 4" : Smer = SMERY.Doprava
            Case "9 4" : Smer = SMERY.Dolu
            Case "9 5" : Smer = SMERY.Doleva
            Case "1 5" : Smer = SMERY.Dolu
            Case "1 6" : Smer = SMERY.Doprava
            Case "9 6" : Smer = SMERY.Dolu
            Case "9 7" : Smer = SMERY.Doleva
            Case "1 7" : Smer = SMERY.Dolu
            Case "1 8" : Smer = SMERY.Doprava
            Case "9 8" : Smer = SMERY.Dolu
            Case "9 9" : Smer = SMERY.Doleva
            Case "1 9" : Smer = SMERY.Dolu
            Case "1 10" : Smer = SMERY.Doprava
            Case "10 10" : Smer = SMERY.Nahoru
            Case "10 1" : Smer = SMERY.Doleva
        End Select
        ''================================================================

        'zm�na sm�ru hlavy
        Select Case Smer
            Case SMERY.Nahoru
                Had(0).y = Had(0).y - 1
            Case SMERY.Dolu
                Had(0).y = Had(0).y + 1
            Case SMERY.Doleva
                Had(0).x = Had(0).x - 1
            Case SMERY.Doprava
                Had(0).x = Had(0).x + 1
        End Select

        'kontrola, jestli nenarazil do zdi
        If Had(0).x < 1 Or Had(0).x > 10 Or Had(0).y < 1 Or Had(0).y > 10 Then
            GameOver()
            PictureBox1.Refresh()
            Exit Sub
        End If
        'kontrola, jestli nenarazil do sebe
        If Plocha(Had(0).x, Had(0).y) = POLE.Had Then
            GameOver()
            PictureBox1.Refresh()
            Exit Sub
        End If
        'kontrola, jestli had nese�ral bonus
        If Plocha(Had(0).x, Had(0).y) = POLE.Bonus Then
            g.DrawImage(ImageList1.Images(5), Had(Delka).x * 35, Had(Delka).y * 35)
            Plocha(Had(Delka).x, Had(Delka).y) = POLE.Had
            Delka = Delka + 1
            If Delka < 96 Then Bonus()
            Me.Text = "Hungry Snake - Sk�re: " & Delka
        End If

        'nakreslit novou hlavu
        g.DrawImage(ImageList1.Images(4), Had(0).x * 35, Had(0).y * 35)
        Plocha(Had(0).x, Had(0).y) = POLE.Had

        PictureBox1.Refresh()
    End Sub

    Public Sub GameOver()
        'konec hry
        Timer1.Enabled = False
        'p�ebarvit pole polopr�hledn�
        g.FillRectangle(New SolidBrush(Color.FromArgb(128, Color.LightBlue)), 0, 0, 420, 420)
        'napsat text
        Dim f As New Font(System.Drawing.FontFamily.GenericSansSerif, 20, FontStyle.Bold)
        g.DrawString("KONEC HRY", f, Brushes.Black, 40, 160)
    End Sub

    Public Sub Bonus()
        'vygeneruje nov� bonus
        Dim b, x, y As Integer
        b = Int(Rnd() * 4)      'obr�zek
        Do
            x = Int(Rnd() * 10) + 1
            y = Int(Rnd() * 10) + 1
        Loop While Plocha(x, y) <> POLE.Volno
        Plocha(x, y) = POLE.Bonus
        g.DrawImage(ImageList1.Images(b), x * 35, y * 35)
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub ZnovuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZnovuToolStripMenuItem.Click
        End
    End Sub

    Private Sub Norm�ln�ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Norm�ln�ToolStripMenuItem.Click
        Timer1.Interval = 300
    End Sub

    Private Sub ZadatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZadatToolStripMenuItem.Click
        Timer1.Interval = InputBox("Zadejte �asov� �daj v milisekund�ch mezi dv�ma posuny hada.", "Zadejte rychlost...")
    End Sub

End Class
