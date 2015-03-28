Public Class RecordReader
    Dim r As IO.StreamReader


    Sub New(ByVal filename As String)
        'otevřít soubor pro čtení
        r = New IO.StreamReader(filename, System.Text.Encoding.UTF8)
    End Sub

    Public Function ReadString() As String
        'přečíst řetězec a odstranit uvozovky
        Return Me.Read().Replace(Chr(34), "")
    End Function

    Private Function Read() As String
        'přečíst ze souboru jeden záznam a vrátit jej jako String
        Dim sb As New System.Text.StringBuilder()

        Dim ch(0) As Char   'pole, do kterého budeme číst znaky ze souboru

        r.ReadBlock(ch, 0, 1)   'načíst první znak
        While ch(0) <> ";"c   'opakujeme, dokud nenarazíme na středník
            sb.Append(ch(0), 1) 'přidat ho do stringu
            r.ReadBlock(ch, 0, 1)   'přečíst další znak
        End While

        Return sb.ToString()
    End Function
End Class
