using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikLogo2
{
    class Program
    {
        static void Main(string[] args)
        {


            int x = int.Parse(Console.ReadLine());

            int n = 3 * x - 2;
            int zLeft = x / 2 + 1;
            int zRight = n - (x / 2);
            int zzLeft = zLeft;
            int zzRight = zRight;

            for (int row = 1; row <= n; row++)
            {
                for (int col = 1; col <= n; col++)
                {
                    if (col == zLeft)
                    {
                        Console.Write("*");
                    }
                    //else if (row==x)
                    //{
                    // Console.WriteLine("{0}*{0}", new string('.',n/2));
                    //}
                    else if (col == zRight)
                    {
                        Console.Write("*");
                    }
                    else if (row > 0 && col == zzLeft)
                    {
                        Console.Write("*");
                    }
                    else if (row > 0 && col == zzRight)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();

                if (row < 2 * x - 1)
                {
                    zzLeft++;
                    zzRight--;
                }
                else
                {
                    zzLeft--;
                    zzRight++;
                }
                zLeft--;
                zRight++;
            }


        }
    }
}