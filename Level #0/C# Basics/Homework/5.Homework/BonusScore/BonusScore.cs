using System;
    class BonusScore
    {
        static void Main()
        {
            Console.WriteLine("Please enter score in the range [1…9]");
            int a = int.Parse(Console.ReadLine());
            if (1 <= a || a >= 9)
            {
                if (1 <= a && a <= 3)
                {
                    Console.WriteLine("The score is between 1 and 3 = {0}", a * 10);
                }
                if (4 <= a && a <= 6)
                {
                    Console.WriteLine("The score is between 4 and 6 = {0}", a * 100);
                }
                if (7 <= a && a <= 9)
                {
                    Console.WriteLine("The score is between 7 and 9 = {0}", a * 1000);
                }
            }
            else
            {
                Console.WriteLine("invalid score");
            }
        }
    }

