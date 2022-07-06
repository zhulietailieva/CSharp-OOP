using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private const double baseCalories = 2;
        //white or wholegrain
        private string flourType;
        //crispy, chewy, homemade
        private string bakingTechnique;
        private int grams;

        public Dough(string flourType, string bakingTechnique, int grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;

        }

        private string FlourType
        {
            get { return this.flourType; }
            set
            {
                if (value.ToLower() != "wholegrain" 
                    && value.ToLower() != "white") throw new Exception("Invalid type of dough.");
                this.flourType = value;

            }
        }
        private string BakingTechnique
        {
            get { return this.bakingTechnique; }
            set
            {
                if (value.ToLower() != "crispy" 
                    && value.ToLower() != "chewy" 
                    && value.ToLower() != "homemade") throw new Exception("Invalid type of dough.");
                this.bakingTechnique = value;

            }
        }

        private int Grams
        {
            get { return this.grams; }
            set
            {
                if (value < 1 || value > 200) throw new Exception("Dough weight should be in the range [1..200].");
                this.grams = value;

            }
        }
        public double GetCalories()
        {
            double type = 1;
            double technique = 1;
            switch (flourType.ToLower())
            {
                case "white": type = 1.5; break;
                case "wholegrain": technique = 1.0; break;
            }
            switch (bakingTechnique.ToLower())
            {
                case "crispy": technique = 0.9; break;
                case "chewy": technique = 1.1; break;
                case "homemade": technique = 1.0; break;
            }

            return baseCalories * technique * type * grams;

        }
    }
}
