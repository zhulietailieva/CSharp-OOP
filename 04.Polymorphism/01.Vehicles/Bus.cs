using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Bus : IDrivable
    {
        public Bus(double fuelQuantity, double litersPerKm, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity) this.FuelQuantity = 0;
            else this.FuelQuantity = fuelQuantity;

            this.FuelConsumption = litersPerKm;
            this.TankCapacity = tankCapacity;
        }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }
        public bool IsEmpty { get; set; }


        public void Drive(double distance)
        {
            if (FuelQuantity - (distance * (FuelConsumption+1.4)) >= 0)
            {
                FuelQuantity -= distance * (FuelConsumption+1.4);
                Console.WriteLine($"Bus travelled {distance} km");
                //ako e tuka greshkata i v dr klasove trqbva da go opravq

                if (FuelQuantity - (distance * (FuelConsumption + 1.4)) == 0)
                {
                    Console.WriteLine("Bus needs refueling");
                }
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }
        public void DriveEmpty(double distance)
        {
            if (FuelQuantity - (distance * FuelConsumption ) >= 0)
            {
                FuelQuantity -= distance * FuelConsumption ;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            var addedFuel = FuelQuantity + liters;
            if (addedFuel > this.TankCapacity) Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            else this.FuelQuantity = addedFuel;
        }
    }
}
