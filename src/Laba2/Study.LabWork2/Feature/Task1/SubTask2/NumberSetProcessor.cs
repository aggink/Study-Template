using System.Diagnostics;

namespace Study.LabWork2.Feature.Task1.SubTask2;

public sealed class NumberSetProcessor
{
    private const int SetsCount = 15;
    private const int NumbersInSet = 100;
    private const int MinNumber = 1;
    private const int MaxNumber = 100;

    private readonly object _resultsLocker = new();
    private readonly object _consoleLocker = new();

    public NumberSetProcessingResult Process(
        IReadOnlyList<IReadOnlyList<int>> numberSets,
        int maxParallelThreads,
        bool verbose = false)
    {
        ValidateNumberSets(numberSets);

        if (maxParallelThreads <= 0)
        {
            throw new ArgumentException("Количество потоков должно быть больше нуля.");
        }

        List<NumberSetResult> results = new();
        List<Thread> threads = new();

        using Semaphore semaphore = new(maxParallelThreads, maxParallelThreads);
        using Mutex totalMutex = new();

        int totalSum = 0;

        Stopwatch stopwatch = Stopwatch.StartNew();

        for (int i = 0; i < numberSets.Count; i++)
        {
            int setNumber = i + 1;
            IReadOnlyList<int> numbers = numberSets[i];

            Thread thread = new(() =>
            {
                semaphore.WaitOne();

                try
                {
                    int threadId = Environment.CurrentManagedThreadId;
                    int sum = numbers.Sum();

                    lock (_resultsLocker)
                    {
                        results.Add(new NumberSetResult(setNumber, sum, threadId));
                    }

                    totalMutex.WaitOne();

                    try
                    {
                        totalSum += sum;
                    }
                    finally
                    {
                        totalMutex.ReleaseMutex();
                    }

                    if (verbose)
                    {
                        lock (_consoleLocker)
                        {
                            Console.WriteLine($"Набор {setNumber}: сумма = {sum}, поток = {threadId}");
                        }
                    }
                }
                finally
                {
                    semaphore.Release();
                }
            });

            threads.Add(thread);
            thread.Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        stopwatch.Stop();

        List<NumberSetResult> orderedResults = results
            .OrderBy(result => result.SetNumber)
            .ToList();

        if (verbose)
        {
            Console.WriteLine($"Общий итог по всем наборам: {totalSum}");
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");
        }

        return new NumberSetProcessingResult(
            orderedResults,
            totalSum,
            maxParallelThreads,
            stopwatch.ElapsedMilliseconds);
    }

    public NumberSetProcessingResult Process(
        string filePath,
        int maxParallelThreads,
        bool verbose = false)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("Путь к файлу не может быть пустым.");
        }

        EnsureNumberSetsFileExists(filePath);

        IReadOnlyList<IReadOnlyList<int>> numberSets = LoadNumberSets(filePath);

        return Process(numberSets, maxParallelThreads, verbose);
    }

    public static IReadOnlyList<IReadOnlyList<int>> LoadNumberSets(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("Путь к файлу не может быть пустым.");
        }

        string[] lines = File.ReadAllLines(filePath)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToArray();

        List<IReadOnlyList<int>> result = new();

        foreach (string line in lines)
        {
            int[] numbers = line
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            result.Add(numbers);
        }

        ValidateNumberSets(result);

        return result;
    }

    private static void ValidateNumberSets(IReadOnlyList<IReadOnlyList<int>> numberSets)
    {
        if (numberSets is null)
        {
            throw new ArgumentNullException(nameof(numberSets));
        }

        if (numberSets.Count != SetsCount)
        {
            throw new InvalidOperationException("Должно быть ровно 15 наборов чисел.");
        }

        for (int i = 0; i < numberSets.Count; i++)
        {
            IReadOnlyList<int> numbers = numberSets[i];

            if (numbers is null)
            {
                throw new InvalidOperationException($"Набор №{i + 1} не может быть пустым.");
            }

            if (numbers.Count != NumbersInSet)
            {
                throw new InvalidOperationException($"Набор №{i + 1} должен содержать ровно 100 чисел.");
            }

            if (numbers.Any(number => number < MinNumber || number > MaxNumber))
            {
                throw new InvalidOperationException($"В наборе №{i + 1} все числа должны быть от 1 до 100.");
            }
        }
    }

    private static void EnsureNumberSetsFileExists(string filePath)
    {
        if (File.Exists(filePath))
        {
            return;
        }

        string? directory = Path.GetDirectoryName(filePath);

        if (!string.IsNullOrWhiteSpace(directory))
        {
            Directory.CreateDirectory(directory);
        }

        Random random = new();
        List<string> lines = new();

        for (int i = 0; i < SetsCount; i++)
        {
            int[] numbers = new int[NumbersInSet];

            for (int j = 0; j < numbers.Length; j++)
            {
                numbers[j] = random.Next(MinNumber, MaxNumber + 1);
            }

            lines.Add(string.Join(' ', numbers));
        }

        File.WriteAllLines(filePath, lines);
    }
}

public sealed class NumberSetResult
{
    public NumberSetResult(int setNumber, int sum, int threadId)
    {
        SetNumber = setNumber;
        Sum = sum;
        ThreadId = threadId;
    }

    public int SetNumber { get; }

    public int Sum { get; }

    public int ThreadId { get; }
}

public sealed class NumberSetProcessingResult
{
    public NumberSetProcessingResult(
        IReadOnlyList<NumberSetResult> results,
        int totalSum,
        int maxParallelThreads,
        long elapsedMilliseconds)
    {
        Results = results;
        TotalSum = totalSum;
        MaxParallelThreads = maxParallelThreads;
        ElapsedMilliseconds = elapsedMilliseconds;
    }

    public IReadOnlyList<NumberSetResult> Results { get; }

    public int TotalSum { get; }

    public int MaxParallelThreads { get; }

    public long ElapsedMilliseconds { get; }

    public int ProcessedSetsCount => Results.Count;
}
