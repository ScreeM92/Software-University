using System;
class FourDigitNumber
    {
        static void Main()
        {
            int numb = int.Parse(Console.ReadLine());
            int a = numb / 1000;
            int b = (numb / 100) % 10;
            int c = (numb / 10) % 10;
            int d = numb % 10;
            Console.WriteLine("Sum of digits is:{0}", (a + b + c + d));
            Console.WriteLine("Reversed is:"+d + c + b + a);
            Console.WriteLine("Last digit in front:"+d + a + b + c);
            Console.WriteLine("Second and third digits exchanged:"+a + c + d + b);
        }
    }

