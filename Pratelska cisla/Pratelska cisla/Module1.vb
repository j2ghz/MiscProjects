Module Module1
    Dim x As Long
    Sub Main()
        x = Console.ReadLine()
        Dim d As DateTime = DateTime.Now
        'For N As ULong = 1 To x
        '    kontrola(N)
        'Next
        Parallel.For(1, x, Sub(i)
                               kontrola(i)  'spustit
                           End Sub)
        Console.WriteLine((DateTime.Now - d).TotalSeconds & " sekund")
        Console.ReadKey()
    End Sub

    Function soucetdelitele(x) As Integer   'sečíst delitele
        Dim l As Long
        For i = 2 To x / 2 + 1
            If x Mod i = 0 Then
                l += i
            End If
        Next
        Return l
    End Function

    Sub kontrola(N)
        Dim a = soucetdelitele(N)
        If N < x And a < x And soucetdelitele(a) = N Then   'kontrola jestli to sedí
            Console.WriteLine(N & " " & a)
        End If
    End Sub

End Module
