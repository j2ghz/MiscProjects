Module Module1
    Function prumer(text As String) As Double
        text = text.Replace("C", "10")
        text = text.Replace("X", "3")
        text = text.Replace("R", "5")
        text = text.Replace("Z", "10")
        text = text.Replace("M", "3")
        text = text.Replace("-", ",5")
        Dim texty() As String = text.Split(Environment.NewLine)
        Dim hodn() As String = texty(0).Split("	")
        Dim vaha() As String = texty(1).Split("	")
        Dim souc As Integer
        For i = 0 To hodn.Length - 1
            souc += CDbl(hodn(i)) * CDbl(vaha(i))
        Next
        Dim sauc2 As Integer
        For i = 0 To vaha.Length - 1
            sauc2 += CInt(vaha(i))
        Next
        Return souc / sauc2
    End Function
End Module
