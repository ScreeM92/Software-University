using System;
using System.Numerics;
class TrailingZeroesInN
{
    static void Main()
        {
            Console.WriteLine("N:");
            int num = int.Parse(Console.ReadLine());
            int result = 1;
            int divide = 5;
            int sum = 0;  
            do
            {
                result = num / divide;
                divide *= divide; //num = result; 
                sum += result;
            } 
            while (result > 0);
            Console.WriteLine(sum);
        }
}

