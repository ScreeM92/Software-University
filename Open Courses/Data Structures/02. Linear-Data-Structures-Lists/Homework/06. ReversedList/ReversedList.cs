namespace _06.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IEnumerable
    {
        private T[] elements;

        public ReversedList(int capacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get { return this.elements.Length; }
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);

                return this.elements[this.Count - 1 - index];
            }

            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new InvalidOperationException("Invalid indedx!");
                }

                this.elements[this.Count - 1 - index] = value;
            }
        }

        public void Add(T item)
        {
            if (this.Count == this.Capacity)
            {
                this.Grow();
            }

            this.elements[this.Count] = item;
            this.Count++;
        }

        public void Remove(int index)
        {
            this.ValidateIndex(index);

            for (int i = this.Count - 1 - index; i < this.Count - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }

            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Grow()
        {
            var newElements = new T[2 * this.Capacity];
            for (int i = 0; i < this.Count; i++)
            {
                newElements[i] = this.elements[i];
            }

            this.elements = newElements;
        }

        private void ValidateIndex(int index)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty.");
            }

            if (index < 0 || index >= this.Count)
            {
                throw new InvalidOperationException("Invalid indedx!");
            }
        }
    }
}