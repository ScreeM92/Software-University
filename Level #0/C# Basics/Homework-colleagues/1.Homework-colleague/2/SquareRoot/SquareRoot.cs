using System;

namespace SquareRoot
{
    class SquareRoot
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Number for square : ");
            int Number = Convert.ToInt32(Console.ReadLine());
            double SqrtNumber = Math.Sqrt(Number);
            Console.WriteLine("Square root of {0} is: {1}", Number, SqrtNumber);
            // V.2 of the problem
            Console.WriteLine("Square root of the number 12345 is {0}", (float)Math.Sqrt(12345));
            Console.ReadLine();
        }
    }
}
