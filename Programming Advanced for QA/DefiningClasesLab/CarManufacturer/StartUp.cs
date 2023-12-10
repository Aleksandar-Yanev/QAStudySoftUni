using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine($"Make: {vwMk3.Make}\nModel: {vwMk3.Model}\nYear: {vwMk3.Year}");
        }
    }
}
