using Study.LabWork1.Features.Task3;
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
    }
}
