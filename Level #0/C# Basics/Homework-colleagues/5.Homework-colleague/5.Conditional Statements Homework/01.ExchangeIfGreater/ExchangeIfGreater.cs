using System;
class ExchangeIfGreater
{
    static void Main()
    {
        double temp = 0;
        Console.Write("Enter a: ");
        double a = double.Parse(Console.ReadLine()); 
        Console.Write("Enter b: ");
        double b = double.Parse(Console.ReadLine());
        if (a>b)
        {
            temp = a;
            a = b;
            b = temp;
            Console.WriteLine(a+" "+b);
        }
        else
        {
            Console.WriteLine(a + " " + b);
        }
    }
}