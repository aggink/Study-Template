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
    public void RunTask1()
    {

        Console.WriteLine("Hello, World!");
        Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА 1 ЗАДАНИЕ 1 ВАРИАНТ 3"); 

        var p1 = new RGBAPixel(1,2,3,0.9);
        var p2 = new RGBAPixel(-1,-2,-3,-4);
        var p3 = new RGBAPixel(9999,12345,9001,42069);
        var p4 = new RGBAPixel(123.456,0.13,256.257,0.65);
        var p5 = new RGBAPixel(-13.8,11.1,79,0.6);

        Console.WriteLine(p1);
        Console.WriteLine(p2);
        Console.WriteLine(p3);
        Console.WriteLine(p4);
        Console.WriteLine(p5);

        Console.Write(p1);
        Console.Write(" + ");
        Console.Write(p4);
        Console.Write(" = ");
        Console.WriteLine(p1 + p4);

        Console.Write(p4);
        Console.Write(" - ");
        Console.Write(p1);
        Console.Write(" = ");
        Console.WriteLine(p4 - p1);

        Console.Write(p1);
        Console.Write(" * ");
        Console.Write(p4);
        Console.Write(" = ");
        Console.WriteLine(p1 * p4);

        Console.Write(p1);
        Console.Write(" * ");
        Console.Write(389);
        Console.Write(" = ");
        Console.WriteLine(p1 * 389);

        Console.Write(p1);
        Console.Write(" / ");
        Console.Write(2);
        Console.Write(" = ");
        Console.WriteLine(p1 / 2);

        Console.Write(p1);
        Console.Write(" == ");
        Console.Write(p2);
        Console.Write(" = ");
        Console.WriteLine(p1 == p2);

        Console.Write(p1);
        Console.Write(" == ");
        Console.Write(p1);
        Console.Write(" = ");
        Console.WriteLine(p1 == p1);

        Console.Write(p1);
        Console.Write(" != ");
        Console.Write(p2);
        Console.Write(" = ");
        Console.WriteLine(p1 != p2);

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
