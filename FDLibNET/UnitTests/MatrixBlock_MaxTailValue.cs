using MathNet.Numerics.LinearAlgebra;
using FDLibNET;

namespace UnitTests;

public class MatrixBlock_MaxTailValue {

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
    public void Test_MatrixBlock_MaxTail_1() {
      var vector = sampleVector.Clone();
      
      var index = -1;
      var value = MatrixBlock.MaxTailValue(vector, 1, ref index);

      Assert.Equal(2, value);
      Assert.Equal(0, index);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MaxTail_2() {
      var vector = sampleVector.Clone();
      
      var index = -1;
      var value = MatrixBlock.MaxTailValue(vector, 2, ref index);

      Assert.Equal(4, value);
      Assert.Equal(0, index);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MaxTail_3() {
      var vector = sampleVector.Clone();
      
      var index = -1;
      var value = MatrixBlock.MaxTailValue(vector, 3, ref index);

      Assert.Equal(4, value);
      Assert.Equal(1, index);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MaxTail_4() {
      var vector = sampleVector.Clone();
      
      var index = -1;
      var value = MatrixBlock.MaxTailValue(vector, 4, ref index);

      Assert.Equal(4, value);
      Assert.Equal(2, index);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MaxTail_5() {
      var vector = sampleVector.Clone();
      
      var index = -1;
      var value = MatrixBlock.MaxTailValue(vector, 5, ref index);

      Assert.Equal(4, value);
      Assert.Equal(3, index);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MaxTail_6() {
      var vector = sampleVector.Clone();
      
      var index = -1;
      var value = MatrixBlock.MaxTailValue(vector, 6, ref index);

      Assert.Equal(4, value);
      Assert.Equal(4, index);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MaxTail_7() {
      var vector = sampleVector.Clone();
      
      var index = -1;
      var value =
        MatrixBlock.MaxTailValue(vector, vector.Count, ref index);

      Assert.Equal(vector.Max(), value);
      Assert.Equal(vector.MaximumIndex(), index);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MaxTail_8() {
      var matrix = sampleMatrix.Clone();
      
      var index = -1;
      var value =
        MatrixBlock.MaxTailValue(matrix.Column(0), 1, ref index);

      Assert.Equal(-4, value);
      Assert.Equal(0, index);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MaxTail_9() {
      var matrix = sampleMatrix.Clone();
      
      var index = -1;
      var value =
        MatrixBlock.MaxTailValue(matrix.Column(0), 2, ref index);

      Assert.Equal(1, value);
      Assert.Equal(0, index);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MaxTail_10() {
      var matrix = sampleMatrix.Clone();
      
      var index = -1;
      var value =
        MatrixBlock.MaxTailValue(matrix.Column(0), 3, ref index);

      Assert.Equal(1, value);
      Assert.Equal(1, index);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MaxTail_11() {
      var matrix = sampleMatrix.Clone();
      
      var index = -1;
      var value =
        MatrixBlock.MaxTailValue(matrix.Column(0), 4, ref index);

      Assert.Equal(2, value);
      Assert.Equal(0, index);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MaxTail_12() {
      var matrix = sampleMatrix.Clone();
      
      var index = -1;
      var value =
        MatrixBlock.MaxTailValue(matrix.Column(0), 5, ref index);

      Assert.Equal(2, value);
      Assert.Equal(1, index);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MaxTail_13() {
      var matrix = sampleMatrix.Clone();
      
      var index = -1;
      var value =
        MatrixBlock.MaxTailValue(
          matrix.Column(matrix.ColumnCount - 1),
          matrix.Column(matrix.ColumnCount - 1).Count,
          ref index);

      Assert.Equal(
        value, matrix.Column(matrix.ColumnCount - 1).Max());

      Assert.Equal(
        index, matrix.Column(matrix.ColumnCount - 1).MaximumIndex());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MaxTail_14() {
      var matrix = sampleMatrix.Clone();
      
      var index = -1;
      var value =
        MatrixBlock.MaxTailValue(
          matrix.Column(matrix.ColumnCount - 1),
          matrix.Column(matrix.ColumnCount - 1).Count,
          ref index);

      Assert.Equal(4, value); 
      Assert.Equal(0, index);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MaxTail_15() {
      var matrix = sampleMatrix.Clone();
      
      var index = -1;
      var value =
        MatrixBlock.MaxTailValue(matrix.Row(1), 1, ref index);

      Assert.Equal(1, value);
      Assert.Equal(0, index);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MaxTail_16() {
      var matrix = sampleMatrix.Clone();
      
      var index = -1;
      var value =
        MatrixBlock.MaxTailValue(matrix.Row(1), 2, ref index);

      Assert.Equal(1, value);
      Assert.Equal(1, index);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MaxTail_17() {
      var matrix = sampleMatrix.Clone();
      
      var index = -1;
      var value =
        MatrixBlock.MaxTailValue(matrix.Row(1), 3, ref index);

      Assert.Equal(3, value);
      Assert.Equal(0, index);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MaxTail_18() {
      var matrix = sampleMatrix.Clone();
      
      var index = -1;
      var value =
        MatrixBlock.MaxTailValue(matrix.Row(1), 4, ref index);

      Assert.Equal(3, value);
      Assert.Equal(1, index);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MaxTail_19() {
      var matrix = sampleMatrix.Clone();
      
      var index = -1;
      var value =
        MatrixBlock.MaxTailValue(
          matrix.Row(matrix.RowCount - 1),
          matrix.Row(matrix.RowCount - 1).Count,
          ref index);

      Assert.Equal(
        value, matrix.Row(matrix.RowCount - 1).Max());

      Assert.Equal(
        index, matrix.Row(matrix.RowCount - 1).MaximumIndex());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_MaxTail_20() {
      var matrix = sampleMatrix.Clone();
      
      var index = -1;
      var value =
        MatrixBlock.MaxTailValue(
          matrix.Row(matrix.RowCount - 1),
          matrix.Row(matrix.RowCount - 1).Count,
          ref index);

      Assert.Equal(3, value);
      Assert.True(2 == index || 3 == index);
    }
}