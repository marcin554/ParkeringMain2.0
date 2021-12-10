using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parkering2._0.ConfigFiles;

namespace Parkering2._0
{
    internal class ParkingSpot:ParkingHouse
    {
        
        public int sizeSpot = 4;
        public int numberSpotId;
        public int avaibleSize { get; set; }
        public List<Vehicles> vehicles { get; set; } = new List<Vehicles>();
       
        
        public ParkingSpot()
        {
            var config = Configuration.LoadSettings();

            sizeSpot = config.sizeParkingSlot;
            avaibleSize = sizeSpot;
            
            

        }
        public void a(string regNummer, string mcOrCar)
        {
            //vehicles.Add(new Vehicles());

            vehicles.Add(new Car(regNummer)
            {
                RegNummer = regNummer


            });
        }

       // Available Size
            //Spot Number

        
    }
}
