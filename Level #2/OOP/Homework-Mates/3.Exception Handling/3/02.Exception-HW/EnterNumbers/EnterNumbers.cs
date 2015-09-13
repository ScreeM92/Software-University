using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterNumbers
{
    class EnterNumbers
    {
        static void Main()
        {

            int start = 1;
            int end = 100;
            int number;
            int oldNumber = 0;
            const int numberCount = 10;
            List<int> allNumbers = new List<int>();

            for (int i = 0; i < numberCount; i++)
            {

                if (i < 1)
                {
                    Console.WriteLine("Enter 10 numbers each at separate line. ");
                }
                else
                {
                    Console.Write("Enter number bigger than previous {0} ", oldNumber);
                }
                number = ReadNumber(start, end);
                if (number > oldNumber)
                {
                    allNumbers.Add(number);
                }
                else
                {
                    while (number <= oldNumber)
                    {
                        Console.Write("Enter bigger ");
                        number = ReadNumber(start, end);
                    }
                }
                oldNumber = number;
            }
            foreach (int n in allNumbers)
            {
                Console.WriteLine(n);
            }
        }

        static int ReadNumber(int start, int end)
        {
            int num = 0;
            Console.WriteLine("number: ");

            string numberStr = Console.ReadLine();
            if (isNumber(numberStr) == true)
            {
                num = int.Parse(numberStr);

                while (num < start && num > end)
                {
                    Console.WriteLine("Number not in range! Enter: ");
                    {
                        num = int.Parse(Console.ReadLine());
                    }
                }

                return num;
            }
            else
            {
                // TODO Problem: Cant recognize if number!
                while (isNumber(numberStr) == false)
                {
                    Console.Write("Try again, ");
                    ReadNumber(start, end);
                }
            }
            return num;
        }

        static bool isNumber(string numberStr)
        {
            int number;
            bool result = int.TryParse(numberStr, out number) == true;
            return result;
        }
    }
}
