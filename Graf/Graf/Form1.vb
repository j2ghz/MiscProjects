Imports System.IO

Public Class Form1

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            'Try
            Chart1.Series.Clear()
            Chart1.Titles.Clear()
            Dim rr As New StreamReader(OpenFileDialog1.FileName)
            Dim zadani() As String = rr.ReadLine().Split(";")       'přečtení ze souboru a parsování
            Chart1.Titles.Add(OpenFileDialog1.FileName)
            For i = 1 To zadani.Length() - 2                        'vytvoření serií pro graf
                Chart1.Series.Add(zadani(i))
                Chart1.Series(zadani(i)).ChartType = DataVisualization.Charting.SeriesChartType.FastLine
                Chart1.Series(zadani(i)).YValueType = DataVisualization.Charting.ChartValueType.Auto
                Chart1.Series(zadani(i)).XValueType = DataVisualization.Charting.ChartValueType.Int64
                Chart1.Series(zadani(i)).BorderWidth = 5
            Next
            While Not rr.EndOfStream
                If Not rr.Peek = Nothing Then
                    Dim radek() As String = rr.ReadLine().Split(";")    'parsování a vložení bodů do grafu
                    For i = 1 To zadani.Length() - 2
                        Chart1.Series(zadani(i)).Points.AddXY(radek(0), radek(i))
                    Next
                End If
            End While
            'Catch ex As Exception                                       'odchycení chyb
            '    MsgBox(Err.Number & " - " & Err.Description, MsgBoxStyle.Critical, ex.ToString)
            'End Try

        End If
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        MsgBox("Stiskněte tlačítko 'Vybrat soubor....'. Otevře se dialog pro výběr souboru. Vyberte soubor. Ihned po kliknutí na OK bude soubor analyzován a zobrazen do grafu.", MsgBoxStyle.Information, "Help")
    End Sub

End Class
