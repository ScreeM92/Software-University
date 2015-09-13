using System;
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int firstDigit = num / 100;
            int secondDigit = (num / 10) % 10;
            int thirdDigit = num % 10;
            if (num == 0)
            {
                Console.WriteLine("Zero");
            }
            else if (num % 100 == 0)
            {
                switch (firstDigit)
                {
                    case 1: Console.Write("One hundred"); break;
                    case 2: Console.Write("Two hundred"); break;
                    case 3: Console.Write("Three hundred"); break;
                    case 4: Console.Write("Four hundred"); break;
                    case 5: Console.Write("Five hundred"); break;
                    case 6: Console.Write("Six hundred"); break;
                    case 7: Console.Write("Seven hundred"); break;
                    case 8: Console.Write("Eight hundred"); break;
                    case 9: Console.Write("Nine hundred"); break;
                    default:
                        break;
                }
            }
            else
            {
                switch (firstDigit)
                {
                    case 1: Console.Write("One hundred and"); break;
                    case 2: Console.Write("Two hundred and"); break;
                    case 3: Console.Write("Three hundred and"); break;
                    case 4: Console.Write("Four hundred and"); break;
                    case 5: Console.Write("Five hundred and"); break;
                    case 6: Console.Write("Six hundred and"); break;
                    case 7: Console.Write("Seven hundred and"); break;
                    case 8: Console.Write("Eight hundred and"); break;
                    case 9: Console.Write("Nine hundred and"); break;
                    default:
                        break;
                }
                switch (secondDigit)
                {
                    case 1: 
                        {
                            switch (thirdDigit)
                            {
                                case 1: Console.Write(" Eleven"); break;
                                case 2: Console.Write(" Twelve"); break;
                                case 3: Console.Write(" Thirteen"); break;
                                case 4: Console.Write(" Forteen"); break;
                                case 5: Console.Write(" Fifteen"); break;
                                case 6: Console.Write(" Sixteen"); break;
                                case 7: Console.Write(" Seventeen"); break;
                                case 8: Console.Write(" Eighteen"); break;
                                case 9: Console.Write(" Nineteen"); break;
                                default: Console.WriteLine(" Ten");
                                    break;
                            }
                        } break;
                    case 2: Console.Write(" Twenty"); break;
                    case 3: Console.Write(" Thirty"); break;
                    case 4: Console.Write(" Forty"); break;
                    case 5: Console.Write(" Fifty"); break;
                    case 6: Console.Write(" Sixty"); break;
                    case 7: Console.Write(" Seventy"); break;
                    case 8: Console.Write(" Eighty"); break;
                    case 9: Console.Write(" Ninety"); break;
                    default: Console.Write("");
                        break;
                }
                switch (thirdDigit)
                {
                    case 1: Console.Write(" One"); break;
                    case 2: Console.Write(" Two"); break;
                    case 3: Console.Write(" Three"); break;
                    case 4: Console.Write(" Four"); break;
                    case 5: Console.Write(" Five"); break;
                    case 6: Console.Write(" Six"); break;
                    case 7: Console.Write(" Seven"); break;
                    case 8: Console.Write(" Eight"); break;
                    case 9: Console.Write(" Nine"); break;
                }
            }
        }
    }

