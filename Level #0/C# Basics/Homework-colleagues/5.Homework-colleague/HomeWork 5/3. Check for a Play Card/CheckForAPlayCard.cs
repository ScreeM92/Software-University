using System;

namespace CheckForAPlayCard
{
    class CheckForAPlayCard
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int k;
            if (s == "J" || s == "Q" || s == "K" || s == "A")
            {
                Console.WriteLine("Yes");
            }
            else
            {
                k = int.Parse(s);
                if (k >= 2 && k <= 10)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("no");
                }
            }
        }
    }
}
