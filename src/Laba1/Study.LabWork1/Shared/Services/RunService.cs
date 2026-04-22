using Study.LabWork1.Shared.Abstractions;
using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.Shared.Services;

public class RunService : IRunService
{
    public void RunTask1()
    {
        var left = new ComplexNum(1.01, 2);
        var right = new ComplexNum(3, -1);

        Console.WriteLine($"left = {left}");
        Console.WriteLine($"right = {right}");
        Console.WriteLine($"left + right = {left + right}");
        Console.WriteLine($"left - right = {left - right}");
        Console.WriteLine($"left * right = {left * right}");
        Console.WriteLine($"left / right = {left / right}");
        Console.WriteLine($"|left| = {+left:0.##}");
        Console.WriteLine($"conjugate(left) = {-left}");
    }

    public void RunTask2() => throw new NotImplementedException();

    public void RunTask3() => throw new NotImplementedException();
}
