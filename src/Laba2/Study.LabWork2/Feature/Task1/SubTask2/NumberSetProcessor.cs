using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask2;

/// <summary>
/// Определяет реализацию для процессора наборов чисел
/// </summary>
public sealed class NumberSetProcessor : INumberSetProcessor
{
    private readonly Semaphore semaphore = new(3, 3);
    private static object locker = new object();
    private static Mutex mutex = new Mutex();

    private readonly List<ResultEntryDto> results = [];
    private int totalSum;
    private TimeSpan executionTime;

    public void Process()
    {
        var dataSets = GenerateDataSets();

        var stopwatch = Stopwatch.StartNew();

        Thread[] threads = new Thread[dataSets.Count];

        for (int i = 0; i < dataSets.Count; i++)
        {
            int index = i;
            threads[i] = new Thread(() => ProcessSet(index, dataSets[index]));
            threads[i].Start();
        }

        foreach (var t in threads)
            t.Join();

        stopwatch.Stop();
        executionTime = stopwatch.Elapsed;
    }

    public ProcessingResultDto GetResult()
    {
        return new ProcessingResultDto
        {
            Results = results,
            TotalSum = totalSum,
            ExecutionTime = executionTime,
            ProcessedSetsCount = results.Count
        };
    }

    private void ProcessSet(int setNumber, int[] numbers)
    {
        semaphore.WaitOne();

        try
        {
            int sum = numbers.Sum();
            int threadId = Thread.CurrentThread.ManagedThreadId;

            lock (locker)
            {
                results.Add(new ResultEntryDto
                {
                    SetNumber = setNumber + 1,
                    Sum = sum,
                    ThreadId = threadId
                });
            }

            mutex.WaitOne();
            try
            {
                totalSum += sum;
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
        finally
        {
            semaphore.Release();
        }
    }

    private static List<int[]> GenerateDataSets()
    {
        const string fileName = "datasets.txt";

        if (File.Exists(fileName))
        {
            return File.ReadAllLines(fileName)
                .Select(line => line.Split(' ')
                .Select(int.Parse)
                .ToArray())
                .ToList();
        }

        Random random = new();
        List<int[]> sets = [];

        for (int i = 0; i < 15; i++)
        {
            int[] numbers = new int[100];

            for (int j = 0; j < 100; j++)
                numbers[j] = random.Next(1, 101);

            sets.Add(numbers);
        }

        File.WriteAllLines(fileName,
            sets.Select(set => string.Join(" ", set)));

        return sets;
    }
}
