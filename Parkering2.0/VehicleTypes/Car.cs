using System;
using Parkering2._0.ConfigFiles;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkering2._0
{
    internal class Car : Vehicles
    {
        
        public Car(string regNummer)
        {
            var config = Configuration.LoadStartSettings();

            Type = "Car";
            Size = 5;
            Price = config.carPrice;
            Time = DateTime.Now;
            
        
        }

        
 
    }
}
