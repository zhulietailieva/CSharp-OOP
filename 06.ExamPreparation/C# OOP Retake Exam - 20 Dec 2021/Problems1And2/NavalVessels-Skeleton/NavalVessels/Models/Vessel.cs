using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;       
        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
            Targets = new List<string>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                this.name = value;
            }
        }

        public ICaptain Captain
        {
            get => this.captain;
            set
            {
                if (value == null)
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                this.captain = value;
            }
        }
        public double ArmorThickness { get; set; }
        public double MainWeaponCaliber { get; protected set; }
        public double Speed { get; protected set; }
        public ICollection<string> Targets { get; private set; }
        public void Attack(IVessel target)
        {
            if (target == null)
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            target.ArmorThickness -= this.MainWeaponCaliber;
                if (target.ArmorThickness < 0)
                {
                    target.ArmorThickness = 0;
                }
            this.Targets.Add(target.Name);
         }
        public abstract void RepairVessel();
        public override string ToString()
        {
            string targets = this.Targets.Count == 0 ? "None" : String.Join(", ", this.Targets);
            StringBuilder res = new StringBuilder(string.Empty);
            res.AppendLine($"- {this.Name}");
            res.AppendLine($" *Type: {this.GetType().Name}");
            res.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            res.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            res.AppendLine($" *Speed: {this.Speed} knots");
            res.AppendLine($" *Targets: {targets}");
            return res.ToString().TrimEnd();
        }
    }
}
