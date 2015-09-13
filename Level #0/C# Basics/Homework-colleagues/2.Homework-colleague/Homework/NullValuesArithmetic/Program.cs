using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullValuesArithmetic
{
    class Program
    {
        static void Main()
        {
            int? a = null;
            double? b = null;

            Console.WriteLine("nullable variables: a: {0} b: {1}", a, b);

            a = null;
            b += 25.56; 
            Console.WriteLine("double nullable variables: a: {0} b: {1}", a, b);
        }
    }
}
