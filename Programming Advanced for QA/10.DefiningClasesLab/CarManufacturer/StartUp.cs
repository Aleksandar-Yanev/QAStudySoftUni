﻿using System;
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
            var tires = new Tire[]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(2, 0.5),
                new Tire(2, 2.3)
            };

            var engine = new Engine(560, 6300);

            var lambo = new Car("Lamborghini", "Urus", 2010, 250, 9, engine, tires);

            Console.WriteLine(lambo.WhoAmI());


            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());
            //double FuelConsumption = double.Parse(Console.ReadLine());

            //Car firstCar = new Car();
            //Car secondCar = new Car(make, model, year);
            //Car thirdCar = new Car(make, model, year, fuelQuantity, FuelConsumption);


            //Car vwMk3 = new Car();

            //vwMk3.Make = "VW";
            //vwMk3.Model = "MK3";
            //vwMk3.Year = 1992;
            //vwMk3.FuelQuantity = 200;
            //vwMk3.FuelConsumption = 200;
            //vwMk3.Drive(2000);

            //Console.WriteLine(vwMk3.WhoAmI());
        }
    }
}
