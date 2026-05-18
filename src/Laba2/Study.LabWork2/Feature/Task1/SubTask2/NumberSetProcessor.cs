using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask2;

public sealed class NumberSetProcessor : INumberSetProcessor
{
    private const int PackCount = 15;
    private const int PackLength = 100;
    private const int LowestValue = 1;
    private const int HighestValue = 100;
    private const int GeneratorSeed = 2402;

    private readonly int _parallelLimit;
    private readonly string _fileName;

    private readonly object _journalLocker = new object();
    private readonly Mutex _sumLocker = new Mutex();

    private readonly List<ResultEntryDto> _journal = new List<ResultEntryDto>();

    private int _grandTotal;
    private TimeSpan _duration;

    public NumberSetProcessor(int maxConcurrentThreads = 3, string? setsFilePath = null)
    {
        if (maxConcurrentThreads <= 0)
        {
            throw new ArgumentException("Лимит одновременно работающих потоков должен быть положительным.");
        }

        _parallelLimit = maxConcurrentThreads;
        _fileName = setsFilePath ?? Path.Combine(AppContext.BaseDirectory, "student_number_packs.txt");
    }

    public void Process()
    {
        ResetState();

        CreateDataFileIfRequired();

        int[][] packs = ReadPacks();

        var limiter = new Semaphore(_parallelLimit, _parallelLimit);
        var threads = new Thread[packs.Length];

        var stopwatch = Stopwatch.StartNew();

        for (int i = 0; i < packs.Length; i++)
        {
            int packIndex = i + 1;
            int[] pack = packs[i];

            threads[i] = new Thread(() => CalculatePack(packIndex, pack, limiter));
        }

        foreach (Thread thread in threads)
        {
            thread.Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        stopwatch.Stop();

        _duration = stopwatch.Elapsed;
    }

    public ProcessingResultDto GetResult()
    {
        return new ProcessingResultDto
        {
            Results = _journal.OrderBy(entry => entry.SetNumber).ToList(),
            TotalSum = _grandTotal,
            ExecutionTime = _duration,
            ProcessedSetsCount = _journal.Count
        };
    }

    private void ResetState()
    {
        _journal.Clear();
        _grandTotal = 0;
        _duration = TimeSpan.Zero;
    }

    private void CalculatePack(int packNumber, int[] values, Semaphore limiter)
    {
        limiter.WaitOne();

        try
        {
            int localSum = values.Sum();
            int currentThread = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine($"Поток {currentThread}: обработан набор {packNumber}, сумма = {localSum}");

            lock (_journalLocker)
            {
                _journal.Add(new ResultEntryDto
                {
                    SetNumber = packNumber,
                    Sum = localSum,
                    ThreadId = currentThread
                });
            }

            _sumLocker.WaitOne();

            try
            {
                _grandTotal += localSum;
            }
            finally
            {
                _sumLocker.ReleaseMutex();
            }
        }
        finally
        {
            limiter.Release();
        }
    }

    private void CreateDataFileIfRequired()
    {
        if (File.Exists(_fileName))
        {
            return;
        }

        string? directory = Path.GetDirectoryName(_fileName);

        if (!string.IsNullOrWhiteSpace(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var generator = new Random(GeneratorSeed);
        var rows = new List<string>();

        for (int pack = 0; pack < PackCount; pack++)
        {
            int[] values = new int[PackLength];

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = generator.Next(LowestValue, HighestValue + 1);
            }

            rows.Add(string.Join(' ', values));
        }

        File.WriteAllLines(_fileName, rows);
    }

    private int[][] ReadPacks()
    {
        string[] rows = File.ReadAllLines(_fileName);

        if (rows.Length != PackCount)
        {
            throw new InvalidOperationException($"Файл должен содержать {PackCount} строк.");
        }

        int[][] packs = new int[PackCount][];

        for (int i = 0; i < rows.Length; i++)
        {
            int[] parsedPack = rows[i]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (parsedPack.Length != PackLength)
            {
                throw new InvalidOperationException($"В наборе {i + 1} должно быть {PackLength} чисел.");
            }

            packs[i] = parsedPack;
        }

        return packs;
    }
}
