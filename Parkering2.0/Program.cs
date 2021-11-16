

// See https://aka.ms/new-console-template for more information

using Parkering2._0;
using Spectre.Console;


AnsiConsole.Write(new BarChart() // for some reason i cant get it to work outside of the main program class. Tried it in ConsoleMenu.
.Width(60)
.Label("[green bold underline]Parking slots[/]")
.CenterLabel()
.AddItem("Free", 12, Color.Green)
.AddItem("Taken", 54, Color.Red));

Console.WriteLine("Give me your register number:");
string registeringNumber = Console.ReadLine();
Vehicles newVehicle[] = new Vehicles();
newVehicle.CreateVehicle(5);



//var menu = new ConsoleMenu.MenuChoice();

