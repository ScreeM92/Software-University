using System;

class DiamondTrolls
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        char star = '*';
        char dot = '.';

        Console.WriteLine("{0}{1}{0}",
            new string (dot, (n + 1)/ 2),
            new string (star, n));

        int countDots = (n - 1) / 2;
        int innerCountDots = countDots;
        int outerCountDots = countDots;

        for (int i = 0; i < (n - 1) / 2; i++)
        {
            string outerDots = new string(dot, outerCountDots--);
            string innerDots = new string(dot, innerCountDots++);
            Console.WriteLine("{0}*{1}*{1}*{0}", outerDots, innerDots);
        }
        Console.WriteLine(new string(star, (n * 2) + 1));


        for (int row = 1; row <= n - 1; row++)
        {
            string outerDots = new string(dot, row);
            string innerDots = new string(dot, n - row - 1);
            Console.WriteLine("{0}*{1}*{1}*{0}", outerDots, innerDots);
        }
        Console.WriteLine("{0}*{0}",new string(dot, n));
    }
}