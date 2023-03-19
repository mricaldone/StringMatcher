// See https://aka.ms/new-console-template for more information
using StringHelper;

Console.WriteLine("Hello, World!");

var tStart = DateTime.Now;

//Arrange
var cadenaBuscada = "puan puan";
//var lineas = new List<string>() { "puanpuan x", "puan puan x", "puan x" };
var lineas = new List<string>() { "puanpuan x", "puan puan x", "puan x" };

for(int i = 0; i < 100000; i++)
{
    lineas.Add($"{i}xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx{i}");
}

//Act
var puntaje = Matcher.BuscarMejor(cadenaBuscada, lineas);
//Assert
Console.WriteLine($"'{puntaje}'");

var tEnd = DateTime.Now;

Console.WriteLine((tEnd - tStart).TotalMilliseconds);