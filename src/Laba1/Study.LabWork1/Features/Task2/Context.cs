using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task2;

public class Context {
    private IStrategy _strategy;

    private decimal _amount;

    public Context(decimal amount, IStrategy strategy){
        _amount = amount;
        _strategy = strategy;
    }


    public void SetStrategy(IStrategy strategy){
        _strategy = strategy;
    }

    
    public decimal Execute() { 
        return _strategy.Calculate(_amount);
    }
}
