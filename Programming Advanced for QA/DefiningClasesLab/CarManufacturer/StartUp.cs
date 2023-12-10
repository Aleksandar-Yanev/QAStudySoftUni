using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main() 
        {
            Car vwMk3 = new Car();
            
            vwMk3.Make = "VW";
            vwMk3.Model = "MK3";
            vwMk3.Year = 1992;
            vwMk3.FuelQuantity = 200;
            vwMk3.FuelConsumption = 200;
            vwMk3.Drive(2000);
           
            Console.WriteLine(vwMk3.WhoAmI());
        }
    }
}
