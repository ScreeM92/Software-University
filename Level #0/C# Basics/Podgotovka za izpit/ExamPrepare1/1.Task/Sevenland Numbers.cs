using System;
using System.Linq;
    class Program
    {
        static void Main()
        {
            //
            int number = int.Parse(Console.ReadLine());
            int numberInDec = 0;
            int position = 0;
            while (number > 0)
            {
                int lastNumber = number % 10;
                numberInDec += lastNumber * (int)Math.Pow(7, position);
                position++;
                number = number / 10;
            }
            numberInDec++;
            string numberInSeven = string.Empty;
            while (numberInDec > 0)
            {
                int lastNumber = numberInDec % 7;
                numberInSeven += lastNumber;
                numberInDec = numberInDec / 7;
            }
            Console.WriteLine(string.Join("", numberInSeven.Reverse()));
        }
    }

