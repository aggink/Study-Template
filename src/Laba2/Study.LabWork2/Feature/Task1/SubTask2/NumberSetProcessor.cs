using Study.LabWork2.Abstractions.Feature.Task1.SubTask2;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2.DtoModels;
using System.Diagnostics;
using System.Text;

namespace Study.LabWork2.Feature.Task1.SubTask2;

public sealed class NumberSetProcessor : INumberSetProcessor
{
    private readonly List<List<int>> _numberSets;
    private ProcessingResultDto _result;
    private readonly object _resultsLock = new object();
    private readonly Mutex _totalSumMutex = new Mutex();
    private readonly Semaphore _processingSemaphore;
    private int _totalSum = 0;
    private List<ResultEntryDto> _resultsList;

    public NumberSetProcessor(List<List<int>> numberSets, int maxConcurrentThreads = 3)
    {
        _numberSets = numberSets;
        _processingSemaphore = new Semaphore(maxConcurrentThreads, maxConcurrentThreads);
        _resultsList = new List<ResultEntryDto>();
    }

    public void Process()
    {
        List<Thread> threads = new List<Thread>();
        Stopwatch sw = Stopwatch.StartNew();

        for (int i = 0; i < _numberSets.Count; i++)
        {
            int setIndex = i;
            int threadId = i + 1;

            Thread thread = new Thread(() => ProcessSingleSet(setIndex, threadId));
            threads.Add(thread);
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        sw.Stop();

        _result = new ProcessingResultDto
        {
            Results = _resultsList,
            TotalSum = _totalSum,
            ExecutionTime = sw.Elapsed,
            ProcessedSetsCount = _resultsList.Count
        };
    }

    private void ProcessSingleSet(int setIndex, int threadId)
    {
        _processingSemaphore.WaitOne();

        try
        {
            var numbers = _numberSets[setIndex];
            int sum = 0;
            foreach (var num in numbers)
            {
                sum += num;
            }

            var resultEntry = new ResultEntryDto
            {
                SetNumber = setIndex + 1,
                Sum = sum,
                ThreadId = threadId
            };

            lock (_resultsLock)
            {
                _resultsList.Add(resultEntry);
                Console.WriteLine($"Набор {setIndex + 1}: сумма = {sum}, обработан потоком {threadId}");
            }

            _totalSumMutex.WaitOne();
            try
            {
                _totalSum += sum;
            }
            finally
            {
                _totalSumMutex.ReleaseMutex();
            }
        }
        finally
        {
            _processingSemaphore.Release();
        }
    }

    public ProcessingResultDto GetResult()
    {
        return _result;
    }

    public static List<List<int>> GenerateNumberSets(int setCount = 15, int numbersPerSet = 100)
    {
        Random random = new Random();
        List<List<int>> sets = new List<List<int>>();

        for (int i = 0; i < setCount; i++)
        {
            List<int> numbers = new List<int>();
            for (int j = 0; j < numbersPerSet; j++)
            {
                numbers.Add(random.Next(1, 101));
            }
            sets.Add(numbers);
        }

        return sets;
    }

    public static void SaveSetsToFile(List<List<int>> sets, string filePath)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < sets.Count; i++)
        {
            sb.AppendLine($"Набор {i + 1}: {string.Join(" ", sets[i])}");
        }
        File.WriteAllText(filePath, sb.ToString());
    }

    public static List<List<int>> LoadSetsFromFile(string filePath)
    {
        List<List<int>> sets = new List<List<int>>();

        if (!File.Exists(filePath))
        {
            return sets;
        }

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split(':');
            if (parts.Length == 2)
            {
                string[] numberStrings = parts[1].Trim().Split(' ');
                List<int> numbers = new List<int>();

                foreach (string numStr in numberStrings)
                {
                    if (!string.IsNullOrEmpty(numStr))
                    {
                        numbers.Add(int.Parse(numStr));
                    }
                }

                sets.Add(numbers);
            }
        }

        return sets;
    }
}
