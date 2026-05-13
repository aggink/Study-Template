namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask2;

using NUnit.Framework;
using Study.LabWork2.Feature.Task1.SubTask2;
[TestFixture]
public sealed class NumberSetProcessorTests
{

    /// <summary>
    /// Тест запуска обработки
    /// </summary>
    [Test]
    public void ResultsTest()
    {
        var processor = new NumberSetProcessor();

        processor.Process();
        var result = processor.GetResult();

        Assert.That(result.Results, Is.Not.Empty);
    }

    /// <summary>
    /// обработано ровно 15 наборов
    /// </summary>
    [Test]
    public void ProcessedSetsCountTest()
    {
        var processor = new NumberSetProcessor();

        processor.Process();
        var result = processor.GetResult();

        Assert.That(result.ProcessedSetsCount, Is.EqualTo(15));
    }

    /// <summary>
    /// Тест проверки суммы наборов
    /// </summary>
    [Test]
    public void TotalSumTest()
    {
        var processor = new NumberSetProcessor();

        processor.Process();
        var result = processor.GetResult();

        int expected = result.Results.Sum(x => x.Sum);

        Assert.That(result.TotalSum, Is.EqualTo(expected));
    }

    /// <summary>
    /// Тест времени выполнения
    /// </summary>
    [Test]
    public void ExecutionTimeTest()
    {
        var processor = new NumberSetProcessor();

        processor.Process();
        var result = processor.GetResult();

        Assert.That(result.ExecutionTime, Is.GreaterThan(TimeSpan.Zero));
    }

    /// <summary>
    /// Тест проверки создания потоков
    /// </summary>
    [Test]
    public void ThreadIdsTest()
    {
        var processor = new NumberSetProcessor();

        processor.Process();
        var result = processor.GetResult();

        Assert.That(result.Results.All(x => x.ThreadId > 0), Is.True);
    }

    /// <summary>
    /// Проверка, что суммы положительные 
    /// </summary>
    [Test]
    public void PositiveSumsTest()
    {
        var processor = new NumberSetProcessor();

        processor.Process();
        var result = processor.GetResult();

        Assert.That(result.Results.All(x => x.Sum > 0), Is.True);
    }

    /// <summary>
    /// Проверка, что номера наборов от 1 до 15
    /// </summary>
    [Test]
    public void SetNumbersTest()
    {
        var processor = new NumberSetProcessor();

        processor.Process();
        var result = processor.GetResult();

        var setNumbers = result.Results.Select(x => x.SetNumber).OrderBy(x => x).ToList();

        var expected = Enumerable.Range(1, 15).ToList();

        Assert.That(setNumbers, Is.EqualTo(expected));
    }

    /// <summary>
    /// Тест GetResult()
    /// </summary>
    [Test]
    public void GetResultTest()
    {
        var processor = new NumberSetProcessor();

        processor.Process();

        var result1 = processor.GetResult();
        var result2 = processor.GetResult();

        Assert.That(result1.TotalSum, Is.EqualTo(result2.TotalSum));
        Assert.That(result1.ProcessedSetsCount, Is.EqualTo(result2.ProcessedSetsCount));
    }
}
