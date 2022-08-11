using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;
        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (pilotRepository.FindByName(pilotName) == null ||
                pilotRepository.FindByName(pilotName).Car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            if (carRepository.FindByName(carModel) == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }
            var car = carRepository.FindByName(carModel);
            pilotRepository.FindByName(pilotName).AddCar(car);
            carRepository.Remove(car);
            return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            if (raceRepository.FindByName(raceName) == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if(pilotRepository.FindByName(pilotFullName)==null||
                !pilotRepository.FindByName(pilotFullName).CanRace||
              raceRepository.FindByName(raceName).Pilots.Any(p => p.FullName == pilotFullName)){
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            var pilot = pilotRepository.FindByName(pilotFullName);
            raceRepository.FindByName(raceName).AddPilot(pilot);
            return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }
            if (type != typeof(Ferrari).Name && type != typeof(Williams).Name)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            //create the car
            IFormulaOneCar car;
            if (type == typeof(Ferrari).Name)
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            carRepository.Add(car);
            return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) != null)
            {
                //such pilot already exists
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            pilotRepository.Add(new Pilot(fullName));
            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            raceRepository.Add(new Race(raceName, numberOfLaps));
            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            var sortedPilots = pilotRepository.Models.OrderByDescending(p => p.NumberOfWins);
            StringBuilder res = new StringBuilder(string.Empty);
            foreach (var pilot in sortedPilots)
            {
                res.AppendLine($"Pilot {pilot.FullName } has { pilot.NumberOfWins} wins.");
            }
            return res.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder res = new StringBuilder(string.Empty);
            
            foreach (var race in raceRepository.Models)
            {
               //Console.WriteLine(race.TookPlace);
                if (race.TookPlace)
                {
                    res.AppendLine(race.RaceInfo());
                }
            }
            return res.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            if (raceRepository.FindByName(raceName) == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            var race = raceRepository.FindByName(raceName);
            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if (race.TookPlace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }
            //valid race
            race.TookPlace = true;
            var sorted = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();           
            StringBuilder res = new StringBuilder();
            res.AppendLine($"Pilot { sorted[0].FullName } wins the { raceName } race.");
            res.AppendLine($"Pilot {sorted[1].FullName} is second in the { raceName } race.");
            res.AppendLine($"Pilot { sorted[2].FullName } is third in the { raceName } race.");
            return res.ToString().TrimEnd();
        }
    }
}
