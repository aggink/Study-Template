using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1;

/// <summary>
/// Версия 1. Использует Monitor (lock) для синхронизации
/// </summary>
public sealed class MonitorService : IPrimeCounter
{
    private int _primeCount = 0;
    private readonly object _lock = new object();
    private readonly List<int> _foundPrimes = new List<int>();

    private static bool IsPrime(int number)
    {
        if (number < 2) { return false; }
        if (number == 2) { return true; }
        if (number % 2 == 0) { return false; }

        int limit = (int)Math.Sqrt(number);
        for (int i = 3; i <= limit; i += 2)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    public PrimeCountResultDto CountPrimes(int start, int end, int threadCount)
    {
        _primeCount = 0;
        _foundPrimes.Clear();

        int totalNumbers = end - start + 1;
        int rangeSize = totalNumbers / threadCount;

        List<Thread> threads = new List<Thread>();
        Stopwatch sw = Stopwatch.StartNew();

        for (int i = 0; i < threadCount; i++)
        {
            int threadStart = start + i * rangeSize;
            int threadEnd = (i == threadCount - 1) ? end : start + (i + 1) * rangeSize - 1;
            int threadId = i + 1;

            Thread thread = new Thread(() =>
            {
                for (int num = threadStart; num <= threadEnd; num++)
                {
                    bool isPrime = IsPrime(num);
                    lock (_lock)
                    {
                        Console.WriteLine($"Thread {threadId}: is checking number {num}, prime: {isPrime}");
                        if (isPrime)
                        {
                            _primeCount++;
                            _foundPrimes.Add(num);
                        }
                    }
                }
            });

            threads.Add(thread);
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        sw.Stop();

        return new PrimeCountResultDto
        {
            PrimeCount = _primeCount,
            ExecutionTime = sw.Elapsed,
            ThreadCount = threadCount,
            SynchronizationType = GetVersionName(),
            FoundPrimes = new List<int>(_foundPrimes)
        };
    }

    public string GetVersionName()
    {
        return "Monitor (lock)";
    }
}
