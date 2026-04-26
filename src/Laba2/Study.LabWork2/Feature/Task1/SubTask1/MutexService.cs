using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1;

/// <summary>
/// Версия 2. Использует Mutex для синхронизации доступа к общему счётчику.
/// </summary>
public sealed class MutexService : IPrimeCounter
{
    /// <summary>
    /// Mutex для синхронизации доступа к общим ресурсам.
    /// </summary>
    private readonly Mutex _mutex = new();

    /// <inheritdoc/>
    public PrimeCountResultDto CountPrimes(int start, int end, int threadCount)
    {
        int primeCount = 0;
        List<int> foundPrimes = new();
        var stopwatch = Stopwatch.StartNew();
        var threads = new List<Thread>();
        int range = (end - start + 1) / threadCount;

        for (int i = 0; i < threadCount; i++)
        {
            int localStart = start + i * range;
            int localEnd = (i == threadCount - 1) ? end : localStart + range - 1;

            Thread t = new Thread(() =>
            {
                for (int num = localStart; num <= localEnd; num++)
                {
                    Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Проверка числа: {num}");

                    if (PrimeUtils.IsPrime(num))
                    {
                        _mutex.WaitOne();
                        try
                        {
                            primeCount++;
                            foundPrimes.Add(num);
                        }
                        finally
                        {
                            _mutex.ReleaseMutex();
                        }
                    }
                }
            });
            threads.Add(t);
            t.Start();
        }

        foreach (var t in threads) t.Join();
        stopwatch.Stop();

        return new PrimeCountResultDto
        {
            PrimeCount = primeCount,
            ExecutionTime = stopwatch.Elapsed,
            ThreadCount = threadCount,
            SynchronizationType = "Mutex",
            FoundPrimes = foundPrimes
        };
    }

    /// <inheritdoc/>
    public string GetVersionName() => "Версия 2. Использует Mutex для синхронизации";
}
