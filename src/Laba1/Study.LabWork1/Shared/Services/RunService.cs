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
        var color1 = new HSL(210, 50, 60);
        var color2 = new HSL(100, 20, 30);
        var sum = color1 + color2;
        var mul = color1 * 2;
        Console.WriteLine(color1);
        Console.WriteLine(sum);
        Console.WriteLine(mul);
        var rgb = color1.ToRGB();
        Console.WriteLine($"RGB: {rgb.R}, {rgb.G}, {rgb.B}");
        Console.WriteLine($"HEX: {color1.ToHEX()}");
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
