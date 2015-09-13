using System;

class Sum_of_n_Numbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        decimal sum = 0m;
        for (int i = 1; i <= n; i++)
        {
            decimal a = decimal.Parse(Console.ReadLine());
            sum = sum + a;
        }
        Console.WriteLine(sum);
    }
}