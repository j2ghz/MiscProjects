Imports System.Text

Public Class Form1

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = TimeOfDay.ToString("HH:mm:ss")
        Dim sb As New StringBuilder
        sb.AppendLine(Convert.ToString(TimeOfDay.Hour, 2).PadLeft(8, "0"))
        sb.AppendLine(Convert.ToString(TimeOfDay.Minute, 2).PadLeft(8, "0"))
        sb.AppendLine(Convert.ToString(TimeOfDay.Second, 2).PadLeft(8, "0"))    'prevedeni na binary
        Select Case CheckBox2.Checked
            Case True
                Label2.Text = sb.ToString()                                     'zobrazeni
            Case False
                Label2.Text = sb.ToString().Replace("1", "■").Replace("0", "□") 'prevedeni na znaky + zobrazeni
        End Select

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Timer1.Enabled = Not CheckBox1.Checked          'zastaveni
    End Sub
End Class
