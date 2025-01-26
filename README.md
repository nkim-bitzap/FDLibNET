<h3>
<p align="center">
  FDLibNET - A force-density library re-written for .NET
</p>
</h3>

```

    // Basic example as found in Program.cs::Test1()

    ForceDensity.PointInfo[] pointInfos = [
      new ForceDensity.PointInfo(-1, -1, 1), // fixed
      new ForceDensity.PointInfo(),
      new ForceDensity.PointInfo(-1, 1, 3),  // fixed
      new ForceDensity.PointInfo(),
      new ForceDensity.PointInfo(1, 1, 1),   // fixed
      new ForceDensity.PointInfo(),
      new ForceDensity.PointInfo(1, -1, 3),  // fixed
      new ForceDensity.PointInfo(),
      new ForceDensity.PointInfo()
    ];

    // Edges (point indices must match the order in 'pointInfos').
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
      Console.WriteLine("x:");
      Console.WriteLine(x);
    }

```
