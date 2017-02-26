using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLibrary;

namespace MatrixTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MatrixCreation()
        {
            Matrix matrix = new Matrix(3, 4);

            Assert.AreEqual(3, matrix.RowCount);
            Assert.AreEqual(4, matrix.ColCount);

            matrix = new SquareMatrix(3);

            Assert.AreEqual(3, matrix.RowCount);
            Assert.AreEqual(3, matrix.ColCount);

            matrix = new Matrix(-5, 0);


        }
    }
}
