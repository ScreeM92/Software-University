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
        double w = double.Parse(Console.ReadLine());
        Console.Write("Enter triangle height: ");
        double h = double.Parse(Console.ReadLine());
        Console.WriteLine(CalcTriangleArea(w, h));
    }
}
