using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 254;
            float b = 45.5346f;
            float c = -23.2341f;
            Console.WriteLine("{0:X}", a);
            Console.WriteLine("{0:F2}", b);
            Console.WriteLine("{0:F2}", c);
        }
    }
}
