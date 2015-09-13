using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter number a:");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter number b:");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter number c:");
        double c = double.Parse(Console.ReadLine());
        if (a >= b)
        {
            if (b >= c)
            {
                Console.WriteLine(a + " " + b + " " + c);

            }
            else
            {
                if (a >= c)
                {
                Console.WriteLine(a + " " + c + " " + b);
                }
            }
        }
        else
        {
            if (b >= c)
            {
                if (c >= a)
                {
                    Console.WriteLine(b + " " + c + " " + a);
                }
                else
                {
                    Console.WriteLine(b + " " + a + " " + c);
                }
            }
        }
        if (c > a)
        {
            if (c > b)
            {
                if (a > b)
                {
                    Console.WriteLine(c + " " + a + " " + b);
                }
                else
                {
                    Console.WriteLine(c + " " + b + " " + a);
                }

            }
        }
    }
}
