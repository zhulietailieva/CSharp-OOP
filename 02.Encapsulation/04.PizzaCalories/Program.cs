using System;

namespace _04.PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInp = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string pizzaName = pizzaInp[1];
                string[] doughInp = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Dough dough = new Dough(doughInp[1], doughInp[2], int.Parse(doughInp[3]));
                Pizza pizza = new Pizza(pizzaName, dough);

                string toppingInput;
                while ((toppingInput = Console.ReadLine()) != "END")
                {
                    string[] toppingData = toppingInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    Topping topping = new Topping(toppingData[1], int.Parse(toppingData[2]));
                    pizza.AddTopping(topping);
                }
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}