﻿using Parkering2._0.ConfigFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkering2._0
{
    public class Mc : Vehicles
    {

        
        public Mc(string regNummer)
        {
            var config = Configuration.LoadSettings();

            Type = "MC";
            Price = config.mcPrice;
            Size = config.mcSize;
            Time = DateTime.Now;

        }

     
        
      


    }
}
