Public Class Form1

    Private Sub novy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles novy.Click
        'ujistit se, že to uživatel chce
        If MsgBox("Neuložené změny aktuální osoby budou ztraceny! Pokračovat?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        'vynulovat hodnoty ve formuláři
        txbJmeno.Text = ""
        txbPrijmeni.Text = ""
        dtpNarozeni.Value = Now
        numPocetDeti.Value = 0
        picFotka.Image = Nothing
    End Sub

    Private Sub picFotka_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picFotka.Click
        'vybrat obrázek
        If OpenFileDialog2.ShowDialog() = Windows.Forms.DialogResult.OK Then
            picFotka.Image = Image.FromFile(OpenFileDialog2.FileName)
        End If
    End Sub

    Private Sub open_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles open.Click
        'ujistit se, že to uživatel chce
        If MsgBox("Neuložené změny aktuální osoby budou ztraceny! Pokračovat?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        'zeptat se na soubor
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'pokud uživatel vybral soubor, načíst jej
            Dim rr As New RecordReader(OpenFileDialog1.FileName)
            'přečíst data
            txbJmeno.Text = rr.ReadString()
            txbPrijmeni.Text = rr.ReadString()
            dtpNarozeni.Value = rr.ReadDate()
            numPocetDeti.Value = rr.ReadInt()
            'načíst obrázek
            Dim bytes() As Byte = rr.ReadBytes()
            If bytes.Length = 1 Then
                'prázdný obrázek
                picFotka.Image = Nothing
            Else
                'načíst obrázek
                Dim ms As New IO.MemoryStream()
                ms.Write(bytes, 0, bytes.Length)
                ms.Position = 0
                picFotka.Image = Image.FromStream(ms)
                ms.Close()
            End If
            'zavřít soubor
            rr.Close()
        End If
    End Sub

    Private Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click
        'zeptat se na soubor
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            'pokud uživatel vybral soubor, otevřít jej a uložit
            Dim rw As New RecordWriter(SaveFileDialog1.FileName)
            'uložit data
            rw.Write(txbJmeno.Text)
            rw.Write(txbPrijmeni.Text)
            rw.Write(dtpNarozeni.Value)
            rw.Write(CInt(numPocetDeti.Value))
            If picFotka.Image IsNot Nothing Then
                'uložit obrázek do MemoryStreamu
                Dim ms As New IO.MemoryStream()
                picFotka.Image.Save(ms, Imaging.ImageFormat.Jpeg)
                rw.Write(ms.ToArray())
                ms.Close()
            Else
                'uložit pole s jedním nulovým bajtem
                rw.Write(New Byte() {0})
            End If
            'zavřít soubor
            rw.Close()
        End If
    End Sub
End Class
