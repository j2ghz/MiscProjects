Public Class Form1
    Enum Barva
        None = 0
        Red = 1
        Green = 2
        Yellow = 3
        Blue = 4
        Purple = 5
    End Enum
    Dim p(10, 10) As Barva          'barva na políčku
    Dim s(10, 10) As Boolean        'je políčko označené?

    Dim r As New Random()           'generátor náhodných čísel

    Dim selected As Integer = 0     'počet vybraných kuliček
    Dim score As Integer = 0        'skóre

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SetClientSizeCore(221, 221)          'velikost vnitřku formuláře na 221x221 pixelů

        Generate()                              'generovat pole
    End Sub

    Public Sub Generate()
        'vygenerovat hrací pole
        For i As Integer = 0 To 10
            For j As Integer = 0 To 10
                p(i, j) = r.Next(5) + 1     'nastavit náhodné číslo
            Next
        Next
        'vynulovat skóre
        score = 0
        Me.Text = score & " bodů - Bubble Breaker"
    End Sub

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        'vykreslit hrací pole
        With e.Graphics
            For i As Integer = 0 To 10
                For j As Integer = 0 To 10

                    Dim c As Color          'určit barvu podle políčka
                    Select Case p(i, j)
                        Case Barva.Red : c = Color.Red
                        Case Barva.Yellow : c = Color.Yellow
                        Case Barva.Green : c = Color.Green
                        Case Barva.Blue : c = Color.Blue
                        Case Barva.Purple : c = Color.Purple
                        Case Else : .FillRectangle(Brushes.Black, i * 20, j * 20, 20, 20) : Continue For
                    End Select
                    'vykresli kuličku
                    .FillEllipse(New Drawing2D.LinearGradientBrush(New Point(i * 20 - 5, j * 20 - 5), New Point(i * 20 + 20, j * 20 + 20), Color.White, c), i * 20 + 1, j * 20 + 1, 18, 18)

                    If s(i, j) Then     'pokud je kulička označená a sousední nemá stejnou barvu, vykreslit hraniční čáry oblasti
                        If i > 0 AndAlso p(i, j) <> p(i - 1, j) Then .DrawLine(Pens.White, i * 20, j * 20, i * 20, j * 20 + 20)
                        If i < 10 AndAlso p(i, j) <> p(i + 1, j) Then .DrawLine(Pens.White, i * 20 + 20, j * 20, i * 20 + 20, j * 20 + 20)
                        If j > 0 AndAlso p(i, j) <> p(i, j - 1) Then .DrawLine(Pens.White, i * 20, j * 20, i * 20 + 20, j * 20)
                        If j < 10 AndAlso p(i, j) <> p(i, j + 1) Then .DrawLine(Pens.White, i * 20, j * 20 + 20, i * 20 + 20, j * 20 + 20)
                    End If
                Next
            Next
        End With
    End Sub

    Public Sub HighLightNeighbours(ByVal x As Integer, ByVal y As Integer)
        'obarvit kuličku i její sousedy, pokud ještě obarveni nejsou
        s(x, y) = True
        selected += 1
        If x > 0 AndAlso p(x, y) = p(x - 1, y) AndAlso Not s(x - 1, y) Then HighLightNeighbours(x - 1, y)
        If x < 10 AndAlso p(x, y) = p(x + 1, y) AndAlso Not s(x + 1, y) Then HighLightNeighbours(x + 1, y)
        If y > 0 AndAlso p(x, y) = p(x, y - 1) AndAlso Not s(x, y - 1) Then HighLightNeighbours(x, y - 1)
        If y < 10 AndAlso p(x, y) = p(x, y + 1) AndAlso Not s(x, y + 1) Then HighLightNeighbours(x, y + 1)
    End Sub

    Public Sub Explode()
        'odprásknout všechny vybrané kuličky
        For x As Integer = 0 To 10
            For y As Integer = 0 To 10
                If s(x, y) Then p(x, y) = Barva.None
            Next
        Next
        Me.Invalidate() : Application.DoEvents() : Threading.Thread.Sleep(50)
    End Sub

    Public Sub MoveDown()
        'posune kuličky dolů
        For x As Integer = 0 To 10
            Dim t As Integer = 10
            For y As Integer = 10 To 0 Step -1
                If p(x, y) > 0 Then p(x, t) = p(x, y) : t -= 1
            Next
            For y As Integer = t To 0 Step -1
                p(x, y) = Barva.None
            Next
        Next
        Me.Invalidate() : Application.DoEvents() : Threading.Thread.Sleep(50)
    End Sub

    Public Sub MoveRight()
        'posune kuličky doprava
        For y As Integer = 0 To 10
            Dim t As Integer = 10
            For x As Integer = 10 To 0 Step -1
                If p(x, y) > 0 Then p(t, y) = p(x, y) : t -= 1
            Next
            For x As Integer = t To 0 Step -1
                p(x, y) = 0
            Next
        Next
        Me.Invalidate() : Application.DoEvents() : Threading.Thread.Sleep(50)

        'pokud je první sloupec prázdný, dogenerovat nový
        If p(0, 10) = 0 Then
            For y As Integer = 10 To r.Next(10) Step -1
                p(0, y) = r.Next(5) + 1
            Next
            Me.Invalidate() : Application.DoEvents() : Threading.Thread.Sleep(50)
            MoveRight()
        End If
    End Sub

    Public Sub ClearSelection()
        'smazat výběr oblasti
        For i As Integer = 0 To 10
            For j As Integer = 0 To 10
                s(i, j) = False
            Next
        Next
        selected = 0
        HideLabel()
    End Sub

    Public Sub SetLabel(ByVal text As String, ByVal x As Integer, ByVal y As Integer)
        Label1.Text = text
        Label1.Left = x * 20 + 20 : If Label1.Left > 110 Then Label1.Left -= 40
        Label1.Top = y * 20 + 20 : If Label1.Top > 110 Then Label1.Top -= 40
        Label1.Visible = True
    End Sub

    Public Sub HideLabel()
        Label1.Visible = False
    End Sub

    Public Sub GameOver()
        MsgBox(Me.Text)
        'konec hry
        Label1.Text = "KONEC HRY"
        Label1.Visible = True
        Label1.AutoSize = False
        Label1.Location = New Point(0, 0)
        Label1.Size = Me.ClientSize
        Beep()

        'počkat 2 sekundy
        Application.DoEvents()
        Threading.Thread.Sleep(2000)
        MsgBox(Label1.Text)
        Beep()
        End
    End Sub

    Public Function HasPossibilities() As Boolean
        'spočítat, jestli máme nějakou možnost
        For x As Integer = 0 To 10
            For y As Integer = 0 To 10
                If p(x, y) > 0 Then
                    If x < 10 AndAlso p(x, y) = p(x + 1, y) Then Return True
                    If y < 10 AndAlso p(x, y) = p(x, y + 1) Then Return True
                End If
            Next
        Next
        Return False
    End Function

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        'obtáhnout kuličky stejné barvy
        Dim x As Integer = e.X \ 20
        Dim y As Integer = e.Y \ 20

        If s(x, y) And selected > 1 Then
            'odkliknout oblast a posunout kuličky
            score += CInt(Label1.Text)
            Me.Text = score & " bodů - Bubble Breaker"
            Explode()
            ClearSelection()
            MoveDown()
            MoveRight()
            If Not HasPossibilities() Then GameOver()

        Else
            'vybrat oblast
            ClearSelection()
            If p(x, y) > 0 Then HighLightNeighbours(x, y)
            Me.Invalidate()
            If selected > 1 Then SetLabel(selected * (selected - 1), x, y)

        End If
    End Sub
End Class
