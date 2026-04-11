using System;
using Study.LabWork1.Features.Task1;
using Study.LabWork1.Shared.Abstractions;

namespace Study.LabWork1.Shared.Services
{
    public class RunService : IRunService
    {
        public void RunTask1()
        {
            var c1 = new ColorHsl(200, 40, 50);
            var c2 = new ColorHsl(100, 20, 30);

            var sum = c1 + c2;
            var scaled = c1 * 1.5;

            Console.WriteLine(c1);
            Console.WriteLine(sum);
            Console.WriteLine(scaled);

            var rgb = c1.ConvertToRgb();
            Console.WriteLine($"RGB: {rgb.r}, {rgb.g}, {rgb.b}");

            Console.WriteLine($"HEX: {c1.ConvertToHex()}");
        }

        public void RunTask2() => throw new NotImplementedException();
        public void RunTask3() => throw new NotImplementedException();
    }
}
