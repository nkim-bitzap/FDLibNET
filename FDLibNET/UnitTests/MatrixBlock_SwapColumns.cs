using MathNet.Numerics.LinearAlgebra;
using FDLibNET;

namespace UnitTests;

public class MatrixBlock_SwapColumns {

    readonly Matrix<double> sampleMatrix =
      Matrix<double>.Build.DenseOfColumns([
        [ 0, 2, 0, 1, -4 ],
        [-3, 3, -1, 0, 1],
        [1, 0, 0, 1, 3],
        [4, 1, 2, 0, 3]
      ]);

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_SwapColumns_1() {
      var matrix = sampleMatrix.Clone();

      MatrixBlock.SwapColumns(matrix, 0, 0);

      Assert.Equal(0, matrix.Column(0)[0]);
      Assert.Equal(2, matrix.Column(0)[1]);
      Assert.Equal(0, matrix.Column(0)[2]);
      Assert.Equal(1, matrix.Column(0)[3]);
      Assert.Equal(-4, matrix.Column(0)[4]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_SwapColumns_2() {
      var matrix = sampleMatrix.Clone();

      MatrixBlock.SwapColumns(matrix, 0, 1);

      Assert.Equal(-3, matrix.Column(0)[0]);
      Assert.Equal(3, matrix.Column(0)[1]);
      Assert.Equal(-1, matrix.Column(0)[2]);
      Assert.Equal(0, matrix.Column(0)[3]);
      Assert.Equal(1, matrix.Column(0)[4]);

      Assert.Equal(0, matrix.Column(1)[0]);
      Assert.Equal(2, matrix.Column(1)[1]);
      Assert.Equal(0, matrix.Column(1)[2]);
      Assert.Equal(1, matrix.Column(1)[3]);
      Assert.Equal(-4, matrix.Column(1)[4]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_SwapColumns_3() {
      var matrix = sampleMatrix.Clone();

      MatrixBlock.SwapColumns(matrix, 0, 1);
      MatrixBlock.SwapColumns(matrix, 0, 1);

      Assert.Equal(0, matrix.Column(0)[0]);
      Assert.Equal(2, matrix.Column(0)[1]);
      Assert.Equal(0, matrix.Column(0)[2]);
      Assert.Equal(1, matrix.Column(0)[3]);
      Assert.Equal(-4, matrix.Column(0)[4]);

      Assert.Equal(-3, matrix.Column(1)[0]);
      Assert.Equal(3, matrix.Column(1)[1]);
      Assert.Equal(-1, matrix.Column(1)[2]);
      Assert.Equal(0, matrix.Column(1)[3]);
      Assert.Equal(1, matrix.Column(1)[4]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_SwapColumns_4() {
      var matrix = sampleMatrix.Clone();

      MatrixBlock.SwapColumns(matrix, 0, 1);
      MatrixBlock.SwapColumns(matrix, 1, 2);

      Assert.Equal(-3, matrix.Column(0)[0]);
      Assert.Equal(3, matrix.Column(0)[1]);
      Assert.Equal(-1, matrix.Column(0)[2]);
      Assert.Equal(0, matrix.Column(0)[3]);
      Assert.Equal(1, matrix.Column(0)[4]);

      Assert.Equal(1, matrix.Column(1)[0]);
      Assert.Equal(0, matrix.Column(1)[1]);
      Assert.Equal(0, matrix.Column(1)[2]);
      Assert.Equal(1, matrix.Column(1)[3]);
      Assert.Equal(3, matrix.Column(1)[4]);

      Assert.Equal(0, matrix.Column(2)[0]);
      Assert.Equal(2, matrix.Column(2)[1]);
      Assert.Equal(0, matrix.Column(2)[2]);
      Assert.Equal(1, matrix.Column(2)[3]);
      Assert.Equal(-4, matrix.Column(2)[4]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_SwapColumns_5() {
      var matrix = sampleMatrix.Clone();

      // Bubble sort, sort the columns by the first element.
      for (int n = matrix.ColumnCount; n > 1; n--) {
        for (int i = 0; i < n - 1; i++) {
          if (matrix.Column(i)[0] > matrix.Column(i + 1)[0]) {
            MatrixBlock.SwapColumns(matrix, i, i + 1);
          }
        } 
      }

      Assert.Equal(-3, matrix.Column(0)[0]);
      Assert.Equal(0, matrix.Column(1)[0]);
      Assert.Equal(1, matrix.Column(2)[0]);
      Assert.Equal(4, matrix.Column(3)[0]);
    }
}
