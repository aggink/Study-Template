using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Legacy;
using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.UnitTests.Features.Task1
{
    [TestFixture]
    public class ComplexNumberTests
    {
        [Test]
        public void ConstructorDefaultIsZero()
        {
            var c = new ComplexNumber();
            ClassicAssert.AreEqual(0.0, c.Real);
            ClassicAssert.AreEqual(0.0, c.Imaginary);
        }

        [TestCase(3, 2)]
        [TestCase(-1.5, 4.2)]
        public void ConstructorWithValuesSetProperties(double real, double imag)
        {
            var c = new ComplexNumber(real, imag);
            ClassicAssert.AreEqual(real, c.Real);
            ClassicAssert.AreEqual(imag, c.Imaginary);
        }

        [Test]
        public void UnaryPlusReturnSame()
        {
            var c = new ComplexNumber(5, -3);
            var result = +c;
            ClassicAssert.AreEqual(c, result);
        }

        [TestCase(3, 2, -3, -2)]
        [TestCase(-1, 4, 1, -4)]
        public void UnaryMinusNegate(double r, double i, double expR, double expI)
        {
            var c = new ComplexNumber(r, i);
            var result = -c;
            ClassicAssert.AreEqual(expR, result.Real);
            ClassicAssert.AreEqual(expI, result.Imaginary);
        }

        [TestCase(1, 2, 3, 4, 4, 6)]
        [TestCase(0, 5, 2, -3, 2, 2)]
        public void Addition(double r1, double i1, double r2, double i2, double expR, double expI)
        {
            var a = new ComplexNumber(r1, i1);
            var b = new ComplexNumber(r2, i2);
            var result = a + b;
            ClassicAssert.AreEqual(expR, result.Real);
            ClassicAssert.AreEqual(expI, result.Imaginary);
        }

        [TestCase(5, 5, 2, 3, 3, 2)]
        [TestCase(1, 1, -1, -1, 2, 2)]
        public void Subtraction(double r1, double i1, double r2, double i2, double expR, double expI)
        {
            var a = new ComplexNumber(r1, i1);
            var b = new ComplexNumber(r2, i2);
            var result = a - b;
            ClassicAssert.AreEqual(expR, result.Real);
            ClassicAssert.AreEqual(expI, result.Imaginary);
        }

        [TestCase(1, 2, 3, 4, -5, 10)]
        [TestCase(0, 1, 0, 1, -1, 0)]
        public void Multiplication(double r1, double i1, double r2, double i2, double expR, double expI)
        {
            var a = new ComplexNumber(r1, i1);
            var b = new ComplexNumber(r2, i2);
            var result = a * b;
            ClassicAssert.AreEqual(expR, result.Real, 0.0001);
            ClassicAssert.AreEqual(expI, result.Imaginary, 0.0001);
        }

        [TestCase(4, 2, 2, -1, 1.2, 1.6)]
        [TestCase(1, 2, 1, 2, 1, 0)]
        public void Division(double r1, double i1, double r2, double i2, double expR, double expI)
        {
            var a = new ComplexNumber(r1, i1);
            var b = new ComplexNumber(r2, i2);
            var result = a / b;
            ClassicAssert.AreEqual(expR, result.Real, 0.0001);
            ClassicAssert.AreEqual(expI, result.Imaginary, 0.0001);
        }

        [Test]
        public void EqualityShouldBeTrue()
        {
            var a = new ComplexNumber(2.5, -1.5);
            var b = new ComplexNumber(2.5, -1.5);
            ClassicAssert.IsTrue(a == b);
            ClassicAssert.IsTrue(a.Equals(b));
        }

        [Test]
        public void NoEquanityShouldBeFalse()
        {
            var a = new ComplexNumber(1, 2);
            var b = new ComplexNumber(2, 1);
            ClassicAssert.IsFalse(a == b);
        }

        [TestCase(3.5, 2.1, "3.5+2.1i")]
        [TestCase(0, 5, "5i")]
        [TestCase(4, 0, "4")]
        [TestCase(0, -3, "-3i")]
        [TestCase(0, 0, "0")]
        public void ToStringCorrect(double real, double imag, string expected)
        {
            var c = new ComplexNumber(real, imag);
            ClassicAssert.AreEqual(expected, c.ToString());
        }
    }
}
