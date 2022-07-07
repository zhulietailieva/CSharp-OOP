using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : IDrivable
    {
        private const double INCREASED_CONSUMPTION = 1.6;
        public Truck(double fuelQuantity,double litersPerKm,double tankCapacity)
        {
            if (fuelQuantity > tankCapacity) this.FuelQuantity = 0;
            else this.FuelQuantity = fuelQuantity;

            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = litersPerKm+INCREASED_CONSUMPTION;
        }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }

        public void Drive(double distance)
        {
            if (FuelQuantity - (distance * FuelConsumption) >= 0)
            {
                FuelQuantity -= distance * FuelConsumption;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            var addedFuel= this.FuelQuantity + (95 * liters) / 100;

            if (addedFuel > this.TankCapacity) Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            else this.FuelQuantity = addedFuel;
           
           
        }
    }
}
