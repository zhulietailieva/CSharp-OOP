using System;

namespace _04.SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split(" ");
            int sumOfIntegers = 0;

            for (int i = 0; i < elements.Length; i++)
            {
                string element = elements[i];
                try
                {
                    int currElement = int.Parse(element);
                    sumOfIntegers += currElement;                   
                }
                catch (FormatException)
                {

                    Console.WriteLine($"The element '{elements[i]}' is in wrong format!");
                }
                catch(OverflowException)
                {
                    Console.WriteLine($"The element '{elements[i]}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{element}' processed - current sum: {sumOfIntegers}");
                }
            }
            Console.WriteLine($"The total sum of all integers is: {sumOfIntegers}");
        }
    }
}
