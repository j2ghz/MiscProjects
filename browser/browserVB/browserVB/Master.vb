'hlavni formular, ve kterem budem zobrazovat zalozky

Public Class Master

    'pridani nove zalozky
    Private Sub tabAdd()
        'vytvorime objekt nove zalozky podle tridy TWindow
        Dim newWindow As TWindow
        newWindow = New TWindow(Me)
    End Sub

    'odebrani zalozky
    Private Sub tabRemove()
        'pokud existuje aktivni zalozka, zavreme ji
        Try
            Me.ActiveMdiChild.Close()
        Catch
            MsgBox("Musíte mít otevøenou záložku")
        End Try
    End Sub

    'zavreni vsech zalozek
    Private Sub mnuCloseAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCloseAll.Click
        For Each tab As Form In Me.MdiChildren
            tab.Close()
        Next
    End Sub

    'nastaveni titulku okna
    Public Sub updateTitle()
        Me.Text = Me.ActiveMdiChild.Text
    End Sub

    'zmena progresu
    Public Sub updateProgress(ByVal progress As Single)
        If progress = 1 Then 'nacteno
            statusLoadProc.Visible = False
            statusLoadBar.Visible = False
            statusLoadTxt.Text = "Hotovo"
        Else 'stale se nacita, zobrazime procenta
            statusLoadTxt.Text = "Naèítám:"
            statusLoadProc.Visible = True
            statusLoadBar.Visible = True
            statusLoadBar.Value = CInt(100 * progress)
        End If
    End Sub

    'v historii krok zpet
    Private Sub ToolBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBack.Click
        'aktivni zalozce predame povel
        Try
            Dim actChild As Slave = Me.ActiveMdiChild
            actChild.tabBack()
        Catch
            MsgBox("Musíte mít otevøenou záložku")
        End Try
    End Sub

    'v historii krok dopredu
    Private Sub ToolForw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolForw.Click
        'aktivni zalozce predame povel
        Try
            Dim actChild As Slave = Me.ActiveMdiChild
            actChild.tabForw()
        Catch
            MsgBox("Musíte mít otevøenou záložku")
        End Try
    End Sub

    'presmerovani
    Private Sub ToolAdresaBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolAdresaBtn.Click
        Try
            'pokud zalozka existuje, predame ji adresu
            Dim actChild As Slave = Me.ActiveMdiChild
            actChild.tabGoto(Me.ToolAdresaTxt.Text)
        Catch
            'pokud zalozka neexistuje, vytvorime ji
            tabAdd()
            Dim actChild As Slave = Me.ActiveMdiChild
            actChild.tabGoto(Me.ToolAdresaTxt.Text)
        End Try
    End Sub

    'pohlidame, pokud v adresim radku uzivatel zadal enter,
    'je to totez, jako kdyby kliknul na "GO"
    Private Sub ToolAdresaTxt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ToolAdresaTxt.KeyDown
        If e.KeyCode = Keys.Enter Then
            ToolAdresaBtn_Click(Me, System.EventArgs.Empty)
        End If
    End Sub

    'konec programu
    Private Sub mnuEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEnd.Click
        End
    End Sub

    'uzivatel pozaduje novou zalozku
    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        tabAdd()
    End Sub

    'ozivatel chce zavrit zalozku
    Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClose.Click
        tabRemove()
    End Sub

    'uzivatel pozaduje novou zalozku
    Private Sub toolTabNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolTabNew.Click
        tabAdd()
    End Sub

End Class
