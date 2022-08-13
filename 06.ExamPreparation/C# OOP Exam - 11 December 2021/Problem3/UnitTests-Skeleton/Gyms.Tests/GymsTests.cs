using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        public void GymWithNullNameShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var gym = new Gym(string.Empty, 5);
            }, "Invalid gym name.");

            Assert.Throws<ArgumentNullException>(() =>
            {
                var gym = new Gym(null, 5);
            }, "Invalid gym name.");
        }
        [Test]
        public void GymWithCapacityLessThanZeroShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var gym = new Gym("Test", -1);
            }, "Invalid gym capacity.");
        }
        [Test]
        public void AddingAthletesWhenTHeGymIsFullShoulThrowException()
        {
            var gym = new Gym("Test", 1);
            gym.AddAthlete(new Athlete("TestAthlete"));
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(new Athlete("AnotherTestAthlete"));
            }, "The gym is full.");
        }
        [Test]
        public void RemovinAthleteThatDoesNotExistSHouldThrowException()
        {
            var gym = new Gym("Test", 1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Test");
            }, "The athlete Test doesn't exist.");
        }
        [Test]
        public void InjuringAthleteThatDoesNotExistSHouldThrowException()
        {
            var gym = new Gym("Test", 1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Test");
            }, "The athlete Test doesn't exist.");
        }
    }
}
