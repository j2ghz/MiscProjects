Imports System.Windows.Forms

Public Class ip
    Public Property ip As Net.IPAddress
        Get
            Return Net.IPAddress.Parse(MaskedTextBox1.Text)
        End Get
        Set(value As Net.IPAddress)
            MaskedTextBox1.Text = value.ToString
        End Set
    End Property
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
