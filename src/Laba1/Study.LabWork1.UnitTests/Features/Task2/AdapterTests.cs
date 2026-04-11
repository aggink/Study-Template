using Study.LabWork1.Features.Task2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.UnitTests.Features.Task2
{
    public class AdapterTests
    {
        public static void Test()
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
    }
}
