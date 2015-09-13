using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StringDisperser
{
    class StringDisperserMain
    {
        static void Main()
        {
            StringDisperser stringDisperser = new StringDisperser("lili", "gosho", "emo");
            StringDisperser stringDisperserCopy = (StringDisperser)stringDisperser.Clone();
            stringDisperserCopy.TotalString.Append("viki");
            foreach (var ch in stringDisperser)
            {
                Console.Write(ch + " ");
            }

            Console.WriteLine();
            foreach (var ch in stringDisperserCopy)
            {
                Console.Write(ch + " ");
            }
        }
    }
}
