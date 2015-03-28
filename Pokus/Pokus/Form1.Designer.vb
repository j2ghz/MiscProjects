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
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.LogOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.KonecToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ZnovuPřihlásitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ZměnaHeslaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UložToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NačtiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogOutToolStripMenuItem, Me.ZměnaHeslaToolStripMenuItem, Me.UložToolStripMenuItem, Me.NačtiToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(73, 25)
        Me.ToolStripMenuItem1.Text = "Soubor"
        '
        'LogOutToolStripMenuItem
        '
        Me.LogOutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KonecToolStripMenuItem, Me.ZnovuPřihlásitToolStripMenuItem})
        Me.LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        Me.LogOutToolStripMenuItem.Size = New System.Drawing.Size(192, 26)
        Me.LogOutToolStripMenuItem.Text = "Log out"
        '
        'KonecToolStripMenuItem
        '
        Me.KonecToolStripMenuItem.Name = "KonecToolStripMenuItem"
        Me.KonecToolStripMenuItem.Size = New System.Drawing.Size(206, 26)
        Me.KonecToolStripMenuItem.Text = "Konec"
        '
        'ZnovuPřihlásitToolStripMenuItem
        '
        Me.ZnovuPřihlásitToolStripMenuItem.Name = "ZnovuPřihlásitToolStripMenuItem"
        Me.ZnovuPřihlásitToolStripMenuItem.Size = New System.Drawing.Size(206, 26)
        Me.ZnovuPřihlásitToolStripMenuItem.Text = "Znovu přihlásit"
        '
        'ZměnaHeslaToolStripMenuItem
        '
        Me.ZměnaHeslaToolStripMenuItem.Name = "ZměnaHeslaToolStripMenuItem"
        Me.ZměnaHeslaToolStripMenuItem.Size = New System.Drawing.Size(192, 26)
        Me.ZměnaHeslaToolStripMenuItem.Text = "Změna hesla"
        '
        'UložToolStripMenuItem
        '
        Me.UložToolStripMenuItem.Name = "UložToolStripMenuItem"
        Me.UložToolStripMenuItem.Size = New System.Drawing.Size(192, 26)
        Me.UložToolStripMenuItem.Text = "Ulož"
        '
        'NačtiToolStripMenuItem
        '
        Me.NačtiToolStripMenuItem.Name = "NačtiToolStripMenuItem"
        Me.NačtiToolStripMenuItem.Size = New System.Drawing.Size(192, 26)
        Me.NačtiToolStripMenuItem.Text = "Načti"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(705, 29)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 505)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(705, 26)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(300, 21)
        Me.ToolStripStatusLabel1.Text = "Do tohoto zápisníku si zapisuj co chceš"
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Location = New System.Drawing.Point(0, 29)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(705, 476)
        Me.TextBox1.TabIndex = 2
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(171, 21)
        Me.ToolStripStatusLabel2.Text = "ToolStripStatusLabel2"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 531)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.Text = "Zápisník"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KonecToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZnovuPřihlásitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ZměnaHeslaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents UložToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NačtiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
