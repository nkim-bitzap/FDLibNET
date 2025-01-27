<h3>
<p align="center">
  FDLibNET - A force-density library re-written for .NET
</p>
</h3>

```

    // Basic example of usage as seen in Program.cs::Test1(). Usually starts
    // with the points.

    ForceDensity.PointInfo[] pointInfos = [
      new ForceDensity.PointInfo(-1, -1, 1), // fixed, index 0
      new ForceDensity.PointInfo(),
      new ForceDensity.PointInfo(-1, 1, 3),  // fixed, index 2
      new ForceDensity.PointInfo(),
      new ForceDensity.PointInfo(1, 1, 1),   // fixed, inded 4
      new ForceDensity.PointInfo(),
      new ForceDensity.PointInfo(1, -1, 3),  // fixed, index 6
      new ForceDensity.PointInfo(),
      new ForceDensity.PointInfo()
    ];

    // Edges (point indices must match the order in 'pointInfos'). The order
    // of the edges themself within the container is not important.

    ForceDensity.EdgeInfo[] edgeInfos = [
      new ForceDensity.EdgeInfo(0, 1),
      new ForceDensity.EdgeInfo(1, 2),
      new ForceDensity.EdgeInfo(2, 3),
      new ForceDensity.EdgeInfo(3, 4),
      new ForceDensity.EdgeInfo(4, 5),
      new ForceDensity.EdgeInfo(5, 6),
      new ForceDensity.EdgeInfo(6, 7),
      new ForceDensity.EdgeInfo(7, 0),
      new ForceDensity.EdgeInfo(1, 8),
      new ForceDensity.EdgeInfo(5, 8),
      new ForceDensity.EdgeInfo(7, 8),
      new ForceDensity.EdgeInfo(3, 8)
    ];

    var fd = new ForceDensity(pointInfos, edgeInfos);
    var x = fd.Solve();

    if (null == x) {
      Console.WriteLine("Failed to solve the linear system.");
    }
    else {
      // NOTE, the solution will have 0-entries for all fixed points. There-
      // fore, use the original input data and post-patch explicitly into the
      // result for the sake of completeness.

      for (int i = 0; i < pointInfos.Length; ++i) {
        var pi = pointInfos[i];

        if (pi.isFixed) x.SetRow(i, pi.AsCoordinateVector());
      }

      Console.WriteLine(x);
    }

```
