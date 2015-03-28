<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Master
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Master))
        Me.toolTabs = New System.Windows.Forms.ToolStrip
        Me.toolTabNew = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.mnu = New System.Windows.Forms.MenuStrip
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuClose = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCloseAll = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuEnd = New System.Windows.Forms.ToolStripMenuItem
        Me.toolTools = New System.Windows.Forms.ToolStrip
        Me.ToolBack = New System.Windows.Forms.ToolStripButton
        Me.ToolForw = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolAdresaLbl = New System.Windows.Forms.ToolStripLabel
        Me.ToolAdresaTxt = New System.Windows.Forms.ToolStripTextBox
        Me.ToolAdresaBtn = New System.Windows.Forms.ToolStripButton
        Me.status = New System.Windows.Forms.StatusStrip
        Me.statusLoadTxt = New System.Windows.Forms.ToolStripStatusLabel
        Me.statusLoadBar = New System.Windows.Forms.ToolStripProgressBar
        Me.statusLoadProc = New System.Windows.Forms.ToolStripStatusLabel
        Me.toolTabs.SuspendLayout()
        Me.mnu.SuspendLayout()
        Me.toolTools.SuspendLayout()
        Me.status.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolTabs
        '
        Me.toolTabs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolTabNew, Me.ToolStripSeparator2})
        Me.toolTabs.Location = New System.Drawing.Point(0, 31)
        Me.toolTabs.Name = "toolTabs"
        Me.toolTabs.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.toolTabs.Size = New System.Drawing.Size(938, 28)
        Me.toolTabs.TabIndex = 4
        Me.toolTabs.Text = "ToolStrip1"
        '
        'toolTabNew
        '
        Me.toolTabNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.toolTabNew.Image = CType(resources.GetObject("toolTabNew.Image"), System.Drawing.Image)
        Me.toolTabNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolTabNew.Name = "toolTabNew"
        Me.toolTabNew.Size = New System.Drawing.Size(111, 25)
        Me.toolTabNew.Text = "Nová záložka"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 28)
        '
        'mnu
        '
        Me.mnu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile})
        Me.mnu.Location = New System.Drawing.Point(0, 0)
        Me.mnu.Name = "mnu"
        Me.mnu.Padding = New System.Windows.Forms.Padding(9, 3, 0, 3)
        Me.mnu.Size = New System.Drawing.Size(938, 31)
        Me.mnu.TabIndex = 2
        Me.mnu.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNew, Me.mnuClose, Me.mnuCloseAll, Me.ToolStripMenuItem1, Me.mnuEnd})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(73, 25)
        Me.mnuFile.Text = "Soubor"
        '
        'mnuNew
        '
        Me.mnuNew.Name = "mnuNew"
        Me.mnuNew.Size = New System.Drawing.Size(263, 26)
        Me.mnuNew.Text = "Nová záložka"
        '
        'mnuClose
        '
        Me.mnuClose.Name = "mnuClose"
        Me.mnuClose.Size = New System.Drawing.Size(263, 26)
        Me.mnuClose.Text = "Zavøít záložku"
        '
        'mnuCloseAll
        '
        Me.mnuCloseAll.Name = "mnuCloseAll"
        Me.mnuCloseAll.Size = New System.Drawing.Size(263, 26)
        Me.mnuCloseAll.Text = "Zavøít všechny záložky"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(260, 6)
        '
        'mnuEnd
        '
        Me.mnuEnd.Name = "mnuEnd"
        Me.mnuEnd.Size = New System.Drawing.Size(263, 26)
        Me.mnuEnd.Text = "Konec"
        '
        'toolTools
        '
        Me.toolTools.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolBack, Me.ToolForw, Me.ToolStripSeparator1, Me.ToolAdresaLbl, Me.ToolAdresaTxt, Me.ToolAdresaBtn})
        Me.toolTools.Location = New System.Drawing.Point(0, 59)
        Me.toolTools.Name = "toolTools"
        Me.toolTools.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.toolTools.Size = New System.Drawing.Size(938, 28)
        Me.toolTools.TabIndex = 0
        Me.toolTools.Text = "ToolStrip1"
        '
        'ToolBack
        '
        Me.ToolBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolBack.Name = "ToolBack"
        Me.ToolBack.Size = New System.Drawing.Size(48, 25)
        Me.ToolBack.Text = "Zpìt"
        '
        'ToolForw
        '
        Me.ToolForw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolForw.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolForw.Name = "ToolForw"
        Me.ToolForw.Size = New System.Drawing.Size(57, 25)
        Me.ToolForw.Text = "Vpøed"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 28)
        '
        'ToolAdresaLbl
        '
        Me.ToolAdresaLbl.Name = "ToolAdresaLbl"
        Me.ToolAdresaLbl.Size = New System.Drawing.Size(68, 25)
        Me.ToolAdresaLbl.Text = "Adresa:"
        '
        'ToolAdresaTxt
        '
        Me.ToolAdresaTxt.Name = "ToolAdresaTxt"
        Me.ToolAdresaTxt.Size = New System.Drawing.Size(598, 28)
        '
        'ToolAdresaBtn
        '
        Me.ToolAdresaBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolAdresaBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolAdresaBtn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolAdresaBtn.Name = "ToolAdresaBtn"
        Me.ToolAdresaBtn.Size = New System.Drawing.Size(37, 25)
        Me.ToolAdresaBtn.Text = "GO"
        '
        'status
        '
        Me.status.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusLoadTxt, Me.statusLoadBar, Me.statusLoadProc})
        Me.status.Location = New System.Drawing.Point(0, 379)
        Me.status.Name = "status"
        Me.status.Padding = New System.Windows.Forms.Padding(2, 0, 21, 0)
        Me.status.Size = New System.Drawing.Size(938, 26)
        Me.status.TabIndex = 6
        Me.status.Text = "StatusStrip1"
        '
        'statusLoadTxt
        '
        Me.statusLoadTxt.Name = "statusLoadTxt"
        Me.statusLoadTxt.Size = New System.Drawing.Size(62, 21)
        Me.statusLoadTxt.Text = "Hotovo"
        '
        'statusLoadBar
        '
        Me.statusLoadBar.Name = "statusLoadBar"
        Me.statusLoadBar.Size = New System.Drawing.Size(150, 25)
        Me.statusLoadBar.Visible = False
        '
        'statusLoadProc
        '
        Me.statusLoadProc.Name = "statusLoadProc"
        Me.statusLoadProc.Size = New System.Drawing.Size(27, 21)
        Me.statusLoadProc.Text = "%"
        Me.statusLoadProc.Visible = False
        '
        'Master
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 405)
        Me.Controls.Add(Me.toolTools)
        Me.Controls.Add(Me.status)
        Me.Controls.Add(Me.toolTabs)
        Me.Controls.Add(Me.mnu)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mnu
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Master"
        Me.Text = "Browser"
        Me.toolTabs.ResumeLayout(False)
        Me.toolTabs.PerformLayout()
        Me.mnu.ResumeLayout(False)
        Me.mnu.PerformLayout()
        Me.toolTools.ResumeLayout(False)
        Me.toolTools.PerformLayout()
        Me.status.ResumeLayout(False)
        Me.status.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toolTabs As System.Windows.Forms.ToolStrip
    Friend WithEvents mnu As System.Windows.Forms.MenuStrip
    Friend WithEvents toolTools As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolAdresaLbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolAdresaTxt As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolAdresaBtn As System.Windows.Forms.ToolStripButton
    Friend WithEvents status As System.Windows.Forms.StatusStrip
    Friend WithEvents statusLoadTxt As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusLoadBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents statusLoadProc As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolForw As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolTabNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCloseAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuEnd As System.Windows.Forms.ToolStripMenuItem

End Class
