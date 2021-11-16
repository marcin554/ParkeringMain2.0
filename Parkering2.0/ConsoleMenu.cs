using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;


namespace Parkering2._0
{

    public class ConsoleMenu
    {



       
        //TAKE IN A VEHICLE
        //TAKE OUT A VEHICLE
        //SEARCH AFTER A VEHICLE
        //EXIT
        
        public string MenuChoice() // Give alternatives to user to choose. Using Spectre console. And it output the decision, so it can be used later.
        {
            string choice;

            choice = AnsiConsole.Prompt(
     new SelectionPrompt<string>()
    .Title("What you want to [green]do[/]?")
    .PageSize(10)
    .AddChoices(new[] {
            "Take in",  "Take out",  "Move Vehicle",  "Look After", "Exit","", "[red]Admin Tools[/]",
    }));
            return choice;
        }

        public void MenuSwitch() //Use decision that was choosed before to do a action.
        {

            string menuChoice = MenuChoice();
            switch (menuChoice)
            {
                case "Take in":
                    TakeIn1();
                    break;
                case "Take out":
                    Console.WriteLine("a");
                    break;
                case "Move Vehicle":
                    Console.WriteLine("a");
                    break;
                case "Look After":
                    Console.WriteLine("a");
                    break;
                case "Admin Tools":
                    Console.WriteLine("a");
                    break;
                case "Exit":
                    Console.WriteLine("b");
                    break;

                default:
                    Console.WriteLine("Something went wrong");
                    break;  
            }

        }
     

        public void TakeIn1() //Creating MC or Car
        {
          
            
            string choice = TakeIn();
            switch (choice)
            {
                case "MC":
                    
                    Console.WriteLine("Your vehicle register number: ");
                    
                   
                    Mc newVehicle = new Mc();
                    newVehicle.RegNummer = AskReg();
                    newVehicle.Time = DateTime.Now;
                    
                    Console.WriteLine(newVehicle.RegNummer);
                    Console.WriteLine(newVehicle.Time);
                    Console.WriteLine(newVehicle.Size);




                    break;
                case "Car":
                    Car newVehicle2 = new Car();
                    newVehicle2.RegNummer = AskReg();
                    newVehicle2.Time = DateTime.Now;
                    Console.WriteLine(newVehicle2.RegNummer);
                    Console.WriteLine(newVehicle2.Time);
                    Console.WriteLine(newVehicle2.Size);
                    break;
                default:
                    break;
            }
        }

        public string AskReg() //Asking for registering number
        {
            string vehicleReg;
            vehicleReg = Console.ReadLine();
            return vehicleReg;
            
            



        }
        public string TakeIn() //Giving choice between MC and Car
        {
            string choice;
            choice = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
   .Title("Which type of vehicle do you own?")
   .PageSize(10)
   .AddChoices(new[] {
            "MC",  "Car",
   }));

            return choice;


        }












    }
}
