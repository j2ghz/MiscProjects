<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Slave
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
        Me.wb = New System.Windows.Forms.WebBrowser
        Me.SuspendLayout()
        '
        'wb
        '
        Me.wb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wb.Location = New System.Drawing.Point(0, 0)
        Me.wb.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.wb.MinimumSize = New System.Drawing.Size(30, 31)
        Me.wb.Name = "wb"
        Me.wb.Size = New System.Drawing.Size(426, 406)
        Me.wb.TabIndex = 0
        '
        'Slave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 406)
        Me.Controls.Add(Me.wb)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Slave"
        Me.Text = "Browser"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents wb As System.Windows.Forms.WebBrowser
End Class
