using System;

class ASCITable
{
    static void Main()
    {

        Console.OutputEncoding = System.Text.Encoding.ASCII;
        Console.Title = "Print the ASCII Table";
        for (int i = 32; i < 127; i++)
        {
            Console.Write((char)i + " ");
        }
        Console.WriteLine();
    }
}