using System;
    class PeaceOfCake
    {
        static void Main()
        {
            decimal numberA = decimal.Parse(Console.ReadLine());
            decimal numberB = decimal.Parse(Console.ReadLine());
            decimal numberC = decimal.Parse(Console.ReadLine());
            decimal numberD = decimal.Parse(Console.ReadLine());

            decimal total = (numberA / numberB) + (numberC / numberD);

            if (total >= 1)
            {
                Console.WriteLine(Math.Floor(total));
            }
            else
            {
                Console.WriteLine("{0:F22}", total);
            }

            decimal denominator = numberB * numberD;
            numberA *= (denominator / numberB);
            numberC *= (denominator / numberD);

            Console.WriteLine("{0}/{1}", numberA + numberC, denominator);
        }
    }

