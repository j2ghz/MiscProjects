Imports OL.SimplePluginsExample
''' <summary>
''' Z�suvn� modul pro n�soben�.
''' </summary>
''' <remarks>Vyn�sob� dv� ��sla.</remarks>
Public Class Multiplication
  'Implementace rozhran� z�suvn�ho modulu pro matematick� operace
  Implements IMathPlugin
  ''' <summary>
  ''' Vrac� n�zev z�suvn�ho modulu.
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public ReadOnly Property Name() As String Implements IMathPlugin.Name
    Get
      Return "N�soben�"
    End Get
  End Property
  ''' <summary>
  ''' Vyn�sob� dv� ��sla.
  ''' </summary>
  ''' <param name="x">Prvn� ��slo.</param>
  ''' <param name="y">Druh� ��slo.</param>
  ''' <returns>Vrac� v�sledek n�soben� dvou ��sel.</returns>
  ''' <remarks></remarks>
  Public Function PerformMathOperation(ByVal x As Single, ByVal y As Single) As Double Implements IMathPlugin.PerformMathOperation
    Return x * y
  End Function
End Class
''' <summary>
''' Z�suvn� modul pro d�len�.
''' </summary>
''' <remarks></remarks>
Public Class Division
  Implements IMathPlugin
  Public ReadOnly Property Name() As String Implements IMathPlugin.Name
    Get
      Return "D�len�"
    End Get
  End Property
  Public Function PerformMathOperation(ByVal x As Single, ByVal y As Single) As Double Implements IMathPlugin.PerformMathOperation
    Return x / y
  End Function
End Class