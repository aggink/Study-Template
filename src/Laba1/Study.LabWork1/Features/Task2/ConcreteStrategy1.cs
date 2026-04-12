using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task2;

public class ConcreteStrategy1 : IStrategy
{
    // Процент скидки
    private decimal _percent;

    public ConcreteStrategy1(decimal percent)
    {
        _percent = percent;
    }

    public decimal Calculate(decimal amount)
    {
   
        decimal discount = amount * _percent / 100m;

        return amount - discount;
    }
}
