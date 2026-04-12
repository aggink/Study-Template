using System;
using System.Globalization;
using System.Text;

namespace Study.LabWork1.Features.Task1;

public sealed class Matrix : IEquatable<Matrix>
{
    private readonly double[,] _data;
    private const double Epsilon = 1e-9;

    public int Rows { get; }
    public int Columns { get; }

    public double Determinant
    {
        get
        {
            EnsureSquare();
            return CalculateDeterminant(_data);
        }
    }

    public Matrix(double[,] values)
    {
        ArgumentNullException.ThrowIfNull(values);

        Rows = values.GetLength(0);
        Columns = values.GetLength(1);

        if (Rows == 0 || Columns == 0)
        {
            throw new ArgumentException("Матрица не может быть пустой.");
        }

        _data = (double[,])values.Clone();
    }

    public double GetValue(int row, int column)
    {
        return _data[row, column];
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        for (int i = 0; i < Rows; i++)
        {
            builder.Append("| ");

            for (int j = 0; j < Columns; j++)
            {
                builder.Append(_data[i, j].ToString("0.00", CultureInfo.InvariantCulture));

                if (j < Columns - 1)
                {
                    builder.Append(' ');
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

    public bool Equals(Matrix? other)
    {
        if (other is null)
        {
            return false;
        }

        if (Rows != other.Rows || Columns != other.Columns)
        {
            return false;
        }

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (Math.Abs(_data[i, j] - other._data[i, j]) > Epsilon)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Matrix);
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Rows);
        hash.Add(Columns);

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                hash.Add(Math.Round(_data[i, j], 8));
            }
        }

        return hash.ToHashCode();
    }

    public static Matrix operator +(Matrix left, Matrix right)
    {
        ArgumentNullException.ThrowIfNull(left);
        ArgumentNullException.ThrowIfNull(right);

        if (left.Rows != right.Rows || left.Columns != right.Columns)
        {
            throw new InvalidOperationException("Складывать можно только матрицы одинакового размера.");
        }

        var result = new double[left.Rows, left.Columns];

        for (int i = 0; i < left.Rows; i++)
        {
            for (int j = 0; j < left.Columns; j++)
            {
                result[i, j] = left._data[i, j] + right._data[i, j];
            }
        }

        return new Matrix(result);
    }

    public static Matrix operator ~(Matrix matrix)
    {
        ArgumentNullException.ThrowIfNull(matrix);

        var result = new double[matrix.Columns, matrix.Rows];

        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Columns; j++)
            {
                result[j, i] = matrix._data[i, j];
            }
        }

        return new Matrix(result);
    }

    public static Matrix operator *(Matrix left, Matrix right)
    {
        ArgumentNullException.ThrowIfNull(left);
        ArgumentNullException.ThrowIfNull(right);

        if (left.Columns != right.Rows)
        {
            throw new InvalidOperationException("Количество столбцов первой матрицы должно совпадать с количеством строк второй.");
        }

        var result = new double[left.Rows, right.Columns];

        for (int i = 0; i < left.Rows; i++)
        {
            for (int j = 0; j < right.Columns; j++)
            {
                double sum = 0;

                for (int k = 0; k < left.Columns; k++)
                {
                    sum += left._data[i, k] * right._data[k, j];
                }

                result[i, j] = sum;
            }
        }

        return new Matrix(result);
    }

    public static Matrix operator /(Matrix left, Matrix right)
    {
        ArgumentNullException.ThrowIfNull(left);
        ArgumentNullException.ThrowIfNull(right);

        return left * right.Inverse();
    }

    public static bool operator ==(Matrix? left, Matrix? right)
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

    public static bool operator !=(Matrix? left, Matrix? right)
    {
        return !(left == right);
    }

    public static bool operator <(Matrix left, Matrix right)
    {
        ArgumentNullException.ThrowIfNull(left);
        ArgumentNullException.ThrowIfNull(right);

        return left.Determinant < right.Determinant - Epsilon;
    }

    public static bool operator >(Matrix left, Matrix right)
    {
        ArgumentNullException.ThrowIfNull(left);
        ArgumentNullException.ThrowIfNull(right);

        return left.Determinant > right.Determinant + Epsilon;
    }

    public static bool operator <=(Matrix left, Matrix right)
    {
        return left < right || Math.Abs(left.Determinant - right.Determinant) <= Epsilon;
    }

    public static bool operator >=(Matrix left, Matrix right)
    {
        return left > right || Math.Abs(left.Determinant - right.Determinant) <= Epsilon;
    }

    public Matrix Inverse()
    {
        EnsureSquare();

        double determinant = Determinant;
        if (Math.Abs(determinant) <= Epsilon)
        {
            throw new InvalidOperationException("Обратную матрицу нельзя найти, так как определитель равен 0.");
        }

        int n = Rows;
        var augmented = new double[n, n * 2];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                augmented[i, j] = _data[i, j];
            }

            for (int j = 0; j < n; j++)
            {
                augmented[i, j + n] = i == j ? 1.0 : 0.0;
            }
        }

        for (int pivot = 0; pivot < n; pivot++)
        {
            int bestRow = pivot;
            for (int row = pivot + 1; row < n; row++)
            {
                if (Math.Abs(augmented[row, pivot]) > Math.Abs(augmented[bestRow, pivot]))
                {
                    bestRow = row;
                }
            }

            if (Math.Abs(augmented[bestRow, pivot]) <= Epsilon)
            {
                throw new InvalidOperationException("Матрица вырожденная.");
            }

            if (bestRow != pivot)
            {
                SwapRows(augmented, bestRow, pivot);
            }

            double pivotValue = augmented[pivot, pivot];
            for (int col = 0; col < n * 2; col++)
            {
                augmented[pivot, col] /= pivotValue;
            }

            for (int row = 0; row < n; row++)
            {
                if (row == pivot)
                {
                    continue;
                }

                double factor = augmented[row, pivot];
                for (int col = 0; col < n * 2; col++)
                {
                    augmented[row, col] -= factor * augmented[pivot, col];
                }
            }
        }

        var inverse = new double[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                inverse[i, j] = augmented[i, j + n];
            }
        }

        return new Matrix(inverse);
    }

    private static void SwapRows(double[,] matrix, int firstRow, int secondRow)
    {
        int columns = matrix.GetLength(1);

        for (int col = 0; col < columns; col++)
        {
            (matrix[firstRow, col], matrix[secondRow, col]) = (matrix[secondRow, col], matrix[firstRow, col]);
        }
    }

    private void EnsureSquare()
    {
        if (Rows != Columns)
        {
            throw new InvalidOperationException("Операция доступна только для квадратных матриц.");
        }
    }

    private static double CalculateDeterminant(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        if (n != m)
        {
            throw new InvalidOperationException("Определитель можно вычислить только для квадратной матрицы.");
        }

        var temp = (double[,])matrix.Clone();
        double determinant = 1.0;
        int sign = 1;

        for (int pivot = 0; pivot < n; pivot++)
        {
            int bestRow = pivot;
            for (int row = pivot + 1; row < n; row++)
            {
                if (Math.Abs(temp[row, pivot]) > Math.Abs(temp[bestRow, pivot]))
                {
                    bestRow = row;
                }
            }

            if (Math.Abs(temp[bestRow, pivot]) <= Epsilon)
            {
                return 0.0;
            }

            if (bestRow != pivot)
            {
                SwapRows(temp, bestRow, pivot);
                sign *= -1;
            }

            double pivotValue = temp[pivot, pivot];
            determinant *= pivotValue;

            for (int row = pivot + 1; row < n; row++)
            {
                double factor = temp[row, pivot] / pivotValue;
                for (int col = pivot; col < n; col++)
                {
                    temp[row, col] -= factor * temp[pivot, col];
                }
            }
        }

        return determinant * sign;
    }
}
