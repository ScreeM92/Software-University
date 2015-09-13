using System;
    class MinMaxSumAndAverageOfNNumbers
    {
        static void Main()
        {
            Console.Write("Enter length of loop: ");
            int length = int.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());
            int min = number;
            int max = number;
            int sum = number;
            double avg = 0;
            for (int i = 0; i < length - 1; i++)
            {
                int num = int.Parse(Console.ReadLine());
                min = Math.Min(min, num);
                max = Math.Max(max, num);
                sum += (num);
                avg = sum / length;
            }
            Console.WriteLine("Min = " + min);
            Console.WriteLine("Max = " + max);
            Console.WriteLine("Sum = " + sum);
            Console.WriteLine("Avg = {0:F2}", avg);

        }
    }

