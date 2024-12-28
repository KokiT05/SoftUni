using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    private int dummyHealth = 10;
    private int dummyExperience = 3;
    private Dummy dummy;

    private int axeAttack = 5;
    private int axeDurability = 10;
    private Axe axe;

    private Hero hero;
    private string heroName = "KoKi";

    [SetUp]
    public void SetUp()
    {
        this.dummy = new Dummy(dummyHealth, dummyExperience);
        this.axe = new Axe(axeAttack, axeDurability);
        this.hero = new Hero(heroName);
    }

    [Test]
    public void DummyLosesHealthWhenIsAttacked()
    {
        int expectedHealth = 5;
        this.axe.Attack(this.dummy);
        //Assert.That(dummy.Health, Is.EqualTo(expectedHealth));
        Assert.True(dummy.Health == expectedHealth, "The Dummy health should decrease");
    }

    [Test]
    public void DeadDummyThrowsExceptionWhenIsAttacked()
    {
        this.axe.Attack(dummy);
        this.axe.Attack(dummy);

        //Assert.Throws<InvalidOperationException>(() => this.axe.Attack(dummy));
        Assert
        .Throws<InvalidOperationException>
        (() => this.dummy.TakeAttack(axeAttack), "Dead dummy cannot be attacked");
    }

    [Test]
    public void DeadDummyGiveXP()
    {
        //this.axe.Attack(this.dummy);
        //this.axe.Attack(this.dummy);
        //int expectedXP = 3;

        //Assert.That(this.dummy.GiveExperience(), Is.EqualTo(expectedXP));

        this.hero.Attack(this.dummy);
        //Assert
        //.That(this.hero.Experience, Is.EqualTo(this.dummy.GiveExperience()), "Dead dummy should give XP");

        Assert.True(this.hero.Experience == this.dummy.GiveExperience());
    }

    [Test]
    public void AliveDummyDontGiveXP()
    {
        Axe axe = new Axe(1, 100);
        axe.Attack(this.dummy);
        //this.dummy.TakeAttack(axe);
        Assert
        .Throws<InvalidOperationException>
        (() => this.dummy.GiveExperience(), "Alive dummy don' give XP");
    }
}