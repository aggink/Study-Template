namespace Study.LabWork1.Features.Task2;
//
public class Context
{
    private IStrategy _strategy;

    public Context(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public double ApplyDiscount(double orderAmount)
    {
        return _strategy.Calculate(orderAmount);
    }
}
