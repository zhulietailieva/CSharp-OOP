using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel,IBattleship
    {
        private const double INITIAL_ARMOUR_THICKNESS = 300;
        private bool sonarMode=false;       
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, INITIAL_ARMOUR_THICKNESS) { }
        public bool SonarMode 
        { 
            get => this.sonarMode;
            private set {  this.sonarMode = value; }
        }
        public override void RepairVessel() { this.ArmorThickness = INITIAL_ARMOUR_THICKNESS; }
        public void ToggleSonarMode()
        {           
            if (SonarMode)
            {
               this. MainWeaponCaliber -= 40;
               this.Speed += 5;
            }
            else
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            this.SonarMode = !SonarMode;
        }
        public override string ToString()
        {
            string isSonarModeOn = SonarMode ? "ON" : "OFF";
            StringBuilder res=new StringBuilder();
            res.AppendLine(base.ToString());
            res.AppendLine($" *Sonar mode: {isSonarModeOn}");
            return res.ToString().TrimEnd();
        }
    }
}
