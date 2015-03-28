Imports System.Collections.Generic
Imports System.IO
Imports System.Reflection
Module MainModule
  Sub Main()
    'Seznam v�ech dostupn�ch z�suvn�ch modul�
    Dim plugins As New List(Of IMathPlugin)
    'Prohled� v�echny dll soubory ve slo�ce aplikace
    For Each file As FileInfo In New DirectoryInfo(My.Application.Info.DirectoryPath).GetFiles("*.dll", SearchOption.TopDirectoryOnly)
      Console.WriteLine("Hled�n� kompatibiln�ch z�suvn�ch modul� v souboru " & file.Name & "...")
      Dim pluginAssembly As Assembly = Nothing
      Try
        'Pokus� se na��st knihovnu
        pluginAssembly = Assembly.LoadFrom(file.FullName)
      Catch ex As Exception
        'P�i na��t�n� knihovny do�lo k chyb� (nap�. nespr�vn� form�t knihovny)
      End Try
      If pluginAssembly IsNot Nothing Then
        'Prohled� v�echny typy v knihovn�
        For Each t As Type In pluginAssembly.GetTypes()
          'Pokud typ implementuje rozhran� z�suvn�ho modulu (definovan�ho v projektu PluginInterface)
          'vytvo�� instanci tohoto typu a p�id� jej do seznamu z�suvn�ch modul�
          If t.GetInterface(GetType(IMathPlugin).FullName) IsNot Nothing Then
            Dim plugin As IMathPlugin = DirectCast(pluginAssembly.CreateInstance(t.FullName), IMathPlugin)
            Console.WriteLine("Nalezen z�suvn� modul: " & plugin.Name)
            plugins.Add(plugin)
          End If
        Next
      End If
      Console.WriteLine()
    Next
    If plugins.Count > 0 Then
      Console.WriteLine("Spu�t�n test z�suvn�ch modul�...")
      'Vytvo�� n�hodn� vstupn� parametry pro matematick� operace
      Dim randomizer As New Random()
      Dim x As Single = randomizer.Next(0, 100)
      Dim y As Single = randomizer.Next(0, 100)
      Console.WriteLine(String.Format("Vytvo�eny n�hodn� vstupn� parametry: {0}, {1}", x, y))
      'Pro ka�d� z�suvn� modul v seznamu se pokus� prov�st jeho matematickou operaci
      For Each plugin As IMathPlugin In plugins
        Try
          Console.WriteLine(String.Format("{0}: {1}", plugin.Name, plugin.PerformMathOperation(x, y)))
        Catch ex As Exception
          'Zde je mo�n� o�et�it p��padn� vyj�mky v z�suvn�m modulu (nap�. vyj�mka vznikl� p�i d�len� nulou)
          Console.WriteLine(String.Format("V z�suvn�m modulu {0} do�lo k chyb�: {1}", plugin.Name, ex.Message))
        End Try
      Next
    Else
      Console.WriteLine(String.Format("Ve slo�ce ""{0}"" nebyly nalezeny ��dn� z�suvn� moduly.", My.Application.Info.DirectoryPath))
    End If
    Console.WriteLine()
    Console.WriteLine("Pokra�ujte stiskem libovoln� kl�vesy...")
    Console.ReadKey()
  End Sub
End Module