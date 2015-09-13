using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Distance_Calculator
{
    static class DistanceCalculator
    {
        public static double CalculateDistance(Point3D firstPoint, Point3D secondPoint)
        {
            double result = 0.0;


            result = ((firstPoint.xcoordinate - secondPoint.xcoordinate) * (firstPoint.xcoordinate - secondPoint.xcoordinate) +
                              (firstPoint.ycoordinate - secondPoint.ycoordinate) * (firstPoint.ycoordinate - secondPoint.ycoordinate) +
                              (firstPoint.zcoordinate - secondPoint.zcoordinate) * (firstPoint.zcoordinate - secondPoint.zcoordinate));

            if (result < 0)
            {
                result *= -1;
            }

            result = Math.Sqrt(result);

            return result;
        }
    }
}
