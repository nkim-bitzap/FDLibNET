using MathNet.Numerics.LinearAlgebra;
using FDLibNET;

namespace UnitTests;

public class MatrixBlock_ColumnTail {

    readonly Matrix<double> sampleMatrix =
      Matrix<double>.Build.DenseOfColumns([
        [ 0, 2, 0, 1, -4 ],
        [-3, 3, -1, 0, 1],
        [1, 0, 0, 1, 3],
        [4, 1, 2, 0, 3]
      ]);

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_ColumnTail_1() {
      var matrix = Matrix<double>.Build.Dense(1, 1);
      
      var tail =
        MatrixBlock.ColumnTail(matrix, 0, 0);

      Assert.Empty(tail);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_ColumnTail_2() {
      var matrix = Matrix<double>.Build.Dense(1, 1);

      var tail = MatrixBlock.ColumnTail(matrix, 0, 1);

      Assert.Single(tail);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_ColumnTail_3() {
      var matrix = sampleMatrix.Clone();

      var tail = MatrixBlock.ColumnTail(matrix, 0, 1);

      Assert.Single(tail);
      Assert.Equal(-4, tail[0]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_ColumnTail_4() {
      var matrix = sampleMatrix.Clone();

      var tail = MatrixBlock.ColumnTail(matrix, 0, 2);

      Assert.Equal(2, tail.Count);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_ColumnTail_5() {
      var matrix = sampleMatrix.Clone();

      var tail =
        MatrixBlock.ColumnTail(matrix, 0, matrix.Column(0).Count);

      Assert.Equal(matrix.Column(0).Count, tail.Count);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_ColumnTail_6() {
      var matrix = sampleMatrix.Clone();

      var tail =
        MatrixBlock.ColumnTail(matrix, 0, matrix.Row(0).Count);

      Assert.Equal(matrix.Row(0).Count, tail.Count);
      Assert.Equal(4, tail.Count);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_ColumnTail_7() {
      var matrix = sampleMatrix.Clone();

      var tail =
        MatrixBlock.ColumnTail(matrix, 0, matrix.Column(0).Count);

      Assert.Equal(0, tail[0]);
      Assert.Equal(2, tail[1]);
      Assert.Equal(0, tail[2]);
      Assert.Equal(1, tail[3]);
      Assert.Equal(-4, tail[4]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_ColumnTail_8() {
      var matrix = sampleMatrix.Clone();

      var tail =
        MatrixBlock.ColumnTail(matrix, 0, matrix.Column(0).Count - 1);

      Assert.Equal(2, tail[0]);
      Assert.Equal(0, tail[1]);
      Assert.Equal(1, tail[2]);
      Assert.Equal(-4, tail[3]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_ColumnTail_9() {
      var matrix = sampleMatrix.Clone();

      var tail =
        MatrixBlock.ColumnTail(matrix, 0, 3);

      Assert.Equal(0, tail[0]);
      Assert.Equal(1, tail[1]);
      Assert.Equal(-4, tail[2]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_ColumnTail_10() {
      var matrix = sampleMatrix.Clone();

      var tail =
        MatrixBlock.ColumnTail(matrix, 0, 1);

      Assert.Equal(-4, tail[0]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_ColumnTail_11() {
      var matrix = sampleMatrix.Clone();

      var tail = MatrixBlock.ColumnTail(
        matrix,
        matrix.ColumnCount - 1,
        matrix.Column(matrix.ColumnCount - 1).Count);

      Assert.Equal(4, tail[0]);
      Assert.Equal(1, tail[1]);
      Assert.Equal(2, tail[2]);
      Assert.Equal(0, tail[3]);
      Assert.Equal(3, tail[4]);
    }
}