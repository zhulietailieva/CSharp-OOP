using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;
        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (heroes.FindByName(heroName) == null) throw new InvalidOperationException($"Hero { heroName} does not exist.");
            if (weapons.FindByName(weaponName) == null) throw new InvalidOperationException($"Weapon {weaponName } does not exist.");
            if (heroes.FindByName(heroName).Weapon != null) throw new InvalidOperationException($"Hero {heroName } is well-armed.");
            heroes.FindByName(heroName).AddWeapon(weapons.FindByName(weaponName));
            var currWeapon = weapons.FindByName(weaponName);
            weapons.Remove(weapons.FindByName(weaponName));
            return $"Hero {heroName} can participate in battle using a { currWeapon.GetType().Name.ToLower() }.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (type == typeof(Barbarian).Name)
            {
                Barbarian barbarian = new Barbarian(name, health, armour);
                if (heroes.FindByName(name) != null)
                {
                    throw new InvalidOperationException($"The hero { name } already exists.");
                }
                heroes.Add(barbarian);
                return $"Successfully added Barbarian { name } to the collection.";
            }
            else if (type == typeof(Knight).Name)
            {
                Knight knight = new Knight(name, health, armour);
                if (heroes.FindByName(name) != null)
                {
                    throw new InvalidOperationException($"The hero { name } already exists.");
                }
                heroes.Add(knight);
                return $"Successfully added Sir { name } to the collection.";
            }
            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
          if(type== "Claymore")
            {
                Claymore claymore = new Claymore(name, durability);
                if (weapons.FindByName(name) != null)
                {
                    throw new InvalidOperationException($"The weapon { name } already exists.");
                }
                weapons.Add(claymore);          
                return $"A { type.ToLower() } {  name } is added to the collection.";
               

            }
          else if (type == "Mace")
            {
                Mace mace = new Mace(name, durability);
                if (weapons.FindByName(name) != null)
                {
                    throw new InvalidOperationException($"The weapon { name } already exists.");
                }
                weapons.Add(mace);
                return $"A { type.ToLower() } {  name } is added to the collection.";
            }
            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }
        }

        public string HeroReport()
        {
            StringBuilder res = new StringBuilder();
            var orderedHeroes = heroes.Models.OrderBy(h => h.Name).ThenByDescending(h => h.Health).ThenBy(h => h.Name);
            foreach (var hero in orderedHeroes)
            {
                res.AppendLine($"{ hero.GetType().Name }: { hero.Name }");
                res.AppendLine($"--Health: {hero.Health }");
                res.AppendLine($"--Armour: { hero.Armour }");
                if (hero.Weapon == null) res.AppendLine("--Weapon: Unarmed");
                else res.AppendLine($"--Weapon: { hero.Weapon.Name }");
            }
            return res.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            var map = new Map();
            var heroesReadyForBattle = this.heroes.Models
                .Where(h => h.IsAlive && h.Weapon != null).ToList();
            return map.Fight(heroesReadyForBattle);
        }
    }
}
