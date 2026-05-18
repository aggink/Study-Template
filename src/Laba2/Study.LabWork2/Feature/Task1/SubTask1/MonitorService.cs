using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1;

public sealed class MonitorService : IPrimeCounter
{
    private readonly object _syncRoot = new object();

    private int _counter;
    private readonly List<int> _primeValues = new List<int>();

    public PrimeCountResultDto CountPrimes(int start, int end, int threadCount)
    {
        CheckArguments(start, end, threadCount);

        _counter = 0;
        _primeValues.Clear();

        Thread[] workers = BuildWorkers(start, end, threadCount);

        var timer = Stopwatch.StartNew();

        StartAll(workers);
        WaitAll(workers);

        timer.Stop();

        return new PrimeCountResultDto
        {
            PrimeCount = _counter,
            ExecutionTime = timer.Elapsed,
            ThreadCount = threadCount,
            SynchronizationType = GetVersionName(),
            FoundPrimes = _primeValues.OrderBy(x => x).ToList()
        };
    }

    public string GetVersionName()
    {
        return "Monitor";
    }

    private Thread[] BuildWorkers(int firstNumber, int lastNumber, int workerCount)
    {
        int allNumbers = lastNumber - firstNumber + 1;
        int baseBlock = allNumbers / workerCount;
        int extraNumbers = allNumbers % workerCount;

        var threads = new Thread[workerCount];

        int blockStart = firstNumber;

        for (int index = 0; index < workerCount; index++)
        {
            int visibleThreadNumber = index + 1;
            int currentStart = blockStart;
            int currentLength = baseBlock + (index < extraNumbers ? 1 : 0);
            int currentEnd = currentStart + currentLength - 1;

            threads[index] = new Thread(() => ScanNumbers(currentStart, currentEnd, visibleThreadNumber));

            blockStart = currentEnd + 1;
        }

        return threads;
    }

    private void ScanNumbers(int from, int to, int threadNumber)
    {
        for (int value = from; value <= to; value++)
        {
            Console.WriteLine($"Поток {threadNumber}: проверяется число {value}");

            if (!IsNumberPrime(value))
            {
                continue;
            }

            lock (_syncRoot)
            {
                _counter++;
                _primeValues.Add(value);

                Console.WriteLine($"Поток {threadNumber}: найдено простое число {value}");
            }
        }
    }

    private static bool IsNumberPrime(int value)
    {
        if (value < 2)
        {
            return false;
        }

        if (value == 2)
        {
            return true;
        }

        if (value % 2 == 0)
        {
            return false;
        }

        int limit = (int)Math.Sqrt(value);

        for (int divisor = 3; divisor <= limit; divisor += 2)
        {
            if (value % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    private static void CheckArguments(int start, int end, int threadCount)
    {
        if (start > end)
        {
            throw new ArgumentException("Начало диапазона не должно быть больше конца.");
        }

        if (threadCount < 1)
        {
            throw new ArgumentException("Количество потоков должно быть больше нуля.");
        }
    }

    private static void StartAll(IEnumerable<Thread> threads)
    {
        foreach (Thread thread in threads)
        {
            thread.Start();
        }
    }

    private static void WaitAll(IEnumerable<Thread> threads)
    {
        foreach (Thread thread in threads)
        {
            thread.Join();
        }
    }
}
