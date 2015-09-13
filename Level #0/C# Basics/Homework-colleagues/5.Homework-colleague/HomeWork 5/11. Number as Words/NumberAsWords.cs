using System;

namespace NumberAsWords
{
    class NumberAsWords
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program will show any inputed number in the range 0-999 as words.");
            Console.WriteLine("Please input a number:");
            string userinput = Console.ReadLine();
            int number;

            if (int.TryParse(userinput, out number) && number > 0 && number < 1000)
            {
                int[] numberArray = new int[3];
                for (int i = 0; i < userinput.Length; i++) //The purpose of the loop is to assign values to the corresponding int array. I know there be easier ways to do it but this is the first thing I came up with.
                {
                    numberArray[i] = userinput[i] - '0';
                }

                string[] ones = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                string[] tens = { "ten", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };
                string[] hundreds = { "One hundred", "Two hundred", "Three hundred", "Four hundred", "Five hundred", "Six hundred", "Seven hundred", "Eight hundred", "Nine hundred" };
                string[] teens = { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };


                if (number > 100 && numberArray[0] > 0)
                {
                    if (numberArray[1] == 0 && numberArray[2] > 0)
                    {
                        Console.WriteLine(hundreds[numberArray[0] - 1] + " and " + ones[numberArray[2] - 1]);
                    }
                    else if (numberArray[1] > 0 && numberArray[2] == 0)
                    {
                        Console.WriteLine(hundreds[numberArray[0] - 1] + " and " + tens[numberArray[1] - 1]);
                    }
                    else if (numberArray[1] > 0 && numberArray[2] > 1)
                    {
                        Console.WriteLine(hundreds[numberArray[0] - 1] + " and " + tens[numberArray[1] - 1] + " " + ones[numberArray[2] - 1]);
                    }
                    else if (numberArray[1] == 1 && numberArray[2] == 1)
                    {
                        Console.WriteLine(hundreds[numberArray[0] - 1] + " and " + teens[numberArray[2] - 1]);
                    }
                    else
                    {
                        Console.WriteLine(hundreds[numberArray[0] - 1]);
                    }
                }

                if (number < 100)
                {
                    if (number < 10 && number > 0)
                    {
                        Console.WriteLine(UppercaseFirst(ones[numberArray[0] - 1]));
                    }
                    else if (number == 0)
                    {
                        Console.WriteLine("Zero");
                    }
                    else if (number > 10 && number < 20)
                    {
                        Console.WriteLine(UppercaseFirst(teens[numberArray[1] - 1]));
                    }
                    else if (number == 10 || number == 20 || number == 30 || number == 40 || number == 50 || number == 60 || number == 70 || number == 80 || number == 90)
                    {
                        Console.WriteLine(UppercaseFirst(tens[numberArray[0] - 1]));
                    }
                    else
                    {
                        Console.WriteLine(UppercaseFirst(tens[numberArray[0] - 1]) + " " + ones[numberArray[1] - 1]);
                    }
                }

            }
            else
            {
                Console.WriteLine("invalid input.");
            }


        }

        //This creates a method to convert the first letter of a word to a capital letter
        static string UppercaseFirst(string words)
        {
            if (string.IsNullOrEmpty(words))
            {
                return string.Empty;
            }
            char[] a = words.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
}
