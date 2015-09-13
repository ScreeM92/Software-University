using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMembersOfSeq
{
    class FirstMembersOfSeq
    {
        static void Main(string[] args)
        {
            for (int i = 2; i <= 11; i++)
            {
                if(i % 2 == 0)
                {
                    Console.Write(i + ", ");
                }
                else
                {
                    if(i == 11)
                    {
                        Console.WriteLine("-" + i + ";");
                        break;
                    }
                    Console.Write("-" + i + ", ");
                }
            }
            Console.WriteLine();
        }
    }
}
