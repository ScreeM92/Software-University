using System;

class QuadraticEquasion
{
    static void Main()
    {
        Console.Write("Enter coefficient for x^2: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter coefficient for x^1: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter coefficient for x^0: ");
        double c = double.Parse(Console.ReadLine());
        double d = b * b - 4 * a * c;
        double x;
        if (d < 0)
        {
            Console.WriteLine("No real roots.");
        }
        if (d == 0)
        {
            Console.WriteLine("x1 = x2 = {0: 0.000}", x = -b / (2.0 * a));//Console.WriteLine("X1 = X2 = {0}", -b / (2 * a));
        }
        if (d > 0)
        {
            double x1 = (-b - Math.Sqrt(d)) / (2.0 * a);//Console.WriteLine("X2 = {0}", (-b + Math.Sqrt(des)) / (2 * a));
            double x2 = (-b + Math.Sqrt(d)) / (2.0 * a);// Console.WriteLine("X1 = {0}", (-b - Math.Sqrt(des)) / (2 * a));                                
            Console.WriteLine("x1 = {0: 0.000}\nx2 = {1: 0.000}", x1, x2);
        }
    }
}