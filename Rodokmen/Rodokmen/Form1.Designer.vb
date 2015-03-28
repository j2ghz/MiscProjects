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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txbJmeno = New System.Windows.Forms.TextBox
        Me.txbPrijmeni = New System.Windows.Forms.TextBox
        Me.dtpNarozeni = New System.Windows.Forms.DateTimePicker
        Me.numPocetDeti = New System.Windows.Forms.NumericUpDown
        Me.picFotka = New System.Windows.Forms.PictureBox
        Me.novy = New System.Windows.Forms.Button
        Me.open = New System.Windows.Forms.Button
        Me.save = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog
        CType(Me.numPocetDeti, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFotka, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Jméno"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Příjmení"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Datum narození"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Počet dětí"
        '
        'txbJmeno
        '
        Me.txbJmeno.Location = New System.Drawing.Point(171, 6)
        Me.txbJmeno.Name = "txbJmeno"
        Me.txbJmeno.Size = New System.Drawing.Size(200, 26)
        Me.txbJmeno.TabIndex = 4
        '
        'txbPrijmeni
        '
        Me.txbPrijmeni.Location = New System.Drawing.Point(171, 38)
        Me.txbPrijmeni.Name = "txbPrijmeni"
        Me.txbPrijmeni.Size = New System.Drawing.Size(200, 26)
        Me.txbPrijmeni.TabIndex = 5
        '
        'dtpNarozeni
        '
        Me.dtpNarozeni.Location = New System.Drawing.Point(171, 74)
        Me.dtpNarozeni.Name = "dtpNarozeni"
        Me.dtpNarozeni.Size = New System.Drawing.Size(200, 26)
        Me.dtpNarozeni.TabIndex = 6
        '
        'numPocetDeti
        '
        Me.numPocetDeti.Location = New System.Drawing.Point(171, 106)
        Me.numPocetDeti.Name = "numPocetDeti"
        Me.numPocetDeti.Size = New System.Drawing.Size(200, 26)
        Me.numPocetDeti.TabIndex = 7
        '
        'picFotka
        '
        Me.picFotka.Location = New System.Drawing.Point(377, 6)
        Me.picFotka.Name = "picFotka"
        Me.picFotka.Size = New System.Drawing.Size(175, 199)
        Me.picFotka.TabIndex = 8
        Me.picFotka.TabStop = False
        '
        'novy
        '
        Me.novy.Location = New System.Drawing.Point(16, 138)
        Me.novy.Name = "novy"
        Me.novy.Size = New System.Drawing.Size(103, 35)
        Me.novy.TabIndex = 9
        Me.novy.Text = "Nový"
        Me.novy.UseVisualStyleBackColor = True
        '
        'open
        '
        Me.open.Location = New System.Drawing.Point(139, 138)
        Me.open.Name = "open"
        Me.open.Size = New System.Drawing.Size(102, 35)
        Me.open.TabIndex = 10
        Me.open.Text = "Otevřít"
        Me.open.UseVisualStyleBackColor = True
        '
        'save
        '
        Me.save.Location = New System.Drawing.Point(266, 138)
        Me.save.Name = "save"
        Me.save.Size = New System.Drawing.Size(105, 35)
        Me.save.TabIndex = 11
        Me.save.Text = "Uložit"
        Me.save.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog2"
        Me.OpenFileDialog2.Filter = "Všechny obrázky|*.jpg;*.bmp;*.gif;*.png"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 286)
        Me.Controls.Add(Me.save)
        Me.Controls.Add(Me.open)
        Me.Controls.Add(Me.novy)
        Me.Controls.Add(Me.picFotka)
        Me.Controls.Add(Me.numPocetDeti)
        Me.Controls.Add(Me.dtpNarozeni)
        Me.Controls.Add(Me.txbPrijmeni)
        Me.Controls.Add(Me.txbJmeno)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.numPocetDeti, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFotka, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txbJmeno As System.Windows.Forms.TextBox
    Friend WithEvents txbPrijmeni As System.Windows.Forms.TextBox
    Friend WithEvents dtpNarozeni As System.Windows.Forms.DateTimePicker
    Friend WithEvents numPocetDeti As System.Windows.Forms.NumericUpDown
    Friend WithEvents picFotka As System.Windows.Forms.PictureBox
    Friend WithEvents novy As System.Windows.Forms.Button
    Friend WithEvents open As System.Windows.Forms.Button
    Friend WithEvents save As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog

End Class
