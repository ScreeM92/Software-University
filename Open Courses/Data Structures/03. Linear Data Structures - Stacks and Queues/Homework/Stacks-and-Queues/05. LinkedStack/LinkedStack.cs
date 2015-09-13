namespace _05.LinkedStack
{
    using System;

    public class LinkedStack<T>
    {
        private StackNode<T> firstNode;

        public LinkedStack()
        {
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            this.firstNode = new StackNode<T>(element, this.firstNode);
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            var resultElement = this.firstNode.Value;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;

            return resultElement;
        }

        public T Peak()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return this.firstNode.Value;
        }

        public T[] ToArray()
        {
            var resultArr = new T[this.Count];
            var currentNode = this.firstNode;

            for (int i = 0; i < this.Count; i++)
            {
                resultArr[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return resultArr;
        }
    }
}