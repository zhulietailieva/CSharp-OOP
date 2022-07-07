using System;

namespace _03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] sites= Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();
            foreach (var number in numbers)
            {
                if (number.Length == 7)
                {
                    Console.WriteLine(stationaryPhone.Call(number));  
                }
                else if(number.Length==10)
                {
                    Console.WriteLine(smartphone.Call(number));  
                }
            }
            foreach (var url in sites)
            {
                Console.WriteLine(   smartphone.Browse(url)); 
            }
        }
    }
}
