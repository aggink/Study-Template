using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task2;

public interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}
