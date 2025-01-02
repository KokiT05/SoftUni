using NUnit.Framework;
using FightingArena;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Warrior firstWarrior;
        private Warrior secondWarrior;
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            this.firstWarrior = new Warrior("FirstWarrior", 100, 200);
            this.secondWarrior = new Warrior("SecondWarrior", 50, 120);
            this.arena = new Arena();
        }

        [Test]
        public void AlreadyEnrolledWarriorsShouldNot_Be_Able_ToEnrollAgain()
        {
            this.arena.Enroll(firstWarrior);

            Assert.Throws<InvalidOperationException>(
            () => this.arena.Enroll(firstWarrior), 
            "Arena cannot enroll same warrior");
        }

        [Test]
        public void CannotBeFight_If_One_Of_TheWarriors_Is_Not_Enrolled()
        {
            this.arena.Enroll(this.firstWarrior);

            Assert.Throws<InvalidOperationException>(
            () => this.arena.Fight(this.firstWarrior.Name, "NoWarrior"),
            "defender is not enroll, fight method should throw error");

            Assert.Throws<InvalidOperationException>(
            () => this.arena.Fight("NoWarrior", this.firstWarrior.Name),
            "attacker is not enroll, fight method should throw error");
        }
    }
}
