using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double litersPerKm,double tankCapacity) : base(fuelQuantity, litersPerKm,tankCapacity)
        {
        }
        public override double FuelConsumption =>base.FuelConsumption+0.9; 

       
    }
}
