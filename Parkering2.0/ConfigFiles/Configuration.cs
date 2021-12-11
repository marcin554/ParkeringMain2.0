using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Parkering2._0.ConfigFiles
{
    public class Configuration
    {

        public int sizeParkingSlots { get; set; }

        public int currentMaxTaken{ get; set; }

        public int sizeParkingSlot { get; set; }

        public int mcSize { get; set; }

        public int mcPrice { get; set; }

        public int carPrice { get; set; }

        public int carSize { get; set; }

        public int firstFreeMin { get; set; }
        public int maximumVehicles{ get; set; }



        public Configuration()
        {
            

        }
       
        
        public string settingsPath = @"../../../ConfigFiles/Settings.json";
        public string parkedVehicles = @"../../../ConfigFiles/Vehicles.json";



        public void SaveSettings()
        {
            //var config = Configuration.LoadSettings();
            //if (config.currentMaxTaken != currentMaxTaken) // I dont have idea how i did that, and how it know what i mean with "currentMaxTaken". I use this to create slots. 
            //{
            //    currentMaxTaken = currentMaxTaken;
            //}
            
            string save1 = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(settingsPath, save1);
            
        }

        public static Configuration LoadSettings()
        {
             string settingsPath = @"../../../ConfigFiles/Settings.json";
             string jsonSettings = File.ReadAllText(settingsPath);
             var config = JsonConvert.DeserializeObject<Configuration>(jsonSettings);
            return config;
        }

        public static List<ParkingSpot> ReadVehiclesFromFile()
        {
            string parkedVehicles = @"../../../ConfigFiles/Vehicles.json";
            string vehiclesJson = File.ReadAllText(parkedVehicles);
            List<ParkingSpot> vehicles = JsonConvert.DeserializeObject<List<ParkingSpot>>(vehiclesJson);
            return vehicles;
        }






















        //public static Configuration? LoadStartSettings(string settingsPath = @"../../../ConfigFiles/Settings.json")
        //{

        //    string settingsJson = File.ReadAllText(settingsPath);
        //    var configuration = JsonConvert.DeserializeObject<Configuration>(settingsPath);
        //    return configuration;
        //}
        //public void LoadSettings()
        //{
        //    string settingsPath = @"../../../ConfigFiles/Settings.json";
        //    string settingsJson = File.ReadAllText(settingsPath);
        //    JsonConvert.DeserializeObject<Configuration>(settingsJson);
        //}
        //public List ReadVehicles()
        //{
        //    string vehiclesJson = File.ReadAllText(settingsPath);
        //    List<Vehicles> vehicles = JsonConvert.DeserializeObject<List<Vehicles>>(vehiclesJson);

        //}





    }
}
