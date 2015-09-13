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
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            ReadNumber(start, end);
        }
        public static void ReadNumber(int start, int end)
        {
            int[] temp = new int[10];
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    string str = Console.ReadLine();

                    temp[i] = int.Parse(str);
                    if (i == 0)
                    {
                        if (temp[i] <= 1 || temp[i] < start || temp[i] > end)
                        {
                            throw new IndexOutOfRangeException(null);
                        }
                    }
                    else
                    {
                        if (temp[i] <= 1 || temp[i] <= temp[i - 1] || temp[i] < start || temp[i] > end)
                        {
                            throw new IndexOutOfRangeException(null);
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The number must be bigger than 1 and previous entered number and between the range of start and end");
                    i--;
                }
                catch (FormatException)
                {
                    Console.WriteLine("input cannot be null");
                    i--;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number must be bigger than 1 and previous entered number and between the range of start and end");
                }
            }
        }
    }
}
