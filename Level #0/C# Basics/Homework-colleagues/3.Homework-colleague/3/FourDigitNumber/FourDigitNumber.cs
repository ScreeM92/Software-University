using System;
    
    class FourDigitNumber
    {
        static void Main()
        {
            Console.Write("Your 4-digit number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            int d = number%10;
            int c = (number/10)%10;
            int b = (number/100)%10;
            int a = (number/1000)%10;

            Console.WriteLine("Sum of Digits: {0}", a + b + c + d);
            Console.WriteLine("Reversed: {0}{1}{2}{3}", d,c,b,a);
            Console.WriteLine("Last Digit in front: {0}{1}{2}{3}", d,a,b,c);
            Console.WriteLine("Second and Third digits reversed: {0}{1}{2}{3}", a,c,b,d);

        }
    }