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
            double[,] values = new double[,] { { 2, 1, 1, 2 }, { 1, -1, 0, -2 }, { 3, -1, 2, 2 } };
            Matrix matrix = new Matrix(values);

            Console.WriteLine(matrix);

            Console.WriteLine(matrix.GetMinor(1,2));

            Console.WriteLine(matrix.ReductionTriangularMatrix());

            Console.ReadKey();
        }
    }
}
