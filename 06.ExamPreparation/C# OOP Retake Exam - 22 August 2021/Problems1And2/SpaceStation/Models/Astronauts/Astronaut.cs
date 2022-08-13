using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private IBag bag;
        protected Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
           this.bag = new Backpack();
        }

        public string Name 
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                this.name = value;
            }
        }
        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                this.oxygen = value;
            }
        }       
        public bool CanBreath => this.Oxygen > 0;
        public IBag Bag => this.bag;
        public virtual void Breath() { this.Oxygen -= 10; }
    }
}
