using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeProject
{
    public class ValidationMethods
    {
        public static double ValidateValue(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Value must be bigger than zero!");
            }
            return value;
        }

        public static void ValidateTriangle(double sideA, double sideB, double sideC)
        {
            if (sideA >= sideC + sideB || sideB >= sideC + sideA ||
                sideC >= sideA + sideB)
            {
                throw new ArithmeticException("Your input parameters do not form a triangle!");
            }
        }
    }
}
