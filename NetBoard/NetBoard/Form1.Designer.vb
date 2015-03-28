<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.TabuleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemCreate = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemConnect = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemDisconnect = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItemSmazatTabuli = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.konec = New System.Windows.Forms.ToolStripMenuItem
        Me.ŠtětecToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ZvolitBarvuŠtětceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripComboSirkaStetce = New System.Windows.Forms.ToolStripComboBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.StripInfo = New System.Windows.Forms.ToolStripStatusLabel
        Me.Pictabule = New System.Windows.Forms.PictureBox
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.Pictabule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TabuleToolStripMenuItem, Me.ŠtětecToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(765, 29)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'TabuleToolStripMenuItem
        '
        Me.TabuleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemCreate, Me.ToolStripMenuItemConnect, Me.ToolStripMenuItemDisconnect, Me.ToolStripSeparator1, Me.ToolStripMenuItemSmazatTabuli, Me.ToolStripSeparator2, Me.konec})
        Me.TabuleToolStripMenuItem.Name = "TabuleToolStripMenuItem"
        Me.TabuleToolStripMenuItem.Size = New System.Drawing.Size(72, 25)
        Me.TabuleToolStripMenuItem.Text = "Tabule"
        '
        'ToolStripMenuItemCreate
        '
        Me.ToolStripMenuItemCreate.Name = "ToolStripMenuItemCreate"
        Me.ToolStripMenuItemCreate.Size = New System.Drawing.Size(205, 26)
        Me.ToolStripMenuItemCreate.Text = "Založit spojení"
        '
        'ToolStripMenuItemConnect
        '
        Me.ToolStripMenuItemConnect.Name = "ToolStripMenuItemConnect"
        Me.ToolStripMenuItemConnect.Size = New System.Drawing.Size(205, 26)
        Me.ToolStripMenuItemConnect.Text = "Připojit se"
        '
        'ToolStripMenuItemDisconnect
        '
        Me.ToolStripMenuItemDisconnect.Enabled = False
        Me.ToolStripMenuItemDisconnect.Name = "ToolStripMenuItemDisconnect"
        Me.ToolStripMenuItemDisconnect.Size = New System.Drawing.Size(205, 26)
        Me.ToolStripMenuItemDisconnect.Text = "Odpojit se"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(202, 6)
        '
        'ToolStripMenuItemSmazatTabuli
        '
        Me.ToolStripMenuItemSmazatTabuli.Name = "ToolStripMenuItemSmazatTabuli"
        Me.ToolStripMenuItemSmazatTabuli.Size = New System.Drawing.Size(205, 26)
        Me.ToolStripMenuItemSmazatTabuli.Text = "Smazat tabuli"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(202, 6)
        '
        'konec
        '
        Me.konec.Name = "konec"
        Me.konec.Size = New System.Drawing.Size(205, 26)
        Me.konec.Text = "Konec"
        '
        'ŠtětecToolStripMenuItem
        '
        Me.ŠtětecToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ZvolitBarvuŠtětceToolStripMenuItem, Me.ToolStripComboSirkaStetce})
        Me.ŠtětecToolStripMenuItem.Name = "ŠtětecToolStripMenuItem"
        Me.ŠtětecToolStripMenuItem.Size = New System.Drawing.Size(69, 25)
        Me.ŠtětecToolStripMenuItem.Text = "Štětec"
        '
        'ZvolitBarvuŠtětceToolStripMenuItem
        '
        Me.ZvolitBarvuŠtětceToolStripMenuItem.Name = "ZvolitBarvuŠtětceToolStripMenuItem"
        Me.ZvolitBarvuŠtětceToolStripMenuItem.Size = New System.Drawing.Size(235, 26)
        Me.ZvolitBarvuŠtětceToolStripMenuItem.Text = "Zvolit barvu štětce"
        '
        'ToolStripComboSirkaStetce
        '
        Me.ToolStripComboSirkaStetce.Name = "ToolStripComboSirkaStetce"
        Me.ToolStripComboSirkaStetce.Size = New System.Drawing.Size(121, 29)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StripInfo})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 534)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(765, 26)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StripInfo
        '
        Me.StripInfo.Name = "StripInfo"
        Me.StripInfo.Size = New System.Drawing.Size(79, 21)
        Me.StripInfo.Text = "Připraven"
        '
        'Pictabule
        '
        Me.Pictabule.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pictabule.Location = New System.Drawing.Point(0, 29)
        Me.Pictabule.Name = "Pictabule"
        Me.Pictabule.Size = New System.Drawing.Size(765, 505)
        Me.Pictabule.TabIndex = 2
        Me.Pictabule.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(765, 560)
        Me.Controls.Add(Me.Pictabule)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "NetBoard"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.Pictabule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents TabuleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemCreate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemConnect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemDisconnect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemSmazatTabuli As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents konec As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents StripInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Pictabule As System.Windows.Forms.PictureBox
    Friend WithEvents ŠtětecToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZvolitBarvuŠtětceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripComboSirkaStetce As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog

End Class
