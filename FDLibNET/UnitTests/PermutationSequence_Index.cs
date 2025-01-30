using MathNet.Numerics.LinearAlgebra;
using FDLibNET;

namespace UnitTests;

public class PermutationSequence_Index {

    [Fact]
    public void Test_PermutationSequence_Index_1() {
      var seq = new PermutationSequence(0);

      Assert.Throws<IndexOutOfRangeException>(() => seq.Index(0));
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_Index_2() {
      var seq = new PermutationSequence(1);

      Assert.Equal(0, seq.Index(0));
      Assert.Throws<IndexOutOfRangeException>(() => seq.Index(1));
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_Index_3() {
      var seq = new PermutationSequence(2);

      Assert.Equal(0, seq.Index(0));
      Assert.Equal(0, seq.Index(1));
      Assert.Throws<IndexOutOfRangeException>(() => seq.Index(2));
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_Index_4() {
      var seq = new PermutationSequence(1);

      Assert.Throws<IndexOutOfRangeException>(() => seq.Index(-1));
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_Index_5() {
      var seqLength = 101;
      var seq = new PermutationSequence(seqLength);

      for (int i = 0; i < seqLength; ++i) {
        Assert.Equal(0, seq.Index(i));
      }

      seq.SetIdentity();

      for (int i = 0; i < seqLength; ++i) {
        Assert.Equal(i, seq.Index(i));
      }
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_Index_6() {
      var seq = new PermutationSequence(0);

      Assert.Throws<IndexOutOfRangeException>(() => seq.SetIndex(0, 0));
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_Index_7() {
      var seq = new PermutationSequence(1);

      Assert.Throws<IndexOutOfRangeException>(() => seq.SetIndex(1, 0));
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_Index_8() {
      var seq = new PermutationSequence(2);

      seq.SetIndex(0, 10);
      seq.SetIndex(1, 20);

      Assert.Throws<IndexOutOfRangeException>(() => seq.SetIndex(2, 0));
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_Index_9() {
      var seq = new PermutationSequence(2);

      Assert.Throws<IndexOutOfRangeException>(() => seq.SetIndex(-1, 1));
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_Index_10() {
      var seq = new PermutationSequence(3);

      Assert.Equal(0, seq.Index(0));
      Assert.Equal(0, seq.Index(1));
      Assert.Equal(0, seq.Index(2));

      seq.SetIdentity(4);

      Assert.Equal(0, seq.Index(0));
      Assert.Equal(1, seq.Index(1));
      Assert.Equal(2, seq.Index(2));
      Assert.Equal(3, seq.Index(3));

      seq.SetIndex(0, seq.Index(0) + 10);
      seq.SetIndex(1, seq.Index(1) + 10);
      seq.SetIndex(2, seq.Index(2) + 10);
      seq.SetIndex(3, seq.Index(3) + 10);

      Assert.Equal(10, seq.Index(0));
      Assert.Equal(11, seq.Index(1));
      Assert.Equal(12, seq.Index(2));
      Assert.Equal(13, seq.Index(3));
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_Index_11() {
      var seqLength = 101;
      var seq = new PermutationSequence(seqLength);

      for (int i = 0; i < seqLength; ++i) {
        seq.SetIndex(i, i + seqLength);
      }

      for (int i = 0; i < seqLength; ++i) {
        Assert.Equal(i + seqLength, seq.Index(i));
      }
    }

    //--------------------------------------------------------------------------
    [Fact]
    public void Test_PermutationSequence_Index_12() {
      var seqLength = 101;
      var seq = new PermutationSequence(seqLength);

      seq.SetIdentity();

      for (int i = 0; i < seqLength; ++i) {
        Assert.Equal(i, seq[i]);
      }
    }

    //--------------------------------------------------------------------------
    [Fact]
    public void Test_PermutationSequence_Index_13() {
      var seq = new PermutationSequence(2);

      seq.SetIdentity();

      Assert.Equal(2, seq.Size());
      Assert.Equal(0, seq[0]);
      Assert.Equal(1, seq[1]);

      (seq[0], seq[1]) = (seq[1], seq[0]);

      Assert.Equal(2, seq.Size());
      Assert.Equal(1, seq[0]);
      Assert.Equal(0, seq[1]);
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_Index_14() {
      var seqLength = 101;
      var seq = new PermutationSequence(seqLength);

      for (int i = 0; i < seqLength; ++i) {
        seq[i] = i + seqLength;
      }

      for (int i = 0; i < seqLength; ++i) {
        Assert.Equal(i + seqLength, seq[i]);
      }
    }

    //--------------------------------------------------------------------------

    [Fact]
    public void Test_PermutationSequence_Index_15() {
      var seq = new PermutationSequence(3);

      Assert.Equal(0, seq[0]);
      Assert.Equal(0, seq[1]);
      Assert.Equal(0, seq[2]);

      seq.SetIdentity(4);

      Assert.Equal(0, seq[0]);
      Assert.Equal(1, seq[1]);
      Assert.Equal(2, seq[2]);
      Assert.Equal(3, seq[3]);

      seq[0] += 10;
      seq[1] += 10;
      seq[2] += 10;
      seq[3] += 10;

      Assert.Equal(10, seq[0]);
      Assert.Equal(11, seq[1]);
      Assert.Equal(12, seq[2]);
      Assert.Equal(13, seq[3]);
    }
}