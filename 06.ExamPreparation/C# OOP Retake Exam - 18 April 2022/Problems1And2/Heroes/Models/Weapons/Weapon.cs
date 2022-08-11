using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon

    {
        private string name;
        private int durability;

        protected Weapon(string name, int durability)
        {
            Name = name;
            Durability = durability;
        }

        public string Name { get { return this.name; }
            private set
                {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Weapon type cannot be null or empty.");
                this.name = value;
                }
            }

        public int Durability { get => this.durability;
            protected set
            {
                if (value < 0) throw new ArgumentException("Durability cannot be below 0.");
                this.durability = value;
            }
        }

        public abstract int DoDamage();
        
    }
}
