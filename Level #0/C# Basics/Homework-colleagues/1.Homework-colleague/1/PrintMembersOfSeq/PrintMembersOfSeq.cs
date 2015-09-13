using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintMembersOfSeq
{
    class PrintMembersOfSeq
    {
        static void Main(string[] args)
        {
            for (int i = 2; i <= 1001; i++)
            {
                if(i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
                else
                {
                    Console.WriteLine("-" + i);
                }
            }
        }
    }
}
