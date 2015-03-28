Public Class RecordWriter


    Dim w As IO.StreamWriter


    Sub New(ByVal filename As String)
        'otevřít soubor pro zápis
        w = New IO.StreamWriter(filename, False, System.Text.Encoding.UTF8)
    End Sub




    Public Sub Write(ByVal number As Integer)
        'zapsat číslo
        w.Write(number)
        w.Write(";")
    End Sub


    Public Sub Write(ByVal text As String)
        'zapsat řetězec (vyházet z něj všechny uvozovky)
        w.Write(Chr(34) & text.Replace(Chr(34), "") & Chr(34))
        w.Write(";")
    End Sub


    Public Sub Write(ByVal bytes() As Byte)
        'zapsat bajty (base64 zakódované)
        w.Write(Convert.ToBase64String(bytes))
        w.Write(";")
    End Sub


    Public Sub Write(ByVal dateTime As Date)
        'zapsat datum
        w.Write(dateTime.ToString("r"))
        w.Write(";")
    End Sub


    Public Sub Close()
        'zavřít soubor
        w.Close()
    End Sub


End Class