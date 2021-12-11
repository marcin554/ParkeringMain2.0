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

        int spotNumber;
        int positionNumber;
        public void DeleteVehicle(string gotRegNummerFind)
        {
            var config = Configuration.LoadSettings();
            vehicleList = Configuration.ReadVehiclesFromFile();

            findVehicle(gotRegNummerFind);
            if (vehicleList[spotNumber].vehicles[positionNumber].Type == "MC")
            {
                      
             vehicleList[spotNumber].vehicles.RemoveAt(positionNumber);
             vehicleList[spotNumber].avaibleSize = vehicleList[spotNumber].avaibleSize + config.mcSize;
              DeleteAndSaveFileVehicles();

            }
            else if (vehicleList[spotNumber].vehicles[positionNumber].Type == "Car")
            {
                vehicleList[spotNumber].vehicles.RemoveAt(positionNumber);
                vehicleList[spotNumber].avaibleSize = vehicleList[spotNumber].avaibleSize + config.carSize;
                DeleteAndSaveFileVehicles();

            }
        }

        public void MoveVehicle (string gotRegNummerFind, int newSlot)
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
                    vehicleList[newSlot].vehicles.Add(tempVehicle);
                    vehicleList[spotNumber].avaibleSize = vehicleList[spotNumber].avaibleSize + config.carSize;
                    vehicleList[newSlot].avaibleSize = vehicleList[newSlot].avaibleSize - config.carSize;
                    DeleteAndSaveFileVehicles();
                }

            }



                
           
        }
       
        public void findVehicle(string gotRegNummerFind)
        {
            
            var config = Configuration.LoadSettings();
            vehicleList = Configuration.ReadVehiclesFromFile();
            
            for (int i = 0; i < config.sizeParkingSlots; i++)
            {
                
                if(vehicleList[i].avaibleSize < config.sizeParkingSlot) // something exist in list
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
                else if(vehicleList[i].avaibleSize == config.sizeParkingSlot)
                {
                    continue;
                }
                break;

                
                
            }
            
        }
        public bool CheckIfThereIsSpace(int slotId, string type) //TODO: Get back here (Oliver code) 
        {
            bool answer = false;
            var config = Configuration.LoadSettings();
            vehicleList = Configuration.ReadVehiclesFromFile();
            if(type == "mc")
            {
                int avaibleSize = vehicleList[slotId].avaibleSize;
                int avaibleMcSize = config.mcSize;
                if (avaibleSize >= avaibleMcSize)
                {
                    answer = true;
                }      
            }
            else if(type == "car")
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
