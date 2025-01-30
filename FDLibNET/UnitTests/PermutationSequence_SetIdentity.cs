using MathNet.Numerics.LinearAlgebra;
using FDLibNET;

namespace UnitTests;

public class PermutationSequence_SetIdentity {

    [Fact]
    public void Test_PermutationSequence_SetIdentity_1() {
      var seq = new PermutationSequence(0);
      seq.SetIdentity();

      Assert.Empty(seq.Indices());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_SetIdentity_2() {
      var seq = new PermutationSequence(1);
      seq.SetIdentity();

      Assert.Equal(0, seq.Indices()[0]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_SetIdentity_3() {
      var seq = new PermutationSequence(2);
      seq.SetIdentity();

      Assert.Equal(0, seq.Indices()[0]);
      Assert.Equal(1, seq.Indices()[1]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_SetIdentity_4() {
      var seq = new PermutationSequence(3);
      seq.SetIdentity();

      Assert.Equal(0, seq.Indices()[0]);
      Assert.Equal(1, seq.Indices()[1]);
      Assert.Equal(2, seq.Indices()[2]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_SetIdentity_5() {
      var seq = new PermutationSequence(3);

      Assert.Equal(3, seq.Indices().Length);

      seq.SetIdentity(2);

      Assert.Equal(2, seq.Indices().Length);
      Assert.Equal(0, seq.Indices()[0]);
      Assert.Equal(1, seq.Indices()[1]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_SetIdentity_6() {
      var seq = new PermutationSequence(2);

      Assert.Equal(2, seq.Indices().Length);

      seq.SetIdentity(3);

      Assert.Equal(3, seq.Indices().Length);
      Assert.Equal(0, seq.Indices()[0]);
      Assert.Equal(1, seq.Indices()[1]);
      Assert.Equal(2, seq.Indices()[2]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_SetIdentity_7() {
      var seq = new PermutationSequence(2);

      Assert.Equal(2, seq.Indices().Length);

      seq.SetIdentity(2);

      Assert.Equal(2, seq.Indices().Length);
      Assert.Equal(0, seq.Indices()[0]);
      Assert.Equal(1, seq.Indices()[1]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_SetIdentity_8() {
      var seq = new PermutationSequence(3);

      Assert.Equal(3, seq.Indices().Length);

      Assert.Equal(3, seq.Indices().Length);
      Assert.Equal(0, seq.Indices()[0]);
      Assert.Equal(0, seq.Indices()[1]);
      Assert.Equal(0, seq.Indices()[2]);

      seq.SetIdentity();

      Assert.Equal(3, seq.Indices().Length);
      Assert.Equal(0, seq.Indices()[0]);
      Assert.Equal(1, seq.Indices()[1]);
      Assert.Equal(2, seq.Indices()[2]);

      seq.SetIdentity(3);

      Assert.Equal(3, seq.Indices().Length);
      Assert.Equal(0, seq.Indices()[0]);
      Assert.Equal(1, seq.Indices()[1]);
      Assert.Equal(2, seq.Indices()[2]);

      seq.SetIdentity(4);

      Assert.Equal(4, seq.Indices().Length);
      Assert.Equal(0, seq.Indices()[0]);
      Assert.Equal(1, seq.Indices()[1]);
      Assert.Equal(2, seq.Indices()[2]);
      Assert.Equal(3, seq.Indices()[3]);
    }
}