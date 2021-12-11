using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Newtonsoft.Json;


namespace Parkering2._0
{

    public class ConsoleMenu
    {

        public ParkingHouse parking = new ParkingHouse();


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
            "Take in",  "Take out",  "Move Vehicle",  "Look After", "Exit","", "Admin Tools",
    }));

            return choice;


        }

        public void MenuSwitch() //Use decision that was choosed before to do a action.
        {
            ParkingHouse parking = new ParkingHouse();
            do
            {
                
                string menuChoice = MenuChoice();
                switch (menuChoice)
                {
                    case "Take in":
                        TakeIn1();
                        break;
                    case "Take out":
                        TakeOut();
                        break;
                    case "Move Vehicle":

                        Move();
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
            while (true);

        }
        

        public void TakeIn1() //Creating MC or Car
        {


            string choice = TakeIn();
            switch (choice)
            {
                case "Mc":

                    Console.WriteLine("Your vehicle register number: ");


                    parking.AddVehicle(AskReg(),choice);                  
                    








                    break;
                case "Car":
                    Console.WriteLine("Your vehicle register number: ");
                    parking.AddVehicle(AskReg(), choice);



             
                    break;
                default:
                    break;
            }
        }

        public void Move()
        {
            Console.WriteLine("");
            parking.MoveVehicle(AskReg(), AskNewSlot());
             
        }
        public string AskReg() //Asking for registering number
        {
            
            
            string vehicleReg = Console.ReadLine();
            return vehicleReg;





        }
        public int AskNewSlot() //Asking for registering number
        {
            Console.WriteLine("Give me your new slot number: ");
            
            int newSlot = int.Parse(Console.ReadLine());
            newSlot = newSlot - 1;
            
            return newSlot;





        }
        public string TakeIn() //Giving choice between MC and Car
        {
            string choice;
            choice = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
   .Title("Which type of vehicle do you own?")
   .PageSize(10)
   .AddChoices(new[] {
            "Mc",  "Car",
   }));

            return choice;


        }

        public void TakeOut()
        {
            Console.WriteLine("Your vehicle register number: ");
            parking.DeleteVehicle(AskReg());
        }











    }
}
