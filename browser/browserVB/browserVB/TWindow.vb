'trida, kterou pouzijeme pro tvorbu objektu, ktere
'budou hlidat spolupraci hlavniho okna a zalozek

Public Class TWindow
    'vnitrni reference na objekty
    Private myButton As ToolStripButton 'tlacitko v hlavnim formulari
    Private myMark As Slave 'formular zalozky
    Private myBrowser As WebBrowser 'webBrowser na formulari zalozky
    Private myMaster As Master 'rodicovske okno

    'konstruktor
    Public Sub New(ByVal myParent As Master)
        'ulozime si instanci rodicovskeho okna
        myMaster = myParent
        'vytvorime a zobrazime nove okno
        myMark = New Slave
        myMark.MdiParent = myMaster
        myMark.Show()
        'vytvorime a pridame tlacitko do zalozkove listy
        myButton = New ToolStripButton
        myMaster.toolTabs.Items.Add(myButton)
        'vytvorime odkaz na browser
        myBrowser = myMark.wb
        'pridame udalosti

        'pokud klikneme, aktivujeme dany form
        AddHandler myButton.Click, AddressOf myMark.tabActivate
        'pokud se formular zavira, znicime tlacitko
        AddHandler myMark.FormClosing, AddressOf Remove
        'pokud se zmenil titulek stranky
        AddHandler myBrowser.DocumentTitleChanged, AddressOf TitleChange
        'pokud se zmenil stav nacitani dokumentu
        AddHandler myBrowser.ProgressChanged, AddressOf ProgressChange
    End Sub

    'zruseni zalozky
    Private Sub Remove(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        'odebereme tlacitko z listy masteru a zrusime reference
        myMaster.toolTabs.Items.Remove(myButton)
        myButton = Nothing
        myMark = Nothing
    End Sub

    'zmena titulku
    Private Sub TitleChange(ByVal sender As Object, ByVal e As System.EventArgs)
        'zjistime novy titulek okna a rozdistribuujeme ho, kam je treba
        Dim text As String
        text = myMark.wb.DocumentTitle
        myMark.Text = text
        myButton.Text = text
        myMaster.updateTitle()
    End Sub

    'zmena progresu nacitani
    Private Sub ProgressChange(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserProgressChangedEventArgs)
        'spocitame progress a obnovime ho v hlavnim okne
        Dim progress As Single
        If myBrowser.IsBusy Then
            If e.MaximumProgress = 0 Then
                progress = 0
            Else
                progress = e.CurrentProgress / e.MaximumProgress
            End If
        Else
            progress = 1
        End If
        If progress > 1 Then progress = 1
        myMaster.updateProgress(progress)
    End Sub

End Class
