using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MatrixLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(3);
            SquareMatrix<int> squareMatrixCopy = squareMatrix.Copy();

            Console.ReadKey();
        }
    }
}
