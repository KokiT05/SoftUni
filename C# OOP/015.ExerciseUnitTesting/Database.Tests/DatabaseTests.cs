using NUnit.Framework;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        [SetUp]
        public void Setup()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            database = new Database.Database(array);
        }

        [Test]
        public void CapacityMustBeExactlySixteen()
        {
            Assert.True(this.database.Count == 16);

            Assert.Throws<InvalidOperationException>(() =>
            this.database = new Database.Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17));
        }

        [Test]
        public void AddMethodShouldAddElementAtTheNextFreeCell()
        {
            this.database = new Database.Database(1, 2, 3);
            this.database.Add(4);
            int[] array = this.database.Fetch();
            int[] expectedArray = new int[] { 1, 2, 3, 4 };

            Assert.AreEqual(array, expectedArray);
        }

        [Test]
        public void AddMethodCannotAddMoreThanSixteenIntegers()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.Add(1));
        }

        [Test]
        public void RemoveMethodShouldRemoveOnlyLastElement()
        {
            int[] expectedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            this.database.Remove();
            int[] arrayDatabase = this.database.Fetch();

            Assert.True(expectedArray[expectedArray.Length - 1] == arrayDatabase[arrayDatabase.Length - 1]);
        }

        [Test]
        public void RemoveMethodCannotElementFromEmptyCollection()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i <= 17; i++)
                {
                    this.database.Remove();
                }
            });
        }

        [Test]
        public void ConstructorsShouldTakeIntegersOnly()
        {
            Type type = this.database.GetType();

            ConstructorInfo constructorInfo = type
                .GetConstructor
                (BindingFlags.Public | BindingFlags.Instance, new Type[] { typeof(int[])});
            ParameterInfo[] parametersInfo = constructorInfo.GetParameters();
            ParameterInfo parameter = parametersInfo[0];

            Assert.That(parameter.ParameterType.Name, Is.EqualTo(typeof(int[]).Name));
            //Assert.That(typeof(int[]), Is.EqualTo(parameter.GetType()));
        }

        [Test]
        public void FetchMethodShouldReturnElementsAsArray()
        {
            var array = this.database.Fetch();

            Assert.True(array is int[]);
        }
    }
}