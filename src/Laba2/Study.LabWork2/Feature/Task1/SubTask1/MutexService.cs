using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1;

public sealed class MutexService : IPrimeCounter
{
    private readonly Mutex _gate = new Mutex();

    private int _totalPrimes;
    private readonly List<int> _numbers = new List<int>();

    public PrimeCountResultDto CountPrimes(int start, int end, int threadCount)
    {
        Validate(start, end, threadCount);

        _totalPrimes = 0;
        _numbers.Clear();

        var watch = Stopwatch.StartNew();

        Thread[] jobs = PrepareJobs(start, end, threadCount);

        foreach (Thread job in jobs)
        {
            job.Start();
        }

        foreach (Thread job in jobs)
        {
            job.Join();
        }

        watch.Stop();

        return new PrimeCountResultDto
        {
            PrimeCount = _totalPrimes,
            ExecutionTime = watch.Elapsed,
            ThreadCount = threadCount,
            SynchronizationType = GetVersionName(),
            FoundPrimes = _numbers.OrderBy(number => number).ToList()
        };
    }

    public string GetVersionName()
    {
        return "Mutex";
    }

    private Thread[] PrepareJobs(int start, int finish, int count)
    {
        int quantity = finish - start + 1;
        int onePart = quantity / count;
        int additional = quantity % count;

        Thread[] result = new Thread[count];

        int nextStart = start;

        for (int i = 0; i < count; i++)
        {
            int jobNumber = i + 1;
            int rangeStart = nextStart;
            int rangeSize = onePart + (i < additional ? 1 : 0);
            int rangeFinish = rangeStart + rangeSize - 1;

            result[i] = new Thread(() => HandleRange(rangeStart, rangeFinish, jobNumber));

            nextStart = rangeFinish + 1;
        }

        return result;
    }

    private void HandleRange(int left, int right, int workerNumber)
    {
        for (int candidate = left; candidate <= right; candidate++)
        {
            Console.WriteLine($"Поток {workerNumber}: проверяется число {candidate}");

            if (IsPrime(candidate))
            {
                _gate.WaitOne();

                try
                {
                    _totalPrimes++;
                    _numbers.Add(candidate);

                    Console.WriteLine($"Поток {workerNumber}: найдено простое число {candidate}");
                }
                finally
                {
                    _gate.ReleaseMutex();
                }
            }
        }
    }

    private static bool IsPrime(int candidate)
    {
        if (candidate < 2)
        {
            return false;
        }

        if (candidate == 2)
        {
            return true;
        }

        if (candidate % 2 == 0)
        {
            return false;
        }

        int maxDivider = (int)Math.Sqrt(candidate);

        for (int divider = 3; divider <= maxDivider; divider += 2)
        {
            if (candidate % divider == 0)
            {
                return false;
            }
        }

        return true;
    }

    private static void Validate(int start, int end, int threads)
    {
        if (start > end)
        {
            throw new ArgumentException("Некорректный диапазон.");
        }

        if (threads <= 0)
        {
            throw new ArgumentException("Количество потоков должно быть положительным.");
        }
    }
}
