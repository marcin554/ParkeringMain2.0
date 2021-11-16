using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkering2._0
{
    public class Vehicles
    {
        public int RegNummer { get; set; }
        public int Price { get; set; }
        public DateTime Time { get; set; }
        public int size { get; set; }

        
        public void CreateVehicle(int RegNmr)
        {
            RegNummer = RegNmr;
            Console.WriteLine(RegNmr);

        }
        
       
      
        //RegNummer
        //Time DataTime time_Now = DataTime.Now;
        //Price
        //Size
       
    }
}
