using NUnit.Framework;
using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

[TestFixture]
public sealed class SemaphoreServiceTests
{
    private SemaphoreService _service;

    [SetUp]
    public void Setup() => _service = new SemaphoreService();

    [Test]
    public void CountPrimes_Range1To10000_ReturnsExactCount()
    {
        var result = _service.CountPrimes(1, 10000, 4);
        Assert.That(result.PrimeCount, Is.EqualTo(1229));
        Assert.That(result.IsValid(1229), Is.True);
    }

    [Test]
    public void CountPrimes_SmallRange_ReturnsCorrectCount()
    {
        var result = _service.CountPrimes(1, 100, 2);
        Assert.That(result.PrimeCount, Is.EqualTo(25));
    }

    [Test]
    public void CountPrimes_SynchronizationType_IsCorrect()
    {
        var result = _service.CountPrimes(1, 50, 1);
        Assert.That(result.SynchronizationType, Is.EqualTo("Semaphore"));
    }

    [Test]
    public void CountPrimes_ThreadCount_MatchesInput()
    {
        var result = _service.CountPrimes(1, 1000, 3);
        Assert.That(result.ThreadCount, Is.EqualTo(3));
    }

    [Test]
    public void CountPrimes_FoundPrimes_ContainsExpectedValues()
    {
        var result = _service.CountPrimes(1, 30, 1);
        Assert.That(result.FoundPrimes, Does.Contain(2));
        Assert.That(result.FoundPrimes, Does.Contain(29));
        Assert.That(result.FoundPrimes.Count, Is.EqualTo(10));
    }

    [Test]
    public void GetVersionName_ReturnsCorrectString()
    {
        Assert.That(_service.GetVersionName(), Does.Contain("Semaphore"));
    }
}
