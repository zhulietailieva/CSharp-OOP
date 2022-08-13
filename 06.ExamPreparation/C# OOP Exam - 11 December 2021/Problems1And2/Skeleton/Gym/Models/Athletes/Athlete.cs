using Gym.Models.Athletes.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private string motivation;
        private int numberOfMedals;
        private int stamina;
        protected Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            FullName = fullName;
            Motivation = motivation;
            Stamina = stamina;
            NumberOfMedals = numberOfMedals;
            Stamina = stamina;
        }
        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
                this.fullName = value;
            }
        }
        public string Motivation
        {
            get => this.motivation;
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);
                this.motivation = value;
            }
        }
        public int Stamina 
        {
            get => this.stamina;
            protected set { this.stamina = value; }
        }
        public int NumberOfMedals 
        {
            get => this.numberOfMedals;
            private set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                this.numberOfMedals = value;
            }
        }
        public abstract void Exercise();
    }
}
