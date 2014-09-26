Imports System.IO
Imports System.Text

Public Class Form1
    Dim pocet As Integer
    Dim zavodnici As New List(Of String)
    Dim zavod As New List(Of Integer)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim rr As New StreamReader(TextBox1.Text)
        pocet = rr.ReadLine()
        zavodnici.AddRange(rr.ReadLine.Split(" "))  'přidat cisla do listu
        zavodnici.AddRange(rr.ReadLine.Split(" "))
        zavodnici.AddRange(rr.ReadLine.Split(" "))
        For Each i As String In zavodnici
            zavod.Add(i)
        Next
        zavod.Sort()                                'seřadit
        Dim s As New StringBuilder
        For Each i As String In zavod               'vypsat
            s.Append(i & " ")
        Next
        TextBox2.Text = s.ToString
    End Sub
End Class
