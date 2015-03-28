Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i As Integer = 1 To 20
            ComboBox1.Items.Add(i)
        Next
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ListBox1.Items.Clear()
        For i As Integer = 1 To 10
            ListBox1.Items.Add(CInt(ComboBox1.SelectedItem) * i)
        Next
    End Sub
End Class
