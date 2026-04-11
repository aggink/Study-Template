namespace Study.LabWork1.Features.Task2
{
    public class SeasonDiscStrat : IStrategy
    {
        public double Calculate(double orderAmount)
        {
            return orderAmount * 0.85;
        }
    }
}
