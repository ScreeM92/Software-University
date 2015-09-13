using System;
class ThirdDigitIs7
{
    static void Main()
    {
        Console.WriteLine("Write number:");
        while (true)
        {
            int numb = int.Parse(Console.ReadLine());
            numb = numb / 100;
            if (numb % 10 == 7)
            {
                Console.WriteLine("True");
                break;
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}

