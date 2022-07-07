using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class Smartphone : IBrowsable, ICallable
    {

        public Smartphone(){}
        
        public string Browse(string url)
        {
            char[] symbols = url.ToCharArray();
            for (int i = 0; i < symbols.Length; i++)
            {
                if (char.IsDigit(symbols[i])) return "Invalid URL!";
            }
            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            char[] symbols = number.ToCharArray();
            for (int i = 0; i < symbols.Length; i++)
            {
                if (!char.IsDigit(symbols[i])) return "Invalid number!";
            }
            return $"Calling... {number}";
        }
    }
}
