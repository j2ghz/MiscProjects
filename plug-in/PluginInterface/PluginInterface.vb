''' <summary>
''' Rozhraní zásuvného modulu pro matematické operace.
''' </summary>
''' <remarks>Zásuvný modul mùže implementovat jakoukoliv matematickou operaci která má dva vstupní parametry.</remarks>
Public Interface IMathPlugin
  ''' <summary>
  ''' Vrací název zásuvného modulu.
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  ReadOnly Property Name() As String
  ''' <summary>
  ''' Provede matematickou operaci a vrátí výsledek.
  ''' </summary>
  ''' <param name="x"></param>
  ''' <param name="y"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Function PerformMathOperation(ByVal x As Single, ByVal y As Single) As Double
End Interface