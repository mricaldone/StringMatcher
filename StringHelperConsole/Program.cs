// See https://aka.ms/new-console-template for more information
using StringHelper;

Console.WriteLine("Hello, World!");



//Arrange
var cadenaBuscada = "puan puan";
//var lineas = new List<string>() { "puanpuan x", "puan puan x", "puan x" };
var lineas = new List<string>() { "puanpuan x", "puan puan x", "puan x" };

for(int i = 0; i < 1000000; i++)
{
    lineas.Add($"{i}xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx{i}");
}

//Act
var tStart = DateTime.Now;
var puntaje = Matcher.BuscarMejor(cadenaBuscada, lineas);
var tEnd = DateTime.Now;
//Assert
Console.WriteLine($"'{puntaje}'");

Console.WriteLine((tEnd - tStart).TotalMilliseconds);