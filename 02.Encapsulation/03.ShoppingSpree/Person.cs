using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name,decimal money)
        {
            this.Name = name;
            this.Money = money;
            products = new List<Product>();

        }
        public string Name { get { return this.name;}
            set 
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Name cannot be empty");
                this.name = value;
            }
        }
        public decimal Money
        {
            get { return this.money; }
            set
            {
                if (value < 0) throw new ArgumentException("Money cannot be negative");
                this.money = value;
            }
        }
        public int ItemsBought => products.Count;
        
        public List<string> GetProducts()
        {
            List<string> res = new List<string>();
            for (int i = 0; i < products.Count; i++)
            {
                res.Add(products[i].Name);

            }
            return res;
        }

        public void Buy(Product product)
        {
           
            if (money >= product.Cost)
            {
                Console.WriteLine($"{this.Name} bought {product.Name}");
                products.Add(product);
                Money -= product.Cost;
               

            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
            

        }
    }
}
