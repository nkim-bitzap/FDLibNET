//------------------------------------------------------------------------------
// @project: FDLibNET
// @file: ForceDensity.cs
// @author: NK
// @date: 26.1.2025

using System.Diagnostics;
using MathNet.Numerics.LinearAlgebra;

namespace FDLibNET {

  //----------------------------------------------------------------------------
  // @class ForceDensity
  // @brief Force density machinery.
  //
  // @abstract This class provides the top-level access to the force density
  //   formfinding machinery. The main task is to maintain all relevant data-
  //   structures (point/edge, fixity, loads, etc.), turn them into matricies
  //   and vectors appropriately and hand them over to the solver.
  //
  // @note This is a naive yet straight-forward approach as for v1.0. No need
  //   to be bitchy about the efficiency yet.
  class ForceDensity {

    //--------------------------------------------------------------------------
    // @struct PointInfo
    // @brief Structure incorporating point data relevant for the formfinding
    //   algorithm.
    public struct PointInfo {
      public double x;
      public double y;
      public double z;

      public double loadX;
      public double loadY;
      public double loadZ;

      public bool isFixed;
    
      // Coordinates are applied to 'fixed' points only, since 'free' points
      // are subject to generation. On the other hand, loads are relevant to
      // 'free' points and can be ignored for the 'fixed' ones.
      public PointInfo(double xArg,
                       double yArg,
                       double zArg)
      {
        x = xArg;
        y = yArg;
        z = zArg;

        loadX = 0.0;
        loadY = 0.0;
        loadZ = 0.0;

        isFixed = true;
      }

      // Convenience ctor to create 'free' points.
      public PointInfo()
      {
        x = 0.0;
        y = 0.0;
        z = 0.0;

        loadX = 0.0;
        loadY = 0.0;
        loadZ = 0.0;

        isFixed = false;
      }

      public Vector<double> AsCoordinateVector() {
        var vec = Vector<double>.Build.Dense(3);

        vec[0] = x;
        vec[1] = y;
        vec[2] = z;
      
        return vec;
      }
    }

    //--------------------------------------------------------------------------
    // @struct EdgeInfo
    // @brief Structure incorporating edge data relevant for the formfinding
    //   algorithm.
    //
    // @note An edge is given by the indices of the corresponding endpoints.
    //   For the time being consider edges undirected. I.e. if there is an
    //   edge (a, b), then there must not be an edge (b, a).
    public struct EdgeInfo {
      public int ib;
      public int ie;
      public double stiffness;

      public EdgeInfo() {
        ib = 0;
        ie = 0;
        stiffness = 10.0;
      }

      public EdgeInfo(int ibArg, int ieArg, double stiffnessArg = 10.0) {
        ib = ibArg;
        ie = ieArg;
        stiffness = stiffnessArg;
      } 
    }

    readonly PointInfo[] _points;
    public PointInfo[] Points {
      get { return _points; }
    }

    readonly EdgeInfo[] _edges;
    public EdgeInfo[] Edges {
      get { return _edges; }
    }

    // Additional parameters we incorporate into the formfinding that reflect
    // the uniform load onto the surface.
    double _loadX = 0.0;
    public double LoadX {
      get { return _loadX; }
      set { _loadX = value; }
    }

    double _loadY = 0.0;
    public double LoadY {
      get { return _loadY; }
      set { _loadY = value; }
    }

    double _loadZ = 0.0;
    public double LoadZ {
      get { return _loadZ; }
      set { _loadZ = value; }
    }

    //--------------------------------------------------------------------------

    public ForceDensity(int numPoints, int numEdges) {
      Debug.Assert(0 < numPoints && 0 < numEdges);

      _points = new PointInfo[numPoints];
      _edges = new EdgeInfo[numEdges];
    }

    //--------------------------------------------------------------------------

    public ForceDensity(PointInfo[] points, EdgeInfo[] edges) {
      Debug.Assert(0 < points.Length && 0 < edges.Length);

      _points = points;
      _edges = edges;
    }

    //--------------------------------------------------------------------------

    public void SetPointInfo(PointInfo info, int index) {
      Debug.Assert(0 <= index && index < Points.Length);

      _points[index] = info;
    }

    //--------------------------------------------------------------------------

    public void SetEdgeInfo(EdgeInfo info, int index) {
      Debug.Assert(0 <= index && index < Edges.Length);

      _edges[index] = info;
    }

    //--------------------------------------------------------------------------

    public Matrix<double>? Solve() {

      int numPoints = Points.Length;
      int numEdges = Edges.Length;

      var C_free = Matrix<double>.Build.Sparse(numEdges, numPoints);
      var C_fixed = Matrix<double>.Build.Sparse(numEdges, numPoints);

      for (int i = 0; i < numEdges; ++i) {
        if (true == Points[Edges[i].ib].isFixed) {
          C_fixed[i, Edges[i].ib] = -1;
        }
        else {
          C_free[i, Edges[i].ib] = -1;
        }

        if (true == Points[Edges[i].ie].isFixed) {
          C_fixed[i, Edges[i].ie] = 1;
        }
        else {
          C_free[i, Edges[i].ie] = 1;
        }
      }

      var Q = Matrix<double>.Build.Sparse(numEdges, numEdges);

      for (int e = 0; e < numEdges; ++e) {
        Q[e, e] = Edges[e].stiffness;
      }

      var C_free_t = C_free.Transpose();
      var A = C_free_t * Q * C_free;

      Matrix<double> xyz_fixed =
        Matrix<double>.Build.Sparse(numPoints, 3);

      Matrix<double> p =
        Matrix<double>.Build.Sparse(numPoints, 3);

      for (int i = 0; i < numPoints; ++i) {
        p[i, 0] = LoadX + Points[i].loadX;
        p[i, 1] = LoadY + Points[i].loadY;
        p[i, 2] = LoadZ + Points[i].loadZ;

        if (Points[i].isFixed) {
          xyz_fixed[i, 0] = Points[i].x;
          xyz_fixed[i, 1] = Points[i].y;
          xyz_fixed[i, 2] = Points[i].z;
        }
      }

      var b = p - (C_free_t * Q * C_fixed * xyz_fixed);

      return new HouseholderQR(A).Solve(b);
    }
  }
}