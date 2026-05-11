using System.Diagnostics;
using System.Threading;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1;

public sealed class SemaphoreService : IPrimeCounter
{
    private int _totalPrimes;
    private readonly Semaphore _semaphore = new(2, 2); // максимум 2 потока одновременно
    private List<int> _foundPrimes = new();

    public PrimeCountResultDto CountPrimes(int start, int end, int threadCount)
    {
        _totalPrimes = 0;
        _foundPrimes = new List<int>();
        var threads = new Thread[threadCount];
        int rangeSize = (end - start + 1) / threadCount;
        var stopwatch = Stopwatch.StartNew();

        for (int i = 0; i < threadCount; i++)
        {
            int threadId = i + 1;
            int segStart = start + i * rangeSize;
            int segEnd = (i == threadCount - 1) ? end : segStart + rangeSize - 1;

            threads[i] = new Thread(() =>
            {
                _semaphore.WaitOne();
                try
                {
                    for (int num = segStart; num <= segEnd; num++)
                    {
                        Console.WriteLine($"Поток {threadId} проверяет число {num}");
                        if (IsPrime(num))
                        {
                            Interlocked.Increment(ref _totalPrimes);
                            lock (_foundPrimes) // для списка нужна блокировка
                            {
                                _foundPrimes.Add(num);
                            }
                        }
                    }
                }
                finally
                {
                    _semaphore.Release();
                }
            });
            threads[i].Start();
        }

        foreach (var t in threads) t.Join();
        stopwatch.Stop();

        return new PrimeCountResultDto
        {
            PrimeCount = _totalPrimes,
            ExecutionTime = stopwatch.Elapsed,
            ThreadCount = threadCount,
            SynchronizationType = GetVersionName(),
            FoundPrimes = _foundPrimes
        };
    }

    public string GetVersionName() => "Semaphore (2 потока)";

    private static bool IsPrime(int number)
    {
        if (number < 2) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;
        int limit = (int)Math.Sqrt(number);
        for (int i = 3; i <= limit; i += 2)
            if (number % i == 0) return false;
        return true;
    }
}
