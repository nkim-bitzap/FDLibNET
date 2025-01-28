using MathNet.Numerics.LinearAlgebra;
using FDLibNET;

namespace UnitTests;

public class MatrixBlock_BottomRows {

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
    public void Test_MatrixBlock_BottomRows_1() {
      var matrix = sampleMatrix.Clone();


    }
}