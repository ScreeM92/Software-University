using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingFloats
{
    class Program
    {
        static void Main(string[] args)
        {
            float a = 5.03f;          //false
            float b = 6.01f;
            Boolean c = (a == b);
            Console.WriteLine(c);

            float d = 5.00000001f;      //true
            float e = 5.00000003f;
            Console.WriteLine(d == e);

            double f = 555.000000001d;  //false
            double g = 555.000000009d;
            Console.WriteLine(f==g);

            double h = 1.0000000000005f;  //true
            double i = 1.0000000000009f; 
            Console.WriteLine(h==i);

            
        }
    }
}
