using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public Mission() { }
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts.Where(x=>x.CanBreath))
            {
                while (planet.Items.Count > 0)
                {
                    var currItem = planet.Items.ElementAt(0);
                    astronaut.Bag.Items.Add(currItem);
                    planet.Items.Remove(currItem);
                    astronaut.Breath();
                    if (!astronaut.CanBreath) break;
                }
           }
        }
    }
}
