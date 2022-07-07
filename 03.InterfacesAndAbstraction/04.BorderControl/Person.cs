using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Person : IIdentifiable
    {
        public Person(string name,int age,string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
    }
}
