using Study.LabWork2.Feature.Task1.SubTask2;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask2;

[TestFixture]
public sealed class NumberSetProcessorTests
{
    [Test]
    public void Process_Should_ProcessAllSets()
    {
        var processor = new NumberSetProcessor();

        processor.Process();

        var result = processor.GetResult();

        Assert.That(result.ProcessedSetsCount, Is.EqualTo(15));
    }

    [Test]
    public void Process_Should_CalculatePositiveTotalSum()
    {
        var processor = new NumberSetProcessor();

        processor.Process();

        var result = processor.GetResult();

        Assert.That(result.TotalSum, Is.GreaterThan(0));
    }

    [Test]
    public void Process_Should_Return15ResultsEntries()
    {
        var processor = new NumberSetProcessor();

        processor.Process();

        var result = processor.GetResult();

        Assert.That(result.Results.Count, Is.EqualTo(15));
    }

    [Test]
    public void Process_Should_NotThrowExceptions_WhenRun()
    {
        var processor = new NumberSetProcessor();

        Assert.DoesNotThrow(() =>
        {
            processor.Process();
        });
    }

    [Test]
    public void Process_Should_HaveUniqueSetNumbers()
    {
        var processor = new NumberSetProcessor();

        processor.Process();

        var result = processor.GetResult();

        var distinct = result.Results.Select(r => r.SetNumber).Distinct();

        Assert.That(distinct.Count(), Is.EqualTo(15));
    }

    [Test]
    public void Process_Should_ProduceSameResult_ForSameInputFile()
    {
        var processor1 = new NumberSetProcessor();
        var processor2 = new NumberSetProcessor();

        processor1.Process();
        processor2.Process();

        var r1 = processor1.GetResult();
        var r2 = processor2.GetResult();

        Assert.That(r1.TotalSum, Is.EqualTo(r2.TotalSum));
    }

    [Test]
    public void ExecutionTime_Should_BePositive()
    {
        var processor = new NumberSetProcessor();

        processor.Process();

        var result = processor.GetResult();

        Assert.That(result.ExecutionTime.TotalMilliseconds, Is.GreaterThan(0));
    }
}
