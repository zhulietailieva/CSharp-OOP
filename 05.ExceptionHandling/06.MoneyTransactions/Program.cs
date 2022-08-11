using System;
using System.Collections.Generic;

namespace _06.MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] accountsInfo = Console.ReadLine().Split(",");
            Dictionary<string, decimal> accounts = new Dictionary<string, decimal>();

            foreach (var account in accountsInfo)
            {
                string[] accountData = account.Split("-");
                string accountNumber = accountData[0];
                decimal accountBalance =decimal.Parse( accountData[1]);
                accounts.Add(accountNumber, accountBalance);
            }
            string inp;
            while ((inp = Console.ReadLine()) != "End")
            {
                string[] cmndArgs = inp.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = cmndArgs[0];
                try
                {
                    string accountNumber = cmndArgs[1];
                    decimal sum = decimal.Parse(cmndArgs[2]);
                    switch (command)
                    {
                        case "Deposit":
                            if (!accounts.ContainsKey(accountNumber)) throw new ArgumentException("Invalid account!");
                            accounts[accountNumber] += sum;
                            Console.WriteLine($"Account {accountNumber} has new balance: {(accounts[accountNumber]):f2}");
                            break;
                        case "Withdraw":
                            if (!accounts.ContainsKey(accountNumber)) throw new ArgumentException("Invalid account!");
                            if (sum > accounts[accountNumber]) throw new ArgumentException("Insufficient balance!");
                            accounts[accountNumber] -= sum;
                            Console.WriteLine($"Account {accountNumber} has new balance: {(accounts[accountNumber]):f2}");
                            break;
                        default: throw new ArgumentException("Invalid command!");                           
                    }
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                finally  {Console.WriteLine("Enter another command"); }               
            }
        }
    }
}
