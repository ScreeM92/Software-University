using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeAfterTenYears
{
    class AgeAfterTenYears
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter your age: ");
            byte age = byte.Parse(Console.ReadLine());
            Console.WriteLine("Your age after 10 years is: {0}", age + 10);
        }
    }
}
