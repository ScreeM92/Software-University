namespace Ex02.DistanceCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class DistanceCalculator
    {
        public static double calculateTheDistance(double firstNumber, double secondNumber)
        {
            return Math.Sqrt(Math.Pow((firstNumber - secondNumber), 2));
        }
    }
}
