namespace Study.LabWork1.Features.Task2
{
    public class NoDiscStrat : IStrategy
    {
        public double Calculate(double orderAmount)
        {
            return orderAmount;
        }
    }
}
