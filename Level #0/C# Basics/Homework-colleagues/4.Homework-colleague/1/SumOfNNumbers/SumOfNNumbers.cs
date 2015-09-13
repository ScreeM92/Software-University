using System;

class SumOfNNumbers
{
    static void Main()
    {
        Console.Write("n=");
        int n = int.Parse(Console.ReadLine());
        double sum = 0;
        for (int i = 1; i <= n; i++)
        {
            Console.Write("number{0}=", i);
            double number = double.Parse(Console.ReadLine());
            sum += number;
        }
        Console.WriteLine("Sum={0}", sum);
    }
}
