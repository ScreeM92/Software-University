namespace _07.LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable
    {
        public int Count { get; private set; }

        private ListNode<T> Head { get; set; }

        private ListNode<T> Tail { get; set; }

        public void Add(T item)
        {
            var newTail = new ListNode<T>(item);

            if (this.Count == 0)
            {
                this.Head = this.Tail = newTail;
            }
            else
            {
                this.Tail.NextNode = newTail;
                this.Tail = newTail;
            }

            this.Count++;
        }

        public void Remove(int index)
        {
            var removedNode = this.ElementAt(index);

            if (removedNode != this.Head)
            {
                var previousNode = this.ElementAt(index - 1);
                previousNode.NextNode = removedNode.NextNode;

                if (removedNode == this.Tail)
                {
                    this.Tail = previousNode;
                }
            }
            else
            {
                this.Head = this.Head.NextNode;
            }

            this.Count--;
        }

        public int FirstIndexOf(T item)
        {
            int index = -1, 
                currenntIndex = 0;
            ListNode<T> currentNode = this.Head;

            while (currenntIndex < this.Count)
            {
                if (item.Equals(currentNode.Value))
                {
                    index = currenntIndex;
                    break;
                }

                currentNode = currentNode.NextNode;
                currenntIndex++;
            }

            return index;
        }

        public int LastIndexOf(T item)
        {
            int index = -1,
                currenntIndex = 0;
            ListNode<T> currentNode = this.Head;

            while (currenntIndex < this.Count)
            {
                if (item.Equals(currentNode.Value))
                {
                    index = currenntIndex;
                }

                currentNode = currentNode.NextNode;
                currenntIndex++;
            }

            return index;
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

        private ListNode<T> ElementAt(int index)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Linked list is empty!");
            }

            if (index < 0 || index >= this.Count)
            {
                throw new InvalidOperationException("Invalid index!");
            }

            var startIndex = 0;
            var currentNode = this.Head;

            while (startIndex != index)
            {
                currentNode = currentNode.NextNode;
                startIndex++;
            }

            return currentNode;
        }
    }
}