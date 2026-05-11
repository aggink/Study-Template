using System;
using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2.Task2
{
    class Program
    {
        static void Main()
        {
            int start = 1;
            int end = 10000;
            int threadCount = Environment.ProcessorCount;

            Console.WriteLine($"Подсчёт простых чисел от {start} до {end} в {threadCount} потоках.\n");

            // Монитор
            Console.WriteLine("=== Monitor (lock) ===");
            var monitor = new MonitorService();
            var result1 = monitor.CountPrimes(start, end, threadCount);
            Console.WriteLine($"Простых чисел: {result1.GetType().GetProperty("PrimeCount")?.GetValue(result1) ?? result1.GetType().GetProperty("Count")?.GetValue(result1)}, " +
                              $"время: {result1.GetType().GetProperty("ElapsedMilliseconds")?.GetValue(result1) ?? result1.GetType().GetProperty("DurationMs")?.GetValue(result1)} мс\n");

            // Мьютекс
            Console.WriteLine("=== Mutex ===");
            var mutex = new MutexService();
            var result2 = mutex.CountPrimes(start, end, threadCount);
            Console.WriteLine($"Простых чисел: {result2.GetType().GetProperty("PrimeCount")?.GetValue(result2) ?? result2.GetType().GetProperty("Count")?.GetValue(result2)}, " +
                              $"время: {result2.GetType().GetProperty("ElapsedMilliseconds")?.GetValue(result2) ?? result2.GetType().GetProperty("DurationMs")?.GetValue(result2)} мс\n");

            // Семафор
            Console.WriteLine("=== Semaphore ===");
            var sem = new SemaphoreService();
            var result3 = sem.CountPrimes(start, end, threadCount);
            Console.WriteLine($"Простых чисел: {result3.GetType().GetProperty("PrimeCount")?.GetValue(result3) ?? result3.GetType().GetProperty("Count")?.GetValue(result3)}, " +
                              $"время: {result3.GetType().GetProperty("ElapsedMilliseconds")?.GetValue(result3) ?? result3.GetType().GetProperty("DurationMs")?.GetValue(result3)} мс\n");

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
