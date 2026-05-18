using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1;

public sealed class SemaphoreService : IPrimeCounter
{
    private Semaphore? _oneThreadZone;

    private int _primeAmount;
    private readonly List<int> _detectedPrimes = new List<int>();

    public PrimeCountResultDto CountPrimes(int start, int end, int threadCount)
    {
        EnsureCorrectInput(start, end, threadCount);

        _primeAmount = 0;
        _detectedPrimes.Clear();
        _oneThreadZone = new Semaphore(1, 1);

        Thread[] threadPool = MakeThreadPool(start, end, threadCount);

        var clock = Stopwatch.StartNew();

        foreach (Thread thread in threadPool)
        {
            thread.Start();
        }

        foreach (Thread thread in threadPool)
        {
            thread.Join();
        }

        clock.Stop();

        return new PrimeCountResultDto
        {
            PrimeCount = _primeAmount,
            ExecutionTime = clock.Elapsed,
            ThreadCount = threadCount,
            SynchronizationType = GetVersionName(),
            FoundPrimes = _detectedPrimes.OrderBy(item => item).ToList()
        };
    }

    public string GetVersionName()
    {
        return "Semaphore";
    }

    private Thread[] MakeThreadPool(int begin, int finish, int threadCount)
    {
        int numbersCount = finish - begin + 1;
        int standardChunk = numbersCount / threadCount;
        int bonus = numbersCount % threadCount;

        Thread[] pool = new Thread[threadCount];

        int currentBegin = begin;

        for (int i = 0; i < threadCount; i++)
        {
            int printedThreadIndex = i + 1;
            int localBegin = currentBegin;
            int localChunk = standardChunk + (i < bonus ? 1 : 0);
            int localFinish = localBegin + localChunk - 1;

            pool[i] = new Thread(() => CheckPart(localBegin, localFinish, printedThreadIndex));

            currentBegin = localFinish + 1;
        }

        return pool;
    }

    private void CheckPart(int begin, int finish, int threadIndex)
    {
        for (int current = begin; current <= finish; current++)
        {
            Console.WriteLine($"Поток {threadIndex}: проверяется число {current}");

            if (!PrimeCheck(current))
            {
                continue;
            }

            _oneThreadZone!.WaitOne();

            try
            {
                _primeAmount++;
                _detectedPrimes.Add(current);

                Console.WriteLine($"Поток {threadIndex}: найдено простое число {current}");
            }
            finally
            {
                _oneThreadZone.Release();
            }
        }
    }

    private static bool PrimeCheck(int number)
    {
        if (number < 2)
        {
            return false;
        }

        if (number == 2)
        {
            return true;
        }

        if (number % 2 == 0)
        {
            return false;
        }

        int finish = (int)Math.Sqrt(number);

        for (int i = 3; i <= finish; i += 2)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    private static void EnsureCorrectInput(int start, int end, int threadCount)
    {
        if (start > end)
        {
            throw new ArgumentException("Левая граница диапазона больше правой.");
        }

        if (threadCount <= 0)
        {
            throw new ArgumentException("Количество потоков должно быть больше нуля.");
        }
    }
}
