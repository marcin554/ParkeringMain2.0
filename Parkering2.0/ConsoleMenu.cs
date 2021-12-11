using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Newtonsoft.Json;
using Parkering2._0.ConfigFiles;


namespace Parkering2._0
{

    public class ConsoleMenu
    {

        public ParkingHouse parking = new ParkingHouse();



        public string MenuChoice() // Give alternatives to user to choose. Using Spectre console. And it output the decision, so it can be used later.
        {
            string choice;

            choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("What you want to [green]do[/]?")
            .PageSize(10)
            .AddChoices(new[] {
            "Take in",  "Take out",  "Move Vehicle",  "Look After","", "Change Settings",
    }));

            return choice;


        }

        public void MenuSwitch() //Use the input from a user to make a decision in a switch
        {
            ParkingHouse parking = new ParkingHouse();
            do
            {
                ParkingMap();
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
                        Search();
                        break;
                    case "Change Settings":
                        MenuChange();
                        
                        break;
                   
                    default:
                        Console.WriteLine("Something went wrong");
                        break;
                }
            }
            while (true);

        }
        

        public void TakeIn1() //Sending information to parkinghouse to create new vehicle.
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

        public void Move() // Sending information to a parkinghouse, to move the vehicle.
        {
            Console.WriteLine("");
            parking.MoveVehicle(AskReg(), AskNewSlot());
             
        }  
        public void Search()
        {

            int a = parking.SearchVehicle(AskReg());
            Console.WriteLine(a + 1);

        } // Sending information to a parkinghouse, to search for position of vehicle.
        public string AskReg() //Asking for registering number
        {             
            string vehicleReg = Console.ReadLine();
            vehicleReg = vehicleReg.ToUpper();
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
        } //Sending information to parkinghouse, and using the method to delete a vehicle.

        public void MenuChange()
        {
            var config = Configuration.LoadSettings();
            string menuChange = MenuChange2();
            switch (menuChange)
            {
                case "Change amount of parking slots.":
                    
                    config.sizeParkingSlots = NewValue();
                    config.SaveSettings();
                    parking.CreateParkingSpaces();

                    break;
                case "Change price of MC.":
                    config.mcPrice = NewValue();
                    config.SaveSettings();

                    break;
                case "Change price of Car.":

                    config.carPrice = NewValue();
                    config.SaveSettings();
                    break;
                case "Change size of MC.":
                    config.mcSize = NewValue();
                    config.SaveSettings();
                    break;
                case "Change size of Car.":

                    config.carSize = NewValue();
                    config.SaveSettings();
                    break;

                
                case "Go Back.":

                    
                    break;

                default:
                    Console.WriteLine("Something went wrong");
                    break;
            }
        } // Giving switch alternative to change different settings.
        public string MenuChange2() // Give alternatives to user to choose. Using Spectre console. And it output the decision, so it can be used later.
        {
            string choice;

            choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("What you want to [green]do[/]?")
            .PageSize(10)
            .AddChoices(new[] {
            "Change amount of parking slots.",  "Change price of MC.",  "Change price of Car.","Change size of MC.", "Change size of Car.", "Go Back.",
    }));

            return choice;

        }

        public int NewValue()
        {
            Console.WriteLine("Give me your new value: ");
            int a = int.Parse(Console.ReadLine());
            return a;
        }//Using this input into ChangeOptions

       

        public void ParkingMap()
        {
            List<ParkingSpot> vehicleList = new List<ParkingSpot>();
            vehicleList = Configuration.ReadVehiclesFromFile();
            var config = Configuration.LoadSettings();
            var table = new Table();

            Table t1 = new Table();

            t1.AddColumns("[grey]EMPTY SPOT =[/] [green]GREEN[/]", "[grey]FULL SPOT =[/] [red]RED[/]", "[yellow]FULL SPOT =[/] [Yellow]HALF TAKEN[/]").Centered().Alignment(Justify.Center);
            AnsiConsole.Write(t1);
            Table newTable = new Table().Centered();
            var parkingSpotColorMarking = "";
            var printResult = "";
            int taken = 0;

            for (int i = 0; i < config.sizeParkingSlots; i++)
            {
                if (vehicleList[i].avaibleSize == config.sizeParkingSlot)
                {

                    parkingSpotColorMarking = "green";

                }
                else if (vehicleList[i].avaibleSize > 0)
                {
                    parkingSpotColorMarking = "yellow";
                }
                else
                {
                    parkingSpotColorMarking = "red";
                    taken = taken + 1;
                }
                printResult += ($"[{parkingSpotColorMarking}] {i + 1}[/] ");
            }
            AnsiConsole.Write(new BarChart()
.Width(80)
.Label("[green bold underline]Parking slots[/]")
.CenterLabel()
.AddItem("Taken", taken, Color.Green)
.AddItem("Total", config.sizeParkingSlots, Color.DeepPink4_1));
            newTable.AddColumn(new TableColumn(printResult));
            AnsiConsole.Write(newTable);

        } // Show parking map, used and a little edited Edwin map.










    }
}
