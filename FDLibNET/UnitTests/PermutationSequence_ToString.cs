using MathNet.Numerics.LinearAlgebra;
using FDLibNET;

namespace UnitTests;

public class PermutationSequence_ToString {

    [Fact]
    public void Test_PermutationSequence_ToString_1() {
      var seq = new PermutationSequence(0);

      Assert.NotEmpty(seq.ToString());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_ToString_2() {
      var seq = new PermutationSequence(1);

      Assert.NotEmpty(seq.ToString());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_ToString_3() {
      var seq = new PermutationSequence(101);

      Assert.NotEmpty(seq.ToString());
    }
}