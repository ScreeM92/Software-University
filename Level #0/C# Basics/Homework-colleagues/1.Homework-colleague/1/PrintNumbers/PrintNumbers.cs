using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintNumbers
{
    class PrintNumbers
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 3; i++)
            {
                if(i == 1)
                {
                    Console.WriteLine(i);
                }
                else if(i == 2)
                {
                    Console.WriteLine((i - 1) + "0" + (i - 1));
                }
                else if(i == 3)
                {
                    Console.WriteLine((i - 2) + "00" + (i - 2));
                }
            }
        }
    }
}
