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


            //string readall = File.ReadAllText(parkedVehicles);
            //ParkingVehiclesList = JsonConvert.DeserializeObject<List<Mc>>(parkedVehicles);

            //using (StreamReader file = File.OpenText(parkedVehicles))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    Vehicles movie2 = (Vehicles)serializer.Deserialize(file, typeof(Vehicles));
            //}
            //ParkingVehiclesList = JsonConvert.DeserializeObject(readall, ParkingVehiclesList);
            //string json2 = JsonConvert.DeserializeObject<List<ParkingVehiclesList2>>(parkedVehicles);
            //File.AppendAllText(parkedVehicles, json2);




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
        //public void takeListVehicles()
        //{
        //    Configuration config;
        //    string readall = File.ReadAllText(parkedVehicles);
        //    config = JsonConvert.DeserializeObject<Configuration>(readall);
        //    return config;

        //}
        //amount of spots
        //taken/free slots
        //show places
        //
        public string AddCar(string regNummer)
        {


            return "a";



        }
        //public void AddMc(string regNummer)
        //{
        //    Vehicles newMc = new Mc(regNummer);
        //    Console.WriteLine(newMc.Time);

        //    string json = JsonConvert.SerializeObject(newMc, Formatting.Indented);
        //    File.WriteAllText(parkedVehicles, json);
        //    Console.WriteLine(json);
        //}



    }
}
