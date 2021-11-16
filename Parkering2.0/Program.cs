

// See https://aka.ms/new-console-template for more information

using Parkering2._0;
using Spectre.Console;

var menu = new ConsoleMenu();

menu.MenuSwitch();
AnsiConsole.Write(new BarChart() // for some reason i cant get it to work outside of the main program class. Tried it in ConsoleMenu.
.Width(60)
.Label("[green bold underline]Parking slots[/]")
.CenterLabel()
.AddItem("Free", 12, Color.Green)
.AddItem("Taken", 54, Color.Red));





















//"SizeParkingSlots": 100,
//  "CurrentMaxTaken": 100,
//  "SizeParkingSlot": 4,

//  "McSize": 2,
//  "CarSize": 4,


//  "McPrice": 10,
//  "CarPrice": 20,

//  "FirstFreeMin": 10