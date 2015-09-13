using System;
    class ForestRoad
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            //for (int row = 1; row <= N; row++)
            //{
            //    for (int col = 1; col <= N; col++)
            //    {
            //        if (row == col)
            //        {
            //            Console.Write("*");
            //        }
            //        else
            //        {
            //            Console.Write(".");
            //        }
            //    }
            //    Console.WriteLine();
            //}

            //for (int row = N - 1; row >= 1 ; row--)
            //{
            //    for (int col = 1; col <= N ; col++)
            //    {
            //        if (row == col)
            //        {
            //            Console.Write("*");
            //        }
            //        else
            //        {
            //            Console.Write(".");
            //        }
            //    }
            //    Console.WriteLine();
            //}

            //2ri nachin
            //for (int row = 0; row < N / 2 + 1; row++)
            //{
            //    string dots = new string('.', row);
            //    string stars = new string('*', N - row * 2);
            //    Console.WriteLine("{0}{1}{0}", dots, stars);
            //}

            //for (int row = 2; row <= N / 2 + 1; row++)
            //{
            //    string dots = new string('.', N / 2 + 1 - row);
            //    string stars = new string('*', row * 2 - 1);
            //    Console.WriteLine("{0}{1}{0}", dots, stars);
            //}


            for (int i = 0; i < N; i++)
            {
                string stars = new string('*', 1);
            }

        }
    }

