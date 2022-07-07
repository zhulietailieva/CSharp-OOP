using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : IDrivable
    {
        private const double INCREASED_CONSUMPTION = 0.9;
        public Car(double fuelQuantity,double litersPerKm,double tankCapacity)
        {
            if (fuelQuantity > tankCapacity) this.FuelQuantity = 0;
            else this.FuelQuantity = fuelQuantity;
            
            this.FuelConsumption = litersPerKm+INCREASED_CONSUMPTION;
            this.TankCapacity = tankCapacity;
        }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }

        public void Drive(double distance)
        {
            if (FuelQuantity - (distance * FuelConsumption) >= 0)
            {
                FuelQuantity -= distance * FuelConsumption;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }

        public void Refuel(double liters)
        {
            if(liters<=0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            var addedFuel=FuelQuantity + liters;
            if (addedFuel > this.TankCapacity) Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            else this.FuelQuantity = addedFuel;

        }
    }
}
