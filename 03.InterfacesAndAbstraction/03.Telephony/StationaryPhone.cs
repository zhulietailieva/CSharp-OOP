using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    internal class StationaryPhone : ICallable
    {
        public StationaryPhone(){ }
        public string Call(string number)
        {
            char[] symbols = number.ToCharArray();
            for (int i = 0; i < symbols.Length; i++)
            {
                if (!char.IsDigit(symbols[i])) return "Invalid number!";
            }
            return $"Dialing... {number}";
        }
    }
}
