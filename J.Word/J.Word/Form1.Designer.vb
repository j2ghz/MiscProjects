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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.SouborToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NovýToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OtevřítToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UložiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ZavřítToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VložitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DatumAČasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DatumToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ČasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PísmoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PísmoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.FontDialog1 = New System.Windows.Forms.FontDialog
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.AllowDrop = True
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(0, 29)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(715, 588)
        Me.TextBox1.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SouborToolStripMenuItem, Me.VložitToolStripMenuItem, Me.PísmoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(715, 29)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SouborToolStripMenuItem
        '
        Me.SouborToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NovýToolStripMenuItem, Me.OtevřítToolStripMenuItem, Me.UložiToolStripMenuItem, Me.ZavřítToolStripMenuItem})
        Me.SouborToolStripMenuItem.Name = "SouborToolStripMenuItem"
        Me.SouborToolStripMenuItem.Size = New System.Drawing.Size(73, 25)
        Me.SouborToolStripMenuItem.Text = "Soubor"
        '
        'NovýToolStripMenuItem
        '
        Me.NovýToolStripMenuItem.Name = "NovýToolStripMenuItem"
        Me.NovýToolStripMenuItem.Size = New System.Drawing.Size(152, 26)
        Me.NovýToolStripMenuItem.Text = "Nový"
        '
        'OtevřítToolStripMenuItem
        '
        Me.OtevřítToolStripMenuItem.Name = "OtevřítToolStripMenuItem"
        Me.OtevřítToolStripMenuItem.Size = New System.Drawing.Size(152, 26)
        Me.OtevřítToolStripMenuItem.Text = "Otevřít"
        '
        'UložiToolStripMenuItem
        '
        Me.UložiToolStripMenuItem.Name = "UložiToolStripMenuItem"
        Me.UložiToolStripMenuItem.Size = New System.Drawing.Size(152, 26)
        Me.UložiToolStripMenuItem.Text = "Uložit"
        '
        'ZavřítToolStripMenuItem
        '
        Me.ZavřítToolStripMenuItem.Name = "ZavřítToolStripMenuItem"
        Me.ZavřítToolStripMenuItem.Size = New System.Drawing.Size(152, 26)
        Me.ZavřítToolStripMenuItem.Text = "Zavřít"
        '
        'VložitToolStripMenuItem
        '
        Me.VložitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatumAČasToolStripMenuItem})
        Me.VložitToolStripMenuItem.Name = "VložitToolStripMenuItem"
        Me.VložitToolStripMenuItem.Size = New System.Drawing.Size(63, 25)
        Me.VložitToolStripMenuItem.Text = "Vložit"
        '
        'DatumAČasToolStripMenuItem
        '
        Me.DatumAČasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatumToolStripMenuItem, Me.ČasToolStripMenuItem})
        Me.DatumAČasToolStripMenuItem.Name = "DatumAČasToolStripMenuItem"
        Me.DatumAČasToolStripMenuItem.Size = New System.Drawing.Size(191, 26)
        Me.DatumAČasToolStripMenuItem.Text = "Datum a čas"
        '
        'DatumToolStripMenuItem
        '
        Me.DatumToolStripMenuItem.Name = "DatumToolStripMenuItem"
        Me.DatumToolStripMenuItem.Size = New System.Drawing.Size(152, 26)
        Me.DatumToolStripMenuItem.Text = "Datum"
        '
        'ČasToolStripMenuItem
        '
        Me.ČasToolStripMenuItem.Name = "ČasToolStripMenuItem"
        Me.ČasToolStripMenuItem.Size = New System.Drawing.Size(152, 26)
        Me.ČasToolStripMenuItem.Text = "Čas"
        '
        'PísmoToolStripMenuItem
        '
        Me.PísmoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PísmoToolStripMenuItem1})
        Me.PísmoToolStripMenuItem.Name = "PísmoToolStripMenuItem"
        Me.PísmoToolStripMenuItem.Size = New System.Drawing.Size(66, 25)
        Me.PísmoToolStripMenuItem.Text = "Písmo"
        '
        'PísmoToolStripMenuItem1
        '
        Me.PísmoToolStripMenuItem1.Name = "PísmoToolStripMenuItem1"
        Me.PísmoToolStripMenuItem1.Size = New System.Drawing.Size(156, 26)
        Me.PísmoToolStripMenuItem1.Text = "Písmo..."
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 591)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(715, 26)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(60, 21)
        Me.ToolStripStatusLabel1.Text = "Datum"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Dokumenty|*.doc"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Dokumenty|*.doc"
        '
        'FontDialog1
        '
        Me.FontDialog1.ShowColor = True
        Me.FontDialog1.ShowHelp = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 1
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ReshowDelay = 100
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        Me.ToolTip1.ToolTipTitle = "Možno otevírat pouze soubory vytvořené tímto programem!"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 617)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "J.Word"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SouborToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NovýToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OtevřítToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UložiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents VložitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DatumAČasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DatumToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ČasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PísmoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PísmoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents ZavřítToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
