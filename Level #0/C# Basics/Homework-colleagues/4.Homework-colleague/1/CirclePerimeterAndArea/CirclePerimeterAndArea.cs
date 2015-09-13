using System;

class CirclePerimeterAndArea
{
    static void Main()
    {
        Console.Write("Radius: ");
        double radius = double.Parse(Console.ReadLine());
 
        double perimeter = ((2 * Math.PI) * radius);
        double area = Math.PI * (radius * radius);
 
        Console.WriteLine("Perimeter = {0:F2}", perimeter);
        Console.WriteLine("Area = {0:F2}", area);
    }
}
