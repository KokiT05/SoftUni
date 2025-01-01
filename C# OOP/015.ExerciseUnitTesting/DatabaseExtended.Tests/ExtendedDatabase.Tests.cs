using NUnit.Framework;
using ExtendedDatabase;
using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        ExtendedDatabase.ExtendedDatabase setUpExtendedDatabase;

        private long setUpPersonId = 1234567890;
        private string setUpPersonUserName = "SetUpPerson";
        Person setUpPerson;

        [SetUp]
        public void Setup()
        {
            this.setUpExtendedDatabase = new ExtendedDatabase.ExtendedDatabase();
            this.setUpPerson = new Person(this.setUpPersonId, this.setUpPersonUserName);
        }

        [Test]
        public void AddMethodCannotAddTwoUsersWhitTheSameName()
        {
            this.setUpExtendedDatabase.Add(setUpPerson);
            this.setUpPerson = new Person(123, this.setUpPersonUserName);
            Assert.Throws<InvalidOperationException>
            (() => this.setUpExtendedDatabase.Add(this.setUpPerson), 
            "ExtendedDatabase has two users with the same name");
        }

        [Test]
        public void AddMethodCannotAddTwoUsersWhitTheSameId()
        {
            this.setUpExtendedDatabase.Add(this.setUpPerson);
            this.setUpPerson = new Person(this.setUpPersonId, "TestUserOne");

            Assert.Throws<InvalidOperationException>
            (() => this.setUpExtendedDatabase.Add(this.setUpPerson), 
            "ExtendedDatabase has two users whit the same id");
        }

        [Test]
        public void RemoveMethodCannotRemoveAUsersFromAnEmptyDatabase()
        {
            //this.setUpExtendedDatabase.Add(this.setUpPerson);

            Assert.Throws<InvalidOperationException>
            (() => this.setUpExtendedDatabase.Remove(), 
            "The remove method removes a user from an empty database");
        }

        [Test]
        public void FindByUsernameMethodCannotFindAUserThatDoesNotMatchTheNameOrEmptyName()
        {
            //this.setUpPerson = new Person(123, "NoUser");
            this.setUpExtendedDatabase.Add(this.setUpPerson);

            Assert.Throws<InvalidOperationException>(
            () => this.setUpExtendedDatabase.FindByUsername("NoUser"),
            "FindBuUsername method did not return an error when searching for a user that does not match the name");

            string nullValueName = null;
            Assert.Throws<ArgumentNullException>(
            () => this.setUpExtendedDatabase.FindByUsername(nullValueName),
            "FindBuUsername method did not return an error when the name is null or empty");
        }

        [Test]
        public void FindByIdMethodCannotFind_A_UserThatDoesNotMatchTheID_OrNegativeId()
        {
            this.setUpExtendedDatabase.Add(this.setUpPerson);

            Random random = new Random();
            long randomId = random.Next(100000, 900000);

            Assert.Throws<InvalidOperationException>(
            () => this.setUpExtendedDatabase.FindById(randomId), 
            "FindById method did not return an error when searching for a user that does not match the id");

            Assert.Throws<ArgumentOutOfRangeException>(
            () => this.setUpExtendedDatabase.FindById(-1),
            "FindById method did not return an error when the id is negative");
        }

        [Test]
        public void ExtendedDatabaseCapacityMustBeExactlySixteen()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i <= 17; i++)
                {
                    this.setUpPerson = new Person(i, $"{i}");
                    this.setUpExtendedDatabase.Add(this.setUpPerson);
                }
            }, "The database does not throw error when the users are more than sixteen");

            // Get capacity with reflection;
        }

        [Test]
        public void AddMethodCannotAddMoreThanSixteenUsers()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 1; i <= 17; i++)
                {
                    this.setUpPerson = new Person(i, $"{i}");
                    this.setUpExtendedDatabase.Add(this.setUpPerson);
                }
            }, "The add method does not throw error when the users are more than sixteen");
        }

        [Test]
        public void RemoveMethodCannotRemoveUsersWhenExtendedDatabaseIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(
            () => this.setUpExtendedDatabase.Remove(), "The remove method remove a user from an empty database");
        }

        [Test]
        public void ConstructorsShouldTakePersonOnly()
        {
            Type type = this.setUpExtendedDatabase.GetType();

            ConstructorInfo constructorInfo = type
                .GetConstructor
                (BindingFlags.Public | BindingFlags.Instance, new Type[] { typeof(Person[]) });
            ParameterInfo[] parametersInfo = constructorInfo.GetParameters();
            ParameterInfo parameter = parametersInfo[0];

            Assert.That(parameter.ParameterType.Name, Is.EqualTo(typeof(Person[]).Name),
            "The constructor does not take only users");
            //Assert.That(typeof(int[]), Is.EqualTo(parameter.GetType()));
        }
    }
}