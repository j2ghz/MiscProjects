Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim x As Integer = 1
        For i As Integer = 1 To NumericUpDown1.Value
            x = multiply(i, X)
        Next
        MsgBox(x)
    End Sub
    Function multiply(ByVal number As ULong, nr As ULong) As ULong
        Dim NumberDigits As Short
        Dim Multiplier As Decimal = number
        Dim Multiplicand(500) As Short
        Dim Carry As Decimal
        Dim Position As Short
        Dim HoldDigit As Decimal
        Dim I As Short = 0
        NumberDigits = nr.ToString.Length - 1
        For I = NumberDigits To 0 Step -1
            Multiplicand(I) = _
            CInt(nr.ToString.Substring(NumberDigits - I, 1))
        Next
        Carry = 0
        For Position = 0 To (2 * NumberDigits - 1)
            HoldDigit = (Multiplicand(Position) * Multiplier) + Carry
            Carry = HoldDigit \ 10
            Multiplicand(Position) = HoldDigit Mod 10
        Next
        Dim TextProductString As New System.Text.StringBuilder
        I = 0
        For I = (2 * NumberDigits - 1) To 0 Step -1
            TextProductString.Append(Multiplicand(I).ToString)
        Next
        Return CULng(TextProductString.ToString.TrimStart("0"c))
    End Function

End Class
