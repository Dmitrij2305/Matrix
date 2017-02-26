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
            return null;
        }
    }
}
