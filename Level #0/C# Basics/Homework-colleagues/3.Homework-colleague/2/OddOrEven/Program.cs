using System;


namespace OddOrEven
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(!(int.Parse(Console.ReadLine()) % 2 == 0));
           
        }
    }
}
