Public Class Form1
    Declare Function MoveWindow Lib "user32.dll" (ByVal hwnd As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal Repaint As Integer) As Integer
    Declare Function GetWindowRect Lib "user32.dll" (ByVal hwnd As IntPtr, ByRef lpRect As RECT) As Integer
    Public WithEvents timer As System.Windows.Forms.Timer
    Public Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure
    Private Sub timer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles timer.Tick
        Dim processes() As Process = Process.GetProcesses 'Nacitame vsetky procesy v systeme
        Dim r As RECT, random As New Random, ranNum As Integer
        For i As Integer = 0 To processes.Length - 1 'Cyklus cez vsetky procesy
            If Not processes(i).MainWindowTitle = String.Empty Then 'Ak ma okno procesu vyplneny titulok
                ranNum = random.Next(-5, 5) 'Vygenerujeme nahodne cislo
                GetWindowRect(processes(i).MainWindowHandle, r) 'Do r nahrame aktualnu poziciu okna
                'Presunieme okno
                MoveWindow(processes(i).MainWindowHandle, r.left + ranNum, r.top + ranNum, r.right - r.left + ranNum, r.bottom - r.top + ranNum, 1)
            End If
        Next
    End Sub
    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        e.Cancel = True
        MyBase.OnClosing(e)
    End Sub
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ShowInTaskbar = False
        Me.Hide()
        timer = New System.Windows.Forms.Timer
        timer.Interval = 1
        timer.Enabled = True
        Randomize()
    End Sub
End Class
