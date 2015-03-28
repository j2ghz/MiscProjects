Public Class Form1
    Dim pole(1, 0)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = Text
        pole(0, 0) = "jojo"
        pole(1, 0) = "acerpower"
        Dim dlg As New LoginForm1()                                'vytvořit objekt nového okna
        While Not (dlg.UsernameTextBox.Text = pole(0, 0) And dlg.PasswordTextBox.Text = pole(1, 0))
            If dlg.ShowDialog() = DialogResult.OK Then
                If dlg.UsernameTextBox.Text = pole(0, 0) And dlg.PasswordTextBox.Text = pole(1, 0) Then
                    Beep()
                Else
                    Beep()
                    Beep()
                    Beep()

                End If
            Else
                End
            End If
        End While
    End Sub

    Private Sub KonecToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KonecToolStripMenuItem.Click
        End
    End Sub

    Private Sub ZnovuPřihlásitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZnovuPřihlásitToolStripMenuItem.Click
        Dim dlg As New LoginForm1()                                'vytvořit objekt nového okna
        If dlg.ShowDialog() = DialogResult.OK Then
            If dlg.UsernameTextBox.Text = pole(0, 0) And dlg.PasswordTextBox.Text = pole(1, 0) Then
                Beep()
            Else
                Beep()
                Beep()
                Beep()

            End If
        Else
            End
        End If
    End Sub

    Private Sub ToolStripContainer1_TopToolStripPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ZměnaHeslaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZměnaHeslaToolStripMenuItem.Click
        pole(0, 0) = InputBox("Login")
        pole(1, 0) = InputBox("heslo")
    End Sub

    Private Sub UložToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UložToolStripMenuItem.Click
        Text = TextBox1.Text
        MsgBox("Uloženo")
    End Sub

    Private Sub NačtiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NačtiToolStripMenuItem.Click
        TextBox1.Text = Text
        MsgBox("Načteno")
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Text = TextBox1.Text

    End Sub
End Class
