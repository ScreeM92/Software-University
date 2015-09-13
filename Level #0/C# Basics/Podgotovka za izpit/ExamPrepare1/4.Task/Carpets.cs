using System;
using System.Text;
    class Carpets
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());


            PrintUpperHalf(lines);
            PrintLowerHalf(lines);
        }

       
        private static void PrintUpperHalf(int lines)
        {
            string center = "/\\";
            string leftGroup = "/ ";
            string rightGroup = " \\";
            for (int i = 0; i < lines / 2; i++)
            {
                if (i % 2 == 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(new string('.', lines / 2 - i - 1));
                    sb.Insert(0, leftGroup, i - 1);
                }
            }
        }

        private static void PrintLowerHalf(int lines)
        {
            throw new NotImplementedException();
        }

    }

