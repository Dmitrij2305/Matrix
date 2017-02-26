using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLibrary;

namespace MatrixTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EmptyMatrixCreation()
        {
            Matrix<int> matrix = new Matrix<int>(3, 4);
            Assert.AreEqual(3, matrix.RowCount);
            Assert.AreEqual(4, matrix.ColCount);

            matrix = new SquareMatrix<int>(3);
            Assert.AreEqual(3, matrix.RowCount);
            Assert.AreEqual(3, matrix.ColCount);

            matrix = new Matrix<int>(-5, 5);
            Assert.Fail("Отрицательные и нулевые значения rowCount и colCount не допускаются");

            matrix = new Matrix<int>(1, 0);
            Assert.Fail("Отрицательные и нулевые значения rowCount и colCount не допускаются");
        }

        [TestMethod]
        public void FilledMatrixCreation()
        {
            int[,] items = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 0, 0 }  };

            Matrix<int> matrix = new Matrix<int>(items);
            Assert.AreEqual<int>(3, matrix.RowCount);
            Assert.AreEqual<int>(4, matrix.ColCount);

            //Matrix<int> sameMatrix = new Matrix<int>(items);
            
        }

        [TestMethod]
        public void MatrixCopy()
        {
            Matrix<int> matrix = new Matrix<int>(3, 4);
            Matrix<int> matrixCopy = matrix.Copy();

            Assert.AreNotSame(matrix, matrixCopy);

            Assert.AreEqual<int>(matrix.RowCount, matrixCopy.RowCount);
            Assert.AreEqual<int>(matrix.ColCount, matrixCopy.ColCount);
        }

        [TestMethod]
        public void SquareMatrixCopy()
        {
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(3);
            SquareMatrix<int> squareMatrixCopy = squareMatrix.Copy();

            Assert.AreNotSame(squareMatrix, squareMatrixCopy);

            Assert.AreEqual<int>(squareMatrix.RowCount, squareMatrixCopy.RowCount);
            Assert.AreEqual<int>(squareMatrix.ColCount, squareMatrixCopy.ColCount);
        }

        [TestMethod]
        public void MatrixTranspose()
        {

        }
    }
}
