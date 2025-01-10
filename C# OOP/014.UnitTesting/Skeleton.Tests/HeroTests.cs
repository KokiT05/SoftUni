using NUnit.Framework;
using Skeleton.Tests.Fakes;

[TestFixture]
public class HeroTests
{
    [Test]
    public void WhenTargetDies_ShouldReceiveExperience()
    {
        FakeTarget target = new FakeTarget();
        FakeWeapon fakeWeapon = new FakeWeapon();

        Hero hero = new Hero("HeroTest", fakeWeapon);

        hero.Attack(target);

        Assert.That(hero.Experience, Is.EqualTo(target.GiveExperience()));
    }
}