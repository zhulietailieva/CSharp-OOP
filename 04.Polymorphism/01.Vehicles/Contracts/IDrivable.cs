using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public interface IDrivable
    {
        
        public double FuelQuantity { get;set; }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }
        public void Drive(double distance);
        public void Refuel(double liters);

    }
}
