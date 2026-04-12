namespace Study.LabWork1.Features.Task1
{
    //
    public class Matrix
    {
        private double[,] _matrix;
        public int GetResult()
        {
            return 0;
        }
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public double Determinant
        {
            get
            {
                return CalculateDeterminant(_matrix);
            }
        }


        private double CalculateDeterminant(double[,] matrix)
        {
            int n = matrix.GetLength(0);

            if (n == 1) return matrix[0, 0];
            if (n == 2) return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

            double determinant = 0;
            for (int i = 0; i < n; i++)
            {
                determinant += Math.Pow(-1, i) * matrix[0, i] * CalculateDeterminant(GetMinor(matrix, 0, i));
            }
            return determinant;
        }

        private double[,] GetMinor(double[,] matrix, int rowToRemove, int colToRemove)
        {
            int n = matrix.GetLength(0);
            double[,] minor = new double[n - 1, n - 1];
            int minorI = 0;

            for (int i = 0; i < n; i++)
            {
                if (i == rowToRemove) continue;

                int minorJ = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j == colToRemove) continue;
                    minor[minorI, minorJ] = matrix[i, j];
                    minorJ++;
                }
                minorI++;
            }
            return minor;
        }

        public Matrix(double[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            _matrix = new double[rows, columns];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    _matrix[i, j] = matrix[i, j];
            Rows = rows;
            Columns = columns;
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null || matrix2 == null)
                throw new ArgumentNullException();

            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
                throw new ArgumentException("Матрицы должны быть одинакового размера для сложения");

            double[,] result = new double[matrix1.Rows, matrix1.Columns];

            for (int i = 0; i < matrix1.Rows; i++)
                for (int j = 0; j < matrix1.Columns; j++)
                    result[i, j] = matrix1._matrix[i, j] + matrix2._matrix[i, j];

            return new Matrix(result);
        }

        public static Matrix operator ~(Matrix matrix)
        {
            double[,] newMatrix = new double[matrix.Columns, matrix.Rows];

            for (int i = 0; i < matrix.Rows; i++)
                for (int j = 0; j < matrix.Columns; j++)
                    newMatrix[j, i] = matrix._matrix[i, j];

            return new Matrix(newMatrix);
        }


        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null || matrix2 == null)
                throw new ArgumentNullException();

            // ЭТА ПРОВЕРКА ОЧЕНЬ ВАЖНА!
            if (matrix1.Columns != matrix2.Rows)
                throw new ArgumentException("Число столбцов первой матрицы должно равняться числу строк второй");

            double[,] result = new double[matrix1.Rows, matrix2.Columns];

            for (int i = 0; i < matrix1.Rows; i++)
                for (int j = 0; j < matrix2.Columns; j++)
                    for (int k = 0; k < matrix1.Columns; k++)
                        result[i, j] += matrix1._matrix[i, k] * matrix2._matrix[k, j];

            return new Matrix(result);
        }

        public static Matrix operator /(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null || matrix2 == null)
                throw new ArgumentNullException();

            if (Math.Abs(matrix2.Determinant) < 0.0001)
                throw new InvalidOperationException("Нельзя делить на вырожденную матрицу (определитель = 0)");

            Matrix inverseMatrix2 = matrix2.Inverse();
            return matrix1 * inverseMatrix2;
        }
        public Matrix Inverse()
        {
            double det = this.Determinant;

            if (Rows == 1 && Columns == 1)
            {
                return new Matrix(new double[,] { { 1.0 / _matrix[0, 0] } });
            }

            double[,] adjugate = new double[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    double[,] minor = GetMinor(_matrix, i, j);
                    double minorDet = CalculateDeterminant(minor);
                    adjugate[j, i] = Math.Pow(-1, i + j) * minorDet;
                }
            }

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    adjugate[i, j] /= det;

            return new Matrix(adjugate);
        }

        public static bool operator ==(Matrix matrix1, Matrix matrix2)
        {
            if (ReferenceEquals(matrix1, null) && ReferenceEquals(matrix2, null))
                return true;
            if (ReferenceEquals(matrix1, null) || ReferenceEquals(matrix2, null))
                return false;

            return Math.Abs(matrix1.Determinant - matrix2.Determinant) < 0.0001;
        }

        public static bool operator !=(Matrix matrix1, Matrix matrix2)
        {
            return !(matrix1 == matrix2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Matrix other)
            {
                return this == other;
            }
            return false;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Rows; i++)
            {
                result += "| ";
                for (int j = 0; j < Columns; j++)
                {
                    result += $"{_matrix[i, j]:F2} ";
                }
                result += "|\n";
            }
            return result;
        }
    }
}
