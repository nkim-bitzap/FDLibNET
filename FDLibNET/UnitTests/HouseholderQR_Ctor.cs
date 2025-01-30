using MathNet.Numerics.LinearAlgebra;
using FDLibNET;
using Microsoft.Win32.SafeHandles;

namespace UnitTests;

public class HouseholderQR_Ctor {

    readonly Matrix<double> sampleMatrix =
      Matrix<double>.Build.DenseOfColumns([
        [ 0, 2, 0, 1, -4 ],
        [-3, 3, -1, 0, 1],
        [1, 0, 0, 1, 3],
        [4, 1, 2, 0, 3]
      ]);

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderQR_Ctor_1() {
      var matrix = Matrix<double>.Build.Dense(0, 0);

      Assert.Throws<InvalidOperationException>(
        () => new HouseholderQR(matrix));
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderQR_Ctor_2() {
      var matrix = Matrix<double>.Build.Dense(1, 0);

      Assert.Throws<InvalidOperationException>(
        () => new HouseholderQR(matrix));
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderQR_Ctor_3() {

      // Strangely enough, this one works.
      var matrix = Matrix<double>.Build.Dense(0, 1);
      var qr = new HouseholderQR(matrix);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderQR_Ctor_4() {
      var matrix = Matrix<double>.Build.Dense(1, 1);
      var qr = new HouseholderQR(matrix);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderQR_Ctor_5() {
      var matrix = Matrix<double>.Build.Dense(2, 1);
      var qr = new HouseholderQR(matrix);
    }


    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderQR_Ctor_6() {
      var matrix = Matrix<double>.Build.Dense(1, 2);
      var qr = new HouseholderQR(matrix);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderQR_Ctor_7() {
      var matrix = Matrix<double>.Build.Dense(2, 2);
      var qr = new HouseholderQR(matrix);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderQR_Ctor_8() {
      var matrix = Matrix<double>.Build.Dense(3, 1);
      var qr = new HouseholderQR(matrix);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderQR_Ctor_9() {
      var matrix = Matrix<double>.Build.Dense(1, 3);
      var qr = new HouseholderQR(matrix);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderQR_Ctor_10() {
      var matrix = Matrix<double>.Build.Dense(3, 2);
      var qr = new HouseholderQR(matrix);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderQR_Ctor_11() {
      var matrix = Matrix<double>.Build.Dense(2, 3);
      var qr = new HouseholderQR(matrix);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderQR_Ctor_12() {
      var matrix = Matrix<double>.Build.Dense(3, 3);
      var qr = new HouseholderQR(matrix);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_HouseholderQR_Ctor_13() {
      var qr = new HouseholderQR(sampleMatrix);
    }
}