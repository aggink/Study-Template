using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Study.LabWork1.Features.Task2;

namespace Study.LabWork1.UnitTests.Features.Task2;

[TestFixture]
internal class StrategyTests
{
    /// Проверка процентной скидки

    [Test]
    public void ConcreteStrategy1_Should_Apply_Percent_Discount()
    {
        var context = new Context(1000m, new ConcreteStrategy1(10));

        var result = context.Execute();

        Assert.That(result, Is.EqualTo(900m));
    }

    
    /// Проверка фиксированной скидки
    [Test]
    public void ConcreteStrategy2_Should_Apply_Fixed_Discount()
    {
        var context = new Context(1000m, new ConcreteStrategy2(200));

        var result = context.Execute();


        Assert.That(result, Is.EqualTo(800m));
    }


    /// Проверка смены стратегии во время работы
  
    [Test]
    public void Context_Should_Change_Strategy_At_Runtime()
    { 
        var context = new Context(1000m, new ConcreteStrategy1(10));

        var firstResult = context.Execute();
        var secondResult = context.Execute();
        context.SetStrategy(new ConcreteStrategy2(300));


        Assert.That(firstResult, Is.EqualTo(900m));
        Assert.That(secondResult, Is.EqualTo(700m));
    }
}
