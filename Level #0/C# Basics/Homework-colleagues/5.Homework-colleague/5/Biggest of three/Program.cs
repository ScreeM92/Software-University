using System;
class BiggestofThree
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your numbers:\t");
        double[] first = new double[4];
        for (int i = 0; i < 3; i++)
        {
            first[i] = double.Parse(Console.ReadLine().PadLeft(25));
        }
        Array.Sort(first);
          
        Console.WriteLine("The largest number : {0}",first[first.Length-1]);
        Console.ReadKey();


    }
}
