Public Class Form1
    Dim d As New Dialog1
    Dim narozeni As Date
    Dim zobraz As Date
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpravitÚdajeToolStripMenuItem.PerformClick()
    End Sub

    Private Sub UpravitÚdajeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpravitÚdajeToolStripMenuItem.Click
        If d.ShowDialog = Windows.Forms.DialogResult.OK Then
            narozeni = d.DateTimePicker1.Value
            zobraz = d.DateTimePicker2.Value
            For i As Integer = 0 To DateTime.DaysInMonth(zobraz.Year, zobraz.Month)
                'Dim x As Integer = (zobraz - narozeni).TotalDays + i
                'Dim c23 = sin((x Mod 23) / 23 * 360)
                'Dim c28 = sin((x Mod 28) / 28 * 360)
                'Dim c33 = sin((x Mod 33) / 33 * 360)
                Dim r As New Random
                Dim c23 = r.NextDouble()
                Dim c28 = r.NextDouble()
                Dim c33 = r.NextDouble()

                Chart1.Series(0).Points.AddXY(i, c23)
                Chart1.Series(1).Points.AddXY(i, c28)
                Chart1.Series(2).Points.AddXY(i, c33)
                Try
                    Chart1.Series(3).Points.AddXY(i, (c23 + c28 + c33) / 3)
                Catch
                End Try
            Next
        End If
    End Sub
    Function sin(a As Integer) As Double
        Return Math.Sin(a * (180 / Math.PI))
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Refresh()
    End Sub
End Class
