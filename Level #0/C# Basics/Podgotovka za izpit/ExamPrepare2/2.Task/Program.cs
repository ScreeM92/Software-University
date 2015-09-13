using System;
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int sum = 0;
            int count = 0;
            for (int i = 0; i < input.Length; i+= 2)
            {
                if (char.IsDigit(input[i]))
                {
                    count++;
                    sum += int.Parse(input[i].ToString());
                }
            }
            Console.WriteLine("{0} {1}", count, sum);
        }
    }

