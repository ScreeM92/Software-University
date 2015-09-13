using System;

namespace TheBiggestOfThreeNumbers
{
    class TheBiggestOfThreeNumbers
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter first variable: ");
                int var1 = int.Parse(Console.ReadLine());
                Console.Write("Enter second variable: ");
                int var2 = int.Parse(Console.ReadLine());
                Console.Write("Enter third variable: ");
                int var3 = int.Parse(Console.ReadLine());
                if (var1 == var2 && var1 == var3)
                {
                    Console.WriteLine("They are all equal!");
                }
                else if (var1 > var2)
                {
                    if (var1 == var3)
                    {
                        Console.WriteLine("A. 1st number {0} is equal to 3rd number {1}\n and they are bigger than 2nd number {2}", var1, var3, var2);
                    }
                    else if (var1 > var3) Console.WriteLine("A. The biggest number is " + var1);
                }
                else if (var2 > var3)
                {
                    if (var2 == var1)
                    {
                        Console.WriteLine("B. 2nd number {0} is equal to 1st number {1}\n and they are bigger than 3rd number {2}", var2, var1, var3);
                    }
                    else if (var2 > var1) Console.WriteLine("B. The biggest number is " + var2);
                }
                if (var3 > var1)
                {
                    if (var3 == var2)
                    {
                        Console.WriteLine("C. 3rd number {0} is equal to 2nd number {1}\n and they are bigger than 1st number {2}", var3, var2, var1);
                    }
                    else if (var3 > var2) Console.WriteLine("C. The biggest number is " + var3);
                }
            }
        }
    }
}
