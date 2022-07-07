using System;

namespace _01.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(carData[1]), double.Parse(carData[2]),double.Parse(carData[3]));
            string[] truckData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Truck truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]), double.Parse(carData[3]));
            string[] busData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Bus bus = new Bus(double.Parse(busData[1]), double.Parse(busData[2]), double.Parse(busData[3]));
            int numOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfLines; i++)
            {
                string[] inpData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = inpData[0];
                switch (command)
                {
                    case "Drive":
                        if (inpData[1] == "Car")
                        {
                            car.Drive(double.Parse(inpData[2]));

                        }
                        else if (inpData[1] == "Truck")
                        {
                            truck.Drive(double.Parse(inpData[2]));
                        }
                        else if (inpData[1] == "Bus")
                        {
                            bus.Drive(double.Parse(inpData[2]));
                        }

                        break;
                    case "DriveEmpty":
                        bus.DriveEmpty(double.Parse(inpData[2]));
                        break;
                    case "Refuel":
                        if (inpData[1] == "Car")
                        {
                            car.Refuel(double.Parse(inpData[2]));

                        }
                        else if (inpData[1] == "Truck")
                        {
                            truck.Refuel(double.Parse(inpData[2]));
                        }
                        else if (inpData[1] == "Bus")
                        {
                            bus.Refuel(double.Parse(inpData[2]));
                        }
                        break;
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
