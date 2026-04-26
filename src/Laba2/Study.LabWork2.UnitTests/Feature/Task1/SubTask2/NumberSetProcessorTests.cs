using NUnit.Framework;
using Study.LabWork2.Feature.Task1.SubTask2;
using System.IO;
using System.Linq;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask2;

[TestFixture]
[NonParallelizable] // Чтобы тесты не конфликтовали из-за общего файла data_sets.json
public sealed class NumberSetProcessorTests
{
    private const string DataFilePath = "data_sets.json";
    private NumberSetProcessor _processor;

    [SetUp]
    public void Setup()
    {
        if (File.Exists(DataFilePath))
            File.Delete(DataFilePath);

        _processor = new NumberSetProcessor();
    }

    [TearDown]
    public void TearDown()
    {
        if (File.Exists(DataFilePath))
            File.Delete(DataFilePath);
    }

    [Test]
    public void Process_CompletesAndReturnsValidResult()
    {
        _processor.Process();
        var result = _processor.GetResult();
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void Process_ProcessesAll15Sets()
    {
        _processor.Process();
        var result = _processor.GetResult();

        Assert.That(result.ProcessedSetsCount, Is.EqualTo(15));
        Assert.That(result.Results.Count, Is.EqualTo(15));
    }

    [Test]
    public void Process_ResultsContainValidData()
    {
        _processor.Process();
        var result = _processor.GetResult();

        foreach (var entry in result.Results)
        {
            Assert.That(entry.SetNumber, Is.InRange(1, 15));
            Assert.That(entry.Sum, Is.GreaterThan(0));
            Assert.That(entry.Sum, Is.LessThanOrEqualTo(10000)); // 100 чисел * макс. 100
            Assert.That(entry.ThreadId, Is.GreaterThan(0));
        }
    }

    [Test]
    public void Process_TotalSum_MatchesIndividualSums()
    {
        _processor.Process();
        var result = _processor.GetResult();
        var calculatedSum = result.Results.Sum(r => r.Sum);

        Assert.That(result.TotalSum, Is.EqualTo(calculatedSum));
    }

    [Test]
    public void Process_ExecutionTime_IsPositive()
    {
        _processor.Process();
        var result = _processor.GetResult();
        Assert.That(result.ExecutionTime.TotalMilliseconds, Is.GreaterThanOrEqualTo(0));
    }

    [Test]
    public void GetResult_ThrowsException_WhenNotProcessed()
    {
        var newProcessor = new NumberSetProcessor();
        Assert.Throws<InvalidOperationException>(() => newProcessor.GetResult());
    }
}
