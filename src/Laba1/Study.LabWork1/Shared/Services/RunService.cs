using Study.LabWork1.Features.Task2;
using Study.LabWork1.Shared.Abstractions;

namespace Study.LabWork1.Shared.Services;

/// <summary>
/// Реализация заданий Л/Р
/// </summary>
public class RunService : IRunService
{
    /// <summary>
    /// Задание 1
    /// </summary>
    public void RunTask1() => throw new NotImplementedException();

    /// <summary>
    /// Задание 2
    /// </summary>
    public void RunTask2()
    {
        Console.WriteLine("==== Тесты Adapter ====\n");
        bool allPassed = true;

        // 2. Тест памяти
        var memRepo = new InMemoryOrderRepository();
        memRepo.Save(new Order { Id = 1, Customer = "Иван", Total = 100m });
        var memResult = memRepo.GetAll();
        bool memOk = memResult.Count == 1 && memResult[0].Customer == "Иван" && memResult[0].Total == 100m;
        allPassed &= memOk;

        // 2. Тест CSV
        string csvPath = "test_adapter_orders.csv";
        if (File.Exists(csvPath)) File.Delete(csvPath);

        var csvRepo = new CsvOrderRepository(new CsvOrderStorage(csvPath));
        csvRepo.Save(new Order { Id = 1, Customer = "Ник", Total = 500m });
        csvRepo.Save(new Order { Id = 2, Customer = "Анна", Total = 750.5m });

        var csvResult = csvRepo.GetAll();
        bool csvOk = csvResult.Count == 2 &&
                     csvResult.Any(o => o.Id == 1 && o.Total == 500m) &&
                     csvResult.Any(o => o.Id == 2 && o.Total == 750.5m);
        allPassed &= csvOk;

        // 3. Проверка файла
        bool fileOk = File.Exists(csvPath) && File.ReadAllLines(csvPath).Length == 3;
        allPassed &= fileOk;

        // Удаление файла
        if (File.Exists(csvPath)) File.Delete(csvPath);

        Console.WriteLine(allPassed ? "Тесты пройдены успешно" : "Тесты не пройдены");
    }

    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3() => throw new NotImplementedException();
}
