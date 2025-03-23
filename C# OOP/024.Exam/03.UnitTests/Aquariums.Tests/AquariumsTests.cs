namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;

    public class AquariumsTests
    {
        Aquarium aquariumTest;

        [SetUp]
        public void StartUp()
        {
            aquariumTest = new Aquarium("JustName", 4);
        }

        [Test]
        public void AquariumConstructor_ShouldSetCorrectParameters()
        {
            Type type = typeof(Aquarium);
            ConstructorInfo constructorInfo = type.GetConstructor(new Type[] { typeof(string), typeof(int) });

            ParameterInfo[] parameters = constructorInfo.GetParameters();

            Assert.That(parameters[0].ParameterType, Is.EqualTo(typeof(string)));
            Assert.That(parameters[1].ParameterType, Is.EqualTo(typeof(int)));
        }

        [Test]
        public void AquariumConstructor_ShouldSetCorrectData()
        {
            string aquariumName = "JustName";
            int aquariumCapacity = 12;
            Aquarium aquarium = new Aquarium(aquariumName, aquariumCapacity);

            Assert.That(aquariumName, Is.EqualTo(aquarium.Name));
            Assert.That(aquariumCapacity, Is.EqualTo(aquarium.Capacity));
        }

        [Test]
        public void AquariumPropertyNameShouldThrowsException()
        {
            string aquariumName = null;
            int aquariumCapacity = 12;

            Assert.Throws<ArgumentNullException>(() => 
                 new Aquarium(aquariumName, aquariumCapacity));

            aquariumName = "";

            Assert.Throws<ArgumentNullException>(() =>
            new Aquarium(aquariumName, aquariumCapacity));
        }

        [Test]
        public void AquariumPropertyCapacityShouldThrowsException()
        {
            string aquariumName = "JustName";
            int aquariumCapacity = -1;

            Assert.Throws<ArgumentException>(() =>
                 new Aquarium(aquariumName, aquariumCapacity));

            aquariumCapacity = -312;

            Assert.Throws<ArgumentException>(() =>
            new Aquarium(aquariumName, aquariumCapacity));
        }

        public void AquariumPropertyCount_ShouldReturnCountOfFish()
        {
            Assert.That(this.aquariumTest.Count, Is.EqualTo(0));

            this.aquariumTest.Add(new Fish("1"));
            this.aquariumTest.Add(new Fish("3"));

            Assert.That(this.aquariumTest.Count, Is.EqualTo(2));

        }

        [Test]
        public void AquariumAddMethod_ShouldThrowException_WhenCapacityIsFull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 40; i++)
                {
                    Fish fish = new Fish($"{i}");
                    this.aquariumTest.Add(fish);
                }
            });
        }

        [Test]
        public void AquariumAddMethod_ShouldAddFish()
        {
            for (int i = 1; i <= 3; i++)
            {
                Fish fish = new Fish($"{i}");
                this.aquariumTest.Add(fish);
            }

            Assert.That(aquariumTest.Count, Is.EqualTo(3));
        }


        [Test]
        public void AquariumRemoveMethod_ShouldThrowsException_WhenIsNull()
        {
            for (int i = 1; i <= 3; i++)
            {
                Fish fish = new Fish($"Fish{i}");
                this.aquariumTest.Add(fish);
            }

            Assert.Throws<InvalidOperationException>(() => this.aquariumTest.RemoveFish("132"));
        }

        [Test]
        public void AquariumRemoveMethod_ShouldRemoveFish()
        {
            for (int i = 1; i <= 3; i++)
            {
                Fish fish = new Fish($"Fish{i}");
                this.aquariumTest.Add(fish);
            }

            this.aquariumTest.RemoveFish("Fish1");
            this.aquariumTest.RemoveFish("Fish2");

            Assert.That(this.aquariumTest.Count, Is.EqualTo(1));
        }

        [Test]
        public void AquariumSellFish_ShoudlThrowsExceptionWhenFishIsNull()
        {
            for (int i = 1; i <= 3; i++)
            {
                Fish fish = new Fish($"Fish{i}");
                this.aquariumTest.Add(fish);
            }

            Assert.Throws<InvalidOperationException>(() => this.aquariumTest.SellFish("NoName"));
        }

        [Test]
        public void AquariumSellFish_ShoudlThrowsExceptionWhenFishIsNotExist()
        {
            for (int i = 1; i <= 3; i++)
            {
                Fish fish = new Fish($"Fish{i}");
                this.aquariumTest.Add(fish);
            }

            Assert.Throws<InvalidOperationException>(() => this.aquariumTest.SellFish("NoName"));
        }

        [Test]
        public void AquariumSellFish_ShouldSellFish()
        {
            Fish specialFish = new Fish("SpecialFish");
            for (int i = 1; i <= 2; i++)
            {
                Fish fish = new Fish($"Fish{i}");
                this.aquariumTest.Add(fish);
            }

            this.aquariumTest.Add(specialFish);
            Fish currentFish = this.aquariumTest.SellFish("SpecialFish");

            Assert.That(currentFish, Is.EqualTo(specialFish));
            Assert.That(currentFish.Available, Is.EqualTo(false));
        }

        [Test]
        public void AquariumReportMethodShouldReturnString()
        {
            for (int i = 1; i <= 2; i++)
            {
                Fish fish = new Fish($"Fish{i}");
                this.aquariumTest.Add(fish);
            }

            string fishNames = "Fish1, Fish2";
            string expectedResult = $"Fish available at {this.aquariumTest.Name}: {fishNames}";

            string actualResult = this.aquariumTest.Report();

            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }
    }
}
