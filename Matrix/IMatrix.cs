using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public interface IMatrix
    {
        int RowCount { get; }
        int ColCount { get; }

        double this[int row, int column] { get; }

        Vector GetRow(int rowIndex);
        Vector GetColumn(int colIndex);
        void SetRow(int rowIndex, Vector row);
        void SetColumn(int colIndex, Vector column);

        IMatrix Transposed { get; }
    }
}
