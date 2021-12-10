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

        public string parkedVehicles = @"../../../ConfigFiles/Vehicles.json";

        public ParkingHouse()
        {
             
        }
        
        public void CreateParkingSpaces()
        {
            var config = Configuration.LoadSettings();
            List<ParkingSpot> vehicleList = new List<ParkingSpot>(capacity: amountOfSpots);
            //    vehicleList.Add(new ParkingSpot());
            //    vehicleList.Add(new ParkingSpot());



            if (config.currentMaxTaken <= config.sizeParkingSlots)
            {
                
                int difference = config.sizeParkingSlots - config.currentMaxTaken;
                for (int i = 0; i < difference; i++)
                {                   
                    vehicleList.Add(new ParkingSpot());
                }
                
            }
            string json = JsonConvert.SerializeObject(vehicleList, Formatting.Indented);
            File.AppendAllText(parkedVehicles, json);
            Console.WriteLine(json);
        }
        public void ParkingList(string regNummer, string mcOrCar)
        {
            CreateParkingSpaces();
            
            
            List<Vehicles> ParkingVehiclesList = new List<Vehicles>();
            
            
            
            



            if (mcOrCar == "Mc")
            {
                ParkingVehiclesList.Add(new Mc(regNummer)
                {
                    RegNummer = regNummer
                }
            );
            }
            else if (mcOrCar == "Car")
            {
                ParkingVehiclesList.Add(new Car(regNummer)
                {
                    RegNummer = regNummer
                }
            );
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }

                //vehicleList.AddRange(ParkingVehiclesList);
                //string json = JsonConvert.SerializeObject(ParkingVehiclesList, Formatting.Indented);
                //File.AppendAllText(parkedVehicles, json);
                //Console.WriteLine(json);
            }

        public void AddCar(string regNummer)
        {


            



        }




    }
}
