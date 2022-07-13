using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            int exceptionCount = 0;
            while (exceptionCount < 3)
            {
                string[] inp = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string command = inp[0];
                switch (command)
                {
                    case "Replace":
                        
                        try
                        {
                            int index = int.Parse(inp[1]);
                            int element = int.Parse(inp[2]);
                            numbers[index] = element;
                        }
                        
                        catch (FormatException)
                        {                            
                            Console.WriteLine("The variable is not in the correct format!");
                            exceptionCount++;
                        }
                        catch (ArgumentException)
                        {

                            Console.WriteLine("The index does not exist!");
                            exceptionCount++;
                        }
                        break;
                    case "Print":
                        try
                        {
                            int startIndex = int.Parse(inp[1]);
                            int endIndex = int.Parse(inp[2]);
                            List<int> numberInRange = new List<int>();

                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                numberInRange.Add(numbers[i]);
                            }
                            Console.WriteLine(String.Join(", ",numberInRange));
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("The variable is not in the correct format!");
                            exceptionCount++;
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("The index does not exist!");
                            exceptionCount++;
                        }                       
                        break;
                    case "Show":
                        try
                        {
                            int showIndex = int.Parse(inp[1]);
                            Console.WriteLine(numbers[showIndex]);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("The variable is not in the correct format!");
                            exceptionCount++;
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("The index does not exist!");
                            exceptionCount++;
                        }                      
                        break;
                }
            }
            Console.WriteLine(String.Join(", ",numbers));
        }
    }
}
