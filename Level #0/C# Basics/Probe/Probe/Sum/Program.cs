using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double sum = 0;
            string[] separator = input.Split(' ');
            for (int i = 0; i < separator.Length; i++)
            {
                sum += double.Parse(separator[i]);
            }
            Console.WriteLine(sum);
        }
    }
}
