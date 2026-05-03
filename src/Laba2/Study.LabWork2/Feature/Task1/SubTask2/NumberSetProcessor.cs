using System.Text;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask2;

public sealed class NumberSetProcessor : INumberSetProcessor
{
    private const int SetCount = 15;
    private const int NumbersPerSet = 100;
    private const string FilePath = "numbersets.txt";

    private List<List<int>> _sets = new();

    private readonly List<ResultEntryDto> _results = new();

    private int _totalSum = 0;

    private readonly object _lockObj = new(); // Monitor
    private readonly Semaphore _semaphore = new Semaphore(4, 4); // n потоков
    private readonly Mutex _mutex = new Mutex();

    private DateTime _startTime;
    private DateTime _endTime;

    public void Process()
    {
        _startTime = DateTime.Now;

        LoadOrGenerateSets();

        Thread[] threads = new Thread[SetCount];

        for (int i = 0; i < SetCount; i++)
        {
            int index = i;
            threads[i] = new Thread(() => ProcessSet(index));
            threads[i].Start();
        }

        foreach (var t in threads)
            t.Join();

        _endTime = DateTime.Now;
    }

    private void ProcessSet(int index)
    {
        _semaphore.WaitOne();

        try
        {
            var set = _sets[index];
            int sum = set.Sum();

            int threadId = Thread.CurrentThread.ManagedThreadId;

            var result = new ResultEntryDto
            {
                SetNumber = index + 1,
                Sum = sum,
                ThreadId = threadId
            };

            // Monitor (lock) — список результатов
            lock (_lockObj)
            {
                _results.Add(result);
            }

            // Mutex — общий итог
            _mutex.WaitOne();
            try
            {
                _totalSum += sum;
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public ProcessingResultDto GetResult()
    {
        return new ProcessingResultDto
        {
            Results = _results.OrderBy(r => r.SetNumber).ToList(),
            TotalSum = _totalSum,
            ExecutionTime = _endTime - _startTime,
            ProcessedSetsCount = _results.Count
        };
    }

    private void LoadOrGenerateSets()
    {
        if (File.Exists(FilePath))
        {
            _sets = File.ReadAllLines(FilePath)
                .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList())
                .ToList();

            return;
        }

        var rnd = new Random();
        var sb = new StringBuilder();

        for (int i = 0; i < SetCount; i++)
        {
            var set = new List<int>();

            for (int j = 0; j < NumbersPerSet; j++)
            {
                set.Add(rnd.Next(1, 101));
            }

            _sets.Add(set);

            sb.AppendLine(string.Join(" ", set));
        }

        File.WriteAllText(FilePath, sb.ToString());
    }
}
