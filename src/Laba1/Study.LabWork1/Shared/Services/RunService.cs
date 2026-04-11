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
        Console.WriteLine("Класс комплексных чисел ComplexNumber\n");

        var a = new ComplexNumber(3.1, 2);
        var b = new ComplexNumber(1, -7);
        var c = new ComplexNumber(0, 5);
        var d = new ComplexNumber(4, 0);
        var f = new ComplexNumber();

        Console.WriteLine($"a = {a}");
        Console.WriteLine($"b = {b}");
        Console.WriteLine($"c = {c}");
        Console.WriteLine($"d = {d}");
        Console.WriteLine($"f = {f}");

        Console.WriteLine($"\nУнарный +a = {+a}");
        Console.WriteLine($"Унарный -a = {-a}");

        Console.WriteLine($"\na + b = {a + b}");
        Console.WriteLine($"a - b = {a - b}");
        Console.WriteLine($"a * b = {a * b}");
        Console.WriteLine($"a / b = {a / b}");

        Console.WriteLine($"\na == b ? {a == b}");
        Console.WriteLine($"a != b ? {a != b}");
        Console.WriteLine($"a == new ComplexNumber(3.1,2) ? {a == new ComplexNumber(3.1, 2)}");

        Console.WriteLine("\nНажмите любую клавишу для продолжения...");
        Console.ReadKey();
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
