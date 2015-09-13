using System;

    class PrimeCheck
    {
        static void Main()
        {
            Console.Write("Number: ");
            int theNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(PrimeChecker(theNumber));
        }

        public static Boolean PrimeChecker (int someNumber)
        {
            int helpNumber=(int) Math.Sqrt(someNumber);
            if (someNumber <= 0) return false;
            if (someNumber==1) return false;
            if (someNumber==2) return true;

            for (int i = 2; i <= helpNumber; i++)
                {
                    if (someNumber % i == 0) return false;
                }
            return true;
        }
        
    }
