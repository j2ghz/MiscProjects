Imports System.IO

Public Class Form1
    Const v As Integer = 20
    Dim su(8)() As String
    Dim nacteno As Boolean = False
    Dim spravne = True
    Private Sub SplitContainer1_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel1.Paint
        Dim p As New Pen(Brushes.Black)
        For i = 0 To 9
            If i Mod 3 = 0 Then
                p.Width = 3
            Else
                p.Width = 1
            End If
            e.Graphics.DrawLine(p, 0, v * i, 9 * v, v * i)
        Next
        For i = 0 To 9
            If i Mod 3 = 0 Then
                p.Width = 3
            Else
                p.Width = 1
            End If
            e.Graphics.DrawLine(p, v * i, 0, v * i, 9 * v) 'Nakrelist tabulku
        Next
        If nacteno Then

            For x = 0 To 8
                For y = 0 To 8
                    e.Graphics.DrawString(su(x)(y), Me.Font, Brushes.Black, 3 + v * x, v * y) 'pridat cisla
                Next
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            ListBox1.Items.Add("Načítání")
            Dim rr As New StreamReader(TextBox1.Text)
            For i = 0 To 8
                su(i) = rr.ReadLine.Split(" ")
            Next
            ListBox1.Items.Add("Načteno")
            nacteno = True
            '----------------------------------------------------
            Dim soucet As Integer = 0
            For i = 0 To 8
                For Each a As String In su(i)
                    soucet += a
                Next
            Next
            If soucet = 405 Then
                ListBox1.Items.Add("Součet OK")
            Else
                Throw New Exception("Špatný součet")

            End If
            ListBox1.Items.Add("Kontrola řádků")
            For i = 0 To 8
                ListBox1.Items.Add(i)
                'Dim soucetsloupce
                'For Each a As String In su(i)
                '    soucetsloupce += a
                'Next
                'If soucetsloupce = 45 Then
                'Else
                '    MsgBox(soucetsloupce)
                '    spravne = False
                '    MsgBox("Špatně")
                'End If

                For Each a As String In su(i)
                    If Not ((su(i).ToList.IndexOf(a) = su(i).ToList.LastIndexOf(a))) Then
                        spravne = False
                    End If
                Next
                If Not (su(i).Contains("1") Or _
                            su(i).Contains("2") Or _
                            su(i).Contains("3") Or _
                            su(i).Contains("4") Or _
                            su(i).Contains("5") Or _
                            su(i).Contains("6") Or _
                            su(i).Contains("7") Or _
                            su(i).Contains("8") Or _
                            su(i).Contains("9")) Then
                    Throw New Exception("Špatný řádek")
                End If
                ListBox1.Items(ListBox1.Items.Count - 1) &= " OK"
            Next
            ListBox1.Items.Add("Řádky OK")
            ListBox1.Items.Add("Kontrola Sloupců")

            ListBox1.Items.Add("sloupce OK")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        SplitContainer1.Panel1.Refresh()
    End Sub
End Class
