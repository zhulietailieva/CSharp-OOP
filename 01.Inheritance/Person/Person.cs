using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;
        public Person(string name,int age)
        {
       //     if (age <= 0) throw new Exception("People cannot have age under 0 years old.");
            this.name = name;
            this.age = age;

        }
        public string Name => this.name;
        public int Age => this.age;
        public override string ToString()
        {
            return $"Name: {name}, Age: {age}";

        }
    }
}
