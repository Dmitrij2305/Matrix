using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLibrary;

namespace MatrixTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ZeroMatrixCreation()
        {
            Matrix matrix = Matrix.CreateZeroMatrix(3, 4);
            Assert.AreEqual(3, matrix.RowCount);
            Assert.AreEqual(4, matrix.ColCount);

            matrix = SquareMatrix.CreateZeroMatrix(3);
            Assert.AreEqual(3, matrix.RowCount);
            Assert.AreEqual(3, matrix.ColCount);

        }

        [TestMethod]
        public void NonPositiveArgumentsZeroMatrixCreation()
        {
            try
            {
                Matrix matrix = Matrix.CreateZeroMatrix(-5, 5);
                Assert.Fail();

                matrix = Matrix.CreateZeroMatrix(1, 0);
                Assert.Fail();
            }
            catch (ArgumentException)
            {
            }
        }

        [TestMethod]
        public void FilledMatrixCreation()
        {
            double[,] values = new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 0, 0 }  };

            Matrix matrix = new Matrix(values);
            Assert.AreEqual<int>(3, matrix.RowCount);
            Assert.AreEqual<int>(4, matrix.ColCount);

            //Matrix sameMatrix = new Matrix(items);
            
        }

        [TestMethod]
        public void FilledSquareMatrixCreation()
        {
            double[,] items = new double[,] { { 1, 2, 3 }, { 5, 6, 7 }, { 9, 10, 0 }  };

            SquareMatrix matrix = new SquareMatrix(items);
            Assert.AreEqual<int>(3, matrix.RowCount);
            Assert.AreEqual<int>(3, matrix.ColCount);

            //Matrix sameMatrix = new Matrix(items);
            
        }

        [TestMethod]
        public void FilledSquareMatrixWrongCreation()
        {
            double[,] items = new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 0, 0 } };

            try
            {
                SquareMatrix matrix = new SquareMatrix(items);
                Assert.Fail();
            }
            catch (ArgumentException)
            {
            }
            
        }

        [TestMethod]
        public void MatrixCopy()
        {
            double[,] values = new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 0, 0 } };
            Matrix matrix = new Matrix(values);
            Matrix matrixCopy = (Matrix)matrix.Clone();

            Assert.AreNotEqual(matrixCopy, matrix);

            Assert.AreEqual<int>(matrix.RowCount, matrixCopy.RowCount);
            Assert.AreEqual<int>(matrix.ColCount, matrixCopy.ColCount);

            Assert.AreSame(matrix, matrixCopy);
        }

        [TestMethod]
        public void SquareMatrixCopy()
        {
            SquareMatrix squareMatrix = new SquareMatrix(3);
            SquareMatrix squareMatrixCopy = (SquareMatrix)squareMatrix.Clone();

            Assert.AreNotEqual(squareMatrix, squareMatrixCopy);

            Assert.AreEqual<int>(squareMatrix.RowCount, squareMatrixCopy.RowCount);
            Assert.AreEqual<int>(squareMatrix.ColCount, squareMatrixCopy.ColCount);

            Assert.AreSame(squareMatrix, squareMatrixCopy);
        }

        [TestMethod]
        public void MatricesFromOneSourceCreation()
        {
            double[,] values = new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 0, 0 } };
            Matrix matrix1 = new Matrix(values);
            Matrix matrix2 = new Matrix(values);

            // TODO: здесь изменить matrix1

            Assert.AreNotSame(matrix1, matrix2);
        }
        
        [TestMethod]
        public void MatrixTranspose()
        {
            double[,] values = new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 0, 0 }  };

            Matrix matrix = new Matrix(values);
            Matrix transposed = (Matrix)matrix.Transposed;

            for (int row = 0; row < matrix.RowCount; row++)
                for (int col = 0; col < matrix.ColCount; col++)
                    Assert.AreEqual<double>(matrix[row, col], transposed[col, row]);
        }

        [TestMethod]
        public void SquareMatrixTranspose()
        {
            double[,] values = new double[,] { { 1, 2, 3 }, { 5, 6, 7 }, { 9, 10, 0 } };

            SquareMatrix matrix = new SquareMatrix(values);
            SquareMatrix transposed = (SquareMatrix)matrix.Transposed;

            for (int row = 0; row < matrix.RowCount; row++)
                for (int col = 0; col < matrix.ColCount; col++)
                    Assert.AreEqual<double>(matrix[row, col], transposed[col, row]);
        }
    }
}
