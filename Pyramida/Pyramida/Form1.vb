Imports System.IO

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim d = DateTime.Now
        PictureBox1.Image = My.Resources.loading
        PictureBox1.Refresh()
        Label1.Text = "Je potreba: " & sum(1, NumericUpDown1.Value) & " kvádrů"
        Dim bitmap As New System.Drawing.Bitmap(5000, 2500)
        Dim g As Graphics = Graphics.FromImage(bitmap)
        Dim vyska = NumericUpDown1.Value
        Dim v = 2500 / vyska
        For i = 1 To vyska  'radky
            Me.Text = FormatPercent(i / vyska, 2)
            For x = 1 To i  'sloupce
                g.FillRectangle(Brushes.SandyBrown, New Rectangle((vyska / 2 + i / 2 - x) * v * 2, (i - 1) * v, 2 * v, 1 * v))
                g.DrawRectangle(New Pen(Brushes.Black, v / 10), New Rectangle((vyska / 2 + i / 2 - x) * v * 2, (i - 1) * v, 2 * v, v)) 'vykresleni + vypocet polohy
            Next
        Next
        PictureBox1.Image = bitmap
        PictureBox1.Refresh()
        Label1.Text &= " trvalo to: " & (Now - d).TotalSeconds
    End Sub
    ''' <summary>
    ''' Vypocita sumu cisel od do
    ''' </summary>
    ''' <param name="od">spodni hranice vcetne</param>
    ''' <param name="po">horni hranice vcetne</param>
    ''' <returns>suma od 'od' do 'po'</returns>
    ''' <remarks></remarks>
    Function sum(od As Integer, po As Integer) As Integer
        Dim vysl As Integer
        For i = od To po
            vysl += i
        Next
        Return vysl
    End Function

    Private Sub Form1_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        PictureBox1.Refresh()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AcceptButton = Button1
    End Sub
End Class
