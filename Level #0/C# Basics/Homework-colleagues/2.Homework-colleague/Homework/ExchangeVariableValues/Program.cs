using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeVariableValues
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;
            int c;

            c = a;
            a = b;
            b = c;

            Console.WriteLine("Default:\na = 5\nb = 10\n\nNew:\na = {0}\nb = {1}", a, b);

            
            a = 5;
            b = 10;

            a = a + b;
            b = a - b;
            a = a - b;

            Console.WriteLine("Default:\na = 5\nb = 10\n\nNew:\na = {0}\nb = {1}", a, b);

        }
    }
}
