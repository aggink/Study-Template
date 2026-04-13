namespace Study.LabWork1.Features.Task2
{
    public class PercDiscStrat : IStrategy
    {
        private readonly double _percentage;//

        public PercDiscStrat(double percentage)
        {
            _percentage = percentage;
        }

        public double Calculate(double orderAmount)
        {
            return orderAmount * (1 - _percentage / 100);
        }
    }
}
