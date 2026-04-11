using System;

using NUnit.Framework;


public class HSLtest
{
    //правильно ли знаечние
    [Test]
    public void Constructor_SetsValuesCorrectly()
    {
        var color = new HSL(120, 50, 25);

        Assert.AreEqual(120, color.Hue);
        Assert.AreEqual(50, color.Saturation);
        Assert.AreEqual(25, color.Lightness);
    }
    //оттенок не зациклилился
    [Test]
    public void Hue_WrapsAround()
    {
        var color = new HSL(370, 50, 50);

        Assert.AreEqual(10, color.Hue);
    }
    //насыщенность не меньше 0 и не больше 100
    [Test]
    public void Saturation_Clamped()
    {
        var color = new HSL(100, 150, 50);

        Assert.AreEqual(100, color.Saturation);
    }
    //светлота не меньше 0 и не больше 100
    [Test]
    public void Lightness_Clamped()
    {
        var color = new HSL(100, 50, -10);

        Assert.AreEqual(0, color.Lightness);
    }
    //проверка оператора сложения
    [Test]
    public void Plus_Works()
    {
        var a = new HSL(100, 20, 30);
        var b = new HSL(50, 10, 15);

        var result = a + b;

        Assert.AreEqual(150, result.Hue);
        Assert.AreEqual(30, result.Saturation);
        Assert.AreEqual(45, result.Lightness);
    }
    //проверка на деление на 0
    [Test]
    public void Divide_ByZero_Throws()
    {
        var color = new HSL(100, 40, 60);

        Assert.Throws<Exception>(() => color / 0);
    }
    //проверка оператора ==
    [Test]
    public void EqualOperator_Works()
    {
        var a = new HSL(120, 50, 50);
        var b = new HSL(120, 50, 50);

        Assert.IsTrue(a == b);
    }
    //проверка перевод в HEX (черный)
    [Test]
    public void ToHex_Works()
    {
        var color = new HSL(0, 0, 0);

        var hex = color.ToHex();

        Assert.AreEqual("#000000", hex);
    }
}
