using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask2;

/// <summary>
/// Реализация процессора наборов чисел с многопоточной обработкой
/// и синхронизацией через Semaphore, Monitor и Mutex.
/// </summary>
public sealed class NumberSetProcessor : INumberSetProcessor
{
    /// <summary>
    /// Количество наборов чисел для обработки.
    /// </summary>
    private const int SetsCount = 15;

    /// <summary>
    /// Количество чисел в каждом наборе.
    /// </summary>
    private const int NumbersPerSet = 100;

    /// <summary>
    /// Максимальное количество одновременно работающих потоков.
    /// </summary>
    private const int MaxConcurrentThreads = 3;

    /// <summary>
    /// Путь к файлу для сохранения/загрузки наборов чисел.
    /// </summary>
    private const string FilePath = "data_sets.json";

    /// <summary>
    /// Массив наборов чисел для обработки.
    /// </summary>
    private int[][] _sets = Array.Empty<int[]>();

    /// <summary>
    /// Кэшированный результат обработки.
    /// </summary>
    private ProcessingResultDto _cachedResult;

    /// <inheritdoc/>
    public void Process()
    {
        LoadOrGenerateSets();

        var resultsList = new List<ResultEntryDto>();
        var resultsLock = new object();
        var totalMutex = new Mutex();
        int grandTotal = 0;

        var semaphore = new Semaphore(MaxConcurrentThreads, MaxConcurrentThreads);
        var stopwatch = Stopwatch.StartNew();
        var threads = new List<Thread>();

        for (int i = 0; i < SetsCount; i++)
        {
            int setIndex = i;
            Thread t = new Thread(() =>
            {
                semaphore.WaitOne();
                try
                {
                    int currentSum = 0;
                    foreach (int num in _sets[setIndex])
                        currentSum += num;

                    lock (resultsLock)
                    {
                        resultsList.Add(new ResultEntryDto
                        {
                            SetNumber = setIndex + 1,
                            Sum = currentSum,
                            ThreadId = Thread.CurrentThread.ManagedThreadId
                        });
                    }

                    totalMutex.WaitOne();
                    try
                    {
                        grandTotal += currentSum;
                    }
                    finally
                    {
                        totalMutex.ReleaseMutex();
                    }
                }
                finally
                {
                    semaphore.Release();
                }
            });

            threads.Add(t);
            t.Start();
        }

        foreach (var t in threads) t.Join();
        stopwatch.Stop();

        _cachedResult = new ProcessingResultDto
        {
            Results = resultsList,
            TotalSum = grandTotal,
            ExecutionTime = stopwatch.Elapsed,
            ProcessedSetsCount = SetsCount
        };
    }

    /// <inheritdoc/>
    public ProcessingResultDto GetResult() => _cachedResult ?? throw new InvalidOperationException("Сначала вызовите Process()");

    /// <summary>
    /// Загружает наборы чисел из файла или генерирует новые, если файл не существует.
    /// </summary>
    /// <remarks>
    /// Используется фиксированный seed (42) для детерминированной генерации,
    /// чтобы результаты можно было воспроизводить и проверять.
    /// </remarks>
    private void LoadOrGenerateSets()
    {
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            _sets = JsonSerializer.Deserialize<int[][]>(json) ?? throw new InvalidOperationException("Файл повреждён");
        }
        else
        {
            var rnd = new Random(42);
            _sets = new int[SetsCount][];
            for (int i = 0; i < SetsCount; i++)
            {
                _sets[i] = new int[NumbersPerSet];
                for (int j = 0; j < NumbersPerSet; j++)
                    _sets[i][j] = rnd.Next(1, 101);
            }
            File.WriteAllText(FilePath, JsonSerializer.Serialize(_sets));
            Console.WriteLine("Наборы чисел сгенерированы и сохранены в data_sets.json");
        }
    }
}
