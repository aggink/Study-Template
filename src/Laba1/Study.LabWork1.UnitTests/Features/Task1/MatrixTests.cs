using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.UnitTests.Features.Task1
{
    [TestFixture]
    internal class MatrixTests
    {
        private readonly Matrix a = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
        private readonly Matrix b = new Matrix(new double[,] { { 5, 6 }, { 7, 8 } });
        private readonly Matrix unit = new Matrix(new double[,] { { 1, 0 }, { 0, 1 } });

        private int passedTests = 0;
        private int totalTests = 0;

        [SetUp]
        public void Setup()
        {
            passedTests = 0;
            totalTests = 0;
        }

        [Test]
        public void TestDeterminant()
        {
            totalTests++;
            double detA = a.Determinant;
            if (Math.Abs(detA - (-2)) < 0.0001)
                passedTests++;
        }

        [Test]
        public void TestPlus()
        {
            totalTests++;
            var result = a + b;
            string resultStr = result.ToString();
            if (resultStr.Contains("6.00") && resultStr.Contains("8.00") &&
                resultStr.Contains("10.00") && resultStr.Contains("12.00"))
                passedTests++;
        }

        [Test]
        public void TestTilde()
        {
            totalTests++;
            var result = ~a;
            if (result.Rows == 2 && result.Columns == 2)
                passedTests++;
        }

        [Test]
        public void TestMultiply()
        {
            totalTests++;
            var result = a * b;
            string resultStr = result.ToString();
            if (resultStr.Contains("19.00"))
                passedTests++;
        }

        [Test]
        public void TestDivide()
        {
            totalTests++;
            try
            {
                var divider = new Matrix(new double[,] { { 2, 0 }, { 0, 2 } });
                var div = a / divider;
                passedTests++;
            }
            catch { }
        }

        [Test]
        public void TestEqual()
        {
            totalTests++;
            if (a == b)
                passedTests++;
        }

        [Test]
        public void TestNotEqual()
        {
            totalTests++;
            if (unit != a)
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
