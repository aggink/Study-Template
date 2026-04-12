using System.Diagnostics.Metrics;
using Study.LabWork1.Shared.Abstractions;
using Study.LabWork1.Features;

namespace Study.LabWork1.Shared.Services;

/// <summary>
/// Реализация заданий Л/Р
/// </summary>
///

public class RunService : IRunService
{
    /// <summary>
    /// Задание 1
    /// </summary>
    public void RunTask1() => throw new NotImplementedException();
    /// <summary>
    /// Задание 2
    /// </summary>
    public void RunTask2()
    {

        Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА 1 ЗАДАНИЕ 2 ВАРИАНТ 4");

        var c = new Client();

        var d1 = new Dud();
        var dudAdapter = new Adapter(d1);
        c.request(dudAdapter, 0);
        c.request(dudAdapter, 1);
        c.request(dudAdapter, 2);

        var b1 = new RealBase();
        c.request(b1, -1);
        c.request(b1, -2);

    }

    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3() => throw new NotImplementedException();
}
