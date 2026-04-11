using System;
using System.Collections.Generic;
using System.Text;
using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.UnitTests.Features.Task1
{

    [TestFixture]
    internal class MatrixTests
    {
        /// <summary>
        /// Проверка свойства Rows
        /// </summary>
        [TestCase(2)]
        public void GetRows(int number)
        {
            var matrix = new Matrix(new double[,]
            {
                { 1, 2 },
                { 3, 4 }
            });

            var result = matrix.Rows;

            Assert.That(number, Is.EqualTo(result), $"Количество строк не равно {number}");
        }

        /// <summary>
        /// Проверка свойства Columns
        /// </summary>
        [TestCase(2)]
        public void GetColumns(int number)
        {
            var matrix = new Matrix(new double[,]
            {
                { 1, 2 },
                { 3, 4 }
            });

            var result = matrix.Columns;

            Assert.That(number, Is.EqualTo(result), $"Количество столбцов не равно {number}");
        }

        /// <summary>
        /// Проверка нахождения определителя
        /// </summary>
        [TestCase(-2)]
        public void GetDeterminant(double number)
        {
            var matrix = new Matrix(new double[,]
            {
                { 1, 2 },
                { 3, 4 }
            });

            var result = matrix.Determinant();

            Assert.That(number, Is.EqualTo(result), $"Определитель не равен {number}");
        }

        /// <summary>
        /// Проверка сложения матриц
        /// </summary>
        [Test]
        public void AddMatrices()
        {
            var left = new Matrix(new double[,]
            {
        { 1, 2 },
        { 3, 4 }
            });

            var right = new Matrix(new double[,]
            {
        { 5, 6 },
        { 7, 8 }
            });

            var result = left + right;

            Assert.Multiple(() =>
            {
                Assert.That(result[0, 0], Is.EqualTo(6), "Элемент [0,0] неверный");
                Assert.That(result[0, 1], Is.EqualTo(8), "Элемент [0,1] неверный");
                Assert.That(result[1, 0], Is.EqualTo(10), "Элемент [1,0] неверный");
                Assert.That(result[1, 1], Is.EqualTo(12), "Элемент [1,1] неверный");
            });
        }

        /// <summary>
        /// Проверка транспонирования матрицы
        /// </summary>
        [Test]
        public void TransposeMatrix()
        {
            var matrix = new Matrix(new double[,]
            {
        { 1, 2, 3 },
        { 4, 5, 6 }
            });

            var result = ~matrix;

            Assert.Multiple(() =>
            {
                Assert.That(result.Rows, Is.EqualTo(3), "Количество строк неверное");
                Assert.That(result.Columns, Is.EqualTo(2), "Количество столбцов неверное");

                Assert.That(result[0, 0], Is.EqualTo(1), "Элемент [0,0] неверный");
                Assert.That(result[0, 1], Is.EqualTo(4), "Элемент [0,1] неверный");
                Assert.That(result[1, 0], Is.EqualTo(2), "Элемент [1,0] неверный");
                Assert.That(result[1, 1], Is.EqualTo(5), "Элемент [1,1] неверный");
                Assert.That(result[2, 0], Is.EqualTo(3), "Элемент [2,0] неверный");
                Assert.That(result[2, 1], Is.EqualTo(6), "Элемент [2,1] неверный");
            });
        }

        /// <summary>
        /// Проверка умножения матриц
        /// </summary>
        [Test]
        public void MultiplyMatrices()
        {
            var left = new Matrix(new double[,]
            {
        { 1, 2 },
        { 3, 4 }
            });

            var right = new Matrix(new double[,]
            {
        { 2, 0 },
        { 1, 2 }
            });

            var result = left * right;

            Assert.Multiple(() =>
            {
                Assert.That(result[0, 0], Is.EqualTo(4), "Элемент [0,0] неверный");
                Assert.That(result[0, 1], Is.EqualTo(4), "Элемент [0,1] неверный");
                Assert.That(result[1, 0], Is.EqualTo(10), "Элемент [1,0] неверный");
                Assert.That(result[1, 1], Is.EqualTo(8), "Элемент [1,1] неверный");
            });
        }

        /// <summary>
        /// Проверка нахождения обратной матрицы
        /// </summary>
        [Test]
        public void InverseMatrix()
        {
            var matrix = new Matrix(new double[,]
            {
        { 1, 2 },
        { 3, 4 }
            });

            var result = matrix.Inverse();

            Assert.Multiple(() =>
            {
                Assert.That(result[0, 0], Is.EqualTo(-2).Within(0.001), "Элемент [0,0] неверный");
                Assert.That(result[0, 1], Is.EqualTo(1).Within(0.001), "Элемент [0,1] неверный");
                Assert.That(result[1, 0], Is.EqualTo(1.5).Within(0.001), "Элемент [1,0] неверный");
                Assert.That(result[1, 1], Is.EqualTo(-0.5).Within(0.001), "Элемент [1,1] неверный");
            });
        }

        /// <summary>
        /// Проверка деления матриц
        /// </summary>
        [Test]
        public void DivideMatrices()
        {
            var left = new Matrix(new double[,]
            {
        { 2, 4 },
        { 6, 8 }
            });

            var right = new Matrix(new double[,]
            {
        { 2, 0 },
        { 0, 2 }
            });

            var result = left / right;

            Assert.Multiple(() =>
            {
                Assert.That(result[0, 0], Is.EqualTo(1).Within(0.001), "Элемент [0,0] неверный");
                Assert.That(result[0, 1], Is.EqualTo(2).Within(0.001), "Элемент [0,1] неверный");
                Assert.That(result[1, 0], Is.EqualTo(3).Within(0.001), "Элемент [1,0] неверный");
                Assert.That(result[1, 1], Is.EqualTo(4).Within(0.001), "Элемент [1,1] неверный");
            });
        }

        /// <summary>
        /// Проверка оператора ==
        /// </summary>
        [TestCase(true)]
        public void EqualMatrices(bool expected)
        {
            var left = new Matrix(new double[,]
            {
                { 1, 2 },
                { 3, 4 }
            });

            var right = new Matrix(new double[,]
            {
                { 2, 0 },
                { 0, -1 }
            });

            var result = left == right;

            Assert.That(expected, Is.EqualTo(result), "Оператор == работает неверно");
        }

        /// <summary>
        /// Проверка оператора !=
        /// </summary>
        [TestCase(true)]
        public void NotEqualMatrices(bool expected)
        {
            var left = new Matrix(new double[,]
            {
                { 1, 2 },
                { 3, 4 }
            });

            var right = new Matrix(new double[,]
            {
                { 2, 0 },
                { 0, 2 }
            });

            var result = left != right;

            Assert.That(expected, Is.EqualTo(result), "Оператор != работает неверно");
        }

        /// <summary>
        /// Проверка оператора >
        /// </summary>
        [TestCase(true)]
        public void GreaterThanMatrices(bool expected)
        {
            var left = new Matrix(new double[,]
            {
                { 2, 0 },
                { 0, 2 }
            });

            var right = new Matrix(new double[,]
            {
                { 1, 2 },
                { 3, 4 }
            });

            var result = left > right;

            Assert.That(expected, Is.EqualTo(result), "Оператор > работает неверно");
        }

        /// <summary>
        /// Проверка оператора <
        /// </summary>
        [TestCase(true)]
        public void LessThanMatrices(bool expected)
        {
            var left = new Matrix(new double[,]
            {
                { 1, 2 },
                { 3, 4 }
            });

            var right = new Matrix(new double[,]
            {
                { 2, 0 },
                { 0, 2 }
            });

            var result = left < right;

            Assert.That(expected, Is.EqualTo(result), "Оператор < работает неверно");
        }

        /// <summary>
        /// Проверка оператора >=
        /// </summary>
        [TestCase(true)]
        public void GreaterOrEqualMatrices(bool expected)
        {
            var left = new Matrix(new double[,]
            {
                { 2, 0 },
                { 0, 2 }
            });

            var right = new Matrix(new double[,]
            {
                { 2, 0 },
                { 0, 2 }
            });

            var result = left >= right;

            Assert.That(expected, Is.EqualTo(result), "Оператор >= работает неверно");
        }

        /// <summary>
        /// Проверка оператора <=
        /// </summary>
        [TestCase(true)]
        public void LessOrEqualMatrices(bool expected)
        {
            var left = new Matrix(new double[,]
            {
                { 1, 2 },
                { 3, 4 }
            });

            var right = new Matrix(new double[,]
            {
                { 2, 0 },
                { 0, 2 }
            });

            var result = left <= right;

            Assert.That(expected, Is.EqualTo(result), "Оператор <= работает неверно");
        }

        /// <summary>
        /// Проверка исключения при сложении матриц разного размера
        /// </summary>
        [Test]
        public void AddMatricesDifferentSize()
        {
            var left = new Matrix(new double[,]
            {
                { 1, 2 },
                { 3, 4 }
            });

            var right = new Matrix(new double[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            });

            Assert.Throws<InvalidOperationException>(() => { var result = left + right; }, "Исключение не выброшено");
        }

        /// <summary>
        /// Проверка исключения при нахождении определителя неквадратной матрицы
        /// </summary>
        [Test]
        public void DeterminantNonSquareMatrix()
        {
            var matrix = new Matrix(new double[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            });

            Assert.Throws<InvalidOperationException>(() => matrix.Determinant(), "Исключение не выброшено");
        }

        /// <summary>
        /// Проверка исключения при нахождении обратной вырожденной матрицы
        /// </summary>
        [Test]
        public void InverseDegenerateMatrix()
        {
            var matrix = new Matrix(new double[,]
            {
                { 1, 2 },
                { 2, 4 }
            });

            Assert.Throws<InvalidOperationException>(() => matrix.Inverse(), "Исключение не выброшено");
        }
    }
}
