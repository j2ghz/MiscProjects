Public Class Form1

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'uložit data
        Dim soubor As New IO.StreamWriter("database.txt")           'otevřít soubor
        For i As Integer = 0 To ListView1.Items.Count - 1           'projít všechny položky seznamu
            soubor.WriteLine(ListView1.Items(i).SubItems(0).Text)   'zapsat datum
            soubor.WriteLine(ListView1.Items(i).SubItems(1).Text)   'zapsat částku
            soubor.WriteLine(ListView1.Items(i).SubItems(2).Text)   'zapsat popis
        Next
        soubor.Close()                                              'zavřít soubor
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'načtení vstupu
        Dim soubor As New IO.StreamReader("database.txt")       'otevřít soubor
        While Not soubor.EndOfStream                            'číst, dokud nejsme na konci souboru
            Dim datum As DateTime = CDate(soubor.ReadLine())    'načíst první řádek z trojice - datum
            Dim castka As Double = CDbl(soubor.ReadLine())      'načíst druhý řádek z trojice - částka
            Dim text As String = soubor.ReadLine()              'načíst třetí řádek z trojice - popis transakce

            'přidat položku do seznamu
            Dim polozka As New ListViewItem()                   'vytvořit novou položku seznamu
            If castka < 0 Then polozka.ForeColor = Color.Red 'pokud je částka menší než nula, obarvit položku červeně
            polozka.Text = datum                                'vypsat datum
            polozka.SubItems.Add(castka)                        'přidat druhý sloupeček s částkou
            polozka.SubItems.Add(text)                          'přidat třetí sloupeček s popisem
            ListView1.Items.Add(polozka)                        'přidat položku do seznamu
        End While

        soubor.Close()                                          'zavřít soubor
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dlg As New Dialog1()                                'vytvořit objekt nového okna
        If dlg.ShowDialog() = DialogResult.OK Then              'zobrazit okno a počkat na zavření, pokud je OK, tak ...

            'zjistit hodnoty z okna
            Dim datum As DateTime = dlg.DateTimePicker1.Value   'zjistit datum
            Dim castka As Double = dlg.NumericUpDown1.Value     'zjistit částku
            Dim text As String = dlg.TextBox1.Text              'zjistit popis

            Dim polozka As New ListViewItem()                   'vytvořit novou položku seznamu
            If castka < 0 Then polozka.ForeColor = Color.Red 'pokud je částka menší než nula, obarvit položku červeně
            polozka.Text = datum.ToShortDateString()   'vypsat datum
            polozka.SubItems.Add(castka)                        'přidat druhý sloupeček s částkou
            polozka.SubItems.Add(text)                          'přidat třetí sloupeček s popisem
            ListView1.Items.Add(polozka)                        'přidat položku do seznamu
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ListView1.SelectedItems.Count = 0 Then Exit Sub 'pokud není vybrána žádná položka, nic neupravovat

        With ListView1.SelectedItems(0)
            Dim dlg As New Dialog1()                                'vytvořit objekt nového okna

            'nastavit do okna hodnoty ze seznamu
            dlg.DateTimePicker1.Value = CDate(.SubItems(0).Text)      'nastavit datum
            dlg.NumericUpDown1.Value = CDbl(.SubItems(1).Text)        'nastavit částku
            dlg.TextBox1.Text = .SubItems(2).Text                     'nastavit popis

            If dlg.ShowDialog() = DialogResult.OK Then              'zobrazit okno a počkat na zavření, pokud je OK, tak ...

                'zjistit hodnoty z okna
                Dim datum As DateTime = dlg.DateTimePicker1.Value   'zjistit datum
                Dim castka As Double = dlg.NumericUpDown1.Value     'zjistit částku
                Dim text As String = dlg.TextBox1.Text              'zjistit popis

                'pokud je částka menší než nula, obarvit položku červeně, jinak ji obarvit černě
                If castka < 0 Then .ForeColor = Color.Red Else .ForeColor = Color.Black
                .SubItems(0).Text = datum.ToShortDateString()            'vypsat datum
                .SubItems(1).Text = castka                               'přidat druhý sloupeček s částkou
                .SubItems(2).Text = text                                 'přidat třetí sloupeček s popisem
            End If
        End With
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If ListView1.SelectedItems.Count = 0 Then Exit Sub 'pokud není vybrána žádná položka, nic nemazat

        ListView1.Items.Remove(ListView1.SelectedItems(0))
    End Sub
End Class
