using MathNet.Numerics.LinearAlgebra;
using FDLibNET;

namespace UnitTests;

public class HouseholderSequence_Trans {

    [Fact]
    public void Test_HouseholderSequence_Trans_1() {
      var vectors = Matrix<double>.Build.Dense(1, 1);
      var coeffs = Vector<double>.Build.Dense(1);

      var seq = new HouseholderSequence(vectors, coeffs);

      Assert.False(seq.Trans());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderSequence_Trans_2() {
      var vectors = Matrix<double>.Build.Dense(1, 1);
      var coeffs = Vector<double>.Build.Dense(1);

      var seq = new HouseholderSequence(vectors, coeffs);
      seq.Transpose();

      Assert.True(seq.Trans());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderSequence_Trans_3() {
      var vectors = Matrix<double>.Build.Dense(1, 1);
      var coeffs = Vector<double>.Build.Dense(1);

      var seq = new HouseholderSequence(vectors, coeffs);

      seq.Transpose();
      seq.Transpose();

      Assert.False(seq.Trans());
    }
}