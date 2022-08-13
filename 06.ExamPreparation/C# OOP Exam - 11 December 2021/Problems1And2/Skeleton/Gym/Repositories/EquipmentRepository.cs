using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly List<IEquipment> models;
        public EquipmentRepository()
        {
            this.models = new List<IEquipment>();
        }        
        public IReadOnlyCollection<IEquipment> Models => models;
        public void Add(IEquipment model) { models.Add(model); }
        public IEquipment FindByType(string type) { return models.FirstOrDefault(m => m.GetType().Name == type); }
        public bool Remove(IEquipment model) { return models.Remove(model); }
    }
}
