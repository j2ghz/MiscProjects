'kod formulare Slave, ktery bude pouzit jako zalozky

Public Class Slave

    'aktivovani formulare
    Public Sub tabActivate(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Activate()
    End Sub

    'otevreni stranky
    Public Sub tabGoto(ByVal address As String)
        wb.Navigate(address)
    End Sub

    'historie zpet
    Public Sub tabBack()
        wb.GoBack()
    End Sub

    'historie vpred
    Public Sub tabForw()
        wb.GoForward()
    End Sub

    'pri otevreni nove zalozky ji maximalizujeme a prejdeme na domovskou stranku
    Private Sub Slave_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        wb.GoHome()
    End Sub

End Class