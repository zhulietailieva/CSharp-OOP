using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations
{
    public class Person : IIdentifiable,IBirthable
    {
        public Person(string name,int age,string id,string bithdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = bithdate;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }
       
    }
}
