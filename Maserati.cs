using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batman
{
    
    
        public class PenguinMaserati : Vehicle
        {
            public bool IceTires { get; private set; }

            public PenguinMaserati()
                : base("Maserati Iceblade", speed: 170, fuel: 90)
            {
                IceTires = true;
            }

            public void LaunchOilSlick()
            {
                Console.WriteLine(" Pingwin wypuszcza plamę oleju z tylnego zderzaka! Zwiększa szansę na poślizg przeciwnika.");
            }
        }
    }

