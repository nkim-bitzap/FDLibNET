using MathNet.Numerics.LinearAlgebra;
using FDLibNET;

namespace UnitTests;

public class MatrixBlock_MatrixPart {

    readonly Matrix<double> sampleMatrix =
      Matrix<double>.Build.DenseOfColumns([
        [ 0, 2, 0, 1, -4 ],
        [-3, 3, -1, 0, 1],
        [1, 0, 0, 1, 3],
        [4, 1, 2, 0, 3]
      ]);

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MatrixPart_1() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.MatrixPart(matrix, 0, 0, 1, 1);

      Assert.Equal(1, part.RowCount);
      Assert.Equal(1, part.ColumnCount);
      Assert.Equal(0, part[0, 0]);
   }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MatrixPart_2() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.MatrixPart(matrix, 0, 0, 1, 2);

      Assert.Equal(1, part.RowCount);
      Assert.Equal(2, part.ColumnCount);
      Assert.Equal(-3, part[0, 1]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MatrixPart_3() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.MatrixPart(matrix, 0, 0, 1, 3);

      Assert.Equal(1, part.RowCount);
      Assert.Equal(3, part.ColumnCount);
      Assert.Equal(1, part[0, 2]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MatrixPart_4() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.MatrixPart(matrix, 0, 0, 1, 4);

      Assert.Equal(1, part.RowCount);
      Assert.Equal(4, part.ColumnCount);
      Assert.Equal(4, part[0, 3]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MatrixPart_5() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.MatrixPart(matrix, 0, 0, 2, 1);

      Assert.Equal(2, part.RowCount);
      Assert.Equal(1, part.ColumnCount);
      Assert.Equal(2, part[1, 0]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MatrixPart_6() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.MatrixPart(matrix, 0, 0, 3, 1);

      Assert.Equal(3, part.RowCount);
      Assert.Equal(1, part.ColumnCount);
      Assert.Equal(0, part[2, 0]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MatrixPart_7() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.MatrixPart(matrix, 0, 0, 4, 1);

      Assert.Equal(4, part.RowCount);
      Assert.Equal(1, part.ColumnCount);
      Assert.Equal(1, part[3, 0]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MatrixPart_8() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.MatrixPart(matrix, 0, 0, 5, 1);

      Assert.Equal(5, part.RowCount);
      Assert.Equal(1, part.ColumnCount);
      Assert.Equal(-4, part[4, 0]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MatrixPart_9() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.MatrixPart(matrix, 0, 0, 2, 2);

      Assert.Equal(2, part.RowCount);
      Assert.Equal(2, part.ColumnCount);
      Assert.Equal(0, part[0, 0]);
      Assert.Equal(2, part[1, 0]);
      Assert.Equal(-3, part[0, 1]);
      Assert.Equal(3, part[1, 1]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MatrixPart_10() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.MatrixPart(matrix, 1, 1, 2, 2);

      Assert.Equal(2, part.RowCount);
      Assert.Equal(2, part.ColumnCount);
      Assert.Equal(3, part[0, 0]);
      Assert.Equal(-1, part[1, 0]);
      Assert.Equal(0, part[0, 1]);
      Assert.Equal(0, part[1, 1]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MatrixPart_11() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.MatrixPart(matrix, 1, 2, 2, 2);

      Assert.Equal(2, part.RowCount);
      Assert.Equal(2, part.ColumnCount);
      Assert.Equal(0, part[0, 0]);
      Assert.Equal(0, part[1, 0]);
      Assert.Equal(1, part[0, 1]);
      Assert.Equal(2, part[1, 1]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MatrixPart_12() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.MatrixPart(matrix, 2, 1, 2, 2);

      Assert.Equal(2, part.RowCount);
      Assert.Equal(2, part.ColumnCount);
      Assert.Equal(-1, part[0, 0]);
      Assert.Equal(0, part[1, 0]);
      Assert.Equal(0, part[0, 1]);
      Assert.Equal(1, part[1, 1]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MatrixPart_13() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.MatrixPart(matrix, 2, 2, 2, 2);

      Assert.Equal(2, part.RowCount);
      Assert.Equal(2, part.ColumnCount);
      Assert.Equal(0, part[0, 0]);
      Assert.Equal(1, part[1, 0]);
      Assert.Equal(2, part[0, 1]);
      Assert.Equal(0, part[1, 1]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MatrixPart_14() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.MatrixPart(matrix, 3, 2, 2, 1);

      Assert.Equal(2, part.RowCount);
      Assert.Equal(1, part.ColumnCount);
      Assert.Equal(1, part[0, 0]);
      Assert.Equal(3, part[1, 0]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MatrixPart_15() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.MatrixPart(matrix, 1, 2, 1, 2);

      Assert.Equal(1, part.RowCount);
      Assert.Equal(2, part.ColumnCount);
      Assert.Equal(0, part[0, 0]);
      Assert.Equal(1, part[0, 1]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MatrixPart_16() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.MatrixPart(matrix, 3, 2, 2, 2);

      Assert.Equal(2, part.RowCount);
      Assert.Equal(2, part.ColumnCount);
      Assert.Equal(1, part[0, 0]);
      Assert.Equal(0, part[0, 1]);
      Assert.Equal(3, part[1, 0]);
      Assert.Equal(3, part[1, 1]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MatrixPart_17() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.MatrixPart(matrix, 3, 0, 2, 3);

      Assert.Equal(2, part.RowCount);
      Assert.Equal(3, part.ColumnCount);
      Assert.Equal(1, part[0, 0]);
      Assert.Equal(0, part[0, 1]);
      Assert.Equal(1, part[0, 2]);
      Assert.Equal(-4, part[1, 0]);
      Assert.Equal(1, part[1, 1]);
      Assert.Equal(3, part[1, 2]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MatrixPart_18() {
      var matrix = sampleMatrix.Clone();

      var part = MatrixBlock.MatrixPart(matrix, 0, 2, 3, 2);

      Assert.Equal(3, part.RowCount);
      Assert.Equal(2, part.ColumnCount);
      Assert.Equal(1, part[0, 0]);
      Assert.Equal(4, part[0, 1]);
      Assert.Equal(0, part[1, 0]);
      Assert.Equal(1, part[1, 1]);
      Assert.Equal(0, part[2, 0]);
      Assert.Equal(2, part[2, 1]);
    }
}