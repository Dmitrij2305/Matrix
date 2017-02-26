using System;
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
    }
}
