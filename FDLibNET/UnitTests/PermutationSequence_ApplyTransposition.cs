using MathNet.Numerics.LinearAlgebra;
using FDLibNET;
using System.Dynamic;

namespace UnitTests;

public class PermutationSequence_ApplyTransposition {

    [Fact]
    public void Test_PermutationSequence_ApplyTransposition_1() {
      var seq = new PermutationSequence(0);

      seq.SetIdentity();
      seq.ApplyTransposition(0, 0);

      Assert.Empty(seq.Indices());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_ApplyTransposition_2() {
      var seq = new PermutationSequence(1);

      seq.SetIdentity();
      seq.ApplyTransposition(0, 0);

      Assert.Single(seq.Indices());
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_ApplyTransposition_3() {
      var seq = new PermutationSequence(2);

      seq.SetIdentity();
      seq.ApplyTransposition(0, 0);

      Assert.Equal(0, seq.Indices()[0]);
      Assert.Equal(1, seq.Indices()[1]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_ApplyTransposition_4() {
      var seq = new PermutationSequence(2);

      seq.SetIdentity();
      seq.ApplyTransposition(0, 1);

      Assert.Equal(2, seq.Indices().Length);
      Assert.Equal(1, seq.Indices()[0]);
      Assert.Equal(0, seq.Indices()[1]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_ApplyTransposition_5() {
      var seq = new PermutationSequence(3);

      seq.SetIdentity();
      seq.ApplyTransposition(0, 1);
      seq.ApplyTransposition(1, 2);

      Assert.Equal(3, seq.Indices().Length);
      Assert.Equal(1, seq.Indices()[0]);
      Assert.Equal(2, seq.Indices()[1]);
      Assert.Equal(0, seq.Indices()[2]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_ApplyTransposition_6() {
      var seq = new PermutationSequence(3);

      seq.SetIdentity();
      seq.ApplyTransposition(0, 1);
      seq.ApplyTransposition(0, 1);

      Assert.Equal(3, seq.Indices().Length);
      Assert.Equal(0, seq.Indices()[0]);
      Assert.Equal(1, seq.Indices()[1]);
      Assert.Equal(2, seq.Indices()[2]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_ApplyTransposition_7() {
      var seqLength = 101;
      var seq = new PermutationSequence(seqLength);

      seq.SetIdentity();

      // Bubble sort (ascending). No changes.
      for (int n = seq.Indices().Length; n > 1; n--) {
        for (int i = 0; i < n - 1; i++) {
          if (seq.Indices()[i] > seq.Indices()[i + 1]) {
            seq.ApplyTransposition(i, i + 1);
          }
        } 
      }

      // Verification.
      for (int i = 0; i < seq.Indices().Length; ++i) {
        Assert.Equal(i, seq.Indices()[i]);
      }
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_ApplyTransposition_8() {
      var seqLength = 101;
      var seq = new PermutationSequence(seqLength);

      seq.SetIdentity();

      // Bubble sort (descending).
      for (int n = seq.Indices().Length; n > 1; n--) {
        for (int i = 0; i < n - 1; i++) {
          if (seq.Indices()[i] < seq.Indices()[i + 1]) {
            seq.ApplyTransposition(i, i + 1);
          }
        } 
      }

      // Verification.
      for (int i = 0; i < seq.Indices().Length; ++i) {
        Assert.Equal(i, seq.Indices()[seqLength - i - 1]);
      }
    }
}