Public Class Form1
    'struktura pro záznam v souboru
    Structure Zaznam
        Dim Text As String
        Dim hodnota As Integer
    End Structure

    'pole záznamů v grafu
    Dim zaznamy() As Zaznam
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'otevřít soubor pro čtení
        Dim sr As New IO.StreamReader("graf.txt", System.Text.Encoding.Default)

        'načíst počet záznamů v souboru
        Dim pocet As Integer = CInt(sr.ReadLine())

        'nadimenzovat pole se záznamy
        ReDim zaznamy(pocet - 1)

        'projít v cyklu záznamy a načítat hodnoty ze souboru do pole
        For i As Integer = 0 To pocet - 1
            zaznamy(i).Text = sr.ReadLine()     'načíst popis
            zaznamy(i).hodnota = CInt(sr.ReadLine())   'načíst částku
        Next

        'zavřít soubor
        sr.Close()
    End Sub

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.Clear(Color.White)

        'zjistit hodnotu nejvyyššího sloupce
        Dim max As Integer = zaznamy(1).hodnota
        For i As Integer = 1 To zaznamy.Length - 1
            If zaznamy(i).hodnota > max Then max = zaznamy(i).hodnota
        Next

        'vykreslit graf
        Dim rozestup As Integer = 800 / (zaznamy.Length + 1)
        Dim vyska As Integer = 500
        Dim sirka As Integer = rozestup * 0.25
        Dim pozadi As New Drawing2D.LinearGradientBrush(New Point(0, 60), New Point(0, 600), Color.LightBlue, Color.Blue)
        For i As Integer = 0 To zaznamy.Length - 1
            Dim x As Integer = (i + 1) * rozestup
            Dim y As Integer = zaznamy(i).hodnota / max * vyska

            'vykreslit sloupec
            e.Graphics.FillRectangle(pozadi, x - sirka, 580 - y, sirka * 2, y)

            'vykreslit popisky pod sloupce
            DrawText(e.Graphics, zaznamy(i).Text, x, 590)

            'vykreslit částky nad sloupce
            Dim txt As String = String.Format("{0:c}", zaznamy(i).hodnota)
            DrawText(e.Graphics, txt, x, 580 - y - 40, -60)
        Next
    End Sub

    Sub DrawText(ByVal g As Graphics, ByVal txt As String, ByVal x As Integer, ByVal y As Integer)
        'vykreslit text zadaný středem
        Dim velikost As SizeF = g.MeasureString(txt, Me.Font)
        Dim s As Integer = velikost.Width / 2
        Dim v As Integer = velikost.Height / 2
        g.DrawString(txt, Me.Font, Brushes.Black, x - s, y - v)
    End Sub

    Sub DrawText(ByVal g As Graphics, ByVal txt As String, ByVal x As Integer, ByVal y As Integer, ByVal rotation As Integer)
        'vykreslit text zadaný středem a rotací
        g.TranslateTransform(x, y)
        g.RotateTransform(rotation)

        'nakreslit text do počátku
        DrawText(g, txt, 0, 0)

        'zrušit transformaci
        g.ResetTransform()
    End Sub
End Class
