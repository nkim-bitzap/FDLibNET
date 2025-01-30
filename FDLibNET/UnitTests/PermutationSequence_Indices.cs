using MathNet.Numerics.LinearAlgebra;
using FDLibNET;

namespace UnitTests;

public class PermutationSequence_Indices {

    [Fact]
    public void Test_PermutationSequence_Indices_1() {
      var seq = new PermutationSequence(0);

      Assert.Empty(seq.Indices());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_Indices_2() {
      var seq = new PermutationSequence(1);

      Assert.Single(seq.Indices());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_Indices_3() {
      var seq = new PermutationSequence(101);

      Assert.Equal(101, seq.Indices().Length);
    }
}