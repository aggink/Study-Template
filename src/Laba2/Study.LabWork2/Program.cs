using Study.LabWork2.Feature.Task1.SubTask1;
using Study.LabWork2.Feature.Task1.SubTask2;

namespace Study.LabWork2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("================================================");
        Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА 2 - ЗАДАНИЕ 1");
        Console.WriteLine("================================================\n");

        // ========== ЗАДАНИЕ 1.1 ==========
        Console.WriteLine("=== ЗАДАНИЕ 1.1 - Поиск простых чисел ===\n");

        int startRange = 1;
        int endRange = 10000;
        int threadCount = 4;
         // Monitor
        MonitorService monitorService = new MonitorService();
        Console.WriteLine($"\n--- {monitorService.GetVersionName()} ---");
        var result1 = monitorService.CountPrimes(startRange, endRange, threadCount);
        Console.WriteLine(result1.ToString());

        // Mutex
        MutexService mutexService = new MutexService();
        Console.WriteLine($"\n--- {mutexService.GetVersionName()} ---");
        var result2 = mutexService.CountPrimes(startRange, endRange, threadCount);
        Console.WriteLine(result2.ToString());

        // Semaphore
        SemaphoreService semaphoreService = new SemaphoreService();
        Console.WriteLine($"\n--- {semaphoreService.GetVersionName()} ---");
        var result3 = semaphoreService.CountPrimes(startRange, endRange, threadCount);
        Console.WriteLine(result3.ToString());

        // ========== ЗАДАНИЕ 1.2 ==========
        Console.WriteLine("\n\n=== ЗАДАНИЕ 1.2 - Обработка наборов чисел ===\n");

        string setsFilePath = "number_sets.txt";
        List<List<int>> numberSets;

        if (File.Exists(setsFilePath))
        {
            numberSets = NumberSetProcessor.LoadSetsFromFile(setsFilePath);
        }
        else
        {
            
            numberSets = NumberSetProcessor.GenerateNumberSets(15, 100);
            NumberSetProcessor.SaveSetsToFile(numberSets, setsFilePath);
        }

        NumberSetProcessor processor = new NumberSetProcessor(numberSets, 3);
        processor.Process();
        var result = processor.GetResult();

        Console.WriteLine($"\nResult: {result.TotalSum}");
        Console.WriteLine($"Time: {result.ExecutionTime.TotalMilliseconds:F2} мс");

        Console.ReadKey();
    }
}
