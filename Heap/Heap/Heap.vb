Public Class Heap
    Public halda As New List(Of Integer)
    Dim lastindex As Integer = 0

    Sub Add(i As Integer)
        halda.Add(i)
        Check(lastindex, halda)
        lastindex += 1
    End Sub

    Public Function heapsort(int() As Integer)
        halda.Clear()
        lastindex = 0
        For Each i As Integer In int
            Add(i)
        Next
        For i = 0 To int.Count - 1
            int(i) = halda(0)
            RemoveMin()
        Next
        Return int
    End Function


    Sub RemoveMin()
        Dim x = halda.Last
        halda.Remove(halda.Last)
        If halda.Count > 0 Then
            halda(0) = x
            checkc(0)
        End If
        lastindex -= 1
    End Sub

    Sub checkc(i As Integer)
        Dim minI As Integer
        If (halda.Count - 1) >= (i * 2 + 2) Then
            minI = IIf(halda(i * 2 + 1) < halda(i * 2 + 2), i * 2 + 1, i * 2 + 2)
        ElseIf (halda.Count - 1) >= i * 2 + 1 Then
            minI = i * 2 + 1
        Else
            Exit Sub
        End If
        swap(i, minI)
        checkc(minI)
    End Sub

    Public Function Check(index As Integer, ByRef he As List(Of Integer))
        If index > 0 Then
            Dim parent As Integer
            parent = IIf((index - 1) Mod 2 = 0, (index - 1) / 2, (index - 2) / 2)
            If he(parent) > he(index) Then
                Dim tmp = he(parent)
                he(parent) = he(index)
                he(index) = tmp
            End If
            If parent >= 0 Then
                Return Check(parent, he)
            Else
                Return he
            End If
        End If
        Return he
    End Function

    Private Sub swap(i As Integer, minI As Integer)
        Dim tmp As Integer = halda(i)
        halda(i) = halda(minI)
        halda(minI) = tmp
    End Sub

End Class
