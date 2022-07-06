using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const int baseCalsPerGram = 2;

        private string type;
        private int grams;

        public Topping(string type, int grams)
        {
            this.Type = type;
            this.Grams = grams;

        }
        private string Type
        {
            get { return this.type; }
            set
            {
                if (value.ToLower() != "meat" 
                    && value.ToLower() != "veggies" 
                    && value.ToLower() != "cheese" 
                    && value.ToLower() != "sauce")
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                this.type = value;
            }
        }
        private int Grams
        {
            get { return this.grams; }
            set
            {
                if (value < 1 || value > 50)
                    throw new Exception($"{this.Type} weight should be in the range [1..50].");
                this.grams = value;

            }
        }
        public double GetCalories()
        {
            double typeD = 1;
            switch (type.ToLower())
            {
                case "meat": typeD = 1.2; break;
                case "veggies": typeD = 0.8; break;
                case "cheese": typeD = 1.1; break;
                case "sauce": typeD = 0.9; break;
            }
            return baseCalsPerGram * typeD * grams;
        }
    }
}
