Public Class Form1
    Dim acer As String
    Dim zmena As Boolean = False
    Dim du As Date = Date.Today
    Dim ca As Date = TimeOfDay
    Dim dat As Date = Date.Now
    Dim jo As String = "Možno otevírat pouze soubory vytvořené tímto programem!"

    Private Sub ToolStripStatusLabel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel1.Click
        MsgBox(Date.Now)
    End Sub

    Private Sub NovýToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NovýToolStripMenuItem.Click
        'ujistit se, že to uživatel chce
        If zmena = True Then
            If MsgBox("Neuložené změny budou ztraceny! Pokračovat?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        ZavřítToolStripMenuItem.Enabled = True
        UložiToolStripMenuItem.Enabled = True
        NovýToolStripMenuItem.Enabled = False
        OtevřítToolStripMenuItem.Enabled = False
        'vynulovat hodnoty ve formuláři
        TextBox1.Text = ""
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub OtevřítToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtevřítToolStripMenuItem.Click
        'ujistit se, že to uživatel chce
        If zmena = True Then
            If MsgBox("Neuložené změny budou ztraceny! Pokračovat?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        ZavřítToolStripMenuItem.Enabled = True
        UložiToolStripMenuItem.Enabled = True
        NovýToolStripMenuItem.Enabled = False
        OtevřítToolStripMenuItem.Enabled = False
        'zeptat se na soubor
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'pokud uživatel vybral soubor, načíst jej
            Dim rr As New RecordReader(OpenFileDialog1.FileName)
            'přečíst data
            TextBox1.Text = rr.ReadString()
            Me.Text = OpenFileDialog1.FileName & " - J.Word"
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub UložiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UložiToolStripMenuItem.Click
        'zeptat se na soubor
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            'pokud uživatel vybral soubor, otevřít jej a uložit
            Me.Cursor = Cursors.WaitCursor
            Dim rw As New RecordWriter(SaveFileDialog1.FileName)
            'uložit data
            rw.Write(TextBox1.Text)
            Me.Text = SaveFileDialog1.FileName & " - J.Word"
            'zavřít soubor
            Me.Cursor = Cursors.Arrow
            rw.Close()
        End If
    End Sub

    Private Sub DatumToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatumToolStripMenuItem.Click
        acer = TextBox1.Text
        acer = du & "   " & acer
        TextBox1.Text = acer
    End Sub

    Private Sub ČasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ČasToolStripMenuItem.Click
        acer = TextBox1.Text
        acer = ca & "   " & acer
        TextBox1.Text = acer
    End Sub

    Private Sub DatumAČasToolStripMenuItem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DatumAČasToolStripMenuItem.DoubleClick
        acer = TextBox1.Text
        acer = dat & "   " & acer
        TextBox1.Text = acer
    End Sub

    Private Sub PísmoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PísmoToolStripMenuItem1.Click
        If FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox1.Font = FontDialog1.Font
        End If
    End Sub

    Private Sub ZavřítToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZavřítToolStripMenuItem.Click
        'ujistit se, že to uživatel chce
        If zmena = True Then
            If MsgBox("Neuložené změny budou ztraceny! Pokračovat?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        TextBox1.Text = ""
        NovýToolStripMenuItem.Enabled = True
        OtevřítToolStripMenuItem.Enabled = True
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        zmena = True
    End Sub
End Class
