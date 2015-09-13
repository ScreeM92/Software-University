namespace Problem_4.Generic_List_Version
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    [Version(99, 2345)]

    public class GenericList<T> where T : IComparable<T>
    {
        private const int DEFAULTSIZE = 16;
        private T[] containerArray = new T[DEFAULTSIZE];
        private int elementsCount = 0;

        public GenericList(int size = DEFAULTSIZE)
        {
            this.ArraySize = size;
        }

        public int ArraySize
        {
            get
            {
                return this.containerArray.Length;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new IndexOutOfRangeException("Invalid array length!");
                }
                else
                {
                    this.containerArray = new T[value];
                }
            }
        }

        public int ElementsCount
        {
            get
            {
                return this.elementsCount;
            }

            private set
            {
                if (this.ArraySize <= this.elementsCount)
                {
                    this.AutoGrow();
                }

                this.elementsCount = value;
            }
        }

        public T this[int index]
        {
            get
            {
                this.CheckIndex(index);
                if (index >= this.ElementsCount)
                {
                    throw new NullReferenceException("Cannot access empty element!");
                }

                return this.containerArray[index];
            }

            set
            {
                this.CheckIndex(index);
                this.containerArray[index] = value;
            }
        }

        public void Add(T element)
        {
            this.ElementsCount++;
            this.containerArray[this.elementsCount - 1] = element;
        }

        public void Remove(int index)
        {
            this.CheckIndex(index);
            if (index > this.ElementsCount - 1)
            {
                throw new NullReferenceException("No element on this index value!");
            }

            T[] destinationArray = new T[this.ArraySize];
            if (this.ArraySize == 1)
            {
                this.Clear();
                return;
            }

            if (index == 0 || index == this.ElementsCount - 1)
            {
                if (index == 0)
                {
                    Array.Copy(this.containerArray, index + 1, destinationArray, 0, this.ArraySize - 2);
                }
                else
                {
                    Array.Copy(this.containerArray, 0, destinationArray, 0, this.ArraySize - 2);
                }
            }
            else
            {
                Array.Copy(this.containerArray, destinationArray, index + 1);
                Array.Copy(this.containerArray, index + 1, destinationArray, index, this.ArraySize - 2 - index);
            }

            this.containerArray = destinationArray;
            this.ElementsCount--;
        }

        public void Insert(T element, int index)
        {
            this.CheckIndex(index);
            this.ElementsCount++;
            T[] destinationArray = new T[this.ArraySize];
            Array.Copy(this.containerArray, destinationArray, index);
            destinationArray[index] = element;
            Array.Copy(this.containerArray, index, destinationArray, index + 1, this.ArraySize - 2 - index);
            this.containerArray = destinationArray;

            //// working insert

            ////T tempElement = this.continerArray[index];
            ////this.continerArray[index] = element;
            ////T copiedElement = this.continerArray[index + 1];
            ////for (int i = index + 1; i < this.elementsCount; i++)
            ////{
            ////    this.continerArray[i] = tempElement;
            ////    tempElement = copiedElement;
            ////    copiedElement = this.continerArray[i + 1];
            ////}
        }

        public void Clear()
        {
            ////this.containerArray = new T[this.ArraySize];
            this.ElementsCount = 0;
            Array.Clear(this.containerArray, 0, this.ArraySize);
        }

        public int FindElementIndex(T element)
        {
            int index = -1;
            for (int i = 0; i < this.elementsCount; i++)
            {
                if (this.containerArray[i].Equals(element))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public bool CheckContains(T element)
        {
            bool contains = false;
            for (int i = 0; i < this.elementsCount; i++)
            {
                if (this.containerArray.Equals(this.containerArray[i]))
                {
                    contains = true;
                    break;
                }
            }

            return contains;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(this.containerArray[0]);
            for (int i = 1; i < this.elementsCount; i++)
            {
                output.Append(string.Format(", {0}", this.containerArray[i]));
            }

            return string.Join(", ", output);
        }

        public T Min()
        {
            if (this.elementsCount == 0)
            {
                throw new NullReferenceException("No elements in array!");
            }

            T minElement = this.containerArray[0];
            for (int i = 1; i < this.elementsCount; i++)
            {
                if (Comparer<T>.Default.Compare(minElement, this.containerArray[i]) == 1)
                {
                    minElement = this.containerArray[i];
                }
            }

            return minElement;
        }

        public T Max()
        {
            if (this.elementsCount == 0)
            {
                throw new NullReferenceException("No elements in array!");
            }

            T maxElement = this.containerArray[0];
            for (int i = 1; i < this.elementsCount; i++)
            {
                if (Comparer<T>.Default.Compare(maxElement, this.containerArray[i]) == -1)
                {
                    maxElement = this.containerArray[i];
                }
            }

            return maxElement;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= this.containerArray.Length)
            {
                throw new IndexOutOfRangeException("Invalid index element!");
            }
        }

        private void AutoGrow()
        {
            T[] doubleArray = new T[this.ArraySize * 2];
            Array.Copy(this.containerArray, doubleArray, this.ArraySize);
            this.containerArray = doubleArray;
        }
    }
}