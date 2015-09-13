using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_CustomLINQ
{
    class LINQExtensionsTest
    {
        static void Main(string[] args)
        {
            var items = new List<string> { "ice-cream", "chocolate", "honey", "sugar", "candy", "strawberry" };

            var whereNot = string.Join(", ", items.WhereNot(w => w == "sugar"));
            Console.WriteLine(whereNot);

            var repeat = string.Join(", ", items.Repeat(3));
            Console.WriteLine(repeat);

            var suffixes = new List<string> { "ate", "rry" };
            var endsWith = string.Join(", ", items.WhereEndsWith(suffixes));
            Console.WriteLine(endsWith);
        }
    }
}