using System;
    class Program
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int sum;
            sum = (b * b) - (4*a*c);
            if (sum > 0)
            {
                Console.WriteLine("x1 ={0}", ((-b) + Math.Sqrt(sum))/ (2 * a));
                Console.Write(" x2 ={0}", ((-b) - Math.Sqrt(sum)) / (2 * a));
            }
            else if (sum == 0)
            {
                Console.WriteLine("x = {0}", (-b) / (2 * a));
            }
            else 
            {
                Console.WriteLine("Няма реални корени");
            }
        }
    }

