using NUnit.Framework;
using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.UnitTests.Features.Task1;

[TestFixture]
internal class MatrixTests
{
    /// <summary>
    /// Проверка правильно ли задаются строки и столбцы
    /// </summary>
    [Test]
    public void Constructor_Should_Set_Rows_And_Columns()
    {
        var matrix = new Matrix(new double[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 }
        });

        Assert.That(matrix.Rows, Is.EqualTo(2));
        Assert.That(matrix.Columns, Is.EqualTo(3));
    }

    /// <summary>
    /// Проверка сложения матриц
    /// </summary>
    [Test]
    public void Plus_Should_Add_Matrices()
    {
        var a = new Matrix(new double[,]
        {
            { 1, 2 },
            { 3, 4 }
        });

        var b = new Matrix(new double[,]
        {
            { 5, 6 },
            { 7, 8 }
        });

        var result = a + b;

        Assert.That(result[0, 0], Is.EqualTo(6));
        Assert.That(result[0, 1], Is.EqualTo(8));
        Assert.That(result[1, 0], Is.EqualTo(10));
        Assert.That(result[1, 1], Is.EqualTo(12));
    }

    /// <summary>
    /// Проверка определителя
    /// </summary>
    [Test]
    public void Determinant_Should_Be_Correct()
    {
        var matrix = new Matrix(new double[,]
        {
            { 1, 2 },
            { 3, 4 }
        });

        Assert.That(matrix.Determinant, Is.EqualTo(-2).Within(0.000001));
    }
}
