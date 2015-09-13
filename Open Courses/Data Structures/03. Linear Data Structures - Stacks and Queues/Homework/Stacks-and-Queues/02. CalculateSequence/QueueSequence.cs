using System;
using System.Collections;
using System.Collections.Generic;

namespace _02.CalculateSequence
{
    class QueueSequence
    {
        public static void Main()
        {
            const int multiplier = 2;
            const int firstAddend = 1;
            const int secondAddend = 2;

            int sequenceLength = 50;
            int currentNumber = int.Parse(Console.ReadLine());

            var sequence = new Queue<int>();
            var tempQueue = new Queue<int>();
            sequence.Enqueue(currentNumber);
            tempQueue.Enqueue(currentNumber);

            while (sequence.Count < sequenceLength)
            {
                currentNumber = tempQueue.Dequeue();

                sequence.Enqueue(currentNumber + firstAddend);
                sequence.Enqueue(multiplier * currentNumber + firstAddend);
                sequence.Enqueue(currentNumber + secondAddend);

                tempQueue.Enqueue(currentNumber + firstAddend);
                tempQueue.Enqueue(multiplier * currentNumber + firstAddend);
                tempQueue.Enqueue(currentNumber + secondAddend);
            }

            while (sequenceLength > 0)
            {
                Console.Write(sequence.Dequeue() + " ");
                sequenceLength--;
            }
        }
    }
}