using System;
using System.Collections.Generic;
using System.Linq;

namespace ANacci
{
    class ANacci
    {
        static void Main()
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());

            int numberLines = int.Parse(Console.ReadLine());


            int endOfSequence = numberLines * 2 - 1;
            int indexThirdLetter = 0;
            //char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();


            if (numberLines == 1)
            {
                Console.WriteLine(firstLetter);
                return;
            }


            int indexFirstLetter = firstLetter - 'A' + 1;
            int indexSecondLetter = secondLetter - 'A' + 1;

            indexThirdLetter = (indexFirstLetter + indexSecondLetter);
            if (indexThirdLetter > 26)
            {
                indexThirdLetter %= 26;
            }


            List<char> listElements = new List<char>();
            listElements.Add(firstLetter);
            listElements.Add(secondLetter);
            listElements.Add((char)(indexThirdLetter + 64));

            for (int i = 3; i < endOfSequence; i++)
            {
                indexFirstLetter = indexSecondLetter;
                indexSecondLetter = indexThirdLetter;

                indexThirdLetter = (indexFirstLetter + indexSecondLetter);

                if (indexThirdLetter > 26)
                {
                    indexThirdLetter %= 26;
                }

                listElements.Add((char)(indexThirdLetter + 64));
            }

            Console.WriteLine(listElements.First());

            int spaces = 0;
            for (int i = 1; i < listElements.Count; i += 2)
            {
                Console.WriteLine("{0}{1}{2}", listElements[i]
                    , new string(' ', spaces), listElements[i + 1]);
                spaces++;
            }
        }
    }
}