using System;
using System.Text;

class TestClass
{
    static void Main()
    {
        StringBuilder a = new StringBuilder();
        a.Append("Musaka s tarator");
        Console.WriteLine(a.Substring(4));

        Console.WriteLine(a.Substring(0, 3));

    }
}
