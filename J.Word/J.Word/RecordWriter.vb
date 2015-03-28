Public Class RecordWriter

    Dim dat As Date = Date.Now
    Dim w As IO.StreamWriter


    Sub New(ByVal filename As String)
        'otevřít soubor pro zápis
        w = New IO.StreamWriter(filename, False, System.Text.Encoding.UTF8)
    End Sub

    Public Sub Write(ByVal i As String)
        w.WriteLine(dat)
        w.Write(i)
    End Sub

    Public Sub Close()
        'zavřít soubor
        w.Close()
    End Sub


End Class
