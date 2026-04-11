using Study.LabWork1.Features.Task2;

namespace Study.LabWork1.UnitTests.Features.Task2
{
    [TestFixture]
    internal class StratTests
    {
        private int passedTests = 0;
        private int totalTests = 0;

        [SetUp]
        public void Setup()
        {
            passedTests = 0;
            totalTests = 0;
        }

        [Test]
        public void TestNoDiscount()
        {
            totalTests++;
            var strategy = new NoDiscStrat();
            double result = strategy.Calculate(1000);
            if (Math.Abs(result - 1000) < 0.0001)
                passedTests++;
        }

        [Test]
        public void TestPercentageDiscount()
        {
            totalTests++;
            var strategy = new PercDiscStrat(20);
            double result = strategy.Calculate(1000);
            if (Math.Abs(result - 800) < 0.0001)
                passedTests++;
        }

        [Test]
        public void TestFixedDiscount()
        {
            totalTests++;
            var strategy = new FixedDiscStrat(150);
            double result = strategy.Calculate(1000);
            if (Math.Abs(result - 850) < 0.0001)
                passedTests++;
        }

        [Test]
        public void TestSeasonalDiscount()
        {
            totalTests++;
            var strategy = new SeasonDiscStrat();
            double result = strategy.Calculate(1000);
            if (Math.Abs(result - 850) < 0.0001)
                passedTests++;
        }

        [Test]
        public void TestContext()
        {
            totalTests++;
            var context = new Context(new NoDiscStrat());
            double result = context.ApplyDiscount(1000);
            if (Math.Abs(result - 1000) < 0.0001)
                passedTests++;
        }

        [TearDown]
        public void Teardown()
        {
            Console.WriteLine($"\nПройдено тестов: {passedTests} из {totalTests}");

            if (passedTests == totalTests)
                Console.WriteLine("все тесты пройдены");
            else
                Console.WriteLine("не все тесты пройдены");
        }
    }
}
