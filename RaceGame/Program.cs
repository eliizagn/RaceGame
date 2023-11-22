// See https://aka.ms/new-console-template for more information
using RaceGame.RaceSimulation;

Console.WriteLine("Hello, World!");
var race = new Race();
race.ChooseDistance();
race.ChooseRaceType();
Console.WriteLine($"Type: {race.Type}");



