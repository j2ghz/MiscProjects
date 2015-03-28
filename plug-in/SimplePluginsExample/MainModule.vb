Imports System.Collections.Generic
Imports System.IO
Imports System.Reflection
Module MainModule
  Sub Main()
    'Seznam všech dostupných zásuvných modulù
    Dim plugins As New List(Of IMathPlugin)
    'Prohledá všechny dll soubory ve složce aplikace
    For Each file As FileInfo In New DirectoryInfo(My.Application.Info.DirectoryPath).GetFiles("*.dll", SearchOption.TopDirectoryOnly)
      Console.WriteLine("Hledání kompatibilních zásuvných modulù v souboru " & file.Name & "...")
      Dim pluginAssembly As Assembly = Nothing
      Try
        'Pokusí se naèíst knihovnu
        pluginAssembly = Assembly.LoadFrom(file.FullName)
      Catch ex As Exception
        'Pøi naèítání knihovny došlo k chybì (napø. nesprávný formát knihovny)
      End Try
      If pluginAssembly IsNot Nothing Then
        'Prohledá všechny typy v knihovnì
        For Each t As Type In pluginAssembly.GetTypes()
          'Pokud typ implementuje rozhraní zásuvného modulu (definovaného v projektu PluginInterface)
          'vytvoøí instanci tohoto typu a pøidá jej do seznamu zásuvných modulù
          If t.GetInterface(GetType(IMathPlugin).FullName) IsNot Nothing Then
            Dim plugin As IMathPlugin = DirectCast(pluginAssembly.CreateInstance(t.FullName), IMathPlugin)
            Console.WriteLine("Nalezen zásuvný modul: " & plugin.Name)
            plugins.Add(plugin)
          End If
        Next
      End If
      Console.WriteLine()
    Next
    If plugins.Count > 0 Then
      Console.WriteLine("Spuštìn test zásuvných modulù...")
      'Vytvoøí náhodné vstupní parametry pro matematické operace
      Dim randomizer As New Random()
      Dim x As Single = randomizer.Next(0, 100)
      Dim y As Single = randomizer.Next(0, 100)
      Console.WriteLine(String.Format("Vytvoøeny náhodné vstupní parametry: {0}, {1}", x, y))
      'Pro každý zásuvný modul v seznamu se pokusí provést jeho matematickou operaci
      For Each plugin As IMathPlugin In plugins
        Try
          Console.WriteLine(String.Format("{0}: {1}", plugin.Name, plugin.PerformMathOperation(x, y)))
        Catch ex As Exception
          'Zde je možné ošetøit pøípadné vyjímky v zásuvném modulu (napø. vyjímka vzniklá pøi dìlení nulou)
          Console.WriteLine(String.Format("V zásuvném modulu {0} došlo k chybì: {1}", plugin.Name, ex.Message))
        End Try
      Next
    Else
      Console.WriteLine(String.Format("Ve složce ""{0}"" nebyly nalezeny žádné zásuvné moduly.", My.Application.Info.DirectoryPath))
    End If
    Console.WriteLine()
    Console.WriteLine("Pokraèujte stiskem libovolné klávesy...")
    Console.ReadKey()
  End Sub
End Module