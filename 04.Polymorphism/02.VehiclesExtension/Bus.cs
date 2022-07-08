using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double litersPerKm,double tankCapacity) : base(fuelQuantity, litersPerKm,tankCapacity)
        {
        }
    
    public override double FuelConsumption => base.FuelConsumption + 1.4;
    public void DriveEmpty(double distance)
    {
            this.FuelConsumption -= 1.4;
            base.Drive(distance);
            this.FuelConsumption += 1.4;
        }
}
}