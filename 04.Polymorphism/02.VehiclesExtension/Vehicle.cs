using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public abstract class Vehicle
    {
        private double litersPerKm;

        public Vehicle(double fuelQuantity, double litersPerKm,double tankCapacity)
        {
            if (fuelQuantity > tankCapacity) this.FuelQuantity = 0;
            else  this.FuelQuantity = fuelQuantity;
           
            this.FuelConsumption = litersPerKm;
            this.TankCapacity = tankCapacity;
        }

        

        public double FuelQuantity { get; set; }
        public virtual double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }
        public virtual void Refuel(double liters)
        {
            if(liters<=0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            if (FuelQuantity + liters > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                return;
            }
            FuelQuantity += liters;
        }
        public  void Drive(double distance)
        {
            string vehicleData = this.GetType().ToString();
            
         string   vehicle = vehicleData.Substring(vehicleData.LastIndexOf('.')+1);
            if (this.FuelQuantity - (this.FuelConsumption* distance) >= 0)
            {
                 
                Console.WriteLine($"{vehicle} travelled {distance} km");
               this.FuelQuantity -=this. FuelConsumption* distance;
                return;
            }
           
                Console.WriteLine($"{vehicle} needs refueling");
        }
   }
}
