using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLINQExtensionMethods
{
    class LinqExtensionsDemo
    {
        static void Main(string[] args)
        {
            string[] towns = { "Sofia", "Varna", "Pleven", "Ruse", "Bourgas", "Plovdiv" };
            var selectedTowns = towns.WhereNot(x => x.StartsWith("P"));
            foreach (var selectedTown in selectedTowns)
            {
                Console.WriteLine(selectedTown);
            }

            int[] luckyNumbers = {1, 24, 57, 89};
            var manyLuckyNumbers = luckyNumbers.Repeat(20);
            Console.WriteLine(string.Join(",", manyLuckyNumbers));

            string[] fruits = { "cherry", "apple", "blueberry", "banana", "strawberries", "raspberry", "blackberry", "mango" };
            var berries = fruits.WhereEndsWith(new[] {"berry", "berries"});
            foreach (var berry in berries)
            {
                Console.WriteLine(berry);
            }
        }
    }
}
