Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim t As New Microsoft.WindowsAPICodePack.Dialogs.TaskDialog
        t.Caption = "caption"
        t.DetailsCollapsedLabel = "details collapsed"
        t.DetailsExpandedLabel = "details exp label"
        t.DetailsExpandedText = "details exp text"
        t.ExpansionMode = Microsoft.WindowsAPICodePack.Dialogs.TaskDialogExpandedDetailsLocation.ExpandContent
        t.ProgressBar = New Microsoft.WindowsAPICodePack.Dialogs.TaskDialogProgressBar
        t.ProgressBar.Value = 50
        t.ProgressBar.State = Microsoft.WindowsAPICodePack.Dialogs.TaskDialogProgressBarState.Paused
        t.InstructionText = "istruction"
        t.Cancelable = True
        t.Text = "text"
        t.Icon = Microsoft.WindowsAPICodePack.Dialogs.TaskDialogStandardIcon.Warning
        t.ProgressBar.State = Microsoft.WindowsAPICodePack.Dialogs.TaskDialogProgressBarState.Error
        t.Show()
    End Sub
End Class
