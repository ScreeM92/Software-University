using System;
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            string binNum = "";
            while (num != 0)
            {
                int rest = num % 2;
                num /= 2;
                binNum = rest + binNum;
            }
            Console.WriteLine(binNum);
        }
    }

