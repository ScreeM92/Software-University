using System;
class CalculateFactorialFormula
    {
        static void Main()
        {
            //Calculate 1 + 1!/X + 2!/X^2 + … + N!/X^n
            Console.Write("Enter n :");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter x :");
            int x = int.Parse(Console.ReadLine());
            double result = 1;
            double nFactorial = 1;
            double xn = 1;
            for (int i = 1; i <= n; i++)
            {
                nFactorial *= i;
                xn *= x;
                result += nFactorial / xn;
            }
            Console.WriteLine("{0:F5}", result);
        }
    }

