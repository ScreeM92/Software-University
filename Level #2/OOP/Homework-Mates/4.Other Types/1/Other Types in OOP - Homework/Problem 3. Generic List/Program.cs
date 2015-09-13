using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // UNCOMMENT TO TEST...

        // GenericList<string> MyArrayOfStrings = new GenericList<string>();
        // Console.WriteLine("Array size: " + MyArrayOfStrings.ArraySize);
        // MyArrayOfStrings.Add("FirstObjString");
        // MyArrayOfStrings.Add("SecondObjString");
        // Console.WriteLine("MAX STRING : " + MyArrayOfStrings.Max());
        // Console.WriteLine("Before remove:");
        // Console.WriteLine(MyArrayOfStrings[0]);
        // Console.WriteLine(MyArrayOfStrings[1] + "\n");

        // added 2 elements - second element becomes first ...
        // MyArrayOfStrings.Remove(0);
        // Console.WriteLine("After remove: ");
        // Console.WriteLine("Element with index 0: " + MyArrayOfStrings[0]);
        GenericList<int> myArrayOfIntegers = new GenericList<int>(1);
        Console.WriteLine("Array size: " + myArrayOfIntegers.ArraySize);
        myArrayOfIntegers.Add(111);
        myArrayOfIntegers.Add(222);
        myArrayOfIntegers.Add(3333);
        myArrayOfIntegers.Add(44);
        myArrayOfIntegers.Add(55555);

        // Console.WriteLine("Before Element with index 0: " + MyArrayOfIntegers[0]);
        // MyArrayOfIntegers.Insert(44, 0);
        // MyArrayOfIntegers.Remove(3);
        // MyArrayOfIntegers.Insert(333, 0);
        // MyArrayOfIntegers.Remove(1);
        // Console.WriteLine("Element with index 0: " + MyArrayOfIntegers[0]);
        // Console.WriteLine("Element with index 1: " + MyArrayOfIntegers[1]);
        // Console.WriteLine("Element with index 2: " + MyArrayOfIntegers[2]);
        for (int i = 0; i < myArrayOfIntegers.ElementsCount; i++)
        {
            Console.WriteLine("Element with index {0}: {1}", i, myArrayOfIntegers[i]);
        }

        Console.WriteLine(myArrayOfIntegers.ToString());
        Console.WriteLine("Min element : {0}", myArrayOfIntegers.Min());
        Console.WriteLine("Max element : {0}", myArrayOfIntegers.Max());
    }
}
