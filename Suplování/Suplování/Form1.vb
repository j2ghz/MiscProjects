Imports System.Text

Public Class Form1
    Dim log As New LoginForm1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NotifyIcon1.ShowBalloonTip(1000, "Zapnuto", "Kontroluji změny", ToolTipIcon.Info)
        WebBrowser1.Navigate("http://www.gjak.cz/webznamky/prehled.aspx?s=6")
    End Sub


    Private Sub PřihlášeníToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PřihlášeníToolStripMenuItem.Click
        log.UsernameTextBox.Text = My.Settings.uziv
        log.PasswordTextBox.Text = My.Settings.hes
        If log.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Settings.uziv = log.UsernameTextBox.Text
            My.Settings.hes = log.PasswordTextBox.Text
        End If
        WebBrowser1.Document.GetElementById("ctl00_cphmain_TextBoxjmeno").SetAttribute("value", My.Settings.uziv)
        WebBrowser1.Document.GetElementById("ctl00_cphmain_TextBoxheslo").SetAttribute("value", My.Settings.hes)
        WebBrowser1.Document.GetElementById("ctl00_cphmain_ButtonPrihlas").InvokeMember("click")
        WebBrowser1.Document.GetElementById("ctl00_cphmain_emenu_Elem_18_ts").InvokeMember("OnMouseOver")

    End Sub
End Class
