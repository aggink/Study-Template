namespace Study.LabWork1.Features.Task2
{
    public class FixedDiscStrat : IStrategy
    {
        private readonly double _discountAmount;

        public FixedDiscStrat(double discountAmount)
        {
            _discountAmount = discountAmount;
        }

        public double Calculate(double orderAmount)
        {
            double result = orderAmount - _discountAmount;
            return result > 0 ? result : 0;
        }
    }
}
