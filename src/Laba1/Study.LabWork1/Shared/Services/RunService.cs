using System.Numerics;
using Study.LabWork1.Shared.Abstractions;
using Study.LabWork1.Features.task1;

namespace Study.LabWork1.Shared.Services;
//namespace Study.LabWork1.Features.task1;

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
        Complex_ z = new Complex_(3, 4);
        Complex_ z1 = new Complex_(1, 2);
        Complex_ z2 = new Complex_(3, 4);

        Complex_ conjugate = -z;
        double modulus = +z;

        Console.WriteLine($"z = {z}");
        Console.WriteLine($"conjugate = {conjugate}");
        Console.WriteLine($"modulus = {modulus}");
        Console.WriteLine($"z1 * z2 = {z1 * z2}");
        Console.WriteLine($"(z1 * z2) / z1 = {(z1 * z2) / z1}");
        Console.WriteLine($"z == z2: {z == z2}");
        Console.WriteLine($"z1 == z2: {z1 == z2}");
        Console.WriteLine($"z1 != z2: {z1 != z2}");
        Console.WriteLine($"z != z2: {z != z2}");
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
