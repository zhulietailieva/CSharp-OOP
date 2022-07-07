using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{


    public class Pet:IBirthable
    {
        public Pet(string name,string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
        public string Name { get; set; }
       
        public string Birthdate { get; set; }
    }
}
