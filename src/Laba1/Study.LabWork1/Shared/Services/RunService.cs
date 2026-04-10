using Study.LabWork1.Features.Task1;
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
    public void RunTask1()
    {
        MySet<int> set1 = new MySet<int>(new List<int> { 1, 2, 2, 3, 4 });
        MySet<int> set2 = new MySet<int>(new List<int> { 3, 4, 5, 6 });
        MySet<int> set3 = new MySet<int>(new List<int> { 4, 3, 2, 1 });

        Console.WriteLine("set1 = " + set1);
        Console.WriteLine("set2 = " + set2);
        Console.WriteLine("set3 = " + set3);
        Console.WriteLine();

        Console.WriteLine("Объединение: " + (set1 | set2));
        Console.WriteLine("Разность: " + (set1 - set2));
        Console.WriteLine("Пересечение: " + (set1 & set2));
        Console.WriteLine("Симметрическая разность: " + (set1 / set2));
        Console.WriteLine();

        Console.WriteLine("set1 == set3: " + (set1 == set3));
        Console.WriteLine("set1 != set2: " + (set1 != set2));
    }
   
    /// <summary>
    /// Задание 2
    /// </summary>
    public void RunTask2() => throw new NotImplementedException();

    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3() => throw new NotImplementedException();
}
