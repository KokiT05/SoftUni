using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [SetUp]
    public void StartUp()
    {
        //AxeLoosesDurabilityAfterAttack 
    }

    [Test]
    public void AxeLoosesDurabilityAfterAttack()
    {
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);

        axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
    }

    [Test]
    public void AttackWithBrokenWeapon()
    {
        Axe axe = new Axe(5, 0);
        Dummy dummy = new Dummy(5, 3);

        Assert
        .Throws<InvalidOperationException>(() => axe.Attack(dummy), "Weapon is broke, can't attack");
    }
}