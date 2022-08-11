using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void CapacityLessThanZeroShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                //Arrange and Act
                var shop = new Shop(-1);
            },
            //Assert
            "Invalid capacity."
            );
        }
        [Test]
        public void CapacitySetterShouldWorkProperlyWithCorrectValues()
        {
            //Arrange
            const int CAPACITY = 10;
            //Act
            var shop = new Shop(CAPACITY);
            //Assert
            Assert.That(shop.Capacity, Is.EqualTo(CAPACITY));
        }
        [Test]
        public void WhenAddingTwoPhonesWithTheSameNameTheProgramShouldThrowException()
        {
            const string TEST_NAME = "Test";
            //Arrange
            var shop = new Shop(3);
            Smartphone phone1 = new Smartphone(TEST_NAME, 10);
            shop.Add(phone1);
            //Act
            var phone2 = new Smartphone(TEST_NAME, 10);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(phone2);
            },
            //Assert
            $"The phone model {TEST_NAME} already exist."
            );
        }
        [Test]
        public void AddingPhoneWhenTheShopIsFullShouldThrowException()
        {
            //Arrange
            var shop = new Shop(1);
            //Act
            shop.Add(new Smartphone("Test", 10));
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("Test2", 10));
            },
            //Assert
           "The shop is full."
            );
        }
        [Test]
        public void AddingACorrectPhonePhoneShouldWorkProperly()
        {
            //Assert
            var shop = new Shop(3);
            Smartphone smartphone = new Smartphone("Test", 10);
            //Act
            shop.Add(smartphone);
            //Assert
            Assert.That(shop.Count == 1);
        }
        [Test]
        public void RemovingPhoneThatDoesNotExistShouldThrowException()
        {
            //Arrange
            var shop = new Shop(5);
            //Act 
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("Test");
            },
            //Assert
            "The phone model Test doesn't exist."
            );
        }
        [Test]
        public void TestingPhoneThatDoesNotExistShouldThrowException()
        {
            //Arrange
            var shop = new Shop(10);
            //Act
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Test", 5);
            },
            //Assert
            "The phone model Test doesn't exist.");
        }  
        [Test]
        public void TestingPhoneWithLittleBatteryShouldThrowException()
        {
            //Arrange
            var shop = new Shop(5);
            var smartphone = new Smartphone("Test", 10);
            smartphone.CurrentBateryCharge = 5;
           
            shop.Add(smartphone);
            //Act
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Test", 6);
            },
            //Assert
            $"The phone model {smartphone.ModelName} is low on batery."
            );               
        }
        [Test]
        public void TestingPhoneWithEnoughBatterySHouldWorkProperly()
        {
            //Arrange
            var shop = new Shop(5);
            var smartphone = new Smartphone("Test", 10);
            smartphone.CurrentBateryCharge = 5;

            shop.Add(smartphone);
            //Act
            
                shop.TestPhone("Test", 4);

            //Assert
            Assert.That(smartphone.CurrentBateryCharge == 1);
        }
        [Test]
        public void ChargingPhoneThatDoesntExistShouldThrowException()
        {
            //Arrange
            var shop = new Shop(10);
            //Act
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("Test");
            },
            //Assert
            "The phone model Test doesn't exist."
            );
        }
        [Test]
        public void ChargingAnExistingPhoneShouldWorkProperly()
        {
            //Arrange
            var shop = new Shop(10);
            var smartphone = new Smartphone("Test", 5);
            smartphone.CurrentBateryCharge = 1;
            shop.Add(smartphone);
            //Act
            
                shop.ChargePhone("Test");

            //Assert
            Assert.That(smartphone.CurrentBateryCharge == smartphone.MaximumBatteryCharge);
        }
    }
}