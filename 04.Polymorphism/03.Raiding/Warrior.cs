using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string name) : base(name, 100)
        {
        }

        public override string CastAbility()
        {
            return $"Warrior - {this.Name} hit for {this.Power} damage";
        }
    }
}
