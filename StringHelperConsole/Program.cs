﻿// See https://aka.ms/new-console-template for more information
using StringHelper;

Console.WriteLine("Hello, World!");

//Arrange
var cadenaBuscada = "puan puan";
var lineas = new List<string>() { "puanpuan x", "puan puan x", "puan x" };
//Act
var puntaje = Matcher.BuscarMejor(cadenaBuscada, lineas);
//Assert
Console.WriteLine($"'{puntaje}'");