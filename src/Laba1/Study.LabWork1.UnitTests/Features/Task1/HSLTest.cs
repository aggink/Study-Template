using System;
using System.Collections.Generic;
using System.Text;
using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.UnitTests.Features.Task1
{
    [TestFixture]
    internal class HSLTest
    {
        /// <summary>
        /// тест проверяет что конструктор правильно работает с ограничениями
        /// </summary>
        [Test]
        public void Constructor()
        {
            var color = new HSL(400, 150, -10);
            Assert.That(color.Hue, Is.InRange(0, 360));
            Assert.That(color.Saturation, Is.LessThanOrEqualTo(100));
            Assert.That(color.Lightness, Is.GreaterThanOrEqualTo(0));
        }
        /// <summary>
        /// проверка перегрузки оператора сложения
        /// </summary>
        [Test]
        public void Addition()
        {
            var a = new HSL(100, 50, 50);
            var b = new HSL(50, 20, 20);
            var result = a + b;
            Assert.That(result.Hue, Is.EqualTo(150));
        }
        /// <summary>
        /// тест проверяет что перевод в RGB возвращает значения в предалах 0-255
        /// </summary>
        [Test]
        public void ToRGB()
        {
            var color = new HSL(120, 100, 50);
            var rgb = color.ToRGB();
            Assert.That(rgb.R, Is.InRange(0, 255));
            Assert.That(rgb.G, Is.InRange(0, 255));
            Assert.That(rgb.B, Is.InRange(0, 255));
        }
        /// <summary>
        /// тест проверяет правильность формата HEX и что он начинается с #
        /// </summary>
        [Test]
        public void ToHEX()
        {
            var color = new HSL(120, 100, 50);
            var hex = color.ToHEX();
            Assert.That(hex.StartsWith("#"));
        }
        /// <summary>
        /// тест проверяет правильность перегрузки оператора ра
        /// </summary>
        [Test]
        public void Ravnosti()
        {
            var a = new HSL(10, 20, 30);
            var b = new HSL(10, 20, 30);
            Assert.That(a == b);
        }
    }
}
