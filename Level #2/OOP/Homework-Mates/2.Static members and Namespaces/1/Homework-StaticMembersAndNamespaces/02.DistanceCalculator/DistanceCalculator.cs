using System;

namespace _02.DistanceCalculator
{
    static class DistanceCalculator
    {
        static double CalculateDistance(double p1, double p2, double p3, double q1, double q2, double q3)
        {
            return Math.Sqrt(((p1 - q1) * (p1 - q1)) + ((p2 - q2) * (p2 - q2)) + ((p3 - q3) * (p3 - q3)));
        }
        static void Main()
        {
            Console.WriteLine(CalculateDistance(1, 2, 3, 4, 5, 6));
        }
    }
}