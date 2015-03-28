<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
		Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
		Me.ToolStripMenuItemTabule = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripMenuItemCreate = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripMenuItemConnect = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripMenuItemDisconnect = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
		Me.ToolStripMenuItem_SmazatTabuli = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
		Me.StripMenuItemKonec = New System.Windows.Forms.ToolStripMenuItem
		Me.ŠtìtecToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripMenuItemBarvaStetce = New System.Windows.Forms.ToolStripMenuItem
		Me.ToolStripComboSirkaStetce = New System.Windows.Forms.ToolStripComboBox
		Me.PicTabule = New System.Windows.Forms.PictureBox
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
		Me.StripInfo = New System.Windows.Forms.ToolStripStatusLabel
		Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
		Me.MenuStrip1.SuspendLayout()
		CType(Me.PicTabule, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StatusStrip1.SuspendLayout()
		Me.SuspendLayout()
		'
		'MenuStrip1
		'
		Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemTabule, Me.ŠtìtecToolStripMenuItem})
		Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.MenuStrip1.Name = "MenuStrip1"
		Me.MenuStrip1.Size = New System.Drawing.Size(640, 24)
		Me.MenuStrip1.TabIndex = 0
		Me.MenuStrip1.Text = "MenuStrip1"
		'
		'ToolStripMenuItemTabule
		'
		Me.ToolStripMenuItemTabule.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemCreate, Me.ToolStripMenuItemConnect, Me.ToolStripMenuItemDisconnect, Me.ToolStripMenuItem2, Me.ToolStripMenuItem_SmazatTabuli, Me.ToolStripMenuItem1, Me.StripMenuItemKonec})
		Me.ToolStripMenuItemTabule.Name = "ToolStripMenuItemTabule"
		Me.ToolStripMenuItemTabule.Size = New System.Drawing.Size(51, 20)
		Me.ToolStripMenuItemTabule.Text = "Tabule"
		'
		'ToolStripMenuItemCreate
		'
		Me.ToolStripMenuItemCreate.Name = "ToolStripMenuItemCreate"
		Me.ToolStripMenuItemCreate.Size = New System.Drawing.Size(185, 22)
		Me.ToolStripMenuItemCreate.Text = "Založit spojení"
		'
		'ToolStripMenuItemConnect
		'
		Me.ToolStripMenuItemConnect.Name = "ToolStripMenuItemConnect"
		Me.ToolStripMenuItemConnect.Size = New System.Drawing.Size(185, 22)
		Me.ToolStripMenuItemConnect.Text = "Pøipojit se"
		'
		'ToolStripMenuItemDisconnect
		'
		Me.ToolStripMenuItemDisconnect.Enabled = False
		Me.ToolStripMenuItemDisconnect.Name = "ToolStripMenuItemDisconnect"
		Me.ToolStripMenuItemDisconnect.Size = New System.Drawing.Size(185, 22)
		Me.ToolStripMenuItemDisconnect.Text = "Odpojit se"
		'
		'ToolStripMenuItem2
		'
		Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
		Me.ToolStripMenuItem2.Size = New System.Drawing.Size(182, 6)
		'
		'ToolStripMenuItem_SmazatTabuli
		'
		Me.ToolStripMenuItem_SmazatTabuli.Name = "ToolStripMenuItem_SmazatTabuli"
		Me.ToolStripMenuItem_SmazatTabuli.Size = New System.Drawing.Size(185, 22)
		Me.ToolStripMenuItem_SmazatTabuli.Text = "Smazat obsah tabule"
		'
		'ToolStripMenuItem1
		'
		Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
		Me.ToolStripMenuItem1.Size = New System.Drawing.Size(182, 6)
		'
		'StripMenuItemKonec
		'
		Me.StripMenuItemKonec.Name = "StripMenuItemKonec"
		Me.StripMenuItemKonec.Size = New System.Drawing.Size(185, 22)
		Me.StripMenuItemKonec.Text = "Konec"
		'
		'ŠtìtecToolStripMenuItem
		'
		Me.ŠtìtecToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemBarvaStetce, Me.ToolStripComboSirkaStetce})
		Me.ŠtìtecToolStripMenuItem.Name = "ŠtìtecToolStripMenuItem"
		Me.ŠtìtecToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
		Me.ŠtìtecToolStripMenuItem.Text = "Štìtec"
		'
		'ToolStripMenuItemBarvaStetce
		'
		Me.ToolStripMenuItemBarvaStetce.Name = "ToolStripMenuItemBarvaStetce"
		Me.ToolStripMenuItemBarvaStetce.Size = New System.Drawing.Size(181, 22)
		Me.ToolStripMenuItemBarvaStetce.Text = "Zvolit barvu štetce"
		'
		'ToolStripComboSirkaStetce
		'
		Me.ToolStripComboSirkaStetce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.ToolStripComboSirkaStetce.Name = "ToolStripComboSirkaStetce"
		Me.ToolStripComboSirkaStetce.Size = New System.Drawing.Size(121, 21)
		'
		'PicTabule
		'
		Me.PicTabule.ErrorImage = Nothing
		Me.PicTabule.Location = New System.Drawing.Point(0, 27)
		Me.PicTabule.Name = "PicTabule"
		Me.PicTabule.Size = New System.Drawing.Size(640, 470)
		Me.PicTabule.TabIndex = 1
		Me.PicTabule.TabStop = False
		'
		'StatusStrip1
		'
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StripInfo})
		Me.StatusStrip1.Location = New System.Drawing.Point(0, 500)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.Size = New System.Drawing.Size(640, 22)
		Me.StatusStrip1.SizingGrip = False
		Me.StatusStrip1.TabIndex = 2
		Me.StatusStrip1.Text = "StatusStrip1"
		'
		'StripInfo
		'
		Me.StripInfo.Name = "StripInfo"
		Me.StripInfo.Size = New System.Drawing.Size(53, 17)
		Me.StripInfo.Text = "Pøipraven"
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ClientSize = New System.Drawing.Size(640, 522)
		Me.Controls.Add(Me.StatusStrip1)
		Me.Controls.Add(Me.PicTabule)
		Me.Controls.Add(Me.MenuStrip1)
		Me.DoubleBuffered = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MainMenuStrip = Me.MenuStrip1
		Me.MaximizeBox = False
		Me.Name = "Form1"
		Me.Text = "NetBoard"
		Me.MenuStrip1.ResumeLayout(False)
		Me.MenuStrip1.PerformLayout()
		CType(Me.PicTabule, System.ComponentModel.ISupportInitialize).EndInit()
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
	Friend WithEvents ToolStripMenuItemTabule As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripMenuItemCreate As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripMenuItemConnect As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents StripMenuItemKonec As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents PicTabule As System.Windows.Forms.PictureBox
	Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
	Friend WithEvents StripInfo As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents ToolStripMenuItemDisconnect As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents ToolStripMenuItem_SmazatTabuli As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
	Friend WithEvents ŠtìtecToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripMenuItemBarvaStetce As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripComboSirkaStetce As System.Windows.Forms.ToolStripComboBox

End Class
