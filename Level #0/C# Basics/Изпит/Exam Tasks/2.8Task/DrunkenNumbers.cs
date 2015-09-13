using System;

public class Program
{
    public static void Main()
    {
        long n = int.Parse(Console.ReadLine());
        string[] numbers = new string[n];
        long beersM = 0;
        long beersV = 0;

        for (int i = 0; i < n; i++)
        {
            long num = long.Parse(Console.ReadLine());
            if (num < 0)
            {
                num = -num;
            }

            numbers[i] = num.ToString();
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            string digit = numbers[i];

            if (digit.Length % 2 == 0)  // even number
            {
                for (int j = 0; j < digit.Length / 2; j++)
                {
                    beersM = (digit[j] - '0') + beersM;
                }

                for (int j = digit.Length / 2; j < digit.Length; j++)
                {
                    beersV = (digit[j] - '0') + beersV;
                }
            }

            else
            {
                for (int j = 0; j < digit.Length / 2 + 1; j++)   // odd number
                {
                    beersM = (digit[j] - '0') + beersM;
                }

                for (int j = digit.Length / 2; j < digit.Length; j++)
                {
                    beersV = (digit[j] - '0') + beersV;
                }
            }

        }

        if (beersM > beersV)
        {
            Console.WriteLine("M {0}", (beersM - beersV));
        }
        else if (beersV > beersM)
        {
            Console.WriteLine("V {0}", (beersV - beersM));
        }
        else
        {
            Console.WriteLine("No {0}", (beersM + beersV));
        }
    }

}