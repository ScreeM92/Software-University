using System;

class TestClass
{
    static void Main(string[] args)
    {   
        //Create two arrays
        BitArray64 firstArray = new BitArray64();
        BitArray64 secondArray = new BitArray64();

        //Fill them with numbers
        for (ulong i = 1; i < 30; i += 3)
        {
            firstArray.Add(i);
            secondArray.Add(30 - i - 1);
        }

        //Get the numbers with foreach
        foreach (var item in firstArray)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine(new string('-', 4));
        
        foreach (var item in secondArray)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();

        //Get the hash code
        Console.WriteLine("Hash code: {0}", firstArray.GetHashCode());
        //Get the element on position 4 with the indexer []
        Console.WriteLine("Element on position 4 in the first array: {0}", firstArray[4]);

        //Check for equals
        if (!firstArray.Equals(secondArray))
        {
            Console.WriteLine("Not equal");
        }
        if (firstArray != secondArray)
        {
            Console.WriteLine("Not equal");
        }
    }
}
