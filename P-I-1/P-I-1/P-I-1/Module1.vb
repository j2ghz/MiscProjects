Imports System.Text

Public Module Module1

    Structure dvoj
        Dim k As Integer
        Dim l As Integer

        Sub New(x As Integer, y As Integer)
            k = x
            l = y
        End Sub

    End Structure

    Dim la As New List(Of Integer)

    Sub Main()

        'Console.Write(vyber(vybratDvojice(nacist("8", "-5 10 32 17 24 -12 13 19"))))   'debug
        Console.Write(write(vybratDvojice(nacist(Console.ReadLine, Console.ReadLine))))
        Console.ReadKey()
    End Sub

    Public Function nacist(p1 As String, p2 As String) As List(Of Integer)
        Dim cisla As New List(Of Integer)
        cisla.Capacity = p1 + 1
        Dim cis() As String = p2.Split(" ")
        For Each c As String In cis
            cisla.Add(Integer.Parse(c))
        Next
        la = cisla
        Return cisla
    End Function

    Public Function vybratDvojice(l As List(Of Integer)) As List(Of dvoj)
        Dim list As New List(Of dvoj)
        For x As Integer = 0 To l.Count - 1
            For y As Integer = l.Count - 1 To x + 1 Step -1
                list.Add(New dvoj(x, y))
                If Not (x = y) Then
                    For i As Integer = x + 1 To y - 1
                        If l(i) >= Math.Min(l(x), l(y)) And l(i) <= Math.Max(l(x), l(y)) Then
                            list.Remove(New dvoj(x, y))
                            Exit For
                        End If
                    Next
                End If
            Next
        Next
        Return list
    End Function

    Public Function write(list As List(Of dvoj)) As String
        Dim sb As New StringBuilder
        For Each a As dvoj In list
            sb.AppendLine(a.k & " - " & a.l & " | " & la(a.k) & " - " & la(a.l) & " (" & a.l - a.k & ")")
        Next
        Return sb.ToString
    End Function

    Public Function vyber(list As List(Of dvoj)) As String
        Dim vybrana As dvoj
        With vybrana
            For Each a As dvoj In list
                If .k = Nothing And .l = Nothing Then
                    vybrana = a
                ElseIf .l - .k < a.l - a.k Then
                    vybrana = a
                ElseIf .l - .k = a.l - a.k And .k < a.k Then
                    vybrana = a
                End If
            Next
        End With
        Return vybrana.k & " " & vybrana.l
    End Function

End Module
