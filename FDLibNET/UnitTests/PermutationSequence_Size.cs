using MathNet.Numerics.LinearAlgebra;
using FDLibNET;

namespace UnitTests;

public class PermutationSequence_Size {

    [Fact]
    public void Test_PermutationSequence_Size_1() {
      var seq = new PermutationSequence(0);

      Assert.Equal(0, seq.Size());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_Size_2() {
      var seq = new PermutationSequence(0);

      Assert.Equal(0, seq.Size());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_Size_3() {
      var seq = new PermutationSequence(1);

      Assert.Equal(1, seq.Size());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_Size_4() {
      var seq = new PermutationSequence(101);

      Assert.Equal(101, seq.Size());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_Size_5() {
      var seq = new PermutationSequence(17);
      seq.SetIdentity();

      Assert.Equal(17, seq.Size());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_Size_6() {
      var seq = new PermutationSequence(17);
      seq.SetIdentity(16);

      Assert.Equal(16, seq.Size());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_Size_7() {
      var seq = new PermutationSequence(17);
      seq.SetIdentity(16);
      seq.SetIdentity(15);

      Assert.Equal(15, seq.Size());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_Size_8() {
      var seq = new PermutationSequence(17);

      seq.SetIdentity(16);
      seq.SetIdentity();
      seq.SetIdentity(15);
      seq.SetIdentity();

      Assert.Equal(15, seq.Size());
    }
}