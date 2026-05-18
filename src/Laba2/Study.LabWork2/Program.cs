using System.Text;
using System.Text.Json;
using Study.LabWork2.Abstractions.Feature.Task2.DtoModels;
using Study.LabWork2.Feature.Task1.SubTask1;
using Study.LabWork2.Feature.Task1.SubTask2;
using Study.LabWork2.Feature.Task2;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Лабораторная работа 2");
Console.WriteLine("Виды операций и решение проблем узкого горлышка");
Console.WriteLine();

ShowPrimeCounterDemo();
ShowNumberPacksDemo();
ShowServerRequestsDemo();

Console.WriteLine();
Console.WriteLine("Выполнение завершено.");
Console.ReadKey();

static void ShowPrimeCounterDemo()
{
    Console.WriteLine("========== Задание 1.1 ==========");
    Console.WriteLine("Подсчёт простых чисел в диапазоне от 1 до 10000");
    Console.WriteLine();

    const int leftBorder = 1;
    const int rightBorder = 10_000;
    const int workersAmount = 4;

    var monitorCounter = new MonitorService();
    var monitorData = monitorCounter.CountPrimes(leftBorder, rightBorder, workersAmount);

    PrintPrimeResult("Monitor", monitorData.PrimeCount, monitorData.ExecutionTime);

    var mutexCounter = new MutexService();
    var mutexData = mutexCounter.CountPrimes(leftBorder, rightBorder, workersAmount);

    PrintPrimeResult("Mutex", mutexData.PrimeCount, mutexData.ExecutionTime);

    var semaphoreCounter = new SemaphoreService();
    var semaphoreData = semaphoreCounter.CountPrimes(leftBorder, rightBorder, workersAmount);

    PrintPrimeResult("Semaphore", semaphoreData.PrimeCount, semaphoreData.ExecutionTime);
}

static void ShowNumberPacksDemo()
{
    Console.WriteLine("========== Задание 1.2 ==========");
    Console.WriteLine("Обработка 15 сохранённых наборов чисел");
    Console.WriteLine();

    string projectFolder = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\.."));
    string storageFolder = Path.Combine(projectFolder, "Data");

    Directory.CreateDirectory(storageFolder);

    string sourceFile = Path.Combine(storageFolder, "student_number_packs.txt");

    Console.WriteLine($"Файл с наборами чисел: {sourceFile}");
    Console.WriteLine();

    var packProcessor = new NumberSetProcessor(
        maxConcurrentThreads: 3,
        setsFilePath: sourceFile
    );

    packProcessor.Process();

    var report = packProcessor.GetResult();

    foreach (var row in report.Results)
    {
        Console.WriteLine($"Набор {row.SetNumber}: сумма = {row.Sum}, поток = {row.ThreadId}");
    }

    Console.WriteLine();
    Console.WriteLine($"Всего обработано наборов: {report.ProcessedSetsCount}");
    Console.WriteLine($"Общая сумма: {report.TotalSum}");
    Console.WriteLine($"Время выполнения: {report.ExecutionTime}");
    Console.WriteLine();
}

static void ShowServerRequestsDemo()
{
    Console.WriteLine("========== Задание 2 ==========");
    Console.WriteLine("Сравнение синхронных и асинхронных запросов");
    Console.WriteLine();

    ServerConfigDto[] apiList =
    {
        new ServerConfigDto
        {
            Name = "Post",
            Url = "https://jsonplaceholder.typicode.com/posts/4"
        },
        new ServerConfigDto
        {
            Name = "User",
            Url = "https://jsonplaceholder.typicode.com/users/2"
        },
        new ServerConfigDto
        {
            Name = "Todo",
            Url = "https://jsonplaceholder.typicode.com/todos/7"
        }
    };

    var syncClient = new SynchronousServerRequestApp();
    var syncResult = syncClient.ExecuteRequests<JsonElement>(apiList);

    Console.WriteLine();
    Console.WriteLine("Итог синхронной версии:");
    Console.WriteLine($"Успешных запросов: {syncResult.SuccessfulRequests}");
    Console.WriteLine($"Ошибочных запросов: {syncResult.FailedRequests}");
    Console.WriteLine($"Время: {syncResult.TotalExecutionTime}");
    Console.WriteLine();

    var asyncClient = new AsynchronousServerRequestApp();
    var asyncResult = asyncClient.ExecuteRequests<JsonElement>(apiList);

    Console.WriteLine();
    Console.WriteLine("Итог асинхронной версии:");
    Console.WriteLine($"Успешных запросов: {asyncResult.SuccessfulRequests}");
    Console.WriteLine($"Ошибочных запросов: {asyncResult.FailedRequests}");
    Console.WriteLine($"Время: {asyncResult.TotalExecutionTime}");
    Console.WriteLine();
}

static void PrintPrimeResult(string title, int amount, TimeSpan elapsed)
{
    Console.WriteLine();
    Console.WriteLine($"Результат версии {title}:");
    Console.WriteLine($"Количество простых чисел: {amount}");
    Console.WriteLine($"Время выполнения: {elapsed}");
    Console.WriteLine();
}
