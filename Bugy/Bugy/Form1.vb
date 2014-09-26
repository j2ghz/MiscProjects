Imports System.IO

Public Class Form1

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ToolStripProgressBar1.Style = ProgressBarStyle.Marquee
        Try

            ToolStripStatusLabel1.Text = "odstranuji"
            Dim d As DateTime = Now
            Dim sr As New StreamReader(TextBox1.Text)
            Dim rr As New StreamWriter(TextBox2.Text, False)    'nastaveni vstupniho a vystupniho soubour
            Dim bug As String = sr.ReadLine
            Dim s As String = sr.ReadLine                       'přečtení
            While s.Contains(bug)                               'dokud tam bug je
                s = s.Replace(bug, "")                          'odstranit
                Application.DoEvents()
            End While
            rr.WriteLine(s)                                         'zapsat výsledek
            ToolStripStatusLabel1.Text = "hotovo - čas: " & (Now - d).TotalSeconds & " sekund"
            sr.Close()
            rr.Close()
        Catch ex As Exception                                   'zachycení chyb
            MsgBox(Err.Number & " - " & Err.Description, MsgBoxStyle.Critical, ex.ToString)
        End Try
        If CheckBox1.Checked = True Then
            MsgBox("vyberte soubor k porovnání")
            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim sr As New StreamReader(TextBox2.Text)
                Dim srr As New StreamReader(OpenFileDialog1.FileName)
                If sr.ReadToEnd = srr.ReadToEnd Then
                    MsgBox("soubory jsou stejné")
                Else
                    MsgBox("soubory nejsou stejné")
                End If
            End If
        End If
        ToolStripProgressBar1.Value = 100
        ToolStripProgressBar1.Style = ProgressBarStyle.Continuous
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox2.Text = SaveFileDialog1.FileName
        End If
    End Sub

    Private Sub ToolStripSplitButton1_ButtonClick(sender As Object, e As EventArgs) Handles ToolStripSplitButton1.ButtonClick
        MsgBox("Do pravého textboxu vložte název vstupního souboru (můžete použít tlačítko s třema tečkama), do levého stejným způsobem název výstupního a stiskněte odstraň bugy. Ve spodní části programe se napíše odstraňuji, po dokončení se zde objeví výsledný čas a vše se uloží do vámi vybraného souboru", MsgBoxStyle.Information, "Help")
    End Sub

End Class
