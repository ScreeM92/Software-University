using System;

namespace BonusScore
{
    class BonusScore
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n < 1 || n > 9)
            {
                Console.WriteLine("Invalid score");
            }
            else if (n >= 1 && n <= 3)
            {
                Console.WriteLine(n * 10);
            }
            else if (n >= 3 && n <= 6)
            {
                Console.WriteLine(n * 100);
            }
            else if (n >= 6 && n < 10)
            {
                Console.WriteLine(n * 1000);
            }
        }
    }
}
