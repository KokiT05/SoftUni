using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private string name;
        private int damage;
        private int hp;
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.name = "WarriorOne";
            this.damage = 100;
            this.hp = 100;
            this.warrior = new Warrior(this.name, this.damage, this.hp);
        }

        [Test]
        public void ConstructorMustCorrectlyRecordThePropertyValues()
        {
            this.warrior = new Warrior(this.name, this.damage, this.hp);

            Assert.True(this.name == this.warrior.Name, 
            "The constructor does not set the correct value for property Name");
            Assert.True(this.damage == this.warrior.Damage, 
            "The constructor does not set the correct value for property Damage");
            Assert.True(this.hp == this.warrior.HP, 
            "The constructor does not set the correct value for property HP");
        }

        [Test]
        public void PropertyNameShouldWorkCorrectly()
        {
            string expectedValueName = "WarriorOne";

            Assert.True(expectedValueName == this.warrior.Name, "Property Name does not return correct value");

            Assert.Throws<ArgumentException>(
            () => this.warrior = new Warrior(null, this.damage, this.hp),
            "Name cannot be null");

            Assert.Throws<ArgumentException>(
            () => this.warrior = new Warrior("", this.damage, this.hp),
            "Name cannot be empty");
        }

        [Test]
        public void PropertyDamageShouldWorkCorrectly()
        {
            int expectedDamage = 100;

            Assert.True(expectedDamage == this.warrior.Damage, "Property Damage does not return correct value");

            Assert.Throws<ArgumentException>(
            () => this.warrior = new Warrior(this.name, 0, this.hp),
            "Property Damage cannot be zero");

            Assert.Throws<ArgumentException>(
            () => this.warrior = new Warrior(this.name, -12, this.hp),
            "Property Damage cannot be negative");
        }

        [Test]
        public void PropertyHP_ShouldWorkCorrectly()
        {
            int expectedHP = 100;

            Assert.True(expectedHP == this.warrior.HP, "Property HP does not return correct value");

            Assert.Throws<ArgumentException>(
            () => this.warrior = new Warrior(this.name, this.damage, -31),
            "Property HP cannot be negative");
        }

        [Test]
        public void AttackMethodShouldWorkCorrect()
        {
            Warrior firstWarrior = new Warrior("FirstWarrior", 10, 30);
            Warrior secondWarrior = new Warrior("SecondWarrior", 200, 1000);

            Assert.Throws<InvalidOperationException>(
            () => firstWarrior.Attack(secondWarrior),
            "Warrior cannot attack when HP is less or equal to 30");

            Assert.Throws<InvalidOperationException>(
            () => secondWarrior.Attack(firstWarrior),
            "Warrior cannot attack when enemy HP is less or equal to 30");

            Assert.Throws<InvalidOperationException>(
            () => this.warrior.Attack(secondWarrior),
            "Warrior cannot attack enemy, enemy is too strong");
        }
    }
}