namespace Presents.Tests
{
    using NUnit.Framework;
    using Presents;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class PresentsTests
    {
        Present present;
        Bag bag;
        [SetUp]
        public void SetUp()
        {
            string originalPresentName = "Present";
            double originalPresentMagic = 200;
            present = new Present(originalPresentName, originalPresentMagic);

            bag = new Bag();
        }

        [Test]
        public void BagMethodCreate_ShouldThrowException_WhenPresentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.bag.Create(null));

            Present newBag = null;

            Assert.Throws<ArgumentNullException>(() => this.bag.Create(newBag));
        }

        [Test]
        public void BagMethodCreate_ShouldThrowException_WhenAlreadyExistPresent()
        {
            this.bag.Create(this.present);

            Assert.Throws<InvalidOperationException>(() => this.bag.Create(this.present));
        }

        [Test]
        public void BagMethodCreate_ShouldAddPresent()
        {
            string expected = $"Successfully added present {this.present.Name}.";

            string actualResult = this.bag.Create(this.present);

            Assert.AreEqual(expected, actualResult);

            IReadOnlyCollection<Present> presents = this.bag.GetPresents();

            Assert.That(presents.Count, Is.EqualTo(1));

        }

        [Test]
        public void BagMethodRemove_ShouldReturnFalse_WhenPresentIsNotExist()
        {
            this.bag.Create(this.present);

            Present newPresent = new Present("FakePresent", 100);

            bool expectedResult = false;
            bool actualResult = this.bag.Remove(newPresent);

            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void BagMethodRemove_ShouldReturnTrue_WhenPresentExist()
        {
            this.bag.Create(this.present);

            bool expectedResult = true;
            bool actualResult = this.bag.Remove(this.present);

            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void BagMethodGetPresent_ShouldReturnPresent()
        {
            this.bag.Create(this.present);

            Present currentPresent = this.bag.GetPresent("Present");

            Assert.That(currentPresent, Is.EqualTo(this.present));
        }

        [Test]
        public void BagMethodGetPresent_ShouldReturnNull()
        {
            this.bag.Create(this.present);

            Present currentPresent = this.bag.GetPresent("NoExist");

            Assert.That(currentPresent, Is.EqualTo(null));
        }


        [Test]
        public void BagGetPresentWithLeastMagic_ShouldReturPresent()
        {
            this.bag.Create(this.present);

            Present firstNewPresent = new Present("FirstPresent", 100);
            this.bag.Create(firstNewPresent);
            Present secondNewPresent = new Present("SecondPresent", 50);
            this.bag.Create(secondNewPresent);

            Present expectedPresentResult = secondNewPresent;

            Assert.That(expectedPresentResult, Is.EqualTo(this.bag.GetPresentWithLeastMagic()));
        }

        [Test]
        public void BagMethodGetPresents_ShouldReturnIReadOnlyCollection()
        {
            this.bag.Create(this.present);

            Present firstNewPresent = new Present("FirstPresent", 100);
            this.bag.Create(firstNewPresent);
            Present secondNewPresent = new Present("SecondPresent", 50);
            this.bag.Create(secondNewPresent);

            IReadOnlyCollection<Present> expectedPresent = new List<Present>() 
                                                        { this.present, firstNewPresent, secondNewPresent};

            IReadOnlyCollection<Present> actualPresent = this.bag.GetPresents();


            //Is.EqualTo(expectedPresent.GetType())
            Assert.That(expectedPresent, Is.EquivalentTo(actualPresent));
            Assert.That(actualPresent.GetType().Name, Is.EqualTo("ReadOnlyCollection`1"));
        }

        [Test]
        public void GetAllBagField()
        {
            Type type = typeof(Bag);

            FieldInfo[] fields = type.GetFields();

            foreach (FieldInfo field in fields)
            {
                if (field.GetType() == typeof(List))
                {
                    Assert.That(field.GetType(), Is.EqualTo(typeof(List)));
                }
            }

            ConstructorInfo[] constructors = type.GetConstructors();

            foreach (var constructor in constructors)
            {
                ParameterInfo[] parameters = constructor.GetParameters();
                Assert.That(parameters.Count(), Is.EqualTo(0));
            }

            Type currentBag = this.bag.GetType();

            FieldInfo[] fieldInfos = currentBag.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            Assert.That(fieldInfos[0].IsPrivate);
            Assert.That(fieldInfos[0] != null);
        }

        [Test]
        public void GetAllConstructorParametersFromPresentClass()
        {
            Type type = typeof(Present);

            ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

            ParameterInfo[] parameters = constructors[0].GetParameters();

            Assert.That(parameters[0].ParameterType, Is.EqualTo(typeof(string)));
            Assert.That(parameters[1].ParameterType, Is.EqualTo(typeof(double)));

            Present present = new Present("Present", 100);

            Type typePresent = present.GetType();

            PropertyInfo[] propertyInfos = typePresent.GetProperties();

            Assert.That(propertyInfos[0].GetValue(present), Is.EqualTo("Present"));
            Assert.That(propertyInfos[1].GetValue(present), Is.EqualTo(100));

            Assert.That(present.Name, Is.EqualTo("Present"));
            Assert.That(present.Magic, Is.EqualTo(100));


        }
    }
}
