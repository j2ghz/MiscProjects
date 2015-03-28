Public Class Form1

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Image1.Visible = False ' hide coins
        Label1.Text = CStr(Int(Rnd() * 10)) ' pick numbers
        Label2.Text = CStr(Int(Rnd() * 10))
        Label3.Text = CStr(Int(Rnd() * 10))
        'if any caption is 7 display coin stack and beep
        If (CDbl(Label1.Text) = 7) Or (CDbl(Label2.Text) = 7) Or (CDbl(Label3.Text) = 7) Then
            Image1.Visible = True
            Beep()
        End If
    End Sub
End Class
