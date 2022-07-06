using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();

        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                this.name = value;

            }
        }
        public int NumberOfToppings => toppings.Count;
        public double TotalCalories { get { return dough.GetCalories() + GetToppingsCal(); } private set { } }

        private double GetToppingsCal()
        {
            double sum = 0;
            for (int i = 0; i < toppings.Count; i++)
            {
                sum += toppings[i].GetCalories();
            }
            return sum;
        }
        public void AddTopping(Topping topping)
        {
            if (this.NumberOfToppings > 10) throw new Exception("Number of toppings should be in range [0..10].");
            this.toppings.Add(topping);
        }
    }
}
