using System;
class TheBiggestOf_3_Numbers
{
    static void Main()
    {
        Console.Write("Enter a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter c: ");
        double c = double.Parse(Console.ReadLine());
        if (a > b && a > c)
        {
            Console.WriteLine("The biggest of three numbers is: {0}",a);
        }
        else if (a < b && b > c)
	    {
            Console.WriteLine("The biggest of three numbers is: {0}", b);
	    }
        else
	    {
            Console.WriteLine("The biggest of three numbers is: {0}", c);
	    }
    }
}