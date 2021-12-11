using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Parkering2._0.ConfigFiles;
namespace Parkering2._0
{
    public class ParkingHouse
    {





        string parkedVehicles = @"../../../ConfigFiles/Vehicles.json";
        List<ParkingSpot> vehicleList = new List<ParkingSpot>();


        public ParkingHouse()
        {

        }
        public void parkingSpotList()
        {

        }
        public void CreateParkingSpaces() //Create new spots objects or delete them.
        {
            int amount = 0;
            bool falsew = false;
            var config = Configuration.LoadSettings();
            vehicleList = Configuration.ReadVehiclesFromFile();
            itsSaveToDelete();
            if (config.currentMaxTaken < config.sizeParkingSlots)
            {
                int difference = config.sizeParkingSlots - config.currentMaxTaken;
                for (int i = 0; i < difference; i++)
                {
                    config.currentMaxTaken = config.currentMaxTaken + 1;
                    vehicleList.Add(new ParkingSpot { numberSpotId = config.currentMaxTaken });
                    DeleteAndSaveFileVehicles();
                    config.SaveSettings();
                    Console.WriteLine("Created Spot.");
                }

            }

            else if (config.currentMaxTaken > config.sizeParkingSlots && falsew == true)
            {

                for (int i = config.currentMaxTaken -1; i > config.sizeParkingSlots; i--)
                {

                    vehicleList.RemoveAt(i);

                    config.currentMaxTaken = config.currentMaxTaken - 1;
                    config.SaveSettings();
                    DeleteAndSaveFileVehicles();


                    Console.WriteLine("Deleted Spot.");

                }
            }
      

            void itsSaveToDelete()
            {


                for (int i = config.sizeParkingSlots; i < config.currentMaxTaken; i++)
                {
                    if (vehicleList[i].avaibleSize == config.sizeParkingSlot)
                    {


                        amount++;




                    }


                }
                if (amount == config.currentMaxTaken - config.sizeParkingSlots)
                {
                    falsew = true;
                    


                }
                else if (amount != config.currentMaxTaken - config.sizeParkingSlots)
                {
                    falsew = false;


                }
                else
                {
                    config.sizeParkingSlots = config.currentMaxTaken;
                    config.SaveSettings();
                }


            }




            //string regNummer = "2";
            //vehicleList[2].vehicles.Add(new Mc(regNummer));
            //Console.WriteLine(vehicleList[2].vehicles[0].Price);
            //ParkingSpot a = new ParkingSpot { };
            //Console.WriteLine(a.CheckIfThereIsSpace);


            //string json = JsonConvert.SerializeObject(vehicleList, Formatting.Indented);
            //File.AppendAllText(parkedVehicles, json);
            //Console.WriteLine(json);

        }

        public void AddVehicle(string gotRegNummer, string mcOrCar) // Add Vehicles to existing parkingSpots
        {
            var config = Configuration.LoadSettings();
            vehicleList = Configuration.ReadVehiclesFromFile();

            for (int i = 0; i < config.sizeParkingSlots; i++)
            {


                if (mcOrCar == "Mc" && vehicleList[i].avaibleSize >= 2) //TODO: AvaibleSize to config
                {
                    vehicleList[i].avaibleSize = vehicleList[i].avaibleSize - 2;

                    Mc newMc = new Mc(gotRegNummer);

                    vehicleList[i].vehicles.Add(newMc);

                    DeleteAndSaveFileVehicles();
                    CreationKvitto(vehicleList[i].numberSpotId);
                    Console.WriteLine(vehicleList[i].vehicles[0].RegNummer);
                    break;
                }
                else if (mcOrCar == "Car" && vehicleList[i].avaibleSize == 4)
                {
                    vehicleList[i].avaibleSize = vehicleList[i].avaibleSize - 4;

                    Car newcar = new Car(gotRegNummer);


                    vehicleList[i].vehicles.Add(newcar);

                    DeleteAndSaveFileVehicles();
                    CreationKvitto(vehicleList[i].numberSpotId);

                    break;





                }

                //vehicleList.AddRange(ParkingVehiclesList);
                //string json = JsonConvert.SerializeObject(ParkingVehiclesList, Formatting.Indented);
                //File.AppendAllText(parkedVehicles, json);
                //Console.WriteLine(json);      
            }
        }

        int spotNumber;
        int positionNumber;
        public void DeleteVehicle(string gotRegNummerFind) //Take out a Vehicle from parking spot. 
        {
            var config = Configuration.LoadSettings();
            vehicleList = Configuration.ReadVehiclesFromFile();

            findVehicle(gotRegNummerFind);
            if (vehicleList[spotNumber].vehicles[positionNumber].Type == "MC")
            {
                Kvitto(vehicleList[spotNumber].vehicles[positionNumber].RegNummer, vehicleList[spotNumber].numberSpotId);
                countPrice(vehicleList[spotNumber].vehicles[positionNumber].Time, vehicleList[spotNumber].vehicles[positionNumber].Type);
                vehicleList[spotNumber].vehicles.RemoveAt(positionNumber);
                vehicleList[spotNumber].avaibleSize = vehicleList[spotNumber].avaibleSize + config.mcSize;
                DeleteAndSaveFileVehicles();

            }
            else if (vehicleList[spotNumber].vehicles[positionNumber].Type == "Car")
            {
                Kvitto(vehicleList[spotNumber].vehicles[positionNumber].RegNummer, vehicleList[spotNumber].numberSpotId);
                countPrice(vehicleList[spotNumber].vehicles[positionNumber].Time, vehicleList[spotNumber].vehicles[positionNumber].Type);
                vehicleList[spotNumber].vehicles.RemoveAt(positionNumber);
                vehicleList[spotNumber].avaibleSize = vehicleList[spotNumber].avaibleSize + config.carSize;
                DeleteAndSaveFileVehicles();

            }
        }

        public void MoveVehicle(string gotRegNummerFind, int newSlot) // Give ability to move the vehicle to other parking spots.
        {

            var config = Configuration.LoadSettings();
            vehicleList = Configuration.ReadVehiclesFromFile();


            findVehicle(gotRegNummerFind);
            if (vehicleList[spotNumber].vehicles[positionNumber].Type == "MC")
            {
                string type = "mc";
                bool checkSpace = CheckIfThereIsSpace(newSlot, type);
                if (checkSpace == true)
                {
                    var tempVehicle = vehicleList[spotNumber].vehicles[positionNumber];
                    CreationKvitto(vehicleList[newSlot].numberSpotId);
                    vehicleList[spotNumber].vehicles.RemoveAt(positionNumber);
                    vehicleList[newSlot].vehicles.Add(tempVehicle);
                    vehicleList[spotNumber].avaibleSize = vehicleList[spotNumber].avaibleSize + config.mcSize;
                    vehicleList[newSlot].avaibleSize = vehicleList[newSlot].avaibleSize - config.mcSize;

                    DeleteAndSaveFileVehicles();
                }

            }
            else if (vehicleList[spotNumber].vehicles[positionNumber].Type == "Car")
            {
                string type = "car";
                bool checkSpace = CheckIfThereIsSpace(newSlot, type);

                if (checkSpace == true)
                {
                    var tempVehicle = vehicleList[spotNumber].vehicles[positionNumber];
                    vehicleList[spotNumber].vehicles.RemoveAt(positionNumber);
                    CreationKvitto(vehicleList[newSlot].numberSpotId);
                    vehicleList[newSlot].vehicles.Add(tempVehicle);
                    vehicleList[spotNumber].avaibleSize = vehicleList[spotNumber].avaibleSize + config.carSize;
                    vehicleList[newSlot].avaibleSize = vehicleList[newSlot].avaibleSize - config.carSize;
                    DeleteAndSaveFileVehicles();
                }

            }





        }

        public void findVehicle(string gotRegNummerFind) // Search tool for vehicles, it goes through list, to find a regnummer that is same as the one in input.
        {

            var config = Configuration.LoadSettings();
            vehicleList = Configuration.ReadVehiclesFromFile();

            for (int i = 0; i < config.sizeParkingSlots; i++)
            {

                if (vehicleList[i].avaibleSize < config.sizeParkingSlot) // something exist in list
                {
                    if (vehicleList[i].vehicles[0].Type == "Car") // It mean that there cant be more vehicles in there. So it dont need to check for2. 
                    {
                        if (vehicleList[i].vehicles[0].RegNummer == gotRegNummerFind)
                        {
                            spotNumber = i;
                            positionNumber = 0;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (vehicleList[i].avaibleSize >= config.mcSize) // if there are 2 avaible
                    {
                        if (vehicleList[i].vehicles[0].RegNummer == gotRegNummerFind)
                        {
                            spotNumber = i;
                            positionNumber = 0;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (vehicleList[i].avaibleSize == 0) // if there is 0 avaible, check 1 position on list. 
                    {
                        if (vehicleList[i].vehicles[0].RegNummer == gotRegNummerFind)
                        {
                            spotNumber = i;
                            positionNumber = 0;
                        }
                        else if (vehicleList[i].vehicles[1].RegNummer == gotRegNummerFind) // if there is 0 avaible, check 2nd position on list
                        {
                            spotNumber = i;
                            positionNumber = 1;
                        }
                    }
                }
                else if (vehicleList[i].avaibleSize == config.sizeParkingSlot)
                {
                    continue;
                }
                else
                {
                    continue;
                }



            }

        }

        public int SearchVehicle(string regNr) // for user to find parking of his 
        { 
            findVehicle(regNr);
            return spotNumber;
        }
        public bool CheckIfThereIsSpace(int slotId, string type) // Check if there is avaible space in the parkingSpot
        {
            bool answer = false;
            var config = Configuration.LoadSettings();
            vehicleList = Configuration.ReadVehiclesFromFile();
            if (type == "mc")
            {
                int avaibleSize = vehicleList[slotId].avaibleSize;
                int avaibleMcSize = config.mcSize;
                if (avaibleSize >= avaibleMcSize)
                {
                    answer = true;
                }
            }
            else if (type == "car")
            {
                int avaibleSize = vehicleList[slotId].avaibleSize;
                int avaibleCarSize = config.carSize;
                if (avaibleSize >= avaibleCarSize)
                {
                    answer = true;
                }
            }
            return answer;


        }
        public void DeleteAndSaveFileVehicles() //It destroy the file and create new from memory. 
        {
            //var config = Configuration.LoadSettings();    
            File.Delete(parkedVehicles);

            string json = JsonConvert.SerializeObject(vehicleList, Formatting.Indented);
            File.AppendAllText(parkedVehicles, json);
        }

        public void DeleteAllVehicles()
        {

        }

        public void countPrice(DateTime timeRegistered, string Type) 
        {

            var config = Configuration.LoadSettings();

            DateTime now = DateTime.Now;
            DateTime minusFree = DateTime.Now - new TimeSpan(0, config.firstFreeMin, 0);

            TimeSpan span = now.Subtract(timeRegistered);


            if (Type == "Car")
            {
                int totalCost = span.Hours * config.carPrice;
                Console.WriteLine("Your total cost is: {0} CZK.", totalCost);
                Console.WriteLine("");
            }
            else if (Type == "MC")
            {
                int totalCost = span.Hours * config.mcPrice;
                Console.WriteLine("Your total cost is: {0} CZK.", totalCost);
                Console.WriteLine("");
            }
        }//Its calculating the price for using parking. (-10 min for free)

        public void Kvitto(string RegNmr, int slotNr) // Just output for user to know where he parked.
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Your vehicle with registernumber: {0} on parking place {1} have been taken out.", RegNmr, slotNr);
            Console.WriteLine("=================================================");
        }

        public void CreationKvitto(int slotNr)// Just output for user to know where he parked.
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("You placed your vehicle on spot: {0} ", slotNr);
            Console.WriteLine("=================================================");
        }






    }
}