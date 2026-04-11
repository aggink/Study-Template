using Study.LabWork1.Shared.Services;

namespace Study.LabWork1;

/// <summary>
/// Начальная точка входа
/// </summary>
public static class Program
{
    /// <summary>
    /// Номер выполняемой задачи
    /// </summary
    /// <summary>
    /// Старт программы
    /// </summary>
    public static void Main()
    {
        Console.WriteLine("Choose Task: 1, 2, 3");
        int RUN_TASK_NUMBER = int.Parse(Console.ReadLine());

        var service = new RunService();

        // todo: можно переписать на ввод с консоли

        switch (RUN_TASK_NUMBER)
        {
            case 1:
                service.RunTask1();
                break;
            case 2:
                service.RunTask2();
                break;
            case 3:
                service.RunTask3();
                break;
            default:
                throw new NotSupportedException();
        }
    }
}
