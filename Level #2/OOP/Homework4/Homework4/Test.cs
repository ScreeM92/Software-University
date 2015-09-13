using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    class Test
    {
        static void Main()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(2);
            queue.Enqueue(10);
            queue.Enqueue(5);
            queue.Enqueue(6);
            var resultQueue = queue.WhereNot(x => x % 3 == 0);

            foreach (var item in resultQueue)
            {
                Console.WriteLine(item);
            }
        }
    }
}
