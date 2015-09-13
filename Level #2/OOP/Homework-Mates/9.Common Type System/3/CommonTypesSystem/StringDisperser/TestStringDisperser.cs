using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class TestDisperser
    {
        static void Main()
        {
            StringDisperser disperser = new StringDisperser("hello", "world");
            Console.WriteLine(disperser);
            foreach (var ch in disperser)
            {
                Console.Write(ch + " ");
            }
            StringDisperser disperser2 = new StringDisperser("hey", "man!");
            Console.WriteLine();
            Console.WriteLine(disperser.CompareTo(disperser2));
            StringDisperser disperser2Copy = (StringDisperser)disperser2.Clone();
            disperser2Copy.Strings[0] = "new";
            Console.WriteLine(disperser2Copy);
            Console.WriteLine(disperser2);
        }
    }

