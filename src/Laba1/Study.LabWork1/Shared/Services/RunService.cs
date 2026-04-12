using Study.LabWork1.Shared.Abstractions;
using Study.LabWork1.Features.Task1;
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
        Console.WriteLine("Task 1: Matrix");

        var first = new Matrix(new double[,]
        {
            { 1, 2 },
            { 3, 4 }
        });

        var second = new Matrix(new double[,]
        {
            { 2, 0 },
            { 1, 2 }
        });

        Console.WriteLine("First matrix:");
        Console.WriteLine(first);
        Console.WriteLine();

        Console.WriteLine("Second matrix:");
        Console.WriteLine(second);
        Console.WriteLine();

        Console.WriteLine("first + second:");
        Console.WriteLine(first + second);
        Console.WriteLine();

        Console.WriteLine("first * second:");
        Console.WriteLine(first * second);
        Console.WriteLine();

        Console.WriteLine("transpose(first):");
        Console.WriteLine(~first);
        Console.WriteLine();

        Console.WriteLine($"det(first) = {first.Determinant:0.00}");
        Console.WriteLine($"det(second) = {second.Determinant:0.00}");
        Console.WriteLine($"first > second -> {first > second}");
    }

    /// <summary>
    /// Задание 2
    /// </summary>
    public void RunTask2() => Console.WriteLine("Еще не сделано");

    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3() => Console.WriteLine("Еще не сделано");
}
