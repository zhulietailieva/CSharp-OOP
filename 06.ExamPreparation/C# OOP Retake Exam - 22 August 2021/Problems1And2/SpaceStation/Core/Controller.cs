using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private int exploredPlanets=0;
        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type == typeof(Biologist).Name)
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == typeof(Geodesist).Name)
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == typeof(Meteorologist).Name)
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }
            astronauts.Add(astronaut);
            return String.Format(OutputMessages.AstronautAdded, astronaut.GetType().Name, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            planets.Add(planet);
            return String.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            var suitableAstronauts = new List<IAstronaut>();
            foreach (var astronaut in this.astronauts.Models)
            {
                if (astronaut.Oxygen > 60) suitableAstronauts.Add(astronaut);
            }
            if (suitableAstronauts.Count == 0)
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            
            var planetToExplore = planets.FindByName(planetName);
            var mission = new Mission();
            mission.Explore(planetToExplore, suitableAstronauts);
            exploredPlanets++;
            var deadAstronauts = suitableAstronauts.Count(x => !(x.CanBreath));
            return String.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var astronaut in astronauts.Models)
            {
                string bagItems = astronaut.Bag.Items.Count == 0 
                    ? "none"
                    : string.Join(", ", astronaut.Bag.Items);
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.AppendLine($"Bag items: {bagItems}");
            }
            return sb.ToString().TrimEnd();
        }
        public string RetireAstronaut(string astronautName)
        {
            if (astronauts.FindByName(astronautName) == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, 
                    astronautName));
            astronauts.Remove(astronauts.FindByName(astronautName));
            return String.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}