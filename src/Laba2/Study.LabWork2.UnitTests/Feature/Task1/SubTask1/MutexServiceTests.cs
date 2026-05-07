using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

[TestFixture]
public sealed class MutexServiceTests
{
    private MutexService _service;

    [SetUp]
    public void SetUp()
    {
        _service = new MutexService();
    }

    [Test]
    public void GetVersionName_ReturnsCorrectName()
    {
        var result = _service.GetVersionName();
        Assert.That(result, Is.EqualTo("Mutex"));
    }

    [Test]
    public void CountPrimes_ReturnsCorrectCount()
    {
        var result = _service.CountPrimes(1, 10_000, 4);
        Assert.That(result.PrimeCount, Is.EqualTo(1229));
    }

    [Test]
    public void CountPrimes_ExecutionTimeIsPositive()
    {
        var result = _service.CountPrimes(1, 10_000, 4);
        Assert.That(result.ExecutionTime.TotalMilliseconds, Is.GreaterThan(0));
    }

    [Test]
    public void CountPrimes_ThreadCountIsCorrect()
    {
        var result = _service.CountPrimes(1, 10_000, 4);
        Assert.That(result.ThreadCount, Is.EqualTo(4));
    }

    [Test]
    public void CountPrimes_SynchronizationTypeIsCorrect()
    {
        var result = _service.CountPrimes(1, 10_000, 4);
        Assert.That(result.SynchronizationType, Is.EqualTo("Mutex"));
    }

    [Test]
    public void CountPrimes_FoundPrimesCountMatchesPrimeCount()
    {
        var result = _service.CountPrimes(1, 10_000, 4);
        Assert.That(result.FoundPrimes.Count, Is.EqualTo(result.PrimeCount));
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(8)]
    public void CountPrimes_WorksWithDifferentThreadCounts(int threadCount)
    {
        var result = _service.CountPrimes(1, 10_000, threadCount);
        Assert.That(result.PrimeCount, Is.EqualTo(1229));
    }
}
