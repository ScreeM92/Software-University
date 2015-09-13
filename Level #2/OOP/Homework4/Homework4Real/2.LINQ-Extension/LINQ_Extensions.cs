using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Custom_LINQ_Extensions_Methods
{
    class LINQ_Extensions
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(2);
            queue.Enqueue(24);
            queue.Enqueue(51);
            queue.Enqueue(61);
            queue.Enqueue(65);
            queue.Enqueue(90);
            queue.Enqueue(100);
            var result = queue.WhereNot(x => x % 3 == 0);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }


            List<int> numbers = new List<int>();
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);
            var allNumbers = numbers.Repeat(3);
            Console.WriteLine();
            foreach (var item in allNumbers)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            List<string> words = new List<string>() { "Configuration", "hi", "cool", "full", "Hello", "how", "revolution", "commendation", "contrition", " starvation" };
            List<string> suffixes = new List<string>() { "tion", "l" };
            var filtredWords = words.WhereEndsWith(suffixes);

            foreach (var item in filtredWords)
            {
                Console.WriteLine(item);
            }
        }
    }
}