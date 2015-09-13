using System;
    class PlayWithIntDoubleAndString
    {
        static void Main()
        {
                Console.WriteLine("Please choose a type: 1 - Int, 2 - Double, 3 - String");
                int number = int.Parse(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        Console.WriteLine("Please enter a Int:");
                        int numberInt = int.Parse(Console.ReadLine());
                        Console.WriteLine(numberInt + 1);
                        break;
                    case 2:
                        Console.WriteLine("Please enter a Double:");
                        double numberDouble = double.Parse(Console.ReadLine());
                        Console.WriteLine(numberDouble + 1);
                        break;
                    case 3:
                        Console.WriteLine("Please enter a String:");
                        string numberString = Console.ReadLine();
                        Console.WriteLine(numberString + "*");
                        break;
                    default:
                        Console.WriteLine("Try again:");
                        break;
                }
         }
    }

