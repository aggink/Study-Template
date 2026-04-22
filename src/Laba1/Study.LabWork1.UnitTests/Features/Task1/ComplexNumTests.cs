using NUnit.Framework;
using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.UnitTests.Features.Task1;

[TestFixture]
public sealed class ComplexNumTests
{
[Test]
public void Addition_ShouldReturnCorrectResult()
{
var left = new ComplexNum(1.5, 2);
var right = new ComplexNum(2.5, -3);

var result = left + right;

Assert.That(result.Real, Is.EqualTo(4));
Assert.That(result.Imagine, Is.EqualTo(-1));
}

[Test]
public void Subtraction_ShouldReturnCorrectResult()
{
var left = new ComplexNum(5, 3);
var right = new ComplexNum(1, 2);

var result = left - right;

Assert.That(result.Real, Is.EqualTo(4));
Assert.That(result.Imagine, Is.EqualTo(1));
}

[Test]
public void Multiplication_ShouldReturnCorrectResult()
{
var left = new ComplexNum(1, 2);
var right = new ComplexNum(3, 4);

var result = left * right;

Assert.That(result.Real, Is.EqualTo(-5));
Assert.That(result.Imagine, Is.EqualTo(10));
}

[Test]
public void Division_ShouldReturnCorrectResult()
{
var left = new ComplexNum(1, 2);
var right = new ComplexNum(3, 4);

var result = left / right;

Assert.That(result.Real, Is.EqualTo(0.44).Within(0.0001));
Assert.That(result.Imagine, Is.EqualTo(0.08).Within(0.0001));
}

[Test]
public void Division_ByZeroComplex_ShouldThrow()
{
var left = new ComplexNum(1, 2);
var right = new ComplexNum(0, 0);

Assert.Throws<DivideByZeroException>(() => _ = left / right);
}

[Test]
public void UnaryPlus_ShouldReturnModule()
{
var value = new ComplexNum(3, 4);

var module = +value;

Assert.That(module, Is.EqualTo(5));
}

[Test]
public void UnaryMinus_ShouldReturnConjugate()
{
var value = new ComplexNum(2, -7);

var result = -value;

Assert.That(result.Real, Is.EqualTo(2));
Assert.That(result.Imagine, Is.EqualTo(7));
}

[Test]
public void Equality_ShouldCompareByValues()
{
var left = new ComplexNum(10, -2);
var right = new ComplexNum(10, -2);

Assert.That(left == right, Is.True);
Assert.That(left != right, Is.False);
Assert.That(left.Equals(right), Is.True);
}

[Test]
public void ToString_ShouldFollowRequiredFormat()
{
Assert.That(new ComplexNum(1.01, 2).ToString(), Is.EqualTo("1.01 + 2i"));
Assert.That(new ComplexNum(3, 0).ToString(), Is.EqualTo("3"));
Assert.That(new ComplexNum(0, 4).ToString(), Is.EqualTo("4i"));
Assert.That(new ComplexNum(0, -4).ToString(), Is.EqualTo("-4i"));
}
}
