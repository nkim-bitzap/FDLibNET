using MathNet.Numerics.LinearAlgebra;
using FDLibNET;

namespace UnitTests;

public class HouseholderSequence_Length {

    [Fact]
    public void Test_HouseholderSequence_Length_1() {
      var vectors = Matrix<double>.Build.Dense(1, 1);
      var coeffs = Vector<double>.Build.Dense(1);

      var seq = new HouseholderSequence(vectors, coeffs);

      Assert.Equal(1, seq.Length());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderSequence_Length_2() {
      var vectors = Matrix<double>.Build.Dense(2, 2);
      var coeffs = Vector<double>.Build.Dense(2);

      var seq = new HouseholderSequence(vectors, coeffs);

      Assert.Equal(2, seq.Length());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderSequence_Length_3() {
      var vectors = Matrix<double>.Build.Dense(2, 1);
      var coeffs = Vector<double>.Build.Dense(2);

      var seq = new HouseholderSequence(vectors, coeffs);

      Assert.Equal(1, seq.Length());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderSequence_Length_4() {
      var vectors = Matrix<double>.Build.Dense(1, 2);
      var coeffs = Vector<double>.Build.Dense(2);

      var seq = new HouseholderSequence(vectors, coeffs);

      Assert.Equal(1, seq.Length());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderSequence_Length_5() {
      var vectors = Matrix<double>.Build.Dense(3, 3);
      var coeffs = Vector<double>.Build.Dense(3);

      var seq = new HouseholderSequence(vectors, coeffs);

      Assert.Equal(3, seq.Length());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderSequence_Length_6() {
      var vectors = Matrix<double>.Build.Dense(3, 3);
      var coeffs = Vector<double>.Build.Dense(3);

      var seq = new HouseholderSequence(vectors, coeffs);
      seq.SetLength(1);

      Assert.Equal(1, seq.Length());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderSequence_Length_7() {
      var vectors = Matrix<double>.Build.Dense(3, 3);
      var coeffs = Vector<double>.Build.Dense(3);

      var seq = new HouseholderSequence(vectors, coeffs);
      seq.SetLength(2);

      Assert.Equal(2, seq.Length());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderSequence_Length_8() {
      var vectors = Matrix<double>.Build.Dense(3, 3);
      var coeffs = Vector<double>.Build.Dense(3);

      var seq = new HouseholderSequence(vectors, coeffs);
      seq.SetLength(9);

      Assert.Equal(9, seq.Length());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderSequence_Length_9() {
      var vectors = Matrix<double>.Build.Dense(3, 3);
      var coeffs = Vector<double>.Build.Dense(3);

      var seq = new HouseholderSequence(vectors, coeffs);
      seq.SetLength(0);

      Assert.Equal(0, seq.Length());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderSequence_Length_10() {
      var vectors = Matrix<double>.Build.Dense(3, 3);
      var coeffs = Vector<double>.Build.Dense(3);

      var seq = new HouseholderSequence(vectors, coeffs);
      seq.SetLength(-3);

      Assert.Equal(-3, seq.Length());
    }
}