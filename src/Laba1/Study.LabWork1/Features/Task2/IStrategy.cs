using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task2;

public interface IStrategy
{
    // Метод, который будет считать итоговую сумму
    decimal Calculate(decimal amount);
}
