using System;

namespace SortThreeNumbersWithNestedIfs
{
    class SortThreeNumbersWithNestedIfs
    {
        static void Main(string[] args)
        {
            Console.Write("Please, enter the First real number, A = ");
            string numberStr = Console.ReadLine();
            decimal numA = decimal.Parse(numberStr);
            Console.Write("Enter the Second real number, B = ");
            numberStr = Console.ReadLine();
            decimal numB = decimal.Parse(numberStr);
            Console.Write("Enter the Third real number, C = ");
            numberStr = Console.ReadLine();
            decimal numC = decimal.Parse(numberStr);

            decimal theBiggest = 0;
            decimal theMiddle = 0;
            decimal theSmallest = 0;
            if (numA >= numC && numB >= numC)
            {
                theSmallest = numC;
                if (numA >= numB)
                {
                    theBiggest = numA;
                    theMiddle = numB;
                }
                else
                {
                    theBiggest = numB;
                    theMiddle = numA;
                }
            }
            else if (numA >= numB && numB <= numC)
            {
                theSmallest = numB;
                if (numA >= numC)
                {
                    theBiggest = numA;
                    theMiddle = numC;
                }
                else
                {
                    theBiggest = numC;
                    theMiddle = numA;
                }
            }
            else
            {
                theSmallest = numA;
                if (numB >= numC)
                {
                    theBiggest = numB;
                    theMiddle = numC;
                }
                else
                {
                    theBiggest = numC;
                    theMiddle = numB;
                }
            }
            Console.WriteLine("These 3 numbers, sorted in Descending order are: {0}, {1}, {2} !",
                theBiggest, theMiddle, theSmallest);
            Console.ReadLine();
        }
    }
}
