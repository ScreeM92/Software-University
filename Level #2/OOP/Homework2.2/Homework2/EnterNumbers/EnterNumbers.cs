using System;
    class EnterNumbers
    {
        static void Main()
        {
            int count = 0;
            int start = 0;
            int end = 100;

            while(count < 10)
            {
                try
                {
                    int currentNum = ReadNumber(start, end);

                    if(currentNum > start)
                    {
                        start = currentNum;
                    }

                    count++;
                }
                catch (ArgumentException aex)
                {
                    Console.WriteLine("{0} Repeat input!", aex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} Repeat input!", ex.Message);
                }
            }
        }

        public static int ReadNumber(int start, int end)
        {
            int num = int.Parse(Console.ReadLine());

            if (num <= start || num >= end)
            {
                throw new ArgumentException("The number is outside of the requested range!");
            }
            return num;
        }
    }

