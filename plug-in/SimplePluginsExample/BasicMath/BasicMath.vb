Imports OL.SimplePluginsExample
''' <summary>
''' Z�suvn� modul pro s��t�n�.
''' </summary>
''' <remarks></remarks>
Public Class Addition
  Implements IMathPlugin
  Public ReadOnly Property Name() As String Implements IMathPlugin.Name
    Get
      Return "S��t�n�"
    End Get
  End Property
  Public Function PerformMathOperation(ByVal x As Single, ByVal y As Single) As Double Implements IMathPlugin.PerformMathOperation
    Return x + y
  End Function
End Class
''' <summary>
''' Z�suvn� modul pro od��t�n�.
''' </summary>
''' <remarks></remarks>
Public Class Subtraction
  Implements IMathPlugin
  Public ReadOnly Property Name() As String Implements IMathPlugin.Name
    Get
      Return "Od��t�n�"
    End Get
  End Property
  Public Function PerformMathOperation(ByVal x As Single, ByVal y As Single) As Double Implements IMathPlugin.PerformMathOperation
    Return x - y
  End Function
End Class