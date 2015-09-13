using System;
class DeclareVariables
    {
        static void Main()
    {
        ushort firstnumber = 52130;   // Declare five variables choosing for
        sbyte secondnumber = -115; //each of them the most appropriate of the types
        int thirdnumber = 4825932; //byte, sbyte, short, ushort, int, uint, long, ulong 
        byte fourthnumber = 97;  //to represent the following values: 52130, -115, 4825932, 97, -10000.
        short fifthnumber = -10000;

        {
            Console.WriteLine("First Number: {0}\nSecond Number: {1}\nThird Number: {2}\nFourth Number is: {3}\nFifth Number is: {4}", firstnumber, secondnumber, thirdnumber, fourthnumber, fifthnumber);
        }
    }
    }

