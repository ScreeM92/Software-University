namespace _03.ArrayStack
{
    using System;

    public class ArrayStack<T>
    {
        private const int InitialCapacity = 16;
        private T[] elements;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
            this.Count = 0;
        }

        public int Capacity 
        {
            get { return this.elements.Length; }
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count == this.Capacity)
            {
                this.Grow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            var resultElement = this.elements[--this.Count];

            return resultElement;
        }

        public T Peak()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            var resultElement = this.elements[this.Count - 1];

            return resultElement;
        }

        public T[] ToArray()
        {
            var resultArr = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                resultArr[i] = this.elements[this.Count - 1 - i];
            }
            
            return resultArr;
        }

        private void Grow()
        {
            var newElements = new T[2 * this.Capacity];
            this.CopyAllElementsTo(newElements);
            this.elements = newElements;
        }

        private void CopyAllElementsTo(T[] newElements)
        {
            Array.Copy(this.elements, newElements, this.Count);
        }
    }
}
