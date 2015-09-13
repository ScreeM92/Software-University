using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMax
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = '\u2660';
            char b = '\u2665';
            char c = '\u2666';
            char d = '\u2663';
            for (int i = 2; i <= 14; i++)
            {
                if (i == 11)
                {
                    goto start;
                }
                if (i == 12)
                {
                    goto btart;
                }
                if (i == 13)
                {
                    goto ctart;
                }
                if (i == 14)
                {
                    goto dtart;
                }
                Console.Write("{0}{1} ", i, a);
                Console.Write("{0}{1} ", i, b);
                Console.Write("{0}{1} ", i, c);
                Console.Write("{0}{1} ", i, d);
                Console.WriteLine();
                continue;
            start:
                Console.Write("J{0} ", a);
                Console.Write("J{0} ", b);
                Console.Write("J{0} ", c);
                Console.Write("J{0} ", d);
                Console.WriteLine();
            btart:
                Console.Write("Q{0} ", a);
                Console.Write("Q{0} ", b);
                Console.Write("Q{0} ", c);
                Console.Write("Q{0} ", d);
                Console.WriteLine();
            ctart:    Console.Write("K{0} ", a);
                      Console.Write("K{0} ", b);
                      Console.Write("K{0} ", c);
                      Console.Write("K{0} ", d);
                      Console.WriteLine();
            dtart:
                      Console.Write("A{0} ", a);
                      Console.Write("A{0} ", b);
                      Console.Write("A{0} ", c);
                      Console.Write("A{0} ", d);
                      Console.WriteLine();
                      break;
            }
        }
    }
}
