using System;
class MultiSign
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter your three numbers:");
            Console.Write("A : \t");
            double a = double.Parse(Console.ReadLine());
            Console.Write("B : \t");
            double b = double.Parse(Console.ReadLine());
            Console.Write("C : \t");
            double c = double.Parse(Console.ReadLine());
            int zeroCounter = 0;
            char answer = 'X';
            if (a < 0)
            {
                zeroCounter++;
            }
            if (b < 0)
            {
                zeroCounter++;
            }
            if (c < 0)
            {
                zeroCounter++;
            }

            if (zeroCounter % 2 == 0)
            {
                answer = '+';
            }
            else if (zeroCounter % 2 > 0)
            {
                answer = '-';
            }
            if (a == 0 || b == 0 || c == 0)
            {
                answer = '0';
            }
            Console.Write("The sign of your multiplication is:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0}\n",answer);
        }
    }
}