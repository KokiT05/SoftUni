using Moq;
using NUnit.Framework;
using Skeleton.Contracts;
using Skeleton.Tests.Fakes;

[TestFixture]
public class HeroTests
{
    [Test]
    public void WhenTargetDies_ShouldReceiveExperience()
    {
        //FakeTarget target = new FakeTarget();
        //FakeWeapon fakeWeapon = new FakeWeapon();

        //Hero hero = new Hero("HeroTest", fakeWeapon);

        //hero.Attack(target);

        //Assert.That(hero.Experience, Is.EqualTo(target.GiveExperience()));

        Mock<ITarget> target = new Mock<ITarget>();
        Mock<IWeapon> weapon = new Mock<IWeapon>();

        target.Setup(t => t.IsDead()).Returns(true);
        target.Setup(t => t.GiveExperience())
                .Returns(20);

        Hero hero = new Hero("Ivan", weapon.Object);

        hero.Attack(target.Object);

        Assert.That(hero.Experience, Is.EqualTo(target.Object.GiveExperience()));
        //Assert.That(hero.Experience, Is.EqualTo(20));
    }
}