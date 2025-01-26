//------------------------------------------------------------------------------
// @project: FDLibNET
// @file: HouseholderQR.cs
// @author: NK
// @date: 22.1.2025

using System.Diagnostics;
using MathNet.Numerics.LinearAlgebra;

using MatrixType = MathNet.Numerics.LinearAlgebra.Matrix<double>;
using VectorType = MathNet.Numerics.LinearAlgebra.Vector<double>;

namespace FDLibNET {

  //----------------------------------------------------------------------------
  // @class MatrixBlock
  // @brief Static methods for extracting matrix parts.
  //
  // @note This is far from complete, but sufficient for the current implemen-
  //   tation. Might get extended later though, if other factorization methods
  //   become desirable.
  public static class MatrixBlock {

    public static void SwapValues(VectorType array, int i, int j) {
      Debug.Assert(0 <= i && i < array.Count);
      Debug.Assert(0 <= j && j < array.Count);

      (array[j], array[i]) = (array[i], array[j]);
    }

    //--------------------------------------------------------------------------

    public static void SwapColumns(MatrixType matrix, int ci, int cj) {
      int numRows = matrix.RowCount;
      int numColumns = matrix.ColumnCount;

      if (0 == numRows || 0 == numColumns) return;

      Debug.Assert(ci < numColumns && cj < numColumns);

      for (int i = 0; i < numRows; ++i) {
        (matrix[i, ci], matrix[i, cj]) =
        (matrix[i, cj], matrix[i, ci]);
      }
    }

    //--------------------------------------------------------------------------

    public static Vector<double> ColumnTail(MatrixType matrix,
                                            int column,
                                            int tailSize)
    {
      int numRows = matrix.RowCount;
      int numColumns = matrix.ColumnCount;

      Debug.Assert(0 <= column && column < numColumns);
      Debug.Assert(0 <= tailSize && tailSize <= numRows);

      if (0 == numRows || 0 == numColumns) {
        return Vector<double>.Build.Dense(0);
      }

      return matrix.Column(column).SubVector(
        numRows - tailSize, tailSize);
    }

    //--------------------------------------------------------------------------

    public static double MaxTailValue(VectorType array,
                                      int tail,
                                      ref int maxIndex)
    {
      Debug.Assert(0 < tail && tail <= array.Count);

      var tailVector = array.SubVector(array.Count - tail, tail);
      maxIndex = tailVector.MaximumIndex();

      return tailVector[maxIndex];
    }

    //--------------------------------------------------------------------------

    public static MatrixType MatrixPart(MatrixType matrix,
                                        int startRow,
                                        int startColumn,
                                        int numPartRows,
                                        int numPartColumns)
    {
      int numRows = matrix.RowCount;
      int numColumns = matrix.ColumnCount;

      Debug.Assert(0 <= startRow && startRow < numRows);
      Debug.Assert(0 <= startColumn && startColumn < numColumns);

      Debug.Assert(1 <= numPartRows &&
                   numPartRows <= numRows - startRow);
      Debug.Assert(1 <= numPartColumns &&
                   numPartColumns <= numColumns - startColumn);

      return matrix.SubMatrix(
        startRow, numPartRows, startColumn, numPartColumns);
    }

    //--------------------------------------------------------------------------

    public static MatrixType TopLeftPart(MatrixType matrix,
                                         int numRows,
                                         int numColumns)
    {
      return MatrixPart(matrix, 0, 0, numRows, numColumns);
    }

    //--------------------------------------------------------------------------

    public static MatrixType BottomRightPart(MatrixType matrix,
                                             int numRows,
                                             int numColumns)
    {
      return MatrixPart(matrix,
                        matrix.RowCount - numRows,
                        matrix.ColumnCount - numColumns,
                        numRows,
                        numColumns);
    }

    //--------------------------------------------------------------------------

    public static MatrixType TopRows(MatrixType matrix, int numRows) {
      return MatrixPart(matrix, 0, 0, numRows, matrix.ColumnCount);
    }

    //--------------------------------------------------------------------------

    public static MatrixType BottomRows(MatrixType matrix, int numRows) {
      return MatrixPart(
        matrix, matrix.RowCount - numRows, 0, numRows, matrix.ColumnCount);
    }

    //--------------------------------------------------------------------------

    public static void MakeUpperTriangular(MatrixType matrix) {
      for (int i = 1; i < matrix.RowCount; ++i) 
        for (int j = 0; j < i; ++j)
          matrix[i, j] = 0;
    }

    //--------------------------------------------------------------------------

    public static MatrixType ApplyHouseholderLeft(MatrixType block,
                                                  VectorType essential,
                                                  double tau)
    {
      int numBlockRows = block.RowCount;
      int numBlockColumns = block.ColumnCount;

      if (1 == numBlockRows) {  block *= (1 - tau); }
      else if (0 != tau) {

        MatrixType bottom = MatrixBlock.BottomRightPart(
          block, numBlockRows - 1, numBlockColumns);

        var tmp = (essential * bottom) + block.Row(0);

        block.SetRow(0, block.Row(0) - tau * tmp);

        // Basic math: if A is a matrix of dimension n x m and B has dimension
        // m x k, then the product (A * B) has the dimension n x k.
        bottom -=
          MatrixType.Build.DenseOfColumnVectors(tau * essential) *
          MatrixType.Build.DenseOfRowVectors(tmp);

        block.SetSubMatrix(1, 0, bottom);
      }

      return block;
    }
  }

  //----------------------------------------------------------------------------
  // @class HouseholderSequence
  // @brief Management of the householder reflections/sequence.
  //
  // @note This stuff is minimal and could be performed inline, i leave this
  //   as-is however for potential extensions in future.
  public class HouseholderSequence(MatrixType vectors, VectorType coeffs) {

    MatrixType m_vectors = vectors;
    VectorType m_coeffs = coeffs;
    int m_length = vectors.Diagonal().Count;
    int m_shift = 0;
    bool m_trans = false;

    //--------------------------------------------------------------------------

    public bool Trans() {
      return m_trans;
    }

    void SetTrans(bool trans) {
      m_trans = trans;
    }

    public int Length() {
      return m_length;
    }

    public void SetLength(int length) {
      m_length = length;
    }

    public void Transpose() {
      SetTrans(!m_trans);
    }

    public VectorType EssentialVector(int k) {
      int start = k + m_shift + 1;
      int tail = m_vectors.RowCount - start;

      return MatrixBlock.ColumnTail(m_vectors, k, tail);
    }

    public MatrixType ApplyOnTheLeft(MatrixType matrix) {

      // Prevent the argument matrix from being hammered.
      var result = MatrixType.Build.DenseOfMatrix(matrix);

      // NOTE, the Eigen implementation uses a different approach for large
      // entries, which applies reflectors by block. This is done merely due
      // to the performance. For the initial baby-steps we ignore this and
      // handle all cases uniformly.
      for (int k = 0; k < m_length; ++k) {
        int actual_k = m_trans ? k : m_length - k - 1;
        
        var essential = EssentialVector(actual_k);
        var block = MatrixBlock.BottomRows(
          result, m_vectors.RowCount - m_shift - actual_k);

        var h = MatrixBlock.ApplyHouseholderLeft(block,
                                                 essential,
                                                 m_coeffs[actual_k]);

        result.SetSubMatrix(result.RowCount - block.RowCount, 0, h);
      }

      return result;
    }
  }  

  //----------------------------------------------------------------------------
  // @class HouseholderQR
  // @brief Class providing functionality for the QR factorization using the
  //   householder reflections.
  //
  // @note This is necessary in order to generate proper results during linear
  //   system solving. The plain Math.Net functionality is insufficient for
  //   our particular purpose, hence this sadomaso.
  public class HouseholderQR {

    MatrixType m_qr;
    VectorType m_hCoeffs;
    VectorType m_colNormsUpdated;
    VectorType m_colNormsDirect;
    PermutationSequence m_colsPermutation;
  
    int m_nonzero_pivots = 0;
    bool m_isInitialized = false;

    //--------------------------------------------------------------------------

    public HouseholderQR(MatrixType matrix) {
      int rows = matrix.RowCount;
      int cols = matrix.ColumnCount;
      int size = matrix.Diagonal().Count;

      m_qr = matrix;

      m_hCoeffs = VectorType.Build.Dense(size);
      m_colNormsUpdated = VectorType.Build.Dense(cols);
      m_colNormsDirect = VectorType.Build.Dense(cols);
      m_colsPermutation = new PermutationSequence(cols);

      Factorize();
    }

    //--------------------------------------------------------------------------

    static MatrixType MakeHouseholder(VectorType column,
                                      ref double tau,
                                      ref double beta)
    {
      VectorType tail = column.SubVector(1, column.Count - 1);
  
      int size = column.Count;

      double c0 = column[0];
      double tailSqNorm = 0.0;
      double tol = 2.2250738585072014E-308;

      if (size != 1) {
        double columnNorm = tail.L2Norm();
        tailSqNorm = columnNorm * columnNorm;
      }

      if (tailSqNorm <= tol) {
        tau = 0;
        beta = c0;

        return MatrixType.Build.Dense(tail.Count, 1, 0.0);
      }
      else {
        beta =  Math.Sqrt((c0 * c0) + tailSqNorm);
  
        if (c0 >= 0.0) { beta = -beta; }

        tau = (beta - c0) / beta;

        for (int i = 0; i < tail.Count; ++i) {
          tail[i] /= (c0 - beta);
        }

        return MatrixType.Build.DenseOfColumnVectors(tail);
      }
    }

    //--------------------------------------------------------------------------
  
    void Factorize() {

      int rows = m_qr.RowCount;
      int cols = m_qr.ColumnCount;
      int size = m_qr.Diagonal().Count;
  
      double[] m_temp = new double[cols];

      int[] m_colsTranspositions = new int[cols];
      int number_of_transpositions = 0;

      for (int k = 0; k < cols; ++k) {
        // 'colNormsDirect(k)' caches the most recent directly computed norm
        // of column 'k'.
        m_colNormsDirect[k] = m_qr.Column(k).L2Norm();
        m_colNormsUpdated[k] = m_colNormsDirect[k];
      }

      // As in Eigen, use the machine epsilon for IEEE-doubles instead of the
      // epsilon for a particular datatype.
      double eps = 2.2204460492503131e-16;
  
      var norm_downdate_threshold = Math.Sqrt(eps);
      var threshold_helper_part = m_colNormsUpdated.Max() * eps;
      var threshold_helper =
        (threshold_helper_part * threshold_helper_part) / rows;

      // The generic case is that in which all pivots are non-zero (invertible
      // case).
      m_nonzero_pivots = size;
      double m_maxpivot = 0;

      for (int k = 0; k < size; ++k) {
        int biggest_col_index = int.MinValue;

        double biggest_col_norm =
          MatrixBlock.MaxTailValue(
            m_colNormsUpdated, cols - k, ref biggest_col_index);

        double biggest_col_sq_norm = biggest_col_norm * biggest_col_norm;
          biggest_col_index += k;

        // Track the number of meaningful pivots but don't stop the decomposi-
        // tion to make sure that the initial matrix is properly reproduced.
        if (m_nonzero_pivots == size
        && biggest_col_sq_norm < threshold_helper * (rows - k)) {
          m_nonzero_pivots = k;
        }

        m_colsTranspositions[k] = biggest_col_index;

        if (k != biggest_col_index) {
          MatrixBlock.SwapColumns(m_qr, k, biggest_col_index);
          MatrixBlock.SwapValues(m_colNormsUpdated, k, biggest_col_index);
          MatrixBlock.SwapValues(m_colNormsDirect, k, biggest_col_index);

          ++number_of_transpositions;
        }

        double beta = 0.0;
        double tau = m_hCoeffs[k];

        var essential =
          MakeHouseholder(MatrixBlock.ColumnTail(m_qr, k, rows - k),
                                                 ref tau,
                                                 ref beta);

        m_hCoeffs[k] = tau;

        for (int i = 0; i < essential.RowCount; ++i)
          m_qr[i + rows - essential.RowCount, k] = essential[i, 0];

        m_qr[k, k] = beta;

        // Remember the maximum absolute value of diagonal coefficients.
        if (Math.Abs(beta) > m_maxpivot) m_maxpivot = Math.Abs(beta);

        if (0 < cols - k - 1) {
          var block =
            MatrixBlock.BottomRightPart(m_qr, rows - k, cols - k - 1);

          m_qr.SetSubMatrix(
            k,
            k + 1,
            MatrixBlock.ApplyHouseholderLeft(block,
                                             essential.Column(0),
                                             m_hCoeffs[k]));
        }

        for (int j = k + 1; j < cols; ++j) {
          // The following implements the stable norm downgrade as discussed
          // in http://www.netlib.org/lapack/lawnspdf/lawn176.pdf and used in
          // LAPACK routines xGEQPF and xGEQP3.
          if (0 != m_colNormsUpdated[j]) {
            var temp = Math.Abs(m_qr[k, j]) / m_colNormsUpdated[j];

            temp = (1 + temp) * (1 - temp);
            temp = temp < 0 ? 0 : temp;

            var q = m_colNormsUpdated[j] / m_colNormsDirect[j];
            var temp2 = temp * (q * q);

            if (temp2 <= norm_downdate_threshold) {
              // The updated norm has now become too inaccurate so recompute
              // the column norm directly.
              m_colNormsDirect[j] =
                MatrixBlock.ColumnTail(m_qr, j, rows - k - 1).L2Norm();

              m_colNormsUpdated[j] = m_colNormsDirect[j];
            }
            else {
              m_colNormsUpdated[j] *= Math.Sqrt(temp);
            }
          }
        }
      }

      m_colsPermutation.SetIdentity();

      for (int k = 0; k < size; ++k) {
        m_colsPermutation.ApplyTransposition(k, m_colsTranspositions[k]);
      }

      m_isInitialized = true;
    }

    //--------------------------------------------------------------------------

    public MatrixType? Solve(MatrixType rhs) {

      // We never know.
      Debug.Assert(m_isInitialized);

      int rows = rhs.RowCount;
      int cols = rhs.ColumnCount;
      int size = rhs.Diagonal().Count;

      if (0 == m_nonzero_pivots) { return null; }

      var hSequence = new HouseholderSequence(m_qr, m_hCoeffs);
    
      // This whole stuff can be made in-place without involving the sequence-
      // object. For v1.0 leave this as-is for fucks sake.
      hSequence.SetLength(m_nonzero_pivots);
      hSequence.Transpose();
  
      var block =
        MatrixBlock.TopLeftPart(m_qr, m_nonzero_pivots, m_nonzero_pivots);

      MatrixBlock.MakeUpperTriangular(block);

      var c =
        MatrixBlock.TopRows(hSequence.ApplyOnTheLeft(rhs), m_nonzero_pivots);

      // Now actually try to solve the stuff we have pre-conditioned. Just use
      // a built-in solver for that.
      var x = block.Solve(c);
    
      var solution =
        MatrixType.Build.Dense(m_qr.ColumnCount, rhs.ColumnCount);

      // A last thing remains which is to post-patch the generated permutation
      // coefficients into the solution.
      for (int i = 0; i < m_nonzero_pivots; ++i)
        solution.SetRow(m_colsPermutation.Index(i), x.Row(i));

      for (int i = m_nonzero_pivots; i < m_qr.ColumnCount; ++i)
        solution.ClearRow(m_colsPermutation.Index(i));

      return solution;
    }
  }
}