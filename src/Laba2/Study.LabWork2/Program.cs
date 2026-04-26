using System;
using Study.LabWork2.Feature.Task1.SubTask1;
using Study.LabWork2.Feature.Task1.SubTask2;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;

namespace Study.LabWork2;

/// <summary>
/// Точка входа в приложение лабораторной работы №2.
/// </summary>
public static class Program
{
    /// <summary>
    /// Главная точка входа в приложение.
    /// </summary>
    /// <remarks>
    /// Выполняет последовательно:
    /// 1. Задание 1.1 — подсчёт простых чисел тремя версиями с разной синхронизацией.
    /// 2. Задание 1.2 — обработка наборов чисел с ограничением потоков.
    /// </remarks>
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== Задание 1.1 ===\n");

        const int start = 1;
        const int end = 10000;
        const int threadCount = 4;

        IPrimeCounter[] versions = new IPrimeCounter[]
        {
            new MonitorService(),
            new MutexService(),
            new SemaphoreService()
        };

        foreach (var version in versions)
        {
            Console.WriteLine($"Запуск: {version.GetVersionName()}");
            var result = version.CountPrimes(start, end, threadCount);
            Console.WriteLine(result.ToString());
            Console.WriteLine(new string('-', 60));
        }

        Console.WriteLine("\n=== Задание 1.2 ===\n");

        var processor = new NumberSetProcessor();
        processor.Process();
        var procResult = processor.GetResult();

        Console.WriteLine("Результаты по наборам:");
        foreach (var entry in procResult.Results)
        {
            Console.WriteLine($"  {entry.ToString()}");
        }

        Console.WriteLine($"\nОбщий итог: {procResult.TotalSum}");
        Console.WriteLine($"Время выполнения: {procResult.ExecutionTime.TotalMilliseconds:F2} мс");
        Console.WriteLine($"Обработано наборов: {procResult.ProcessedSetsCount}");

        Console.WriteLine("\nРабота завершена.");
        Console.ReadLine();
    }
}
