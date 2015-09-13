using System;
class MultiplicationSign
{
    static void Main()
    {
        Console.Write("Enter a :");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter b :");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter c :");
        double c = double.Parse(Console.ReadLine());
        if (a == 0 || b == 0 || c == 0)
        {
            Console.WriteLine("0");
        }
        else
        {
            if (a > 0)
            {
                if (b > 0 && c > 0)
                {
                    Console.WriteLine("+");
                }
                else if (b < 0 && c < 0)
                {
                    Console.WriteLine("+");
                }    
                else 
                {
                    Console.WriteLine("-");
                }    
            }
            else
            {
                if (b > 0 && c > 0) 
                {
                    Console.WriteLine("-");
                }
                else if (b < 0 && c < 0)
                {
                    Console.WriteLine("-");
                }
                else
                {
                    Console.WriteLine("+");
                }
            }

        }
    }
}