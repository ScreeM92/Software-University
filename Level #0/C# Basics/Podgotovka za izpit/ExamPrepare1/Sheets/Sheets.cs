using System;
    class Sheets
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string nStr = Convert.ToString(n, 2).PadLeft(11, '0');
            for (int i = 0; i < nStr.Length ; i++)
            {
                if (nStr[i] == '0')
                {
                    Console.WriteLine("A{0}", i);
                }
            }
            //2-ri variant
            //string[] formats = new string[11];
            //for (int i = 0; i < formats.Length; i++)
            //{
            //    formats[i] = "A" + i;
            //}

            //int n = int.Parse(Console.ReadLine());

            //for (int i = 0; i < formats.Length; i++)
            //{
            //    int mask = 1;
            //    if ((n & mask) == 0)
            //    {
            //        Console.WriteLine(formats[formats.Length - i - 1]);
            //    }
            //    n >>= 1;
            //}
        }
    }

