using System;

public class MathExpression
{
    public static void Main()
    {
        double n = double.Parse(Console.ReadLine());
        double m = double.Parse(Console.ReadLine());
        double p = double.Parse(Console.ReadLine());

        double result = (n * n + (1 / (m * p)) + 1337) / (n - (128.523123123 * p)) + Math.Sin((int)m % 180);
        Console.WriteLine("{0:0.000000}", result);
    }

}