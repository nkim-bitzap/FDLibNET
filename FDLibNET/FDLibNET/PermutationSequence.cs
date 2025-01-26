//------------------------------------------------------------------------------
// @project: FDLibNET
// @file: PermutationSequence.cs
// @author: NK
// @date: 22.1.2025

using System.Diagnostics;
using IndexType = System.Int32;
using IndicesType = System.Int32[];

namespace FDLibNET {
  
  //----------------------------------------------------------------------------
  // @class PermutationSequence
  // @brief Helper class to track the pivoting during the QR factorization.
  public class PermutationSequence(int size)
  {
    IndicesType m_indices = new IndexType[size];

    public IndicesType Indices() {
      return m_indices;
    }

    public int Size() { return Indices().Length; }

    // Explicit indexing versions are range-checked and might throw. The sub-
    // script/indexer operator is however unchecked in STL-style.
    public IndexType Index(int index) {
      if (index >= Size()) {
        throw new IndexOutOfRangeException(
          "Permutation vector index access out of range.");
      }

      return Indices()[index];
    }

    public void SetIndex(int index, IndexType value) {
      if (index >= Size()) {
        throw new IndexOutOfRangeException(
          "Permutation vector index access out of range.");
      }

      m_indices[index] = value;
    }

    public IndexType this[int key] {
      get {
        Debug.Assert(0 <= key && key < Size());
        return Indices()[key];
      }

      set {
        Debug.Assert(0 <= key && key < Size());
        Indices()[key] = value;
      }
    }

    public void ApplyTransposition(int i, int j) {
      if (i != j) {
        (this[i], this[j]) = (this[j], this[i]);
      }
    }

    public void SetIdentity() {
      for (int i = 0; i < Size(); ++i) {
        this[i] = i;
      }
    }

    public void SetIdentity(int newSize) {
      m_indices = new IndexType[newSize];
      SetIdentity();
    }
  
    override public String ToString() {
      String result =
        new("PermutationSequence " + Indices().Length +
            "-" + typeof(IndexType) + Environment.NewLine);

      foreach (IndexType index in m_indices) {
        result += (index + Environment.NewLine);
      }

      return result;
    }
  }
}