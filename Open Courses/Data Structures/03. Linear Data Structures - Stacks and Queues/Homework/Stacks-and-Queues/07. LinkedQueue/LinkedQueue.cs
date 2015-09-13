namespace _07.LinkedQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedQueue<T> : IEnumerable
    {
        public LinkedQueue()
        {
            this.Count = 0;
        }

        public QueueNode<T> Head { get; private set; }

        public QueueNode<T> Tail { get; private set; }

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            var newTail = new QueueNode<T>(element);

            if (this.Count == 0)
            {
                this.Head = this.Tail = newTail;
            }
            else
            {
                newTail.PrevNode = this.Tail;
                this.Tail.NextNode = newTail;
                this.Tail = newTail;
            }
            
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            var resultElement = this.Head.Value;
            this.Head = this.Head.NextNode;
            
            if (this.Head != null)
            {
                this.Head.PrevNode = null;
            }
            else
            {
                this.Tail = null;
            }

            this.Count--;
            return resultElement;
        }

        public T Peak()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            var resultElement = this.Head.Value;

            return resultElement;
        }

        public T[] ToArray()
        {
            var resultArr = new T[this.Count];
            var currentNode = this.Head;

            for (int i = 0; i < this.Count; i++)
            {
                resultArr[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return resultArr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.Head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}