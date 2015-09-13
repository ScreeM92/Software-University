namespace DistanceCalculatorSoap
{
    using System;

    public class DistanceCalculator : IDistanceService
    {
        public double CalcDistance(Point startPoint, Point endPoint)
        {
            var horizontalDistance = Math.Pow(startPoint.X - endPoint.X, 2);
            var verticalDistance = Math.Pow(startPoint.Y - endPoint.Y, 2);
            var distance = Math.Sqrt(horizontalDistance + verticalDistance);

            return distance;
        }
    }
}