using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            var captain = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            if (captain==null)
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            var vessel = vessels.FindByName(selectedVesselName); 
            if (vessel==null)
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);
            if (vessel.Captain != null)
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
            vessel.Captain = captain;
            captain.Vessels.Add(vessel);
            return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attackingVessel = vessels.FindByName(attackingVesselName);
            var defendingVessel = vessels.FindByName(defendingVesselName);
            if (attackingVessel == null)
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            if (defendingVessel == null)
                return String.Format(OutputMessages.VesselNotFound, defendingVesselName);
            if (attackingVessel.ArmorThickness == 0)
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            if (defendingVessel.ArmorThickness == 0)
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            attackingVessel.Attack(defendingVessel);
            attackingVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();
            return String.Format(OutputMessages.SuccessfullyAttackVessel,
                defendingVesselName, attackingVesselName, defendingVessel.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            var captain = captains.FirstOrDefault(c => c.FullName == captainFullName);
            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            if (captains.Any(c => c.FullName == fullName))
            return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            var captain = new Captain(fullName);                                     
            this.captains.Add(captain);
            return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);           
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel;
            switch (vesselType)
            {
                case "Submarine":
                    vessel = new Submarine(name, mainWeaponCaliber, speed);
                    break;
                case "Battleship":
                    vessel = new Battleship(name, mainWeaponCaliber, speed);
                    break;
                default:
                    return OutputMessages.InvalidVesselType;
            }
            if (vessels.FindByName(name) != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }
            vessels.Add(vessel);
            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);
            if (vessel == null)
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            vessel.RepairVessel();
            return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);
            if (vessel == null)
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            if (vessel.GetType() == typeof(Submarine))
            {
                Submarine submarine = (Submarine)vessel;
                submarine.ToggleSubmergeMode();
                return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
            else 
            {             
                Battleship battleship = (Battleship)vessel;
                battleship.ToggleSonarMode();
                return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
        }

        public string VesselReport(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);
            return vessel.ToString();
        }
    }
}
