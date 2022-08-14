using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        
        private string name;
        private double budget;
        private List<IMilitaryUnit> army;
        private List<IWeapon> weapons;
        public Planet(string name,double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.army = new List<IMilitaryUnit>();
            this.weapons = new List<IWeapon>();
        }
        public string Name 
        {
            get => this.name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                this.name = value;
            }
        }

        public double Budget 
        {
            get => this.budget;
            private set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                this.budget = value;
            }
        }
        
        public double MilitaryPower 
        {
            get => CalculateMilitaryPower();
            private set {this.MilitaryPower = value; }
        }
        public IReadOnlyCollection<IMilitaryUnit> Army => army;
        public IReadOnlyCollection<IWeapon> Weapons => weapons;

        private double CalculateMilitaryPower()
        {
            double totalAmount = this.Army.Sum(x => x.EnduranceLevel) + this.Weapons.Sum(x => x.DestructionLevel);
            if(this.Army.Any(x=>x.GetType().Name== "AnonymousImpactUnit"))
            {
                totalAmount *= 1.3;
            }
            if(this.Weapons.Any(x=>x.GetType().Name== "NuclearWeapon"))
            {
                totalAmount *= 1.45;
            }
            return Math.Round(totalAmount, 3);
        }
        public void AddUnit(IMilitaryUnit unit) { army.Add(unit); }
        public void AddWeapon(IWeapon weapon) { weapons.Add(weapon); }
        public string PlanetInfo()
        {
            string unitsInfo = this.army.Count == 0
                ? "No units" : string.Join(", ", army.Select(x=>x.GetType().Name));
            string weaponsInfo = this.weapons.Count == 0
                ? "No weapons" : string.Join(", ", weapons.Select(x => x.GetType().Name));
            var sb = new StringBuilder();
            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            sb.AppendLine($"--Forces: {unitsInfo}");
            sb.AppendLine($"--Combat equipment: {weaponsInfo}");
            sb.AppendLine($"--Military Power: {this.MilitaryPower}");
            return sb.ToString().TrimEnd();
        }
        public void Profit(double amount) => this.Budget += amount;
        public void Spend(double amount)
        {
            if (Budget - amount < 0) throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            this.Budget -= amount;
        }
        public void TrainArmy()
        {         
            foreach (var force in army)
            {
                force.IncreaseEndurance();
            }
        }
    }
}
