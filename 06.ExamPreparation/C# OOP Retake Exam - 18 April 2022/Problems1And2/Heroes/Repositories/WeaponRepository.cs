using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        public WeaponRepository()
        {
            weapons = new Dictionary<string, IWeapon>();
        }
        private readonly Dictionary<string, IWeapon> weapons;
       
        public IReadOnlyCollection<IWeapon> Models => weapons.Values;
        public void Add(IWeapon model) => weapons.Add(model.Name, model);
        public IWeapon FindByName(string name)
        {
            
            if (weapons.ContainsKey(name))
            {
                return weapons[name];
            }
            return null;
        }

        public bool Remove(IWeapon model)
        {
            if (weapons.ContainsKey(model.Name))
            {
                weapons.Remove(model.Name);
                return true;
            }
            return false;
        }
    }
}
