using System;
using System.Text;

class GenericList<T>
{   
    //Combinations of fields and properties
    public int Size { get; private set; }
    public int ElementsCounter {get; private set; }
    private T[] List { get; set; }
    //Fields
    private static readonly int defaultSize = 4;

    //One constructor for taking the size of the collection
    public GenericList(int size)
    {
        this.List = new T[size];
        this.Size = size;
    }

    //Method for adding elements in the collection
    public void AddElement(dynamic element)
    {
        this.List[ElementsCounter] = element;   
        ElementsCounter++;

        IncreaseCapacity();
    }

    //Method for inserting an element at given position
    public void InsertElement(T element, int position)
    {
        if (position > ElementsCounter || position < 0)
        {
            throw new IndexOutOfRangeException("The entered index is out of the array");
        }

        int endIndex = ElementsCounter;
        if (position < ElementsCounter)
        {
            while (endIndex >= position)
            {
                T temp = this.List[endIndex];
                this.List[endIndex] = this.List[endIndex - 1];
                this.List[endIndex - 1] = temp;
                endIndex--;
            }
        }

        this.List[position] = element;
        ElementsCounter++;

        IncreaseCapacity();
    }

    //Method for deleting element at given position
    public void DeleteElement(int position)
    {
        if (position > ElementsCounter || position < 0)
        {
            throw new IndexOutOfRangeException("The entered index is out of the array");
        }

        while (position <= ElementsCounter)
        {
            T temp = this.List[position];
            this.List[position] = this.List[position - 1];
            this.List[position - 1] = temp;
            position++;
        }
        ElementsCounter--;

        IncreaseCapacity();
    }

    //Private method for increasing the capacity of the collection - when capacity is reached it grows twice
    private void IncreaseCapacity()
    {
        if (ElementsCounter >= this.Size)
        {
            this.Size *= 2;
            
            T[] tempArray = (T[])List.Clone();
            this.List = new T[Size];

            for (int i = 0; i < tempArray.Length; i++)
            {
                this.List[i] = tempArray[i];
            }
        }
    }

    //Override ToString() - calling [the created object].ToString() will print the content of the collection
    public override string ToString()
    {
        StringBuilder toStringer = new StringBuilder();

        for (int i = 0; i < ElementsCounter; i++)
        {
            toStringer.Append(List[i]);
            if (i < ElementsCounter - 1)
            {
                toStringer.Append(", ");
            }
        }

        return string.Format(toStringer.ToString());
    }

    //Method for getting the element at given position
    public T this[int position]
    {
        get
        {
            if (position > ElementsCounter - 1 || position < 0)
            {
                throw new IndexOutOfRangeException("The entered index is out of the array");
            }
            return this.List[position];
        }
    }

    //Method for clearing the collection - the call of this method will make the collection size 4 by default
    public void Clear()
    {
        this.List = new T[defaultSize];
        ElementsCounter = 0;
    }

    //Method for finding the max element in the collection
    public T Max<T>() where T : System.IComparable<T>, IComparable
    {
        dynamic max = List[0];
        for (int i = 1; i < ElementsCounter; i++)
        {
            T tempValue = (dynamic)this.List[i];
            if (tempValue.CompareTo(max) > 0) 
            {
                max = List[i];
            }
        }
        return max;
    }

    //Method for finding the min element in the collection
    public T Min<T>() where T : System.IComparable<T>, IComparable
    {
        dynamic min = this.List[0];
        for (int i = 1; i < ElementsCounter; i++)
        {
            T listItem = (dynamic)this.List[i];
            if (listItem.CompareTo(min) < 0) 
            {
                min = this.List[i];
            }
        }
        return min;
    }

    //Method for finding the position of given element if there is any
    public int FindElement(T value)
    {
        for (int i = 0; i < ElementsCounter; i++)
        {
            if (this.List[i] == (dynamic)value)
            {
                return i;
            }
        }
        return -1;
    }

}