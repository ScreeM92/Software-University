using System;


namespace BitFromIntegerExtraction
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int bit = (n >> p) & 1;
            Console.WriteLine("{0}", bit);
        }
    }
}
