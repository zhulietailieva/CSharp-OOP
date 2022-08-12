using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience = 0;
        private ICollection<IVessel> vessels;

        public Captain(string fullName)
        {
            FullName = fullName;
            vessels = new List<IVessel>();
        }

        public string FullName 
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                this.fullName = value;
            }
        }

        public int CombatExperience 
        { 
            get => this.combatExperience; 
            private set { this.combatExperience = value; }
        }
        public ICollection<IVessel> Vessels => vessels;
        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            this.Vessels.Add(vessel);
        }
        public void IncreaseCombatExperience() {this.CombatExperience += 10; }
        public string Report()
        {
            StringBuilder res = new StringBuilder();
            res.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels.");
            if (this.Vessels.Count > 0)
            {
                foreach (var vessel in this.Vessels)
                {
                    res.AppendLine(vessel.ToString());
                }
            }
            return res.ToString().TrimEnd();
        }
    }
}
