using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double litersPerKm,double tankCapacity)
            : base(fuelQuantity, litersPerKm,tankCapacity)
        {
        }
        public override double FuelConsumption => base.FuelConsumption + 1.6;
        public override void Refuel(double liters)
        {
            if (FuelQuantity + liters > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                return;
            }
            liters = 0.95 * liters;
            base.Refuel(liters);
        }
    }
}
