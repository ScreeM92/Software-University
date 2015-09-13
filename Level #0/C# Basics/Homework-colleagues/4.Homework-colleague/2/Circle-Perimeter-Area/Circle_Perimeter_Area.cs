using System;

class Circle_Perimeter_Area
{
    static void Main()
    {
        const double pi = 3.14159265359;
        Console.Write("Enter radius of the circle: ");
        double r = double.Parse(Console.ReadLine());
        double C = 2 * pi * r;
        double S = pi * r * r;
        Console.WriteLine("Perimeter: {0:0.00}\nArea: {1:0.00}", C, S);
    }
}