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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.AplikaceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ZnovuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Nastven�ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RychlostToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Norm�ln�ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ZadatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Hr�tToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.Location = New System.Drawing.Point(13, 34)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.MaximumSize = New System.Drawing.Size(450, 450)
        Me.PictureBox1.MinimumSize = New System.Drawing.Size(450, 450)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(450, 450)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.White
        Me.ImageList1.Images.SetKeyName(0, "bonus1.PNG")
        Me.ImageList1.Images.SetKeyName(1, "bonus2.PNG")
        Me.ImageList1.Images.SetKeyName(2, "bonus3.PNG")
        Me.ImageList1.Images.SetKeyName(3, "bonus4.PNG")
        Me.ImageList1.Images.SetKeyName(4, "snake_b.png")
        Me.ImageList1.Images.SetKeyName(5, "snake_h.png")
        Me.ImageList1.Images.SetKeyName(6, "wall.png")
        '
        'Timer1
        '
        Me.Timer1.Interval = 300
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AplikaceToolStripMenuItem, Me.Nastven�ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(477, 29)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AplikaceToolStripMenuItem
        '
        Me.AplikaceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ZnovuToolStripMenuItem, Me.Hr�tToolStripMenuItem})
        Me.AplikaceToolStripMenuItem.Name = "AplikaceToolStripMenuItem"
        Me.AplikaceToolStripMenuItem.Size = New System.Drawing.Size(84, 25)
        Me.AplikaceToolStripMenuItem.Text = "Aplikace"
        '
        'ZnovuToolStripMenuItem
        '
        Me.ZnovuToolStripMenuItem.Name = "ZnovuToolStripMenuItem"
        Me.ZnovuToolStripMenuItem.Size = New System.Drawing.Size(152, 26)
        Me.ZnovuToolStripMenuItem.Text = "Konec"
        '
        'Nastven�ToolStripMenuItem
        '
        Me.Nastven�ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RychlostToolStripMenuItem})
        Me.Nastven�ToolStripMenuItem.Name = "Nastven�ToolStripMenuItem"
        Me.Nastven�ToolStripMenuItem.Size = New System.Drawing.Size(86, 25)
        Me.Nastven�ToolStripMenuItem.Text = "Nastven�"
        '
        'RychlostToolStripMenuItem
        '
        Me.RychlostToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Norm�ln�ToolStripMenuItem, Me.ZadatToolStripMenuItem})
        Me.RychlostToolStripMenuItem.Name = "RychlostToolStripMenuItem"
        Me.RychlostToolStripMenuItem.Size = New System.Drawing.Size(160, 26)
        Me.RychlostToolStripMenuItem.Text = "Rychlost"
        '
        'Norm�ln�ToolStripMenuItem
        '
        Me.Norm�ln�ToolStripMenuItem.Name = "Norm�ln�ToolStripMenuItem"
        Me.Norm�ln�ToolStripMenuItem.Size = New System.Drawing.Size(163, 26)
        Me.Norm�ln�ToolStripMenuItem.Text = "Norm�ln�"
        '
        'ZadatToolStripMenuItem
        '
        Me.ZadatToolStripMenuItem.Name = "ZadatToolStripMenuItem"
        Me.ZadatToolStripMenuItem.Size = New System.Drawing.Size(163, 26)
        Me.ZadatToolStripMenuItem.Text = "Zadat..."
        '
        'Hr�tToolStripMenuItem
        '
        Me.Hr�tToolStripMenuItem.Name = "Hr�tToolStripMenuItem"
        Me.Hr�tToolStripMenuItem.Size = New System.Drawing.Size(152, 26)
        Me.Hr�tToolStripMenuItem.Tag = "0"
        Me.Hr�tToolStripMenuItem.Text = "Start"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 504)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1042, 786)
        Me.MinimumSize = New System.Drawing.Size(450, 480)
        Me.Name = "Form1"
        Me.Text = "Hungry Snake"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AplikaceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZnovuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nastven�ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RychlostToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Norm�ln�ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZadatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Hr�tToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
