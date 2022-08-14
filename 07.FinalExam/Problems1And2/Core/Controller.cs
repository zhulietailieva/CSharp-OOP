using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;
        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            if (planets.FindByName(planetName) == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            if (unitTypeName != "SpaceForces" && 
                unitTypeName != "StormTroopers" && 
                unitTypeName != "AnonymousImpactUnit")
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            //valid unitType name and valid planetName
            var planet = planets.FindByName(planetName);
            if (planet.Army.Any(a => a.GetType().Name == unitTypeName))
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded,
                    unitTypeName, planetName));
            IMilitaryUnit unit;
            switch (unitTypeName)
            {
                case "SpaceForces": unit = new SpaceForces();
                    break;
                case "StormTroopers":unit = new StormTroopers();
                    break;
                case "AnonymousImpactUnit":unit = new AnonymousImpactUnit();
                    break;
                default: unit = null;
                    break;
            }
             planet.Spend(unit.Cost);
             planet.AddUnit(unit);            
            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }
        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (planets.FindByName(planetName) == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            if (weaponTypeName != "BioChemicalWeapon"
                && weaponTypeName != "NuclearWeapon"
                && weaponTypeName != "SpaceMissiles")
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            var planet = planets.FindByName(planetName);
            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
                throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, 
                    weaponTypeName, planetName));
            IWeapon weaponToAdd;
            switch (weaponTypeName)
            {
                case "BioChemicalWeapon":
                    weaponToAdd = new BioChemicalWeapon(destructionLevel);
                    break;
                case "NuclearWeapon":
                    weaponToAdd = new NuclearWeapon(destructionLevel);
                    break;
                case "SpaceMissiles":
                    weaponToAdd = new SpaceMissiles(destructionLevel);
                    break;
                default:
                    weaponToAdd = null;
                    break;
            }
            planet.Spend(weaponToAdd.Price);
            planet.AddWeapon(weaponToAdd);
            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }
        public string CreatePlanet(string name, double budget)
        {
            if (planets.FindByName(name) != null)
                return string.Format(OutputMessages.ExistingPlanet, name);
            var newPlanet = new Planet(name, budget);
            planets.AddItem(newPlanet);
            return String.Format(OutputMessages.NewPlanet, name);
        }
        public string ForcesReport()
        {
            var sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            var orderedPlanets = planets.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name);
            foreach (var planet in orderedPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var planet1 = planets.FindByName(planetOne);
            var planet2 = planets.FindByName(planetTwo);
            IPlanet winner;
            if (planet1.MilitaryPower > planet2.MilitaryPower) winner = planet1;
            else if (planet1.MilitaryPower < planet2.MilitaryPower) winner = planet2;
            else
            {
                var nuclearWeaponsPlanet1 = planet1.Weapons.Any(w => w.GetType().Name == "NuclearWeapon");
                var nuclearWeaponsPlanet2 = planet2.Weapons.Any(w => w.GetType().Name == "NuclearWeapon");
                if (nuclearWeaponsPlanet1 == nuclearWeaponsPlanet2) winner = null;
                else if (nuclearWeaponsPlanet1) winner = planet1;
                else winner = planet2;
            }
            if (winner == null)
            {
                planet1.Spend(planet1.Budget / 2);
                planet2.Spend(planet2.Budget / 2);
                return OutputMessages.NoWinner;
            }
            else if (winner == planet1)
            {
                planet1.Spend(planet1.Budget / 2);
                planet1.Profit(planet2.Budget / 2);
                double losingPlanetForcesAndWeaponsCosts =
                    planet2.Weapons.Sum(x => x.Price) + planet2.Army.Sum(x => x.Cost);
                planet1.Profit(losingPlanetForcesAndWeaponsCosts);
                planets.RemoveItem(planetTwo);
                return String.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }
            else
            {
                planet2.Spend(planet2.Budget / 2);
                planet2.Profit(planet1.Budget / 2);
                double losingPlanetForcesAndWeaponsCosts =
                    planet1.Weapons.Sum(x => x.Price) + planet2.Army.Sum(x => x.Cost);
                planet2.Profit(losingPlanetForcesAndWeaponsCosts);
                planets.RemoveItem(planetOne);
                return String.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }
        }
        public string SpecializeForces(string planetName)
        {
            var planet = planets.FindByName(planetName);
            if (planet == null)
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            //planet exists
            if (planet.Army.Count == 0)
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
           planet.Spend(1.25);
            foreach (var unit in planet.Army)
            {
                unit.IncreaseEndurance();
            }            
            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
