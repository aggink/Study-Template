using Study.LabWork1.Shared.Services;

namespace Study.LabWork1;

/// <summary>
/// Начальная точка входа
/// </summary>
public static class Program
{
    /// <summary>
    /// Номер выполняемой задачи
<<<<<<< task-3
    /// </summary>
    private const int RUN_TASK_NUMBER = 3;

=======
    /// </summary
>>>>>>> main
    /// <summary>
    /// Старт программы
    /// </summary>
    public static void Main()
    {
        Console.WriteLine("Выберите задание (1, 2 или 3):");//1
        int RUN_TASK_NUMBER = int.Parse(Console.ReadLine());

        var service = new RunService();

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
//
