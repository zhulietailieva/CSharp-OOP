using System;
using System.Collections.Generic;

namespace _03.Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
               
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                switch (type)
                {
                    case "Druid": heroes.Add(new Druid(name));
                        break;
                    case "Paladin":heroes.Add(new Paladin(name));
                        break;
                    case "Rogue":heroes.Add(new Rogue(name));
                        break;
                    case "Warrior":heroes.Add(new Warrior(name));
                        break;
                    default: Console.WriteLine("Invalid hero!");
                        break;
                }
            }
            double bossPower = double.Parse(Console.ReadLine());
            int totalHeroPower = 0;
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility()); 
                totalHeroPower += hero.Power;
            }
            if (totalHeroPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }
    }
}
