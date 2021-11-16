using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkering2._0.ConfigFiles
{
    public class Configuration
    {
        public int SizeParkingSlots;

        public int CurrentMaxTaken;

        public int SizeParkingSlot;

        public int McSize;

        public int CarSize;

        public int FirstFreeMin;

        public string SettingsPath = @"../../../ConfigFiles/Settings.json";
        public string ParkedVehicles = @"../../../ConfigFiles/Vehicles.json";




    }
}
