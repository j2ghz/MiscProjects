''' <summary>
''' Rozhran� z�suvn�ho modulu pro matematick� operace.
''' </summary>
''' <remarks>Z�suvn� modul m��e implementovat jakoukoliv matematickou operaci kter� m� dva vstupn� parametry.</remarks>
Public Interface IMathPlugin
  ''' <summary>
  ''' Vrac� n�zev z�suvn�ho modulu.
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  ReadOnly Property Name() As String
  ''' <summary>
  ''' Provede matematickou operaci a vr�t� v�sledek.
  ''' </summary>
  ''' <param name="x"></param>
  ''' <param name="y"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Function PerformMathOperation(ByVal x As Single, ByVal y As Single) As Double
End Interface