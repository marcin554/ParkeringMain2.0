using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Parkering2._0
{
    public class ParkingHouse
    {

       
           

        
        public string parkedVehicles = @"../../../ConfigFiles/Vehicles.json";



        public void ParkingList(string regNummer, string mcOrCar)
        {
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


            string json = JsonConvert.SerializeObject(ParkingVehiclesList, Formatting.Indented);
            File.AppendAllText(parkedVehicles, json);
            Console.WriteLine(json);
        }
     
        public string AddCar(string regNummer)
        {


            return "a";



        }




    }
}
