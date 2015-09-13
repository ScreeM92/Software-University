using System;
class NumberAsWords
{
    static void Main()
    {
        Console.Write("Enter number: ");
        ushort num = ushort.Parse(Console.ReadLine());
        if (num > 0 && num <= 12)
        {
            switch (num)
            {
                case 0:Console.WriteLine("zero");break;
                case 1:Console.WriteLine("one");break;
                case 2:Console.WriteLine("two");break;
                case 3:Console.WriteLine("three");break;
                case 4:Console.WriteLine("four");break;
                case 5:Console.WriteLine("five");break;
                case 6:Console.WriteLine("six");break;
                case 7:Console.WriteLine("seven");break;
                case 8:Console.WriteLine("eith");break;
                case 9:Console.WriteLine("nine");break;
                case 10:Console.WriteLine("ten");break;
                case 11:Console.WriteLine("eleven");break;
                case 12:Console.WriteLine("twelve"); break;
                default:Console.WriteLine("not a number"); break;
        }
        }

    }
}