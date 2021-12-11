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



        public void SaveSettings() // Save the settings that are sended from current memory and saving it as file (settings.json)
        {
      
            
            string save1 = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(settingsPath, save1);
            
        }

        public static Configuration LoadSettings() // Read the settings.json file, so the values can be used
        {
             string settingsPath = @"../../../ConfigFiles/Settings.json";
             string jsonSettings = File.ReadAllText(settingsPath);
             var config = JsonConvert.DeserializeObject<Configuration>(jsonSettings);
            return config;
        }

        public static List<ParkingSpot> ReadVehiclesFromFile() // Read vehicles.json file and the list of spots that include list of vehicles.
        {
            string parkedVehicles = @"../../../ConfigFiles/Vehicles.json";
            string vehiclesJson = File.ReadAllText(parkedVehicles);
            List<ParkingSpot> vehicles = JsonConvert.DeserializeObject<List<ParkingSpot>>(vehiclesJson);
            return vehicles;
        }



























    }
}
