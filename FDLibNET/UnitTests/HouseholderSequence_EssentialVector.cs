using MathNet.Numerics.LinearAlgebra;
using FDLibNET;

namespace UnitTests;

public class HouseholderSequence_EssentialVector {

    readonly Matrix<double> sampleMatrix =
      Matrix<double>.Build.DenseOfRows([
        [ 0, 2, 0, 1, -4 ],
        [-3, 3, -1, 0, 1],
        [1, 0, 0, 1, 3],
        [4, 1, 2, 0, 3]
      ]);

    readonly Vector<double> sampleCoeffs =
      Vector<double>.Build.DenseOfArray([4, 1, -2, 3, 5]);

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderSequence_EssentialVector_1() {
      var seq = new HouseholderSequence(sampleMatrix, sampleCoeffs);
      var essential = seq.EssentialVector(0);

      Assert.Equal(3, essential.Count);
      Assert.Equal(-3, essential[0]);
      Assert.Equal(1, essential[1]);
      Assert.Equal(4, essential[2]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderSequence_EssentialVector_2() {
      var seq = new HouseholderSequence(sampleMatrix, sampleCoeffs);
      var essential = seq.EssentialVector(1);

      Assert.Equal(2, essential.Count);
      Assert.Equal(0, essential[0]);
      Assert.Equal(1, essential[1]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderSequence_EssentialVector_3() {
      var seq = new HouseholderSequence(sampleMatrix, sampleCoeffs);
      var essential = seq.EssentialVector(2);

      Assert.Single(essential);
      Assert.Equal(2, essential[0]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderSequence_EssentialVector_4() {
      var seq = new HouseholderSequence(sampleMatrix, sampleCoeffs);
      var essential = seq.EssentialVector(3);

      Assert.Empty(essential);
    }
}