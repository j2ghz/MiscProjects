Imports System.Text

Module Module1

    Sub Main()
        Dim sirka As Integer = Console.ReadLine()
        Dim vyska As Integer = Console.ReadLine
        Dim tabulka As String = Console.ReadLine()
        Dim t(sirka - 1, vyska - 1)
        Dim st As New Stack
        For i As Integer = (sirka * vyska) - 1 To 0 Step -1
            st.Push(tabulka(i))
        Next
        For x As Integer = 0 To sirka - 1
            For y As Integer = 0 To vyska - 1
                t(x, y) = st.Pop
            Next
        Next

        st = New Stack
        Dim text As String = Console.ReadLine()
        For i As Integer = (text.Length) - 1 To 0 Step -1
            st.Push(text(i))
        Next
        For i = 0 To st.Count - 1
            Dim x As Integer = 0
            Dim y As Integer = 0

        Next
        Console.ReadKey()
    End Sub

End Module
