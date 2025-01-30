using MathNet.Numerics.LinearAlgebra;
using FDLibNET;

namespace UnitTests;

public class MatrixBlock_MakeUpperTriangular {

    [Fact]
    public void Test_MatrixBlock_MakeUpperTriangular_1() {
      var matrix = Matrix<double>.Build.DenseOfRows(
      [ [-3] ]);

      MatrixBlock.MakeUpperTriangular(matrix);

      Assert.Equal(1, matrix.RowCount);
      Assert.Equal(1, matrix.ColumnCount);
      Assert.Equal(-3, matrix[0, 0]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MakeUpperTriangular_2() {
      var matrix = Matrix<double>.Build.DenseOfRows(
      [ [ -3, 7] ]);

      MatrixBlock.MakeUpperTriangular(matrix);

      Assert.Equal(1, matrix.RowCount);
      Assert.Equal(2, matrix.ColumnCount);
      Assert.Equal(-3, matrix[0, 0]);
      Assert.Equal(7, matrix[0, 1]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MakeUpperTriangular_3() {
      var matrix = Matrix<double>.Build.DenseOfRows(
      [ [ -3, 7, 1] ]);

      MatrixBlock.MakeUpperTriangular(matrix);

      Assert.Equal(1, matrix.RowCount);
      Assert.Equal(3, matrix.ColumnCount);
      Assert.Equal(-3, matrix[0, 0]);
      Assert.Equal(7, matrix[0, 1]);
      Assert.Equal(1, matrix[0, 2]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MakeUpperTriangular_4() {
      var matrix = Matrix<double>.Build.DenseOfRows(
      [ [-3], [4] ]);

      MatrixBlock.MakeUpperTriangular(matrix);

      Assert.Equal(2, matrix.RowCount);
      Assert.Equal(1, matrix.ColumnCount);
      Assert.Equal(-3, matrix[0, 0]); 

      // Below the diagonal.
      Assert.Equal(0, matrix[1, 0]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MakeUpperTriangular_5() {
      var matrix = Matrix<double>.Build.DenseOfRows(
      [ [-3], [4], [0] ]);

      MatrixBlock.MakeUpperTriangular(matrix);

      Assert.Equal(3, matrix.RowCount);
      Assert.Equal(1, matrix.ColumnCount);
      Assert.Equal(-3, matrix[0, 0]); 
      Assert.Equal(0, matrix[1, 0]);
      Assert.Equal(0, matrix[2, 0]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MakeUpperTriangular_6() {
      var matrix = Matrix<double>.Build.DenseOfRows(
      [ [-3, 1], [4, 6], [0, -1] ]);

      MatrixBlock.MakeUpperTriangular(matrix);

      Assert.Equal(3, matrix.RowCount);
      Assert.Equal(2, matrix.ColumnCount);

      // first row
      Assert.Equal(-3, matrix[0, 0]);
      Assert.Equal(1, matrix[0, 1]);

      // second row
      Assert.Equal(0, matrix[1, 0]);
      Assert.Equal(6, matrix[1, 1]);

      // third row
      Assert.Equal(0, matrix[2, 0]);
      Assert.Equal(0, matrix[2, 1]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MakeUpperTriangular_7() {
      var matrix = Matrix<double>.Build.DenseOfRows(
      [ [-3, 1, 1], [4, 6, 7], [4, 2, -1] ]);

      MatrixBlock.MakeUpperTriangular(matrix);

      Assert.Equal(3, matrix.RowCount);
      Assert.Equal(3, matrix.ColumnCount);

      // first row
      Assert.Equal(-3, matrix[0, 0]);
      Assert.Equal(1, matrix[0, 1]);
      Assert.Equal(1, matrix[0, 2]);

      // second row
      Assert.Equal(0, matrix[1, 0]);
      Assert.Equal(6, matrix[1, 1]);
      Assert.Equal(7, matrix[1, 2]);

      // third row
      Assert.Equal(0, matrix[2, 0]);
      Assert.Equal(0, matrix[2, 1]);
      Assert.Equal(-1, matrix[2, 2]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MakeUpperTriangular_8() {
      var matrix = Matrix<double>.Build.DenseOfRows(
      [ [-3, 1, 1], [4, 6, 7] ]);

      MatrixBlock.MakeUpperTriangular(matrix);

      Assert.Equal(2, matrix.RowCount);
      Assert.Equal(3, matrix.ColumnCount);

      // first row
      Assert.Equal(-3, matrix[0, 0]);
      Assert.Equal(1, matrix[0, 1]);
      Assert.Equal(1, matrix[0, 2]);

      // second row
      Assert.Equal(0, matrix[1, 0]);
      Assert.Equal(6, matrix[1, 1]);
      Assert.Equal(7, matrix[1, 2]);
    }
}