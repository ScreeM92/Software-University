using System;
    class DigitAsWord
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Please enter a digit (0-9)");
                string number = Console.ReadLine();
                bool breakWhile = true;
                switch (number)
                {
                    case "0":
                        Console.WriteLine("Zero");
                        break;
                    case "1":
                        Console.WriteLine("One");
                        break;
                    case "2":
                        Console.WriteLine("Two");
                        break;
                    case "3":
                        Console.WriteLine("Three");
                        break;
                    case "4":
                        Console.WriteLine("Four");
                        break;
                    case "5":
                        Console.WriteLine("Five");
                        break;
                    case "6":
                        Console.WriteLine("Six");
                        break;
                    case "7":
                        Console.WriteLine("Seven");
                        break;
                    case "8":
                        Console.WriteLine("Eight");
                        break;
                    case "9":
                        Console.WriteLine("Nine");
                        break;
                    default:
                        Console.WriteLine("Not a digit");
                        breakWhile = false;
                        continue;
                        break;
                }
                break;
            }
           
        }
    }

