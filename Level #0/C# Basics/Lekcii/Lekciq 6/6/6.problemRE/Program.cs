using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.problemRE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter N=");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter K=");
            int K = int.Parse(Console.ReadLine());
            int sumK = 1;
            int sumN = 1;
            for (int i = 1; i <= N; i++)
            {
                sumN *= i;
            }
            for (int i = 1; i <= K; i++)
            {
                sumK *= i;
            }
            int sumF = sumN / sumK;
            Console.WriteLine(sumF);
        }
    }
}
