using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task2;

public class DarkCheckbox : ICheckbox
{
    public void Render()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine(" ☑ Dark Checkbox — тёмный чекбокс ");
        Console.ResetColor();
    }
}
