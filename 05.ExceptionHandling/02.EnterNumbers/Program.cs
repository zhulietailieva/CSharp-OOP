using System;
using System.Collections.Generic;

namespace _02.EnterNumbers
{
    internal class Program
    {
        
        static void Main(string[] args)
        { 
            List<int> numbers = new List<int>();
            try 
	        {	        	   
            while (numbers.Count < 10)
                {
                    string line = Console.ReadLine() ;
                   
                    int number;
                    bool success = int.TryParse(line, out number);
                    if (!success) throw new FormatException("Invalid Number!");
                    if (numbers.Count == 0)
                    {
                        numbers.Add(number);
                        continue;
                    }
                    numbers.Sort();
                    int minNumber = numbers[0];
                    if (number < minNumber || number >= 100)
                        throw new ArgumentException($"Your number is not in range {minNumber} - 100!");
                    numbers.Add(number);

                }
	        }
	        catch (FormatException ex)
	            {

                Console.WriteLine(ex.Message);
	            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
       
        
    }
}
