using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 101;
            Console.WriteLine(Convert.ToString(n, 2).PadLeft(16, '0'));
        }
    }
}
