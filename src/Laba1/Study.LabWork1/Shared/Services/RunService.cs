<<<<<<< task-3
using Study.LabWork1.Features.Task3;
=======
using Study.LabWork1.Features.Task1;
using Study.LabWork1.Features.Task2;
>>>>>>> main
using Study.LabWork1.Shared.Abstractions;

namespace Study.LabWork1.Shared.Services;
//
public class RunService : IRunService
{
<<<<<<< task-3
    /// <summary>
    /// Задание 1
    /// </summary>
    public void RunTask1() => throw new NotImplementedException();

    /// <summary>
    /// Задание 2
    /// </summary>
    public void RunTask2() => throw new NotImplementedException();

    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3()
    {
        Console.WriteLine("==== Тесты TreeNode ====");

        var root = new TreeNode("Корень");
        var child1 = new TreeNode("Потомок 1");
        var child2 = new TreeNode("Потомок 2");
        var grandChild1 = new TreeNode("Внук 1.1");

        root.AddChild(child1);
        root.AddChild(child2);
        child1.AddChild(grandChild1);

        Console.WriteLine("Результат вывода:");
        root.PrintAllValues();
=======
    public void RunTask1()
    {
        Console.WriteLine("=== ЗАДАНИЕ 1. МАТРИЦЫ ===\n");

        var a = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
        var b = new Matrix(new double[,] { { 5, 6 }, { 7, 8 } });
        var unit = new Matrix(new double[,] { { 1, 0 }, { 0, 1 } });
        var c = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });

        Console.WriteLine("Матрица A:");
        Console.WriteLine(a);
        Console.WriteLine("Матрица B:");
        Console.WriteLine(b);
        Console.WriteLine("Единичная матрица E:");
        Console.WriteLine(unit);

        Console.WriteLine($"det(A) = {a.Determinant}");
        Console.WriteLine($"det(B) = {b.Determinant}");
        Console.WriteLine($"det(E) = {unit.Determinant}");

        Console.WriteLine("\nA + B:");
        Console.WriteLine(a + b);

        Console.WriteLine("\n~A:");
        Console.WriteLine(~a);

        Console.WriteLine("\nA * B:");
        Console.WriteLine(a * b);

        Console.WriteLine($"\nA == B: {a == b}");
        Console.WriteLine($"E == A: {unit == a}");
        Console.WriteLine($"A != B: {a != b}");
        Console.WriteLine($"E != A: {unit != a}");
    }

    public void RunTask2()
    {
        Console.WriteLine("=== ЗАДАНИЕ 2. СТРАТЕГИЯ СКИДОК ===\n");

        double orderAmount = 1000;
        var context = new Context(new NoDiscStrat());

        Console.WriteLine($"Сумма заказа: {orderAmount} руб.\n");

        context.SetStrategy(new NoDiscStrat());
        Console.WriteLine($"Без скидки: {context.ApplyDiscount(orderAmount)} руб.");

        context.SetStrategy(new PercDiscStrat(20));
        Console.WriteLine($"Скидка 20%: {context.ApplyDiscount(orderAmount)} руб.");

        context.SetStrategy(new FixedDiscStrat(150));
        Console.WriteLine($"Скидка 150 руб: {context.ApplyDiscount(orderAmount)} руб.");

        context.SetStrategy(new SeasonDiscStrat());
        Console.WriteLine($"Сезонная скидка 15%: {context.ApplyDiscount(orderAmount)} руб.");
    }

    public void RunTask3()
    {
        Console.WriteLine("====== IN PROGRESS... ======");
>>>>>>> main
    }
}
