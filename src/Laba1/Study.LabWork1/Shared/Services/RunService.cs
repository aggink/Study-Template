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
        Matrix a = new Matrix(new double[,]
        {
                { 1, 2 },
                { 3, 4 }
        });

        Matrix b = new Matrix(new double[,]
        {
                { 5, 6 },
                { 7, 8 }
        });

        Console.WriteLine("Матрица A:");
        Console.WriteLine(a);
        Console.WriteLine();

        Console.WriteLine("Матрица B:");
        Console.WriteLine(b);
        Console.WriteLine();


        Console.WriteLine($"Определитель A: {a.Determinant}");
        Console.WriteLine($"Определитель B: {b.Determinant}");
        Console.WriteLine();

        Console.WriteLine($"A == B: {a == b}");
        Console.WriteLine($"A != B: {a != b}");
        Console.WriteLine($"A > B: {a > b}");
        Console.WriteLine($"A < B: {a < b}");
        Console.WriteLine(); }

      /// <summary>
      /// Задание 2
      /// </summary>
        public void RunTask2() {
    }

    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3()
    {
    }
}

