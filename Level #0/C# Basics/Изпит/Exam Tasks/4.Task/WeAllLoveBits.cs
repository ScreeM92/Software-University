using System;
class WeAllLoveBits
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(Console.ReadLine());
                int newP = 0;

                while (num != 0)
                {
                    newP <<= 1;
                    newP |= num & 1;
                    num >>= 1;
                }
                Console.WriteLine(newP);
            }
        }
    }

