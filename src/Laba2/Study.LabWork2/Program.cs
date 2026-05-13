using Study.LabWork2.Feature.Task1.SubTask2;

namespace Study.LabWork2;

public static class Program
{
    public static void Main()
    {
        var processor = new NumberSetProcessor();

        processor.Process();

        var result = processor.GetResult();

        foreach (var item in result.Results)
        {
            Console.WriteLine(
                $"Набор {item.SetNumber}: сумма = {item.Sum}, поток = {item.ThreadId}");
        }

        Console.WriteLine($"\nОбщий итог: {result.TotalSum}");
        Console.WriteLine($"Время выполнения: {result.ExecutionTime.TotalMilliseconds} мс");
    }
}
