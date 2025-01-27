using MathNet.Numerics.LinearAlgebra;
using FDLibNET;

namespace UnitTests;

public class MatrixBlock_SwapValues {

    readonly Vector<double> sampleVector =
      Vector<double>.Build.DenseOfArray([ 1, 3, 0, -7, 4, 2]);

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_SwapValues_1() {
      var vector = sampleVector.Clone();
      
      MatrixBlock.SwapValues(vector, 0, 1);

      Assert.Equal(3, vector[0]);
      Assert.Equal(1, vector[1]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_SwapValues_2() {
      var vector = sampleVector.Clone();
      
      MatrixBlock.SwapValues(vector, 0, 1);
      MatrixBlock.SwapValues(vector, 0, 1);

      Assert.Equal(1, vector[0]);
      Assert.Equal(3, vector[1]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_SwapValues_3() {
      var vector = sampleVector.Clone();
      
      MatrixBlock.SwapValues(vector, 0, 1);
      MatrixBlock.SwapValues(vector, 1, 2);

      Assert.Equal(3, vector[0]);
      Assert.Equal(0, vector[1]);
      Assert.Equal(1, vector[2]);

    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_SwapValues_4() {
      var vector = sampleVector.Clone();
      
      MatrixBlock.SwapValues(vector, 0, 0);

      Assert.Equal(1, vector[0]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_MatrixBlock_SwapValues_5() {
      var vector = sampleVector.Clone();

      // Bubble sort.
      for (int n = vector.Count; n > 1; n--) {
        for (int i = 0; i < n - 1; i++) {
          if (vector[i] > vector[i + 1]) {
            MatrixBlock.SwapValues(vector, i, i + 1);
          }
        } 
      }

      Assert.Equal(-7, vector[0]);
      Assert.Equal(0, vector[1]);
      Assert.Equal(1, vector[2]);
      Assert.Equal(2, vector[3]);
      Assert.Equal(3, vector[4]);
      Assert.Equal(4, vector[5]);
    }
}
