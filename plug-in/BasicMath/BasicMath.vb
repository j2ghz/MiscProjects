Imports OL.SimplePluginsExample
''' <summary>
''' Zásuvný modul pro sèítání.
''' </summary>
''' <remarks></remarks>
Public Class Addition
  Implements IMathPlugin
  Public ReadOnly Property Name() As String Implements IMathPlugin.Name
    Get
      Return "Sèítání"
    End Get
  End Property
  Public Function PerformMathOperation(ByVal x As Single, ByVal y As Single) As Double Implements IMathPlugin.PerformMathOperation
    Return x + y
  End Function
End Class
''' <summary>
''' Zásuvný modul pro odèítání.
''' </summary>
''' <remarks></remarks>
Public Class Subtraction
  Implements IMathPlugin
  Public ReadOnly Property Name() As String Implements IMathPlugin.Name
    Get
      Return "Odèítání"
    End Get
  End Property
  Public Function PerformMathOperation(ByVal x As Single, ByVal y As Single) As Double Implements IMathPlugin.PerformMathOperation
    Return x - y
  End Function
End Class