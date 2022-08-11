using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private bool canRace = false;
        private IFormulaOneCar car;

        public Pilot(string fullName)
        {
            FullName = fullName;
        }

        public string FullName 
        {
            get => this.fullName;
           private  set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                this.fullName = value;
            }
        }

        public IFormulaOneCar Car 
        {
            get => this.car;
          private   set
            {
                if (value == null)
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                this.car = value;
            }
        }

        public int NumberOfWins { get; private set; }

        public bool CanRace 
        {
            get => canRace;
          private   set { canRace = value; }
        }

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
        public override string ToString()
        {
            return $"Pilot {this.FullName } has { this.NumberOfWins} wins.";
        }
    }
}
