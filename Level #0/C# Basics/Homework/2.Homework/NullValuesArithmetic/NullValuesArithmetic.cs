using System;
    class NullValuesArithmetic
    {
        static void Main()
        {
            int? first = null;
            double? second = null;
            Console.WriteLine("Null value: " + first);
            Console.WriteLine("Null value: " + second);

            first = null;
            second = null;
            Console.WriteLine("Number + null value: " + first);
            Console.WriteLine("Number + null value: " + second);

            first = 7;
            second = 4.5;
            Console.WriteLine("Number value: " + first);
            Console.WriteLine("Number value: " + second);
        }
    }

