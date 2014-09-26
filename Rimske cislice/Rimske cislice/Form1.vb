Imports System.IO
Imports System.Text

Public Class Form1
    ''' <summary>
    ''' Prevest na arabske cislice
    ''' </summary>
    ''' <param name="x">rimska cislice</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function naarabske(x As String) As Integer
        Dim i As Integer
        For Each a As Char In x
            Select Case a               'prevedeni jednotlivych cisel
                Case "I"
                    i += 1
                Case "V"
                    i += 5
                Case "X"
                    i += 10
                Case "L"
                    i += 50
                Case "C"
                    i += 100
                Case "D"
                    i += 500
                Case "M"
                    i += 1000
                Case ""

                Case Else
                    Throw New Exception("Špatný znak")      'chyba, jiný znak
            End Select
        Next
        Return i
    End Function
    ''' <summary>
    ''' Prevest na rimske cisla
    ''' </summary>
    ''' <param name="x">arabske cislo</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function narimske(x As Integer) As String
        Dim sb As New StringBuilder
        While x >= 1000
            sb.Append("M")      'prevedeni
            x -= 1000
        End While
        While x >= 500
            sb.Append("D")
            x -= 500
        End While
        While x >= 100
            sb.Append("C")
            x -= 100
        End While
        While x >= 50
            sb.Append("L")
            x -= 50
        End While
        While x >= 10
            sb.Append("X")
            x -= 10
        End While
        While x >= 5
            sb.Append("V")
            x -= 5
        End While
        While x >= 1
            sb.Append("I")
            x -= 1
        End While
        Return sb.ToString      'vratit rimske cislo
    End Function
    Private Sub VybratSouborToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VybratSouborToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim rr As New StreamReader(OpenFileDialog1.FileName)    'otevreni souboru
            Dim soucet As Integer
            While Not rr.EndOfStream        'cist po radcich
                Dim z = rr.ReadLine()
                Dim y = naarabske(z)        'prevest
                ListBox1.Items.Add(z & " = " & y)
                soucet += y                 'pridat do souctu
            End While
            ListBox1.Items.Add(" Pro soubor: " & OpenFileDialog1.FileName & " je součet " & soucet & " (" & narimske(soucet) & ")") 'vypsat soucet
        End If
    End Sub

End Class
