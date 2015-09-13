using System;
class BiggestOfFive
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your numbers:\t");
        double[] first = new double[5];
        for (int i = 0; i < first.Length; i++)
        {
            first[i] = double.Parse(Console.ReadLine().PadLeft(25));
        }
        Array.Sort(first);

        Console.WriteLine("The largest number : {0}", first[first.Length - 1]);
        Console.ReadKey();

    }
}
