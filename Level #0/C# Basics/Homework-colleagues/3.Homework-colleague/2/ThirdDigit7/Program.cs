using System;


namespace ThirdDigit7
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the number");
            int i = int.Parse(Console.ReadLine());
            if (i % 1000 > 699 && i % 1000 < 800)
            {
                Console.WriteLine("The third digit is 7");
            }
            else
            {
                Console.WriteLine("The third digit is not 7");
            }
        }
    }
}
