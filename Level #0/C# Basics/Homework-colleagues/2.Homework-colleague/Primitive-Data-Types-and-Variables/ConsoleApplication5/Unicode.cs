using System;
class UnicodeValue
{
    static void Main()
    {
        int code = 72;
        Console.WriteLine("The hexadecimal representation of code 72 is: {0:X}", code);
        char symbol = '\u0048';
        Console.WriteLine("The symbol is: {0}", symbol);
    }
}