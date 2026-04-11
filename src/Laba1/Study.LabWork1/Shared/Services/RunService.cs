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
    public void RunTask1() {
        Console.WriteLine("==== Тесты Pixel ====\n");

        var p1 = new Pixel(255, 0, 0);
        var p2 = new Pixel(0, 255, 0, 0.5f);
        var p3 = new Pixel(0, 0, 255, 1.0f);
        var p4 = new Pixel();
        var p5 = new Pixel(255, 0, 0, 1f);
        var p6 = new Pixel(300, -50, 255, 1.5f);
        var p7 = new Pixel(100, 100, 100, 0.8f);

        Console.WriteLine($"p1 = {p1}");
        Console.WriteLine($"p2 = {p2}");
        Console.WriteLine($"p3 = {p3}");
        Console.WriteLine($"p4 = {p4}");
        Console.WriteLine($"p5 = {p5}");
        Console.WriteLine($"p6 (300, -50, 255, 1.5f) = {p6}");
        Console.WriteLine($"p7 = {p7}\n");

        Console.WriteLine($"p1 + p2 = {p1 + p2}");
        Console.WriteLine($"p1 - p2 = {p1 - p2}");
        Console.WriteLine($"p1 * 1.5f = {p1 * 1.5f}");
        Console.WriteLine($"p1 / 2f = {p1 / 2f}\n");

        Console.WriteLine($"p1 == p2: {p1 == p2}");
        Console.WriteLine($"p1 != p2: {p1 != p2}");
        Console.WriteLine($"p1 == p2: {p1 == p5}");
        Console.WriteLine($"p1 != p2: {p1 != p5}\n");

        Console.WriteLine($"p5 = {p5}");

        Console.WriteLine($"p1 в HEX: {p1.PixelToHex()}");
        Console.WriteLine($"p2 в HEX: {p2.PixelToHex()}\n");

        Console.WriteLine($"p7 * 2 = {p7 * 2}");
        Console.WriteLine($"p7 / 2 = {p7 / 2}\n");

        Console.WriteLine("==== Тесты пройдены ====");
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
