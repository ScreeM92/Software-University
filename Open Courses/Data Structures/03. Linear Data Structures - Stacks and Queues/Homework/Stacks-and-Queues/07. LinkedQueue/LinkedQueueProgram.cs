namespace _07.LinkedQueue
{
    using System;

    public class LinkedQueueProgram
    {
        public static void Main()
        {
            var linkedQueue = new LinkedQueue<int>();
            linkedQueue.Enqueue(1);
            linkedQueue.Enqueue(3);
            linkedQueue.Enqueue(2);

            Console.WriteLine("Foreach:");
            foreach (var el in linkedQueue)
            {
                Console.WriteLine(el);
            }
            
            Console.WriteLine("--\nPeak: {0}", linkedQueue.Peak());

            Console.WriteLine("--");

            //while (linkedQueue.Count > 0)
            //{
            //    Console.WriteLine(linkedQueue.Dequeue());
            //}
        } 
    }
}