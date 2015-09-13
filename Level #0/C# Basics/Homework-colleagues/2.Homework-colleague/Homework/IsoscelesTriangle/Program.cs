using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoscelesTriangle
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            char a = '\u00A9';
            Console.WriteLine(@"
                           {0}
                          {0} {0}
                         {0}   {0}
                        {0} {0} {0} {0}", a);

            }
        }
    }

