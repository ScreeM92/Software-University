using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = "Hello";
            string last = "World";
            object full = first + " " + last;
            Console.WriteLine(full);
            string all = (string)full;     
            Console.WriteLine(all);

        }
    }
}
