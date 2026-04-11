using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task1
{
    /// <summary>
    /// Класс для работы с матрицами и основными операциями над ними.
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// Внутреннее представление матрицы.
        /// </summary>
        private double[,] matrix;

        /// <summary>
        /// Позволяет получать элемент матрицы по индексам строки и столбца.
        /// </summary>
        public double this[int row, int column]
        {
            get { return matrix[row, column]; }
        }

        /// <summary>
        /// Возвращает количество строк матрицы.
        /// </summary>
        public int Rows
        {
            get { return matrix.GetLength(0); }
        }

        /// <summary>
        /// Возвращает количество столбцов матрицы.
        /// </summary>
        public int Columns
        {
            get { return matrix.GetLength(1); }
        }

        /// <summary>
        /// Находит определитель матрицы.
        /// </summary>
        public double Determinant()
        {
            if (Rows != Columns)
                throw new InvalidOperationException("Определитель можно найти только у квадратной матрицы.");

            return FindDeterminant(matrix);
        }

        /// <summary>
        /// Вычисляет определитель матрицы.
        /// </summary>
        private double FindDeterminant(double[,] data)
        {
            int size = data.GetLength(0);

            if (size == 1)
                return data[0, 0];

            if (size == 2)
                return data[0, 0] * data[1, 1] - data[0, 1] * data[1, 0];

            double det = 0;

            for (int j = 0; j < size; j++)
            {
                double[,] minor = GetMinor(data, 0, j);
                double sign = (j % 2 == 0) ? 1 : -1;

                det += sign * data[0, j] * FindDeterminant(minor);
            }

            return det;
        }

        /// <summary>
        /// Формирует минор матрицы.
        /// </summary>
        private double[,] GetMinor(double[,] data, int rowToRemove, int colToRemove)
        {
            int size = data.GetLength(0);
            double[,] minor = new double[size - 1, size - 1];

            int r = 0;

            for (int i = 0; i < size; i++)
            {
                if (i == rowToRemove)
                    continue;

                int c = 0;

                for (int j = 0; j < size; j++)
                {
                    if (j == colToRemove)
                        continue;

                    minor[r, c] = data[i, j];
                    c++;
                }

                r++;
            }

            return minor;
        }

        /// <summary>
        /// Находит обратную матрицу.
        /// </summary>
        public Matrix Inverse()
        {
            if (Rows != Columns)
                throw new InvalidOperationException("Обратную матрицу можно найти только у квадратной матрицы.");

            int n = Rows;
            double[,] a = (double[,])matrix.Clone();
            double[,] result = new double[n, n];

            for (int i = 0; i < n; i++)
                result[i, i] = 1;

            for (int i = 0; i < n; i++)
            {
                double pivot = a[i, i];

                if (pivot == 0)
                    throw new InvalidOperationException("Матрица вырожденная.");

                for (int j = 0; j < n; j++)
                {
                    a[i, j] /= pivot;
                    result[i, j] /= pivot;
                }

                for (int k = 0; k < n; k++)
                {
                    if (k == i) continue;

                    double factor = a[k, i];

                    for (int j = 0; j < n; j++)
                    {
                        a[k, j] -= factor * a[i, j];
                        result[k, j] -= factor * result[i, j];
                    }
                }
            }

            return new Matrix(result);
        }

        /// <summary>
        /// Проверяет равенство матриц по их определителям.
        /// </summary>
        public static bool operator ==(Matrix left, Matrix right)
        {
            return left.Determinant() == right.Determinant();
        }

        /// <summary>
        /// Проверяет неравенство матриц по их определителям.
        /// </summary>
        public static bool operator !=(Matrix left, Matrix right)
        {
            return left.Determinant() != right.Determinant();
        }

        /// <summary>
        /// Проверяет, больше ли определитель левой матрицы определителя правой.
        /// </summary>
        public static bool operator >(Matrix left, Matrix right)
        {
            return left.Determinant() > right.Determinant();
        }

        /// <summary>
        /// Проверяет, меньше ли определитель левой матрицы определителя правой.
        /// </summary>
        public static bool operator <(Matrix left, Matrix right)
        {
            return left.Determinant() < right.Determinant();
        }

        /// <summary>
        /// Проверяет, больше или равен ли определитель левой матрицы определителю правой.
        /// </summary>
        public static bool operator >=(Matrix left, Matrix right)
        {
            return left.Determinant() >= right.Determinant();
        }

        /// <summary>
        /// Проверяет, меньше или равен ли определитель левой матрицы определителю правой.
        /// </summary>
        public static bool operator <=(Matrix left, Matrix right)
        {
            return left.Determinant() <= right.Determinant();
        }

        /// <summary>
        /// Складывает две матрицы одинакового размера.
        /// </summary>
        public static Matrix operator +(Matrix left, Matrix right)  
        {
            if (left.Rows != right.Rows || left.Columns != right.Columns)//проверка на корректность матриц
            {
                throw new InvalidOperationException();
            }

            double[,] result = new double[left.Rows, left.Columns];

            for (int i = 0; i < left.Rows; i++)
            {
                for (int j = 0; j < left.Columns; j++)
                {
                    result[i, j] = left.matrix[i, j] + right.matrix[i, j];
                }
            }

            return new Matrix(result);
        }

        /// <summary>
        /// Транспонирует матрицу.
        /// </summary>
        public static Matrix operator ~(Matrix value)        
        {
            double[,] result = new double[value.Columns, value.Rows];

            for (int i = 0; i < value.Rows; i++)
                for (int j = 0; j < value.Columns; j++)
                    result[j, i] = value.matrix[i, j];

            return new Matrix(result);
        }

        /// <summary>
        /// Умножает две матрицы.
        /// </summary>
        public static Matrix operator *(Matrix left, Matrix right)
        {
            if (left.Columns != right.Rows)
                throw new InvalidOperationException();

            double[,] result = new double[left.Rows, right.Columns];

            for (int i = 0; i < left.Rows; i++)
                for (int j = 0; j < right.Columns; j++)
                    for (int k = 0; k < left.Columns; k++)
                        result[i, j] += left.matrix[i, k] * right.matrix[k, j];

            return new Matrix(result);
        }

        /// <summary>
        /// Делит одну матрицу на другую через умножение на обратную матрицу.
        /// </summary>
        public static Matrix operator /(Matrix left, Matrix right)
        {
            return left * right.Inverse();
        }

        /// <summary>
        /// Возвращает строковое представление матрицы.
        /// </summary>
        public override string ToString()
        {
            string result = "";

            for (int i = 0; i < Rows; i++)
            {
                result += "| ";

                for (int j = 0; j < Columns; j++)
                {
                    result += matrix[i, j].ToString("F2");

                    if (j < Columns - 1)
                    {
                        result += " ";
                    }
                }

                result += " |";

                if (i < Rows - 1)
                {
                    result += "\n";
                }
            }






            return result;
        }


        /// <summary>
        /// Создает новый экземпляр матрицы из двумерного массива.
        /// </summary>
        public Matrix(double[,] data)
        {
            matrix = data;
        }
    }
}
