namespace _04.VehicleCatalogue;

public class Truck
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Weight { get; set; }
}

public class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int HorsePower { get; set; }
}

public class Catalog
{
    public List <Truck> Trucks { get; set; }
    public List <Car> Cars { get; set; }

    public Catalog()
    {
        Trucks = new List<Truck>();
        Cars = new List<Car>();
    }
}

class Program
{
    static void Main(string[] args)
    {
        string input;
        
        Catalog catalog = new Catalog();

        while ((input = Console.ReadLine()) != "end")
        {
            string[] separatedInput = input.Split("/");
            Truck currentTruck = new Truck();
            Car currentCar = new Car();

            if (separatedInput[0] == "Truck")
            {
                currentTruck.Brand = separatedInput[1];
                currentTruck.Model = separatedInput[2];
                currentTruck.Weight = int.Parse(separatedInput[3]);

                catalog.Trucks.Add(currentTruck);
            }
            else if (separatedInput[0] == "Car")
            {
                currentCar.Brand = separatedInput[1];
                currentCar.Model = separatedInput[2];
                currentCar.HorsePower = int.Parse(separatedInput[3]);

                catalog.Cars.Add(currentCar);
            }
        }
        Console.WriteLine("Cars:");
        foreach (var car in catalog.Cars.OrderBy(c => c.Brand))
        {
            Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
        }

        Console.WriteLine("Trucks:");
        foreach (var truck in catalog.Trucks.OrderBy(t => t.Brand))
        {
            Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
        }
    }
}