using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task2;

public class LightCheckbox : ICheckbox
{
    public void Render()
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.White;
        Console.WriteLine(" ☑ Light Checkbox — светлый чекбокс ");
        Console.ResetColor();
    }
}
