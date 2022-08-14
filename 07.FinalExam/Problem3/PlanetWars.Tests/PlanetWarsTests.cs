using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
           [Test]
           public void PlanetNameWithNullOrEmptyShouldThrowException()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var planet = new Planet(null, 100);
                }, "Invalid planet Name");

                Assert.Throws<ArgumentException>(() =>
                {
                    var planet = new Planet(String.Empty, 100);
                }, "Invalid planet Name");
            }
            [Test]
            public void VlidPlanetNameShouldWorkCorrectly()
            {
                var planet = new Planet("Test", 100);
                Assert.That(planet.Name, Is.EqualTo("Test"));
            }
            [Test]
            public void BudgetBelowZeroShouldThrowException()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var planet = new Planet("Test", -1);
                }, "Budget cannot drop below Zero!");               
            }
            

            [Test]
            public void SpeedinFundWithAmountGreaterThanTheBudgetShoulThrowException()
            {
                var planet = new Planet("Test", 5);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(6);
                }, "Not enough funds to finalize the deal.");
            }
            [Test]
            public void SpeedingFundsWithCorrectValueShouldWorkProperly()
            {
                var planet = new Planet("Test", 5);
                planet.SpendFunds(4);
                Assert.That(planet.Budget, Is.EqualTo(1));
            }
            [Test]
            public void AddingAWeponWithExistiongNameShouldThrowException()
            {
                var planet = new Planet("Test", 5);
                planet.AddWeapon(new Weapon("TestWeapon", 5, 5));
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(new Weapon("TestWeapon", 4, 4));
                }, "There is already a TestWeapon weapon.");
            }
            [Test]
            public void RemoveWeaponMethodShouldWorkCorrectly()
            {
                var planet = new Planet("Test", 5);
                planet.AddWeapon(new Weapon("TestWeapon", 5, 5));
                planet.RemoveWeapon("TestWeapon");
                Assert.That(planet.Weapons.Count == 0);
            }
            [Test]
            public void AddWeaponMethodShouldWorkCorrectly()
            {
                var planet = new Planet("Test", 5);
                Assert.That(planet.Weapons.Count == 0);
                planet.AddWeapon(new Weapon("TestWeapon", 5, 5));
                Assert.That(planet.Weapons.Count == 1);
            }

            [Test]
            public void UpgradingWeaponThatDoesNotExistShouldThrowException()
            {
                var planet = new Planet("Test", 5);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("WeaponName");
                }, "WeaponName does not exist in the weapon repository of Test");
            }
            [Test]
            public void UpgradingExistiongWeaponShouldWorkPoroperly()
            {
                var planet = new Planet("Test", 5);
                var weapon = new Weapon("Name", 100, 5);
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon("Name");
                Assert.That(weapon.DestructionLevel, Is.EqualTo(6));               
            }
            [Test]
            public void DestructingPlanetWithBiggerOrEqualMilitaryPowerRatioShouldThrowException()
            {
                var planet1 = new Planet("Name1", 5);
                var planet2 = new Planet("Name2", 5);
                planet1.AddWeapon(new Weapon("weaponName1", 5, 5));
                planet2.AddWeapon(new Weapon("weaponName2", 6, 6));
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet1.DestructOpponent(planet2);
                }, "Name2 is too strong to declare war to!");
                var planet3=new Planet("Name3",5);
                planet3.AddWeapon(new Weapon("weaponName3", 5, 5));
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet1.DestructOpponent(planet3);
                }, "Name3 is too strong to declare war to!");
            }
            [Test]
            public void DestructingPlanetWithSmallerValuesOfMilitaryPowerRatioShouldWorkCorrectly()
            {
                var planet1 = new Planet("Name1", 5);
                var planet2 = new Planet("Name2", 5);
                planet1.AddWeapon(new Weapon("weaponName1", 5, 5));
                planet2.AddWeapon(new Weapon("weaponName2", 4, 4));
                var res = planet1.DestructOpponent(planet2);
                Assert.That(res, Is.EqualTo("Name2 is destructed!"));
            }
            [Test]
            public void CreatingWeaponWithANegativePriceShouldThrowException()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var weapon = new Weapon("Test", -1, 5);
                }, "Price cannot be negative.");
            }
            [Test]
            public void MilitaryPowerRatioPropertyShouldWorkCorrectly()
            {
                var planet = new Planet("Test", 5);
                planet.AddWeapon(new Weapon("Name", 100, 5));
                planet.AddWeapon(new Weapon("Name2", 100, 5));
                planet.AddWeapon(new Weapon("Name3", 100, 5));
                Assert.That(planet.MilitaryPowerRatio, Is.EqualTo(15));
            }
            [Test]
            public void ProfitMethodShouldWorkCorrectly()
            {
                var planet = new Planet("Test", 5);
                planet.Profit(5);
                Assert.That(planet.Budget, Is.EqualTo(10));
            }
            [Test]
            public void IncreasingDestructionLevelMethodShouldWorkProperly()
            {
                var weapon = new Weapon("Test", 100, 5);
                weapon.IncreaseDestructionLevel();
                Assert.That(weapon.DestructionLevel, Is.EqualTo(6));
            }
            [Test]
            public void IsNuclearWeaponPropertyShouldWorkCorrectly()
            {
                var weapon = new Weapon("Name", 5, 1);
                var weapon2 = new Weapon("Name", 5, 10);
                var weapon3 = new Weapon("Name", 5, 11);

                Assert.That(weapon.IsNuclear, Is.EqualTo(false));
                Assert.That(weapon2.IsNuclear, Is.EqualTo(true));
                Assert.That(weapon3.IsNuclear, Is.EqualTo(true));
            }
        }
    }
}
