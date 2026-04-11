using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.UnitTests.Features.Task1
{
    [TestFixture]
    public class ColorHslTests
    {
        [Test]
        public void Constructor_ShouldLimitValues()
        {
            var color = new ColorHsl(500, 150, -20);

            Assert.That(color.H, Is.InRange(0, 360));
            Assert.That(color.S, Is.EqualTo(100));
            Assert.That(color.L, Is.EqualTo(0));
        }

        [Test]
        public void PlusOperator_ShouldWorkCorrectly()
        {
            var a = new ColorHsl(100, 30, 40);
            var b = new ColorHsl(50, 20, 10);

            var result = a + b;

            Assert.That(result.H, Is.EqualTo(150));
            Assert.That(result.S, Is.EqualTo(50));
            Assert.That(result.L, Is.EqualTo(50));
        }

        [Test]
        public void RgbConversion_ShouldBeValid()
        {
            var color = new ColorHsl(0, 100, 50);
            var rgb = color.ConvertToRgb();

            Assert.That(rgb.r, Is.InRange(0, 255));
            Assert.That(rgb.g, Is.InRange(0, 255));
            Assert.That(rgb.b, Is.InRange(0, 255));
        }

        [Test]
        public void HexConversion_ShouldStartWithHash()
        {
            var color = new ColorHsl(0, 100, 50);
            var hex = color.ConvertToHex();

            Assert.That(hex.StartsWith("#"));
        }

        [Test]
        public void EqualityOperator_ShouldReturnTrue()
        {
            var a = new ColorHsl(10, 20, 30);
            var b = new ColorHsl(10, 20, 30);

            Assert.That(a == b);
        }
    }
}
