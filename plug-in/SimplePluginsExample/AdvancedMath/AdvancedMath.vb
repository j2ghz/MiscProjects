Imports OL.SimplePluginsExample
''' <summary>
''' Zásuvný modul pro násobení.
''' </summary>
''' <remarks>Vynásobí dvì èísla.</remarks>
Public Class Multiplication
  'Implementace rozhraní zásuvného modulu pro matematické operace
  Implements IMathPlugin
  ''' <summary>
  ''' Vrací název zásuvného modulu.
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public ReadOnly Property Name() As String Implements IMathPlugin.Name
    Get
      Return "Násobení"
    End Get
  End Property
  ''' <summary>
  ''' Vynásobí dvì èísla.
  ''' </summary>
  ''' <param name="x">První èíslo.</param>
  ''' <param name="y">Druhé èíslo.</param>
  ''' <returns>Vrací výsledek násobení dvou èísel.</returns>
  ''' <remarks></remarks>
  Public Function PerformMathOperation(ByVal x As Single, ByVal y As Single) As Double Implements IMathPlugin.PerformMathOperation
    Return x * y
  End Function
End Class
''' <summary>
''' Zásuvný modul pro dìlení.
''' </summary>
''' <remarks></remarks>
Public Class Division
  Implements IMathPlugin
  Public ReadOnly Property Name() As String Implements IMathPlugin.Name
    Get
      Return "Dìlení"
    End Get
  End Property
  Public Function PerformMathOperation(ByVal x As Single, ByVal y As Single) As Double Implements IMathPlugin.PerformMathOperation
    Return x / y
  End Function
End Class