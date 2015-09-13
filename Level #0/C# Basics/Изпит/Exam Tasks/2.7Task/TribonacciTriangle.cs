using System;
using System.Numerics;


public class Program
{
    public static void Main()
    {
        long n1 = long.Parse(Console.ReadLine());
        long n2 = long.Parse(Console.ReadLine());
        long n3 = long.Parse(Console.ReadLine());
        long l = long.Parse(Console.ReadLine());

        long sum = 0;

        Console.WriteLine(n1);
        Console.WriteLine(n2 + " " + n3);

        if (l <= 2)
        {
            return;
        }

        for (long row = 2; row < l; row++)
        {
            for (long col = 0; col <= row; col++)
            {
                sum = n1 + n2 + n3;

                if (col == row)
                {
                    Console.Write(sum);
                    n1 = n2;
                    n2 = n3;
                    n3 = sum;
                    break;
                }

                Console.Write(sum + " ");
                n1 = n2;
                n2 = n3;
                n3 = sum;
            }
            Console.WriteLine();
        }
    }
}
