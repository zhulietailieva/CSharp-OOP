using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        protected Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.Equipment = new List<IEquipment>();
            this.Athletes = new List<IAthlete>();
        }
        public string Name 
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                this.name = value;
            }
        }
        public int Capacity 
        {
            get => this.capacity;
            private set { this.capacity = value; }
        }

        public double EquipmentWeight
        {
            get { return this.Equipment.Sum(x => x.Weight);}
        }
        public ICollection<IEquipment> Equipment { get; private set; }
        public ICollection<IAthlete> Athletes { get;private set; }
        public void AddAthlete(IAthlete athlete)
        {
            if (Athletes.Count < Capacity)this.Athletes.Add(athlete);
            else throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
        }
        public void AddEquipment(IEquipment equipment) {this.Equipment.Add(equipment); }
        public  void Exercise()
        {
            foreach (var athlete in Athletes)
            {
                athlete.Exercise();
            }
        }
        public string GymInfo()
        {
            var athletes = this.Athletes.Count == 0 ? "No athletes" : String.Join(", ", this.Athletes);
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            sb.AppendLine($"Athletes: {athletes}");
            sb.AppendLine($"Equipment total count: {this.Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");
            return sb.ToString().TrimEnd();
        }
        public bool RemoveAthlete(IAthlete athlete) { return this.Athletes.Remove(athlete); }
    }
}
