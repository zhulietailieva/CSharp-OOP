using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;
      
        protected Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            
            Armour = armour;
            
        }

        public string Name { get => this.name;
           private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Hero name cannot be null or empty.");
                this.name = value;
            }
        }

        public int Health { get => this.health;
        private set
            {
                if (value < 0) throw new ArgumentException("Hero health cannot be below 0.");
                this.health = value;
            }
        }

        public int Armour { get => this.armour;
        private set
            {
                if (value < 0) throw new ArgumentException("Hero armour cannot be below 0.");
                this.armour = value;
            }
        }

        public IWeapon Weapon { get => this.weapon;
        private set
            {
                if (value == null) throw new ArgumentException("Weapon cannot be null.");
                this.weapon = value;
            }
        }

        public bool IsAlive { get
            {
                return health > 0;
            }
            private set { }
        }
        public void AddWeapon(IWeapon weapon)
        {
            this.Weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            this.armour -= points;
            if (this.armour < 0)
            {
                int pointsLeftToTake = Math.Abs(this.armour);
                this.armour = 0;
                this.health -= pointsLeftToTake;
                if (this.health <= 0)
                {
                    this.health = 0;
                    IsAlive = false;
                }
            }
        }
    }
}
