using System;
using System.Globalization;
    class DecimalToHexadecimalNumber
    {
        static void Main()
        { 
            //1 variant
            //Console.Write("Enter your decimal number: ");
            //long dec = long.Parse(Console.ReadLine());

            //string hexaStr = dec.ToString("X");

            //long hexa = long.Parse(hexaStr, NumberStyles.HexNumber);

            //Console.WriteLine(hexaStr);

            //2 variant
            long decNumber = long.Parse(Console.ReadLine());
            string hexNumber = "";
            if (decNumber == 0)
            {
                hexNumber = "0";
            }
            else
            {
                while (decNumber > 0)
                {
                    long remain = decNumber % 16;
                    decNumber /= 16;
                    switch (remain)
                    {
                        case 10: hexNumber = "A" + hexNumber; break;
                        case 11: hexNumber = "B" + hexNumber; break;
                        case 12: hexNumber = "C" + hexNumber; break;
                        case 13: hexNumber = "D" + hexNumber; break;
                        case 14: hexNumber = "E" + hexNumber; break;
                        case 15: hexNumber = "F" + hexNumber; break;
                        default: hexNumber = remain + hexNumber; break;
                    }
                }
            }
            Console.WriteLine(hexNumber);
        }
    }

