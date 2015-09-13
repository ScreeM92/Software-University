using System;
    class SumOf5Numbers
    {
        static void Main()
        {
            string input = Console.ReadLine();
            double sum = 0;
            string[] separator = input.Split(' ');
            for (int i = 0; i < separator.Length; i++)
            {
                sum = sum + double.Parse(separator[i]);
            }
            Console.WriteLine("Sum = {0}", sum);
        }
    }
