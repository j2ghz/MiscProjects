Imports System.Text

Module Module1
    Dim m() As Integer = {5000, 2000, 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1}
    Dim v As New List(Of String)
    Sub Main()
        Dim hodn = Console.ReadLine
        mince(hodn, 0, "")
        v.Sort()
        For Each i As String In v
            Console.WriteLine(souc(i) & " - " & i)
        Next
        Console.WriteLine("done")
        Console.ReadKey()
    End Sub

    Sub mince(zbyva As Integer, iMince As Integer, vysl As String)
        If zbyva <= 0 And Not v.Contains(vysl) Then
            SyncLock v
                v.Add(vysl)
            End SyncLock
        End If
        Dim sb As New StringBuilder
        For i As Integer = iMince To m.Count - 1
            For x As Integer = 0 To zbyva \ m(iMince)
                '           Parallel.For(0, zbyva \ m(iMince) + 1, Sub(x)
                If zbyva = 0 Then
                    If Not v.Contains(vysl) Then v.Add(vysl)
                Else
                    Console.Title = vysl
                    mince(zbyva - (m(iMince) * x), iMince + 1, vysl & repeat(m(iMince), x))
                End If
                '    End Sub )
            Next
        Next
    End Sub

    Private Function repeat(m As Integer, x As Integer) As String
        Dim sb As New StringBuilder
        For i As Integer = 1 To x
            sb.Append(m)
        Next
        Return sb.ToString
    End Function

    Private Function souc(i As String) As String
        Dim soucet As Integer = 0
        For Each c As Char In i
            If Integer.TryParse(c, Nothing) = True Then
                soucet += CInt(Val(c))
            End If
        Next
        Return soucet
    End Function



End Module
