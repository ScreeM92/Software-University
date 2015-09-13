using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Distance_Calculator
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            Point3D pointOne = new Point3D(3.4, 4, 5);
            Point3D pointTwo = new Point3D(5, 6, 7);


            double result = DistanceCalculator.CalculateDistance(pointOne, pointTwo);
            Console.WriteLine("The distance is: {0:F3}", result);
        }
    }
}
