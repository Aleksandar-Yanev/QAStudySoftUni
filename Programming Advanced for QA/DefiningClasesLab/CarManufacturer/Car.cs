using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        string make;

       public string Make
        { 
            get { return make; } 
            set {  make = value; } 
        } 

        public string Model { get; set; }

        public int Year { get; set; }
    }
}
