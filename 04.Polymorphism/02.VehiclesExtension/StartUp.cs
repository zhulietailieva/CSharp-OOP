using System;

namespace _02.VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(carData[1]), double.Parse(carData[2]),double.Parse(carData[3]));

            string[] truckData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Truck truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]),double.Parse(truckData[3]));

            string[] busData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Bus bus = new Bus(double.Parse(busData[1]), double.Parse(busData[2]), double.Parse(busData[3]));

            int numOfInpLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfInpLines; i++)
            {
                string[] cmnd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (cmnd[0])
                {
                    case "Drive":
                        double distance = double.Parse(cmnd[2]);
                        if (cmnd[1] == "Car")
                        {
                            car.Drive(distance);
                        }
                        else if (cmnd[1] == "Truck")
                        {
                            truck.Drive(distance);
                        }
                        else if (cmnd[1] == "Bus")
                        {
                            bus.Drive(distance);
                        }
                        break;
                    case "Refuel":
                        double liters = double.Parse(cmnd[2]);
                        if (cmnd[1] == "Car")
                        {
                            car.Refuel(liters);
                        }
                        else if (cmnd[1] == "Truck")
                        {
                            truck.Refuel(liters);
                        }
                        else if (cmnd[1] == "Bus")
                        {
                            bus.Refuel(liters);
                        }
                        break;
                    case "DriveEmpty":
                        bus.DriveEmpty(double.Parse(cmnd[2]));
                        break;
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
