<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Master
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Master))
        Me.mnu = New System.Windows.Forms.MenuStrip
        Me.SouborToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NováZáložkaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ZavřítZáložkuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCloseAll = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.KonecToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Tooltabs = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.Toolback = New System.Windows.Forms.ToolStripButton
        Me.ToolForw = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolAdresaTxt = New System.Windows.Forms.ToolStripTextBox
        Me.ToolAdresaBtn = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.statusLoadtxt = New System.Windows.Forms.ToolStripStatusLabel
        Me.statusLoadBar = New System.Windows.Forms.ToolStripProgressBar
        Me.statusLoadProc = New System.Windows.Forms.ToolStripStatusLabel
        Me.mnu.SuspendLayout()
        Me.Tooltabs.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnu
        '
        Me.mnu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SouborToolStripMenuItem})
        Me.mnu.Location = New System.Drawing.Point(0, 0)
        Me.mnu.Name = "mnu"
        Me.mnu.Size = New System.Drawing.Size(637, 29)
        Me.mnu.TabIndex = 1
        Me.mnu.Text = "MenuStrip1"
        '
        'SouborToolStripMenuItem
        '
        Me.SouborToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NováZáložkaToolStripMenuItem, Me.ZavřítZáložkuToolStripMenuItem, Me.mnuCloseAll, Me.ToolStripSeparator1, Me.KonecToolStripMenuItem})
        Me.SouborToolStripMenuItem.Name = "SouborToolStripMenuItem"
        Me.SouborToolStripMenuItem.Size = New System.Drawing.Size(73, 25)
        Me.SouborToolStripMenuItem.Text = "Soubor"
        '
        'NováZáložkaToolStripMenuItem
        '
        Me.NováZáložkaToolStripMenuItem.Name = "NováZáložkaToolStripMenuItem"
        Me.NováZáložkaToolStripMenuItem.Size = New System.Drawing.Size(263, 26)
        Me.NováZáložkaToolStripMenuItem.Text = "Nová záložka"
        '
        'ZavřítZáložkuToolStripMenuItem
        '
        Me.ZavřítZáložkuToolStripMenuItem.Name = "ZavřítZáložkuToolStripMenuItem"
        Me.ZavřítZáložkuToolStripMenuItem.Size = New System.Drawing.Size(263, 26)
        Me.ZavřítZáložkuToolStripMenuItem.Text = "Zavřít záložku"
        '
        'mnuCloseAll
        '
        Me.mnuCloseAll.Name = "mnuCloseAll"
        Me.mnuCloseAll.Size = New System.Drawing.Size(263, 26)
        Me.mnuCloseAll.Text = "Zavřít všechny záložky"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(260, 6)
        '
        'KonecToolStripMenuItem
        '
        Me.KonecToolStripMenuItem.Name = "KonecToolStripMenuItem"
        Me.KonecToolStripMenuItem.Size = New System.Drawing.Size(263, 26)
        Me.KonecToolStripMenuItem.Text = "Konec"
        '
        'Tooltabs
        '
        Me.Tooltabs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.Tooltabs.Location = New System.Drawing.Point(0, 29)
        Me.Tooltabs.Name = "Tooltabs"
        Me.Tooltabs.Size = New System.Drawing.Size(637, 28)
        Me.Tooltabs.TabIndex = 2
        Me.Tooltabs.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(111, 25)
        Me.ToolStripButton1.Text = "Nová záložka"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Toolback, Me.ToolForw, Me.ToolStripSeparator2, Me.ToolStripLabel1, Me.ToolAdresaTxt, Me.ToolAdresaBtn})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 57)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(637, 28)
        Me.ToolStrip2.TabIndex = 3
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'Toolback
        '
        Me.Toolback.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Toolback.Image = CType(resources.GetObject("Toolback.Image"), System.Drawing.Image)
        Me.Toolback.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Toolback.Name = "Toolback"
        Me.Toolback.Size = New System.Drawing.Size(48, 25)
        Me.Toolback.Text = "Zpět"
        '
        'ToolForw
        '
        Me.ToolForw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolForw.Image = CType(resources.GetObject("ToolForw.Image"), System.Drawing.Image)
        Me.ToolForw.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolForw.Name = "ToolForw"
        Me.ToolForw.Size = New System.Drawing.Size(57, 25)
        Me.ToolForw.Text = "Vpřed"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 28)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(62, 25)
        Me.ToolStripLabel1.Text = "Adresa"
        '
        'ToolAdresaTxt
        '
        Me.ToolAdresaTxt.Name = "ToolAdresaTxt"
        Me.ToolAdresaTxt.Size = New System.Drawing.Size(100, 28)
        '
        'ToolAdresaBtn
        '
        Me.ToolAdresaBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolAdresaBtn.Image = CType(resources.GetObject("ToolAdresaBtn.Image"), System.Drawing.Image)
        Me.ToolAdresaBtn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolAdresaBtn.Name = "ToolAdresaBtn"
        Me.ToolAdresaBtn.Size = New System.Drawing.Size(37, 25)
        Me.ToolAdresaBtn.Text = "GO"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusLoadtxt, Me.statusLoadBar, Me.statusLoadProc})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 533)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(637, 26)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'statusLoadtxt
        '
        Me.statusLoadtxt.Name = "statusLoadtxt"
        Me.statusLoadtxt.Size = New System.Drawing.Size(62, 21)
        Me.statusLoadtxt.Text = "Hotovo"
        '
        'statusLoadBar
        '
        Me.statusLoadBar.Name = "statusLoadBar"
        Me.statusLoadBar.Size = New System.Drawing.Size(100, 20)
        '
        'statusLoadProc
        '
        Me.statusLoadProc.Name = "statusLoadProc"
        Me.statusLoadProc.Size = New System.Drawing.Size(27, 21)
        Me.statusLoadProc.Text = "%"
        '
        'Master
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(637, 559)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.Tooltabs)
        Me.Controls.Add(Me.mnu)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mnu
        Me.Name = "Master"
        Me.Text = "J.Prohlížeč"
        Me.mnu.ResumeLayout(False)
        Me.mnu.PerformLayout()
        Me.Tooltabs.ResumeLayout(False)
        Me.Tooltabs.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnu As System.Windows.Forms.MenuStrip
    Friend WithEvents SouborToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NováZáložkaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZavřítZáložkuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCloseAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents KonecToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tooltabs As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Toolback As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolForw As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolAdresaTxt As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolAdresaBtn As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents statusLoadtxt As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusLoadBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents statusLoadProc As System.Windows.Forms.ToolStripStatusLabel

End Class
