using System;

static class DistanceIn3DSpace
{
    public static double CalculateDistance(Point3D firstPoint, Point3D secondPoint)
    {
        double distance = Math.Sqrt(
            (firstPoint.WidthX - secondPoint.WidthX) * (firstPoint.WidthX - secondPoint.WidthX) +
            (firstPoint.HeightY - secondPoint.HeightY) * (firstPoint.HeightY - secondPoint.HeightY) +
            (firstPoint.DepthZ - secondPoint.DepthZ) * (firstPoint.DepthZ - secondPoint.DepthZ)
            );
        return distance;
    }
}