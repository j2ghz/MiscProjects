Module Module1
    Dim pocetsouperu As Integer = 100
    Dim dd As New Dictionary(Of Integer, String)
    Sub Main()
        For i As Integer = 1 To 10
            Dim d As DateTime = Now
            Console.WriteLine(i)
            'Dim pocetkol = Console.ReadLine()
            vyrad(pocetsouperu, i, 0, "")
            Console.WriteLine(dd.Count)
            Dim ii = dd.First
            For Each a In dd
                If ii.Key < a.Key Then
                    ii = a
                End If
            Next
            Console.WriteLine(ii)
            Console.WriteLine((Now - d).ToString)
            dd = New Dictionary(Of Integer, String)
        Next
    End Sub
    Sub vyrad(hraci As Integer, pocetpruchodu As Integer, zisk As Integer, vyrazeno As String)
        If pocetpruchodu >= 1 Then
            For i As Integer = 1 To hraci
                vyrad(hraci - i, pocetpruchodu - 1, zisk + (i / hraci * 100000), vyrazeno & " " & i)
            Next
        Else
            If Not dd.ContainsKey(zisk) Then
                dd.Add(zisk, vyrazeno)
            End If
        End If
    End Sub

End Module
