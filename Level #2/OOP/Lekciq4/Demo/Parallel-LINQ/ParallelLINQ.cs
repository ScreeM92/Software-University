using System;
using System.Diagnostics;
using System.Linq;

namespace Parallel_LINQ
{
    class Program
    {
        static int SumDefault(int[] array)
        {
            /*
             *
             * Sum all numbers in the array.
             *
             * */
            return array.Sum();
        }

        static int SumAsParallel(int[] array)
        {
            /*
             *
             * Enable parallelization and then sum.
             *
             * */
            return array.AsParallel().Sum();
        }

        static void Main()
        {
            // Generate array.
            int[] array = Enumerable.Range(0, short.MaxValue).ToArray();

            // Test methods.
            Console.WriteLine(SumAsParallel(array));
            Console.WriteLine(SumDefault(array));

            const int m = 10000;
            var s1 = Stopwatch.StartNew();
            for (int i = 0; i < m; i++)
            {
                SumDefault(array);
            }
            s1.Stop();
            var s2 = Stopwatch.StartNew();
            for (int i = 0; i < m; i++)
            {
                SumAsParallel(array);
            }
            s2.Stop();
            Console.WriteLine("{0} - Default Query", s1.Elapsed);
            Console.WriteLine("{0} - Parallel Query", s2.Elapsed);
        }
    }
}
