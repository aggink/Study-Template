using NUnit.Framework;
using Study.LabWork1.Features.Task1;
using System;

namespace Study.LabWork1.UnitTests.Features.Task1;

public class MatrixTests
{
    [Test]
    public void ToString_ShouldReturnFormattedMatrix()
    {
        var matrix = new Matrix(new double[,]
        {
            { 1, 2.5 },
            { 3.14, 4 }
        });

        var expected = "| 1.00 2.50 |\n| 3.14 4.00 |".Replace("\n", Environment.NewLine);
        Assert.That(matrix.ToString(), Is.EqualTo(expected));
    }

    [Test]
    public void Determinant_ShouldBeCalculatedCorrectly()
    {
        var matrix = new Matrix(new double[,]
        {
            { 1, 2 },
            { 3, 4 }
        });

        Assert.That(matrix.Determinant, Is.EqualTo(-2).Within(1e-9));
    }

    [Test]
    public void Addition_ShouldAddMatrices()
    {
        var first = new Matrix(new double[,]
        {
            { 1, 2 },
            { 3, 4 }
        });

        var second = new Matrix(new double[,]
        {
            { 5, 6 },
            { 7, 8 }
        });

        var result = first + second;

        Assert.That(result.GetValue(0, 0), Is.EqualTo(6).Within(1e-9));
        Assert.That(result.GetValue(1, 1), Is.EqualTo(12).Within(1e-9));
    }

    [Test]
    public void Transpose_ShouldTransposeMatrix()
    {
        var matrix = new Matrix(new double[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 }
        });

        var result = ~matrix;

        Assert.That(result.Rows, Is.EqualTo(3));
        Assert.That(result.Columns, Is.EqualTo(2));
        Assert.That(result.GetValue(1, 0), Is.EqualTo(2).Within(1e-9));
        Assert.That(result.GetValue(2, 1), Is.EqualTo(6).Within(1e-9));
    }

    [Test]
    public void Multiply_ShouldMultiplyMatrices()
    {
        var first = new Matrix(new double[,]
        {
            { 1, 2 },
            { 3, 4 }
        });

        var second = new Matrix(new double[,]
        {
            { 2, 0 },
            { 1, 2 }
        });

        var result = first * second;

        Assert.That(result.GetValue(0, 0), Is.EqualTo(4).Within(1e-9));
        Assert.That(result.GetValue(0, 1), Is.EqualTo(4).Within(1e-9));
        Assert.That(result.GetValue(1, 0), Is.EqualTo(10).Within(1e-9));
        Assert.That(result.GetValue(1, 1), Is.EqualTo(8).Within(1e-9));
    }

    [Test]
    public void Division_ShouldMultiplyByInverseMatrix()
    {
        var first = new Matrix(new double[,]
        {
            { 1, 2 },
            { 3, 4 }
        });

        var second = new Matrix(new double[,]
        {
            { 1, 1 },
            { 0, 1 }
        });

        var result = first / second;

        Assert.That(result.GetValue(0, 0), Is.EqualTo(1).Within(1e-9));
        Assert.That(result.GetValue(0, 1), Is.EqualTo(1).Within(1e-9));
        Assert.That(result.GetValue(1, 0), Is.EqualTo(3).Within(1e-9));
        Assert.That(result.GetValue(1, 1), Is.EqualTo(1).Within(1e-9));
    }

    [Test]
    public void ComparisonOperators_ShouldCompareByDeterminant()
    {
        var first = new Matrix(new double[,]
        {
            { 2, 0 },
            { 0, 2 }
        });

        var second = new Matrix(new double[,]
        {
            { 1, 0 },
            { 0, 1 }
        });

        Assert.That(first > second, Is.True);
        Assert.That(first >= second, Is.True);
        Assert.That(second < first, Is.True);
        Assert.That(second <= first, Is.True);
    }

    [Test]
    public void Equality_ShouldCompareValues()
    {
        var first = new Matrix(new double[,]
        {
            { 1, 2 },
            { 3, 4 }
        });

        var second = new Matrix(new double[,]
        {
            { 1, 2 },
            { 3, 4 }
        });

        Assert.That(first == second, Is.True);
        Assert.That(first != second, Is.False);
    }
}
