/*Write a program that reads 3 numbers: an integer a (0 ≤ a ≤ 500), a floating-point b and a floating-point c
and prints them in 4 virtual columns on the console. 
Each column should have a width of 10 characters.
The number a should be printed in hexadecimal, left aligned; 
then the number a should be printed in binary form, padded with zeroes, 
then the number b should be printed with 2 digits after the decimal point, right aligned; 
the number c should be printed with 3 digits after the decimal point, left aligned.*/

using System;
using System.Text;

class FormattingNums
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Enter an integer a (0 ≤ a ≤ 500): ");
        int a = int.Parse(Console.ReadLine());

        if (a > 500 || a < 0)
        {
            Console.WriteLine("Invalid input");
            return;
        }

        Console.Write("Enter a floating- point number: ");
        float b = float.Parse(Console.ReadLine());

        Console.Write("Enter a floating- point number: ");
        float c = float.Parse(Console.ReadLine());

        Console.Write("|{0,-10:X}|", a);
        Console.Write(Convert.ToString(a, 2).PadLeft(10, '0'));
        Console.Write("|{0,10:0.##}|", b);
        Console.WriteLine("|{0,-10:0.###}|", c);
    }
}
