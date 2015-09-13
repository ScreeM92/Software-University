using System;
    class ExcelColumns
    {
        static void Main()
        {
            char[] alphabet = "1ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int number = int.Parse(Console.ReadLine());

            string alphas = string.Empty;
            for (int i = 0; i < number; i++)
            {
                alphas += Console.ReadLine();
            }

            int pow = number - 1;

            double result = 0;
            for (int j = 0; j < alphas.Length; j++)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (alphas[j] == alphabet[i])
                    {
                        result += i * Math.Pow(26, pow);
                        break;
                    }
                }
                pow--;
            }
            Console.WriteLine(result);
        }
    }

