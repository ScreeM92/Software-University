using System;

class ExchangeVars
{
    static void Main()
    {
        int a = 5;
        int b = 10;
        Console.WriteLine("Variable values before exchange: \n{0}\n{1}", a, b);
        a = a + b; // 15 = 5 + 10
        b = a - b; // 5 = 15 - 10
        a = a - b; // 5 = 15 - 5
        Console.WriteLine("Variable values after exchange: \n{0}\n{1}", a,b);
    }
}