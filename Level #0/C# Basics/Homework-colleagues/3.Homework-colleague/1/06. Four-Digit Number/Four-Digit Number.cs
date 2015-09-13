using System;

class FourDigitNumber
    {
        static void Main()
        {
            Console.WriteLine("Enter a four digit number(it can not start with 0)");
            string inputNum = Console.ReadLine();
            char numOne = inputNum[0]; 
            char numTwo = inputNum[1];
            char numThree = inputNum[2];
            char numFour = inputNum[3];
            int one = (int)Char.GetNumericValue(numOne);
            int two = (int)Char.GetNumericValue(numTwo);
            int three = (int)Char.GetNumericValue(numThree);
            int four = (int)Char.GetNumericValue(numFour);
            int sumFour = one + two + three + four;
            Console.WriteLine("The sum of digits is: " + sumFour);
            Console.Write("The digits in reversed order: " + numFour);
            Console.Write(numThree);
            Console.Write(numTwo);
            Console.WriteLine(numOne);
            Console.Write("Last digit in the first position" + numFour);
            Console.Write(numOne);
            Console.Write(numTwo);
            Console.WriteLine(numThree);
            Console.Write("The second and the third digits exchanged" + numOne);
            Console.Write(numThree);
            Console.Write(numTwo);
            Console.WriteLine(numFour);
        }
    }

