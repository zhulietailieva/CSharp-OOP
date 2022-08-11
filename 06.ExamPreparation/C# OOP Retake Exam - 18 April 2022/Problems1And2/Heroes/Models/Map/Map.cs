using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            string result = string.Empty;
            List<Barbarian> barbarians = new List<Barbarian>();
            List<Knight> knights = new List<Knight>();
            foreach(IHero player in players)
            {
                if (player.GetType()==typeof(Barbarian)) barbarians.Add((Barbarian)player);
                else if (player.GetType() == typeof(Knight)) knights.Add((Knight)player);
            }
            int deadKnights = 0;
            int deadBarbarians = 0;
           
            while (true)
            {
                bool areAllKnightsDead = true;
                bool areAllBarbariansDead = true;
                //knights attack
                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        areAllKnightsDead = false;
                        
                       //Console.WriteLine("knight's durability: "+knight.Weapon.Durability);
                       //Console.WriteLine("knight's name: " + knight.Name);
                       //Console.WriteLine("knight's weapon: " + knight.Weapon.Name);
                        var weaponDamage = knight.Weapon.DoDamage();
                        foreach (var barbarian in barbarians)
                        {
                            if (barbarian.IsAlive)
                            {
                                barbarian.TakeDamage(weaponDamage);
                                if (!barbarian.IsAlive) deadBarbarians++;
                            }
                        }
                    }
                }
                //barbarians attack
                foreach (var barbarian  in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        areAllBarbariansDead = false;
                        var weaponDamage = barbarian.Weapon.DoDamage();
                        foreach(var knight in knights)
                        {
                            if (knight.IsAlive)
                            {
                                knight.TakeDamage(weaponDamage);
                                if (!knight.IsAlive) deadKnights++;
                            }
                        }
                    }
                }
                if (areAllKnightsDead)
                {
                    result = $"The barbarians took {deadBarbarians} casualties but won the battle.";
                    break;
                }
                else if (areAllBarbariansDead)
                {
                    result = $"The knights took {deadKnights} casualties but won the battle.";
                    break;
                }
            }
            return result;
        }
    }
}
