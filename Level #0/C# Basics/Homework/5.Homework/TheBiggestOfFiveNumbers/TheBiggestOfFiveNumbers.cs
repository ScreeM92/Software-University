using System;
    class TheBiggestOfFiveNumbers
    {
        static void Main()
        {
            Console.WriteLine("Please enter number a:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter number b:");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter number c:");
            double c = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter number d:");
            double d = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter number e:");
            double e = double.Parse(Console.ReadLine());
            if (a >= b && a >= c && a >= d && a >= e)
            {
                Console.WriteLine("The biggest of five numbers:{0}", a);
            }
            if (b > a && b >= c && b >= d && b >= e)
            {
                Console.WriteLine("The biggest of five numbers:{0}", b);
            }
            if (c > a && c > b && c >= d && c >= e)
            {
                Console.WriteLine("The biggest of five numbers:{0}", c);
            }
            if (d > a && d > b && d > c && d >= e)
            {
                Console.WriteLine("The biggest of five numbers:{0}", d);
            }
            if (e > a && e > b && e > c && e > d)
            {
                Console.WriteLine("The biggest of five numbers:{0}", e);
            }
        }
    }

