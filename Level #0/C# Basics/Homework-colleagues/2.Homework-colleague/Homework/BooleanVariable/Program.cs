using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooleanVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int b = 5;
            bool c = (a > b);
            bool d = (a < b);
            Console.WriteLine("Your gender is feMale :{0}",c);
            Console.WriteLine("Your gender is Male :{0}",d);

        }
    }
}
