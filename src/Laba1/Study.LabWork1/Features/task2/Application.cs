using System;
using System.Collections.Generic;
using System.Text;
namespace Study.LabWork1.Features.Task2;

public class Application
{
    private readonly IGUIFactory _factory;

    public Application(IGUIFactory factory)
    {
        _factory = factory;
    }

    public void Paint()
    {
        var button = _factory.CreateButton();
        var checkbox = _factory.CreateCheckbox();

        button.Render();
        checkbox.Render();
    }
}
