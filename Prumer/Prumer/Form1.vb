Imports System.IO

Public Class Form1
    Structure znamka
        Dim hodnota As Integer
        Dim vaha As Integer
    End Structure

    Private Sub PrumerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrumerToolStripMenuItem.Click
        Label1.Text = ""
        Dim p As String = My.Computer.FileSystem.GetTempFileName
        My.Computer.FileSystem.WriteAllText(p, TextBox1.Text, True)
        Dim rr As New StreamReader(p)
        While Not rr.EndOfStream
            Label1.Text &= rr.ReadLine() & Environment.NewLine
            Label1.Text &= Math.Round(prumer(rr.ReadLine & Environment.NewLine & rr.ReadLine), 2, MidpointRounding.AwayFromZero) & Environment.NewLine & Environment.NewLine
        End While
    End Sub
End Class
