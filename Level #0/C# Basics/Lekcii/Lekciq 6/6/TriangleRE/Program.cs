using System;
    class Program
    {
        static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int nFactorial = 1;
        int kFactorial = 1;
        decimal result = 1;
        for (int i = 1; i <= n; i++)
        {
            if (1 < k && k < n && n < 100)
            {
            nFactorial *= n;
            kFactorial *= k;
            result = (nFactorial / kFactorial);
            }
        }
        Console.WriteLine(result);
     }
}
