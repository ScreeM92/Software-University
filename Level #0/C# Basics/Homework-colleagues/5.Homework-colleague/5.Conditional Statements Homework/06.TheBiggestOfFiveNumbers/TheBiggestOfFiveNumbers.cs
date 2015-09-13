using System;
class TheBiggestOfFiveNumbers
{
    static void Main()
    {
        Console.Write("Enter a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter c: ");
        double c = double.Parse(Console.ReadLine());
        Console.Write("Enter d: ");
        double d = double.Parse(Console.ReadLine());
        Console.Write("Enter e: ");
        double e = double.Parse(Console.ReadLine());
        if (a > b && a > c && a > d && a > e)
        {
            Console.WriteLine("The biggest of five numbers is: {0}",a);
        }
        if (a < b && b > c && b > d && b > e)
        {
            Console.WriteLine("The biggest of five numbers is: {0}", b);
        }
        if (a < c && b < c && c > d && c > e)
        {
            Console.WriteLine("The biggest of five numbers is: {0}", c);
        }
        if (a <= d && b <= d && c <= d && d >= e)
        {
            Console.WriteLine("The biggest of five numbers is: {0}", d);
        }
        else
        {
            Console.WriteLine("The biggest of five numbers is: {0}", e);
        }
    }
}