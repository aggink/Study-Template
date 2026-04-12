using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task2;

public class ConcreteStrategy2 : IStrategy
{
    // Фиксированная скидка
    private decimal _discount;

    public ConcreteStrategy2(decimal discount)
    {
        _discount = discount;
    }

    public decimal Calculate(decimal amount)
    {
        decimal result = amount - _discount;

        if (result < 0)
        {
            return 0;
        }

        return result;
    }
}
