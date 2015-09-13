using System;

    class ThirdDigit7
    {
        static void Main()
        {
            Console.Write("Number: ");
            string theNumber = Convert.ToString(Console.ReadLine());
            int lenght = theNumber.Length - 3;
            Console.WriteLine(theNumber[lenght]=='7');

            //OR:
            //Console.Write("Number: ");
            //int theNumber = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine((theNumber/100)%7==0);
        }
    }