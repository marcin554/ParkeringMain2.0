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



        int amountOfSpots = 100;

        string parkedVehicles = @"../../../ConfigFiles/Vehicles.json";
        List<ParkingSpot> vehicleList = new List<ParkingSpot>();


        public ParkingHouse()
        {
            
        }
        public void parkingSpotList()
        {
            
        }
        public void CreateParkingSpaces()
        {
            parkingSpotList();
            var config = Configuration.LoadSettings();
           
            
            





            if (config.currentMaxTaken <= config.sizeParkingSlots)
            {

                int difference = config.sizeParkingSlots - config.currentMaxTaken;
                for (int i = 0; i < difference; i++)
                {
                    config.currentMaxTaken = config.currentMaxTaken + 1;
                    Console.WriteLine(config.currentMaxTaken);
                    vehicleList.Add(new ParkingSpot { numberSpotId = config.currentMaxTaken });
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
        public void AddVehicle(string gotRegNummer, string mcOrCar)
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
                        Console.WriteLine(vehicleList[i].vehicles[0].RegNummer);
                        break;
                    }
                    else if (mcOrCar == "Car" && vehicleList[i].avaibleSize == 4)
                    {
                        vehicleList[i].avaibleSize = vehicleList[i].avaibleSize - 4;

                        Car newcar = new Car(gotRegNummer);
                        
                        
                        vehicleList[i].vehicles.Add(newcar);

                        DeleteAndSaveFileVehicles();
                    
                        break;
                       




                    }
                   
                    //vehicleList.AddRange(ParkingVehiclesList);
                    //string json = JsonConvert.SerializeObject(ParkingVehiclesList, Formatting.Indented);
                    //File.AppendAllText(parkedVehicles, json);
                    //Console.WriteLine(json);      
            }
            }
        public void DeleteVehicle(string gotRegNummerFind)
        {
            var config = Configuration.LoadSettings();
            vehicleList = Configuration.ReadVehiclesFromFile();
            for (int i = 0; i < config.sizeParkingSlots; i++)
            {
                bool goNextLoop = false;
                for (int y = 0; y <= config.maximumVehicles -1; y++)
                {
                    Console.WriteLine("Loop");
                    Console.WriteLine(i);
                    
                    if (vehicleList[i].avaibleSize != config.sizeParkingSlot && gotRegNummerFind == vehicleList[i].vehicles[y].RegNummer)
                    {
                        Console.WriteLine("were");
                        if (vehicleList[i].vehicles[y].Type == "MC")
                        {
                            goNextLoop = true;
                            //vehicleList[i].vehicles.Remove(new Vehicles());
                            vehicleList[i].vehicles.RemoveAt(y);
                            vehicleList[i].avaibleSize = vehicleList[i].avaibleSize + config.mcSize;
                            DeleteAndSaveFileVehicles();
                            y = config.maximumVehicles - 1;
                            break;
                        }
                        else if (vehicleList[i].vehicles[y].Type == "Car")
                        {
                            Console.WriteLine("were");
                            goNextLoop = true;
                            //vehicleList[i].vehicles.Remove(new Vehicles());
                            
                            vehicleList[i].vehicles.RemoveAt(y);
                            
                            Console.WriteLine("a");
                            vehicleList[i].avaibleSize = vehicleList[i].avaibleSize + config.carSize;
                            
                            DeleteAndSaveFileVehicles();
                            break;
                        }
                        
                        else
                        {
                            Console.WriteLine("abc");
                        }
                        
                    }
                    else if (vehicleList[i].avaibleSize == config.sizeParkingSlot) // If the spot have all places it mean that there is nothing there, skip. This... Dont connected it to this if and it was breaking my code for like 2-3h...
                    {
                        break;
                       
                    }
                    if (vehicleList[i].vehicles[y].Type == "Car")
                    {
                        break;

                    }
                   
                    
                    

                }
                if (goNextLoop == true)
                {
                    
                    break;
                }
                



            }
        }

        public void MoveVehicle (string gotRegNummerFind, int newSlot)
        {
            var config = Configuration.LoadSettings();
            vehicleList = Configuration.ReadVehiclesFromFile();


            for (int i = 0; i < config.sizeParkingSlots; i++)
            {
                bool goNextLoop = false;
                for (int y = 0; y <= config.maximumVehicles - 1; y++)
                {
                    Console.WriteLine("Loop");
                    Console.WriteLine(i);

                    if (vehicleList[i].avaibleSize != config.sizeParkingSlot && gotRegNummerFind == vehicleList[i].vehicles[y].RegNummer)
                    {
                        Console.WriteLine("were");
                        if (vehicleList[i].vehicles[y].Type == "MC")
                        {
                            var before = vehicleList[i].vehicles[y];
                            vehicleList[i].vehicles.RemoveAt(y);
                            string type = "mc";
                            bool checkSpace = CheckIfThereIsSpace(newSlot, type);
                            if (newSlot >= config.mcSize)
                            {
                                
                            }
                            
                            break;
                        }
                        else if (vehicleList[i].vehicles[y].Type == "Car")
                        {
                            Console.WriteLine("were");
                            goNextLoop = true;
                            //vehicleList[i].vehicles.Remove(new Vehicles());

                            vehicleList[i].vehicles.RemoveAt(y);

                            Console.WriteLine("a");
                            vehicleList[i].avaibleSize = vehicleList[i].avaibleSize + config.carSize;

                            DeleteAndSaveFileVehicles();
                            break;
                        }

                        else
                        {
                            Console.WriteLine("abc");
                        }

                    }
                    else if (vehicleList[i].avaibleSize == config.sizeParkingSlot) // If the spot have all places it mean that there is nothing there, skip. This... Dont connected it to this if and it was breaking my code for like 2-3h...
                    {
                        break;

                    }
                    if (vehicleList[i].vehicles[y].Type == "Car")
                    {
                        break;

                    }




                }
                if (goNextLoop == true)
                {

                    break;
                }




            }



        }

        public bool CheckIfThereIsSpace(int slotId, string type)
        {
            var config = Configuration.LoadSettings();
            vehicleList = Configuration.ReadVehiclesFromFile();
            if(type == "mc")
            {
                vehicleList[slotId].avaibleSize >= config.mcSize;
            }
            {

            }
                
            
            return false;
            
        }
         public void DeleteAndSaveFileVehicles()
        {
            //var config = Configuration.LoadSettings();    
            File.Delete(parkedVehicles);

            string json = JsonConvert.SerializeObject(vehicleList, Formatting.Indented);
            File.AppendAllText(parkedVehicles, json);
        }

        public void DeleteAllVehicles()
        {
            
        }

      




    }
}
