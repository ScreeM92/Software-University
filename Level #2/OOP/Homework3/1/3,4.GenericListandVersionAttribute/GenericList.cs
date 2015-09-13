using System;
using System.Text;

[Version(3, 4)]

public class GenericList<T> where T : IComparable<T>
{
    private const int defaultCapacity = 16;
    private T[] elements;
    private int count = 0;

    public GenericList(int capacity = defaultCapacity)
    {
        elements = new T[capacity];
    }

    public int Count
    {
        get { return this.count; }
    }

    public int Capacity
    {
        get { return this.elements.Length; }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException(String.Format(
                    "Invalid index: {0}.", index));
            }
            return elements[index];
        }
    }

    public void Expand()
    {
        T[] newArray = new T[this.Capacity * 2];
        Array.Copy(this.elements, newArray, this.Capacity);
        this.elements = newArray;
    }

    public void Add(T value)
    {
        if(this.count >= this.Capacity)
        {
            this.Expand();
        }
        this.elements[count] = value;
        this.count++;
    }

    public void Remove(int index)
    {
        if (index < 0 || index >= elements.Length)
        {
            throw new IndexOutOfRangeException(String.Format(
                "Invalid index: {0}.", index));
        }
        for (int i = index; i < this.count - 1; i++)
        {
            this.elements[i] = this.elements[i + 1];
        }
        this.count--;
        this.elements[count] = default(T);
    }

    public void Insert(T element, int index)
    {
        if (index < 0 || index >= elements.Length)
        {
            throw new IndexOutOfRangeException(String.Format(
                "Invalid index: {0}.", index));
        }
        if(this.count >= this.Capacity)
        {
            this.Expand();
        }

        for (int i = this.count; i > index; i--)
        {
            this.elements[i] = this.elements[i - 1];
        }
        this.count++;
        this.elements[index] = element;
    }

    public void Clear()
    {
        this.count = 0;
        this.elements = new T[this.Capacity];       
    }

    public int IndexOf(T element)
    {
        for (int i = 0; i < this.count; i++)
        {
            if(this.elements[i].Equals(element))
            {
                return i;
            }
        }
        return -1;
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < this.count; i++)
        {
            if(this.elements[i].Equals(element))
            {
                return true;
            }
        }
        return false;
    }

    public T Min()
    {
        if (this.count < 0)
        {
            throw new ArgumentNullException("The list is null");
        }
        T min = this.elements[0];
        for (int i = 1; i < this.count; i++)
        {
            if (this.elements[i].CompareTo(min) < 0)
            {
                min = this.elements[i];
            }
        }
        return min;
    }

    public T Max()
    {
        if (this.count < 0)
        {
            throw new ArgumentNullException("The list is null");
        }
        T max = this.elements[0];
        for (int i = 1; i < this.count; i++)
        {
            if (this.elements[i].CompareTo(max) > 0)
            {
                max = this.elements[i];
            }
        }
        return max;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < this.count; i++)
        {
            result.Append(this.elements[i] + ", ");
        }
        return result.ToString().TrimEnd(' ', ',');
    }
}