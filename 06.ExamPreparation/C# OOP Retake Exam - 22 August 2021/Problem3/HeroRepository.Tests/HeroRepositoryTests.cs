using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void CreatingRepostiotryWithNullHeroSHouldThrowException()
    {
        var hr = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() =>
        {
            hr.Create(null);
        }, "Hero is null");
    }
    [Test]
    public void CreatingHeroWithAnExistingNameShouldThrowException()
    {
        var hr = new HeroRepository();
        hr.Create(new Hero("Test", 1));
        Assert.Throws<InvalidOperationException>(() =>
        {
            hr.Create(new Hero("Test", 3));
        }, "Hero with name Test already exists");
    }
    [Test]
    public void CreatingHeroWithCorrectParametersShouldWorkProperly()
    {
        var hr = new HeroRepository();
        var output = hr.Create(new Hero("Test", 1));
        Assert.That(hr.Heroes.Count == 1);
        Assert.That(output, Is.EqualTo("Successfully added hero Test with level 1"));
    }
    [Test]
    public void RemovingHeroNullOrWhiteSpaceHeroShouldThrowException()
    {
        var hr = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() =>
        {
            hr.Remove(null);
        }, "Name cannot be null");
        Assert.Throws<ArgumentNullException>(() =>
        {
            hr.Remove(" ");
        }, "Name cannot be null");
    }
    [Test]
    public void GettingGighestLevelHeroShouldWorkProperly()
    {
        var hr = new HeroRepository();
        hr.Create(new Hero("Test", 1));
        hr.Create(new Hero("Test1", 2));
        var highestLvl = new Hero("Test2", 3);
        hr.Create(highestLvl);
        var highestLvlfromMethod = hr.GetHeroWithHighestLevel();
        Assert.That(highestLvlfromMethod, Is.EqualTo(highestLvl));
    }
    [Test]
    public void MethodGetHeroShouldWorkProperly()
    {
        var hr = new HeroRepository();
        var hero1 = new Hero("Test", 1);
        hr.Create(hero1);
        var getHeroFromMethod = hr.GetHero("Test");
        Assert.That(getHeroFromMethod, Is.EqualTo(hero1));
        Assert.That(hr.GetHero("NoName"), Is.EqualTo(null));
    }
}