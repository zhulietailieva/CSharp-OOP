using System;
using System.Collections.Generic;

namespace _05.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            List<IBirthable> birthables = new List<IBirthable>();
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inpData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (inpData[0])
                {
                    case "Citizen":birthables.Add(new Person(inpData[1],int.Parse(inpData[2]),inpData[3],inpData[4])); break;
                    case "Pet":birthables.Add(new Pet(inpData[1], inpData[2])); break;
                    default: break;
                }
            }
            string year = Console.ReadLine();
            foreach (var birthable in birthables)
            {
                if (birthable.Birthdate.EndsWith(year)) Console.WriteLine(birthable.Birthdate);
            }
        }
    }
}
