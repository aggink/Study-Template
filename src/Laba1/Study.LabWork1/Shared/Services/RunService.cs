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
        // Создаем первую матрицу
        Matrix a = new Matrix(new double[,]
        {
            { 2.21, 4.22 },
            { 6.12, 8.67 }
        });

        // Создаем вторую матрицу
        Matrix b = new Matrix(new double[,]
        {
            { 2, 0 },
            { 0, 2 }
        });

        // Создаем третью матрицу для нахождения обратной матрицы
        Matrix d = new Matrix(new double[,]
        {
            { 1.34, 2.24 },
            { 3.77, 4.78 }
        });

        // Выводим исходные матрицы
        Console.WriteLine("Матрица a:");
        Console.WriteLine(a);
        Console.WriteLine();

        Console.WriteLine("Матрица b:");
        Console.WriteLine(b);
        Console.WriteLine();

        Console.WriteLine("Матрица d:");
        Console.WriteLine(d);
        Console.WriteLine();

        // Показываем количество строк и столбцов
        Console.WriteLine("Rows и Columns для a:");
        Console.WriteLine($"Rows = {a.Rows}, Columns = {a.Columns}");
        Console.WriteLine();

        // Проверяем сложение матриц
        Console.WriteLine("a + b:");
        Console.WriteLine(a + b);
        Console.WriteLine();

        // Проверяем транспонирование матрицы
        Console.WriteLine("Транспонирование ~a:");
        Console.WriteLine(~a);
        Console.WriteLine();

        // Проверяем умножение матриц
        Console.WriteLine("a * b:");
        Console.WriteLine(a * b);
        Console.WriteLine();

        // Находим определитель матрицы a
        Console.WriteLine("Определитель a:");
        Console.WriteLine(a.Determinant());
        Console.WriteLine();

        // Находим определитель матрицы d
        Console.WriteLine("Определитель d:");
        Console.WriteLine(d.Determinant());
        Console.WriteLine();

        // Находим обратную матрицу для d
        Console.WriteLine("Обратная матрица для d:");
        Console.WriteLine(d.Inverse());
        Console.WriteLine();

        // Проверяем, что произведение матрицы на обратную дает единичную матрицу
        Console.WriteLine("Проверка d * d.Inverse():");
        Console.WriteLine(d * d.Inverse());
        Console.WriteLine();

        // Проверяем умножение матрицы на обратную
        Console.WriteLine("a / b:");
        Console.WriteLine(a / b);
        Console.WriteLine();

        // Проверяем операторы сравнения по определителю
        Console.WriteLine("Сравнение матриц по определителю:");
        Console.WriteLine($"a == b : {a == b}");
        Console.WriteLine($"a != b : {a != b}");
        Console.WriteLine($"a > b  : {a > b}");
        Console.WriteLine($"a < b  : {a < b}");
        Console.WriteLine($"a >= b : {a >= b}");
        Console.WriteLine($"a <= b : {a <= b}");
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
