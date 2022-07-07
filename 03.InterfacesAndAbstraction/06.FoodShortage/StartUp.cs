using System;
using System.Collections.Generic;

namespace _06.FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();
            int numOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfLines; i++)
            {
                string[] inpData = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (inpData.Length == 3)
                {
                    //rebel
                    buyers.Add(new Rebel(inpData[0], int.Parse(inpData[1]), inpData[2]));

                }
                else if (inpData.Length == 4)
                {
                    //citizen
                    buyers.Add(new Person(inpData[0], int.Parse(inpData[1]), inpData[2], inpData[3]));
                }
            }
            string nameInp;
            int totalFood = 0;
            while ((nameInp = Console.ReadLine()) != "End")
            {
                foreach (var buyer in buyers)
                {
                    if (buyer.Name == nameInp)
                    {
                        totalFood += buyer.BuyFood();
                    }
                }
            }
            Console.WriteLine(totalFood);
        }
    }
}
