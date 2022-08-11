using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
           [Test]
           public void GarageNameWithNullOrEmptyNameShouldThrowException()
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    //Arrange and Act
                    var garage = new Garage(null, 10);
                }, 
                //Assert
                "Invalid garage name."
                );
                Assert.Throws<ArgumentNullException>(() =>
                {
                    //Arrange and Act
                    var garage = new Garage(String.Empty, 10);
                },
                //Assert
                "Invalid garage name."
                );
            }
            [Test]
            public void GarageNamePropertyShouldWorkCorrectly()
            {
                //Arrange
                const string GARAGE_NAME = "Test";
                //Act
                var garage = new Garage(GARAGE_NAME, 10);
                //Assert
                Assert.That(garage.Name, Is.EqualTo(GARAGE_NAME));
            }
            [Test]
            public void GaragwWithLessOrEqualTo0MechanicsShouldThrowException()
            {
                //Arrange and Act
                Assert.Throws<ArgumentException>(() =>
                {
                    var garage = new Garage("Test", 0);
                },
                //Assert
                "At least one mechanic must work in the garage."
                );
                //Arrange and Act
                Assert.Throws<ArgumentException>(() =>
                {
                    var garage = new Garage("Test", -1);
                },
                //Assert
                "At least one mechanic must work in the garage."
                );
            }
            [Test]
            public void GarageMechanicsPropertyShouldWorkCorrectly()
            {
                //Arrange
                const int MECHANICS = 5;
                //Act
                var garage = new Garage("Test", MECHANICS);
                //Assert
                Assert.That(garage.MechanicsAvailable, Is.EqualTo(MECHANICS));

            }
        }
    }
}