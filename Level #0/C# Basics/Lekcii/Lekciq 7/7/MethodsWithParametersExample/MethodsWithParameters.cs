using System;

class MethodsWithParameters
{
    static double CalcTriangleArea(double width, double height)
    {
        return width * height / 2;
    }

    static void Main()
    {
        Console.Write("Enter triangle width: ");
        double width = double.Parse(Console.ReadLine());
        Console.Write("Enter triangle height: ");
        double height = double.Parse(Console.ReadLine());
        Console.WriteLine(CalcTriangleArea(width, height));
    }
}
