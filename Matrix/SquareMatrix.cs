using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public class SquareMatrix : Matrix
    {
        public SquareMatrix(int size)
            : base(size, size)
        { }

        public SquareMatrix(double[,] values)
            : base(values)
        {
            if (rowCount != colCount)
                throw new ArgumentException("Bidimensional array must have the same row and column numbers to be allowed to initialize square matrix");
        }

        public static SquareMatrix CreateZeroMatrix(int size)
        {
            return new SquareMatrix(size);
        }

        private static SquareMatrix CreateUnitMatrix(int size)
        {
            SquareMatrix matrix = new SquareMatrix(size);

            for (int index = 0; index < size; index++)
                matrix.values[index, index] = 1.0;

            return matrix;
        }

        public object Clone()
        {
            return new SquareMatrix(values);
        }

        public IMatrix Transposed
        {
            get
            {
                SquareMatrix transposed = (SquareMatrix)this.Clone();

                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    for (int colIndex = 0; colIndex < colCount; colIndex++)
                        transposed.values[colIndex, rowIndex] = values[rowIndex, colIndex];

                return transposed;
            }
        }

        public double GetDeterminant(Matrix value)
        {
            double determinant = 0;

            int size = rowCount;

            if (size == 1)
                return values[0, 0];
            else if (size == 2)
                return values[0, 0] * values[1, 1] - values[0, 1] * values[1, 0];
            else
            {
                for (int index = 0; index < size; index++)
                    determinant += values[0, index] * GetDeterminant(GetMinor(0, index));

                return determinant;
            }
        }
    }
}
