using MathNet.Numerics.LinearAlgebra;
using FDLibNET;

namespace UnitTests;

public class MatrixBlock_TopRows {

    readonly Vector<double> sampleVector =
      Vector<double>.Build.DenseOfArray([ 1, 3, 0, -7, 4, 2]);

    readonly Matrix<double> sampleMatrix =
      Matrix<double>.Build.DenseOfColumns([
        [ 0, 2, 0, 1, -4 ],
        [-3, 3, -1, 0, 1],
        [1, 0, 0, 1, 3],
        [4, 1, 2, 0, 3]
      ]);

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_TopRows_1() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.TopRows(matrix, 1);

      Assert.Equal(matrix.ColumnCount, part.ColumnCount);      
      Assert.Equal(1, part.RowCount);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_TopRows_2() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.TopRows(matrix, 2);

      Assert.Equal(matrix.ColumnCount, part.ColumnCount);      
      Assert.Equal(2, part.RowCount);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_TopRows_3() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.TopRows(matrix, 3);

      Assert.Equal(matrix.ColumnCount, part.ColumnCount);      
      Assert.Equal(3, part.RowCount);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_TopRows_4() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.TopRows(matrix, 4);

      Assert.Equal(matrix.ColumnCount, part.ColumnCount);      
      Assert.Equal(4, part.RowCount);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_TopRows_5() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.TopRows(matrix, matrix.RowCount);

      Assert.Equal(matrix.ColumnCount, part.ColumnCount); 
      Assert.Equal(matrix.RowCount, part.RowCount); 
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_TopRows_6() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.TopRows(matrix, 1);

      Assert.Equal(0, part[0, 0]);
      Assert.Equal(-3, part[0, 1]);
      Assert.Equal(1, part[0, 2]);
      Assert.Equal(4, part[0, 3]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_TopRows_7() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.TopRows(matrix, 2);

      Assert.Equal(2, part[1, 0]);
      Assert.Equal(3, part[1, 1]);
      Assert.Equal(0, part[1, 2]);
      Assert.Equal(1, part[1, 3]);
    } 

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_TopRows_8() {
      var matrix = sampleMatrix.Clone();
      var numRows = 3;

      var part = MatrixBlock.TopRows(matrix, numRows);

      for (int row = 0; row < numRows; ++row) {
        for (int col = 0; col < matrix.ColumnCount; ++col) {
          Assert.Equal(matrix[row, col], part[row, col]);
        }
      }
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_TopRows_9() {
      var matrix = sampleMatrix.Clone();
      var numRows = 4;

      var part = MatrixBlock.TopRows(matrix, numRows);

      for (int row = 0; row < numRows; ++row) {
        for (int col = 0; col < matrix.ColumnCount; ++col) {
          Assert.Equal(matrix[row, col], part[row, col]);
        }
      }
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_TopRows_10() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.TopRows(matrix, matrix.RowCount);

      for (int row = 0; row < matrix.RowCount; ++row) {
        for (int col = 0; col < matrix.ColumnCount; ++col) {
          Assert.Equal(matrix[row, col], part[row, col]);
        }
      }
    }
}