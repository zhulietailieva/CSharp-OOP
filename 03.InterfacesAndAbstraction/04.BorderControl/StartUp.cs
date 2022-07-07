using System;
using System.Collections.Generic;

namespace _04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            List<IIdentifiable> identifiables = new List<IIdentifiable>();
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inpData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (inpData.Length == 2)
                {
                    //robot
                    identifiables.Add(new Robot(inpData[0], inpData[1]));
                }
                else if (inpData.Length == 3)
                {
                    //person
                    identifiables.Add(new Person(inpData[0], int.Parse(inpData[1]), inpData[2]));
                }
            }
            string lastDigitsOfFakeIDs = Console.ReadLine();
            foreach (var identifiable in identifiables)
            {
                if (identifiable.Id.EndsWith(lastDigitsOfFakeIDs)) Console.WriteLine(identifiable.Id);
            }
        }
    }
}
