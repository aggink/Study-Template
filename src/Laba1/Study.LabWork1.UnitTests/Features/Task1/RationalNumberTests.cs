using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.UnitTests.Features.Task1
{
    [TestFixture]
    internal class RationalNumberTests
    {
        /// <summary>
        /// Проверка метода
        /// </summary>
        /// <param name="number">Результат выполнения</param>
        [TestCase(1)]
        public void GetResult(int number)
        {
            var rationalNumber = new RationalNumber();

            var result = rationalNumber.GetResult();

            Assert.That(number, Is.EqualTo(result), $"Число не равно {number}");
        }
    }
}
