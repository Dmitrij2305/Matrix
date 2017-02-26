using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public class SquareMatrix<T> : Matrix<T>
    {
        public SquareMatrix(int size)
            : base(size, size)
        { }

        public SquareMatrix<T> Copy()
        {
        }
    }
}
