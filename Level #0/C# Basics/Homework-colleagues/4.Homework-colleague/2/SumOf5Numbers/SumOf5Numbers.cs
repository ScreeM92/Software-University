using System;

class SumOf5Numbers
{
    static void Main()
    {
        char ch;
        int i = 0;
        string a = " ";
        decimal sum = 0m;
        do
        {
            i = Console.Read();
            ch = (char)i;
            if (i == 32 || i == 13)
            {
                sum = sum + decimal.Parse(a);
                a = " ";
            }
            else
            {
                a = a + ch;
            }
        }
        while (i != 13);
        Console.WriteLine(sum);
    }
}