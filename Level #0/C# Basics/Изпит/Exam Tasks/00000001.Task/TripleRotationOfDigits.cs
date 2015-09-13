using System;


public class Program
{
    public static void Main()
    {
        long k = long.Parse(Console.ReadLine());
        string reversedNum = null;
        for (long i = 0; i < 3; i++)
        {
            reversedNum = null;
            long digit = k % 10;
            if (digit == 0)
            {
                k = k / 10;
                continue;
            }

            if (k < 10)
            {
                break;
            }
            k = k / 10;
            reversedNum = digit + reversedNum;
            string newNum = k.ToString();
            reversedNum += newNum;
            k = long.Parse(reversedNum);
        }
        Console.WriteLine(k);
    }
}