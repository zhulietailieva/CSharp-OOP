using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
    public class Person : IIdentifiable,IBirthable,IBuyer
    {
        public Person(string name,int age,string id,string bithdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = bithdate;
            this.Food = 0;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }
        public int Food { get; set; }

        public int BuyFood()
        {
            Food += 10;
            return 10;
        }
    }
}
