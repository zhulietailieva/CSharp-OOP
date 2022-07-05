using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> peopleList = new List<Person>();
            List<Product> productsList = new List<Product>();


           

            try
            {
                //input the people
                string[] peopleInp = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < peopleInp.Length; i++)
                {
                    string[] personData = peopleInp[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = personData[0];
                    decimal money = decimal.Parse(personData[1]);
                    // Console.WriteLine("name: "+name);
                    // Console.WriteLine("money: "+money);
                    Person person = new Person(name, money);                    
                    peopleList.Add(person);
                }
                //input the products
                string[] productsInp = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < productsInp.Length; i++)
                {
                    string[] productData = productsInp[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = productData[0];
                    decimal cost = decimal.Parse(productData[1]);
                    //  Console.WriteLine("name: "+name);
                    //  Console.WriteLine("cost: "+cost);
                    Product product = new Product(name, cost);

                    productsList.Add(product);

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inpData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = inpData[0];
                string product = inpData[1];
                // Console.WriteLine($"name: {name}, product: {product}");

                for (int i = 0; i < peopleList.Count; i++)
                {
                    if (peopleList[i].Name.Equals(name))
                    {
                        for (int j = 0; j < productsList.Count; j++)
                        {
                            if (productsList[j].Name.Equals(product))
                            {
                                peopleList[i].Buy(productsList[j]);
                            }
                        }
                    }
                }

            }
            foreach (var person in peopleList)
            {
                if(person.ItemsBought == 0)
                { 
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ",person.GetProducts())}");
                }
            }
        }
    }
}
