using Study.LabWork1.Shared.Services;

namespace Study.LabWork1;

/// <summary>
/// Начальная точка входа
/// </summary>
public static class Program
{
    /// <summary>
    /// Номер выполняемой задачи
    /// </summary>
    private const int RUN_TASK_NUMBER = 1;

    /// <summary>
    /// Старт программы
    /// </summary>
    public static void Main()
    {
        var service = new RunService();

        service.RunTask1();
        Console.WriteLine();
        service.RunTask2();
    }
}
