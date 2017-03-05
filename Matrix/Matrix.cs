using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public class Matrix
    {
        protected int rowCount;
        public int RowCount
        {
            get { return rowCount; }
        }

        protected int colCount;
        public int ColCount
        {
            get { return colCount; }
        }

        protected double[,] values;

        protected Matrix(int rowCount, int colCount)
        {
            if (rowCount <= 0 || colCount <= 0)
                throw new ArgumentOutOfRangeException();

            this.rowCount = rowCount;
            this.colCount = colCount;

            this.values = new double[rowCount, colCount];
        }

        public static Matrix CreateZeroMatrix(int rowCount, int colCount)
        {
            return new Matrix(rowCount, colCount);
        }

        public Matrix(double[,] values)
        {
            this.rowCount = values.GetUpperBound(0) - values.GetLowerBound(0) + 1;
            this.colCount = values.GetUpperBound(1) - values.GetLowerBound(1) + 1;

            this.values = values.Clone() as double[,];
        }

        public virtual Matrix Clone()
        {
            return new Matrix(values);
        }

        public double this[int row, int column]
        {
            get { return values[row, column]; }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Matrix))
                throw new ArgumentException("Cannot compare incompatible types");

            Matrix other = obj as Matrix;

            if (this.colCount != other.colCount)
                return false;

            if (this.rowCount != other.rowCount)
                return false;

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                for (int colIndex = 0; colIndex < colCount; colIndex++)
                    if (this.values[rowIndex, colIndex].Equals(other.values[rowIndex, colIndex]))
                        return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int colIndex = 0; colIndex < colCount; colIndex++)
                {
                    sb.AppendFormat("{0}\t", values[rowIndex, colIndex]);
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public Vector GetRow(int rowIndex)
        {
            double[] row = new double[colCount];
            for (int colIndex = 0; colIndex < colCount; colIndex++)
                row[colIndex] = values[rowIndex, colIndex];

            return new Vector(row);
        }

        public void SetRow(int rowIndex, Vector row)
        {
            if (row.Count != this.colCount)
                throw new ArgumentException("Set row must have the same count of elements as matrix rows");

            for (int colIndex = 0; colIndex < colCount; colIndex++)
                values[rowIndex, colIndex] = row[colIndex];
        }

        public Vector GetColumn(int colIndex)
        {
            double[] col = new double[rowCount];
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                col[rowIndex] = values[rowIndex, colIndex];

            return new Vector(col);
        }

        public void SetColumn(int colIndex, Vector column)
        {
            if (column.Count != this.rowCount)
                throw new ArgumentException("Set column must have the same count of elements as matrix columns");

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                values[rowIndex, colIndex] = column[colIndex];
        }

        // TODO: объявить и реализовать методы умножения матрицы на константу,
        // константы на матрицу, унарного и бинарного минусов

        public static Matrix operator *(Matrix matrix, double factor)
        {
            Matrix factored = new Matrix(matrix.rowCount, matrix.rowCount);

            for (int rowIndex = 0; rowIndex < matrix.rowCount; rowIndex++)
                for (int colIndex = 0; colIndex < matrix.rowCount; colIndex++)
                    factored.values[rowIndex, colIndex] = matrix.values[rowIndex, colIndex] * factor;

            return factored;
        }

        public static Matrix operator *(double factor, Matrix matrix)
        {
            return matrix * factor;
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.colCount != matrix2.colCount && matrix1.rowCount != matrix2.rowCount)
                throw new ArgumentException("Summable matrices must be have same size");

            Matrix sum = new Matrix(matrix1.rowCount, matrix1.rowCount);

            for (int rowIndex = 0; rowIndex < matrix1.rowCount; rowIndex++)
                for (int colIndex = 0; colIndex < matrix1.rowCount; colIndex++)
                    sum.values[rowIndex, colIndex] = matrix1.values[rowIndex, colIndex] + matrix2.values[rowIndex, colIndex];

            return sum;
        }

        public static Matrix operator -(Matrix matrix)
        {
            return matrix * (-1.0);
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            return matrix1 + matrix2 * (-1.0);
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.colCount != matrix2.rowCount)
                throw new ArgumentException("Multiplied matrices must be compatible");

            Matrix product = new Matrix(matrix1.rowCount, matrix2.colCount);

            for (int rowIndex = 0; rowIndex < matrix1.rowCount; rowIndex++)
                for (int colIndex = 0; colIndex < matrix2.colCount; colIndex++)
                    product.values[rowIndex, colIndex] = matrix1.GetRow(rowIndex) * matrix2.GetColumn(colIndex);

            return product;
        }

        public virtual Matrix Transposed
        {
            get
            {
                Matrix transposed = new Matrix(colCount, rowCount);

                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    for (int colIndex = 0; colIndex < colCount; colIndex++)
                        transposed.values[colIndex, rowIndex] = values[rowIndex, colIndex];

                return transposed;
            }
        }

        public Matrix GetSubmatrixExceptRow(int rowExceptIndex)
        {
            Matrix matrixGetSubmatrixExceptRow = new Matrix(rowCount - 1, colCount);

            Matrix valuesCopy = new Matrix(values.Clone() as double[,]);

            for (int rowIndex = 0; rowIndex < rowCount - 1; rowIndex++)
                for (int colIndex = 0; colIndex < colCount; colIndex++)
                    if (rowIndex < rowExceptIndex)
                        matrixGetSubmatrixExceptRow.values[rowIndex, colIndex] = valuesCopy[rowIndex, colIndex];
                    else
                        matrixGetSubmatrixExceptRow.values[rowIndex, colIndex] = valuesCopy[rowIndex + 1, colIndex];

            return matrixGetSubmatrixExceptRow;
        }
        
        public Matrix GetSubmatrixExceptColumn(int colExceptIndex)
        {
            Matrix matrixGetSubmatrixExceptColumn = new Matrix(rowCount, colCount -1);

            Matrix valuesCopy = new Matrix(values.Clone() as double[,]);

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                for (int colIndex = 0; colIndex < colCount - 1; colIndex++)
                    if (colIndex < colExceptIndex)
                        matrixGetSubmatrixExceptColumn.values[rowIndex, colIndex] = valuesCopy[rowIndex, colIndex];
                    else
                        matrixGetSubmatrixExceptColumn.values[rowIndex, colIndex] = valuesCopy[rowIndex, colIndex + 1];

            return matrixGetSubmatrixExceptColumn;
        }

        public Matrix GetMinor(int rowExceptIndex, int colExceptIndex)
        {
            Matrix minor = new Matrix(values);

            if ((rowExceptIndex + colExceptIndex) % 2 == 0)
                return minor.GetSubmatrixExceptRow(rowExceptIndex).GetSubmatrixExceptColumn(colExceptIndex);

            else
                return -minor.GetSubmatrixExceptRow(rowExceptIndex).GetSubmatrixExceptColumn(colExceptIndex);
        }

        public Matrix ReductionTriangularMatrix()
        {
            Matrix triangularMatrix = new Matrix(values);

            for (int overRowIndex = 0; overRowIndex < rowCount - 1; overRowIndex++)
                for (int underRowIndex = overRowIndex + 1; underRowIndex < rowCount; underRowIndex++)
                    for (int colIndex = colCount - 1; colIndex >= 0; colIndex--)
                        triangularMatrix.values[underRowIndex, colIndex] =
                        triangularMatrix[underRowIndex, colIndex] -
                        (triangularMatrix[underRowIndex, overRowIndex] / triangularMatrix[overRowIndex, overRowIndex]) *
                        triangularMatrix[overRowIndex, colIndex];

            return triangularMatrix;
        }
    }
}
