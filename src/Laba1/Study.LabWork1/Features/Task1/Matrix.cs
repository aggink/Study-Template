using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;


namespace Study.LabWork1.Features.Task1;

public class Matrix
{

    private readonly double[,] _values;

    public int Rows { get; }
    public int Columns { get; }

    public double Determinant
    {
        get
        {
            if (Rows != Columns)
            {
                throw new InvalidOperationException("Определитель можно вычислить только для квадратной матрицы.");
            }

            return CalculateDeterminant(_values);
        }
    }

    public Matrix(double[,] values)
    {
        if (values == null)
        {
            throw new ArgumentNullException(nameof(values));
        }

        int rows = values.GetLength(0);
        int columns = values.GetLength(1);

        if (rows == 0 || columns == 0)
        {
            throw new ArgumentException("Матрица не может быть пустой.");
        }

        Rows = rows;
        Columns = columns;

        _values = (double[,])values.Clone();
    }

    
    public double this[int row, int column]
    {
        get
        {
            return _values[row, column];
        }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < Rows; i++)
        {
            builder.Append("| ");

            for (int j = 0; j < Columns; j++)
            {
                builder.Append(_values[i, j].ToString("0.00", CultureInfo.InvariantCulture));

                if (j < Columns - 1)
                {
                    builder.Append(" ");
                }
            }

            builder.Append(" |");

            if (i < Rows - 1)
            {
                builder.AppendLine();
            }
        }

        return builder.ToString();
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Matrix other)
        {
            return false;
        }

        if (Rows != other.Rows || Columns != other.Columns)
        {
            return false;
        }

        const double epsilon = 0.000001;

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (Math.Abs(_values[i, j] - other._values[i, j]) > epsilon)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        HashCode hash = new HashCode();
        hash.Add(Rows);
        hash.Add(Columns);

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                hash.Add(_values[i, j]);
            }
        }

        return hash.ToHashCode();
    }

    public static Matrix operator +(Matrix left, Matrix right)
    {
        if (left.Rows != right.Rows || left.Columns != right.Columns)
        {
            throw new InvalidOperationException("Для сложения размеры матриц должны совпадать.");
        }

        double[,] result = new double[left.Rows, left.Columns];

        for (int i = 0; i < left.Rows; i++)
        {
            for (int j = 0; j < left.Columns; j++)
            {
                result[i, j] = left._values[i, j] + right._values[i, j];
            }
        }

        return new Matrix(result);
    }

    public static Matrix operator ~(Matrix matrix)
    {
        double[,] result = new double[matrix.Columns, matrix.Rows];

        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Columns; j++)
            {
                result[j, i] = matrix._values[i, j];
            }
        }

        return new Matrix(result);
    }

    public static Matrix operator *(Matrix left, Matrix right)
    {
        if (left.Columns != right.Rows)
        {
            throw new InvalidOperationException("Нельзя умножить матрицы: столбцы первой должны быть равны строкам второй.");
        }

        double[,] result = new double[left.Rows, right.Columns];

        for (int i = 0; i < left.Rows; i++)
        {
            for (int j = 0; j < right.Columns; j++)
            {
                double sum = 0;

                for (int k = 0; k < left.Columns; k++)
                {
                    sum += left._values[i, k] * right._values[k, j];
                }

                result[i, j] = sum;
            }
        }

        return new Matrix(result);
    }

    public static Matrix operator /(Matrix left, Matrix right)
    {
        return left * right.GetInverse();
    }

    public static bool operator == (Matrix left, Matrix right)
    {
        if (ReferenceEquals(left, right))
        {
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        return left.Equals(right);
    }

    public static bool operator !=(Matrix left, Matrix right)
    {
        return !(left == right);
    }

    public static bool operator >(Matrix left, Matrix right)
    {
        ValidateMatricesForDeterminantComparison(left, right);
        return left.Determinant > right.Determinant;
    }

    public static bool operator <(Matrix left, Matrix right)
    {
        ValidateMatricesForDeterminantComparison(left, right);
        return left.Determinant < right.Determinant;
    }

    public static bool operator >=(Matrix left, Matrix right)
    {
        ValidateMatricesForDeterminantComparison(left, right);
        return left.Determinant >= right.Determinant;
    }

    public static bool operator <=(Matrix left, Matrix right)
    {
        ValidateMatricesForDeterminantComparison(left, right);
        return left.Determinant <= right.Determinant;
    }

    
    public Matrix GetInverse()
    {
        if (Rows != Columns)
        {
            throw new InvalidOperationException("Обратная матрица существует только для квадратной матрицы.");
        }

        double determinant = Determinant;

        if (Math.Abs(determinant) < 0.000001)
        {
            throw new InvalidOperationException("Обратную матрицу нельзя найти, если определитель равен 0.");
        }

       
        if (Rows == 1)
        {
            return new Matrix(new double[,] { { 1.0 / _values[0, 0] } });
        }

        double[,] cofactors = new double[Rows, Columns];

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                double[,] minor = GetMinor(_values, i, j);
                double minorDeterminant = CalculateDeterminant(minor);

                cofactors[i, j] = Math.Pow(-1, i + j) * minorDeterminant;
            }
        }

        Matrix adjugate = ~new Matrix(cofactors);

        double[,] result = new double[Rows, Columns];

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                result[i, j] = adjugate[i, j] / determinant;
            }
        }

        return new Matrix(result);
    }

    private static void ValidateMatricesForDeterminantComparison(Matrix left, Matrix right)
    {
        if (left is null || right is null)
        {
            throw new ArgumentNullException("Матрицы не должны быть null.");
        }

        if (left.Rows != left.Columns || right.Rows != right.Columns)
        {
            throw new InvalidOperationException("Сравнение по определителю возможно только для квадратных матриц.");
        }
    }

   
    private static double CalculateDeterminant(double[,] matrix)
    {
        int size = matrix.GetLength(0);

        if (size != matrix.GetLength(1))
        {
            throw new InvalidOperationException("Определитель можно вычислить только для квадратной матрицы.");
        }

        if (size == 1)
        {
            return matrix[0, 0];
        }

        if (size == 2)
        {
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }

        double determinant = 0;

        for (int column = 0; column < size; column++)
        {
            double[,] minor = GetMinor(matrix, 0, column);
            determinant += Math.Pow(-1, column) * matrix[0, column] * CalculateDeterminant(minor);
        }

        return determinant;
    }


    private static double[,] GetMinor(double[,] matrix, int rowToRemove, int columnToRemove)
    {
        int size = matrix.GetLength(0);
        double[,] minor = new double[size - 1, size - 1];

        int minorRow = 0;

        for (int i = 0; i < size; i++)
        {
            if (i == rowToRemove)
            {
                continue;
            }

            int minorColumn = 0;

            for (int j = 0; j < size; j++)
            {
                if (j == columnToRemove)
                {
                    continue;
                }

                minor[minorRow, minorColumn] = matrix[i, j];
                minorColumn++;
            }

            minorRow++;
        }

        return minor;
    }
}
