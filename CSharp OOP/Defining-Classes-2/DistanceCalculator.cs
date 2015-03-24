using System;


static class DistanceCalculator3D
{
    /// <summary>
    /// Calculates the distance between two 3D points.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static double CalculateDistanceBetween(Point3D a, Point3D b)
    {
        return Math.Sqrt((a.X-b.X)*(a.X-b.X)+(a.Y-b.Y)*(a.Y-b.Y)+(a.Z-b.Z)*(a.Z-b.Z));
    }
}