Imports System.Security.Principal
Imports System.Runtime.InteropServices
Public Class Form1
    'Z bezpečnostních důvodů neumožníme třídu dědit
    Public NotInheritable Class Security
        'Deklarace funkcí z Win32 API a konstant
  Private Declare Auto Function LogonUser Lib "advapi32.dll" (
    ByVal lpszUsername As String, _
    ByVal lpszDomain As String, _
    ByVal lpszPassword As String, _
    ByVal dwLogonType As Integer, _
    ByVal dwLogonProvider As Integer, _
    ByRef phToken As IntPtr) As Boolean
  Private Declare Auto Function CloseHandle Lib "kernel32.dll" (
    ByVal handle As IntPtr) As Boolean
        Private Const LOGON32_LOGON_INTERACTIVE As Integer = 2
        Private Const LOGON32_PROVIDER_DEFAULT As Integer = 0
        'Private konstruktor neumožní vytvořit instanci třídy
        Private Sub New()
        End Sub
        'Statická funkce pro ověření identity uživatele
        Public Shared Function AuthenticateUser( _
          ByVal domain As String, _
          ByVal userName As String, _
          ByVal password As String) As Boolean
            Dim userToken As IntPtr = IntPtr.Zero
            'Pokus o přihlášení uživatele
            Dim returnValue As Boolean = LogonUser( _
              userName, _
              domain, _
              password, _
              LOGON32_LOGON_INTERACTIVE, _
              LOGON32_PROVIDER_DEFAULT, _
              userToken)
            If Not returnValue Then
                'V případě že funkce selže nebo autentizace
                'neproběhne úspěšně vrací hodnotu False.
                'CloseHandle uvolní unmanaged zdroje
                returnValue = CloseHandle(userToken)
                Return False
            Else
                'Vytvoří identitu a vrátí příslušnou hodnotu,
                'dá se dále použít např. pro ověření, zda-li je uživatel
                'členem určité skupiny (Users, Administrators...)
                Dim identity As New WindowsIdentity(userToken)
                returnValue = CloseHandle(userToken)
                Return identity.IsAuthenticated
            End If
        End Function
    End Class

    'Použití:
    Public allowUserAccess As Boolean = Security.AuthenticateUser("JOZEF", "jojo", "vb.netjojo12")
    'Pokud není počítač v doméně, použijte jako parametr název počítače 

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If allowUserAccess = False Then
            Application.Exit()
        End If
    End Sub
End Class
