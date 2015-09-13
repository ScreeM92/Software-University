using System;


namespace DivideBy7And5
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            if (num == 0)
            {
                Console.WriteLine(false); 
            }
            else
            {
                Console.WriteLine(num % 7 == 0 && num % 5 == 0);
            }
            
        }
    }
}
