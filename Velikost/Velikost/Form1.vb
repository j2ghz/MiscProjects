Imports System.IO

Public Class form1
    Public Function GetDirectoryLength(ByVal path As String) As Long
        'V případě že cesta ke složce nebyla nalezena, vrací velikost 0.
        If Not IO.Directory.Exists(path) Then Return 0
        Dim length As Long, _
            parentDirectory As New DirectoryInfo(path)
        Try
            For Each file As FileInfo In parentDirectory.GetFiles()
                length += file.Length
            Next
            For Each directory As DirectoryInfo In parentDirectory.GetDirectories()
                length += GetDirectoryLength(directory.FullName)
            Next
        Catch ex As FileNotFoundException
            'Soubor nebyl nalezen.
            MsgBox("Soubor nebyl nalezen.", , "Chyba")
        Catch ex As UnauthorizedAccessException
            'Nedostatek oprávnění pro přístup k souboru nebo složce.
            MsgBox("Nedostatek oprávnění pro přístup k souboru nebo složce.", , "Chyba")
        End Try
        Return length
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox(GetDirectoryLength(TextBox1.Text) & "bitů.", , "Velikost je:")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub
End Class