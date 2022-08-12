using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double INITIAL_ARMOUR_THICKNESS = 200;
        private bool submergeMode = false;
        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, INITIAL_ARMOUR_THICKNESS) { }
        public bool SubmergeMode 
        { 
            get => this.submergeMode;
            private set { this.submergeMode = value; }
        }
        public override void RepairVessel() { this.ArmorThickness = INITIAL_ARMOUR_THICKNESS; }
        public void ToggleSubmergeMode()
        {         
            if (submergeMode)
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
            else
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            this.SubmergeMode = !SubmergeMode;
        }
        public override string ToString()
        {
            string isSubmergeModeOn = SubmergeMode ? "ON" : "OFF";
            StringBuilder res = new StringBuilder();
            res.AppendLine(base.ToString());
            res.AppendLine($" *Submerge mode: {isSubmergeModeOn}");
            return res.ToString().TrimEnd();
        }
    }
}
