using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divide
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int p = 0;
            for (int i = a; i <= b; i++)
            {
                
                if (i % 5 == 0)
                {
                    Console.WriteLine(i);
                    p += 1; //p++
                }
            }
            Console.WriteLine(p);
        }
    }
}
