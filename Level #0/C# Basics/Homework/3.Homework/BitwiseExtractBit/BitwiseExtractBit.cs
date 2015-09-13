using System;

class BitwiseExtractBit
{
    static void Main()
    {
        Console.WriteLine("Enter an unsigned integer:");
        uint number = uint.Parse(Console.ReadLine());
        Console.WriteLine("Binary representation:");
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(16, '0'));
        uint moveNumber = number >> 3;
        uint bit = moveNumber & 1;
        Console.WriteLine("The value of the bit #3:");
        Console.WriteLine(bit);
    }
}