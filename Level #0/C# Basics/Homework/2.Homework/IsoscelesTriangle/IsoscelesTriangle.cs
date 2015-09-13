using System;
using System.Text; 

class TheCopyrightSymbol
{
    static void Main()
    {
        char copyRight = '\u00A9';
        Console.OutputEncoding = Encoding.Unicode; 
        Console.WriteLine(@"
   {0}
  {0} {0}
 {0}   {0}
{0} {0} {0} {0}"
, copyRight);
    }
}
