using System;
using System.Collections;
using System.Collections.Generic;

class BitArray64 : IEnumerable<int>
{   
    //Field
    private List<ulong> values = new List<ulong>();
    
    //Property
    public List<ulong> Values
    {
        get
        {
            return this.values;
        }
        set
        {
            this.values = value;
        }
    }

    //Implement Enumerator and Enumerable methods
    IEnumerator IEnumerable.GetEnumerator()
    {
        // Call the generic version of the method
        return this.GetEnumerator();
    }
    
    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < values.Count; i++)
        {   
            yield return Convert.ToInt32(this.values[i]);
        }
    }

    //Add method for adding elements in the array
    public void Add(ulong item)
    {
        if (item < 0)
        {
            throw new OverflowException("The value was too small");
        }
        this.values.Add(item);
    }

    //Override Equals()
    public override bool Equals(object obj)
    {
        BitArray64 newObject = obj as BitArray64;
        if ((object)obj == null)
        {
            return false;
        }

        if (!BitArray64.Equals(this.values.Count, newObject.values.Count))
        {
            return false;
        }

        for (int i = 0; i < this.values.Count; i++)
        {
            if (!BitArray64.Equals(this.values[i], newObject[i]))
            {
                return false;
            }
        }
        return true;
    }
    //Override GetHashCode()
    public override int GetHashCode()
    {
        return this.values.GetHashCode() ^ this.values[0].GetHashCode();
    }

    //Make indexer for easier access to the elements
    public ulong this[int index]
    {
        get 
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("The index must be positive!");
            }
            if (index > values.Count)
            {
                throw new ArgumentOutOfRangeException("The index must be smaller or equal to the size of the array");
            }
            return this.values[index];
        }
        set
        {
            if (value < 0)
            {
                throw new OverflowException("The value was too small!");
            }
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("The index must be positive!");
            }
            if (index > values.Count)
            {
                throw new ArgumentOutOfRangeException("The index must be smaller or equal to the size of the array");
            }
            this.values[index] = value;
        }
    }

    //Overload the operators == nad !=
    public static bool operator ==(BitArray64 firstObj, BitArray64 secondObj)
    {
        return firstObj.Equals(secondObj);
    }
    public static bool operator !=(BitArray64 firstObj, BitArray64 secondObj)
    {
        return !firstObj.Equals(secondObj);
    }
}
