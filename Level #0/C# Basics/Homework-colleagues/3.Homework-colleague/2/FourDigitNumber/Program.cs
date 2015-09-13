using System;


namespace FourDigitNumber
{
    class Program
    {
        static void Main()

        {
            Console.WriteLine("Enter digit a from 1 to 9");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter digit b from 1 to 9");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter digit c from 1 to 9");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter digit d from 1 to 9");
            int d = int.Parse(Console.ReadLine());
            int sum = a + b + c + d;
            Console.WriteLine(new string('*',25));
            Console.WriteLine(sum);
            Console.WriteLine(new string('*',25));
            Console.WriteLine("{0}{1}{2}{3}",a, b, c ,d);
            Console.WriteLine(new string('*', 25));
            Console.WriteLine("{0}{1}{2}{3}", d, b, c, a);
            Console.WriteLine(new string('*', 25));
            Console.WriteLine("{0}{1}{2}{3}", a, c, b, d);
            Console.WriteLine(new string('*', 25));




        }
    }
}
