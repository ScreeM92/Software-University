/*Write a program that reads the coefficients 
a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it (prints its real roots). */

using System;

class QuadraticEquation
{
    static void Main(string[] args)
    {
        Console.Write("Enter a: ");
        float a = float.Parse(Console.ReadLine());
        
        Console.Write("Enter b: ");
        float b = float.Parse(Console.ReadLine());
        
        Console.Write("Enter c: ");
        float c = float.Parse(Console.ReadLine());

        double d = b * b - 4 * a * c;

        if (d < 0)
        {
            Console.WriteLine("The equation has no real roots");
        }
        else if (d == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine("The root of the equation is x1 = x2 = {0}", x);
        }
        else if (d > 0)
        {
            double rootD = Math.Sqrt(d);
            double x1 = (-b - rootD) / (2 * a);
            double x2 = (-b + rootD) / (2 * a);
            
            Console.WriteLine("The roots of the equation are x1 = {0} and x2 = {1}", x1, x2);
        }
    }
}
