using System;
    class TheBiggestOf3Numbers
    {
        static void Main()
        {
            Console.WriteLine("Please enter number a:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter number b:");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter number c:");
            double c = double.Parse(Console.ReadLine());
            if (a > b && a > c)
            {
                Console.WriteLine("The biggest of three numbers:{0}", a);
            }
            if (b > a && b > c)
            {
                Console.WriteLine("The biggest of three numbers:{0}", b);
            }
            if (c > a && c > b)
            {
                Console.WriteLine("The biggest of three numbers:{0}", c);
            }
        }
    }

