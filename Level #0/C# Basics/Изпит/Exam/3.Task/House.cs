using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Task
{
    class House
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            char dot = '.';
            char star = '*';
            int first = (N - 1) / 2;

            Console.WriteLine("{0}*{0}", new string('.', first));
            for (int i = 0; i < (N - 3) / 2; i++)
			{
			 Console.WriteLine("{0}*{1}*{0}", new string('.', --first), new string('.', 2 * i + 1));
			}

            Console.WriteLine(new string('*', N));

            int outDots = N / 4;

            for (int i = 0; i < (N + 1) / 2 - 2; i++)
            {
                Console.WriteLine("{0}*{1}*{0}", new string('.', outDots), new string('.', N- 2 * outDots - 2));
            }
            Console.WriteLine("{0}{1}{0}", new string('.', outDots), new string('*', N - 2 * outDots));
        }
    }
}
