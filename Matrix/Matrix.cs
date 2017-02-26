using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public class Matrix
    {
        private int rowCount;
        public int RowCount
        {
            get { return rowCount; }
        }

        private int colCount;
        public int ColCount
        {
            get { return colCount; }
        }

        public Matrix(int rowCount, int colCount)
        {
            this.rowCount = rowCount;
            this.colCount = colCount;
        }

        public Matrix Copy()
        {
<<<<<<< HEAD
            this.rowCount = items.GetUpperBound(0) - items.GetLowerBound(0) + 1;
            this.colCount = items.GetUpperBound(1) - items.GetLowerBound(1) + 1;

            this.data = new T[rowCount + 1, colCount + 1];
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                for (int colIndex = 0; colIndex < colCount; colIndex++)
                    data[rowIndex + 1, colIndex + 1] = items[rowIndex, colIndex];
        }

        public Matrix<T> Copy()
        {
            Matrix<T> copy = new Matrix<T>(rowCount, colCount);

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                for (int colIndex = 0; colIndex < colCount; colIndex++)
                    copy.data[rowIndex, colIndex] = data[rowIndex, colIndex];

            return copy;
        }

        //public Matrix<T> 

        public T this[int row, int column]
        {
            get { return data[row, column]; }
            set { data[row, column] = value; }
        }
        
        public Matrix<T> Transposed
        {
            get
            {
                Matrix<T> transposed = new Matrix<T>(rowCount, colCount);

                for (int rowIndex = 1; rowIndex <= rowCount; rowIndex++)
                    for (int colIndex = 1; colIndex <= colCount; colIndex++)
                        transposed.data[rowIndex, colIndex] = data[colIndex, rowIndex];

                return transposed;
            }
=======
            return null;
>>>>>>> parent of 71ee35a... Первый блин
        }
    }
}
