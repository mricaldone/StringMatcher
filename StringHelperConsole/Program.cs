// See https://aka.ms/new-console-template for more information
using CsvHelper;
using StringHelper;
using StringHelperConsole;
using System.Globalization;

Console.WriteLine("Hello, World!");



//Arrange
var cadenaBuscada = "capitanbermudez";
//var lineas = new List<string>() { "puanpuan x", "puan puan x", "puan x" };
/*
var lineas = new List<string>() { "puanpuan x", "puan puan x", "puan x" };

for(int i = 0; i < 1000000; i++)
{
    lineas.Add($"{i}xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx{i}");
}
*/
var lineas = new List<string>();

using (var reader = new StreamReader("Localidades.csv"))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    var rows = csv.GetRecords<CsvRow>();
    lineas = (from r in rows select r.Localidad).ToList<string>();
}

//Act
var tStart = DateTime.Now;
var puntaje = Matcher.BuscarMejor(cadenaBuscada, lineas);
Matcher.BuscarMejor(cadenaBuscada, null);
var tEnd = DateTime.Now;
//Assert
Console.WriteLine($"'{puntaje}'");

Console.WriteLine((tEnd - tStart).TotalMilliseconds);