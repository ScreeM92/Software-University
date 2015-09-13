using System;
class ExchangeIfGreater
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Enter your first number: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter your second number: ");
            double b = double.Parse(Console.ReadLine());
            if ((int)a > (int)b)
            {
                b = b + a;
                a = b - a;
                b = b - a;
            }
            Console.WriteLine("{0}, {1}", a, b);
        }
    }
}
