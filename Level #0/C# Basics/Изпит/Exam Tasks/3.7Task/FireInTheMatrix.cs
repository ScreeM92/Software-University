using System;

public class FireInTheMatrix
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int leftElement = n / 2 - 1;
        int rightElement = n / 2;

        for (int row = 0; row < n / 2; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (col == leftElement)
                {
                    Console.Write("#");
                }
                else if (col == rightElement)
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(".");
                }
            }
            leftElement--;
            rightElement++;
            Console.WriteLine();
        }
        leftElement++;
        rightElement--;

        for (int row = 0; row < n / 4; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (col == leftElement)
                {
                    Console.Write("#");
                }
                else if (col == rightElement)
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(".");
                }
            }
            leftElement++;
            rightElement--;
            Console.WriteLine();
        }

        Console.WriteLine(new string('-', n));

        for (int row = 0; row < n / 2; row++)
        {
            Console.Write(new string('.', row));
            Console.Write(new string('\\', n / 2 - row));
            Console.Write(new string('/', n / 2 - row));
            Console.WriteLine(new string('.', row));
        }









        //// top
        //for (int i = 0; i < n / 2; i++)
        //{
        //    for (int j = 0; j < n; j++)
        //    {
        //        if (j == leftElement)
        //        {
        //            Console.Write("#");
        //        }

        //        else if (j == rightElement)
        //        {
        //            Console.Write("#");
        //        }

        //        else
        //        {
        //            Console.Write(".");
        //        }
        //    }

        //    leftElement--;
        //    rightElement++;
        //    Console.WriteLine();
        //}

        //leftElement++;
        //rightElement--;

        //for (int i = 0; i < n / 4; i++)
        //{
        //    for (int j = 0; j < n; j++)
        //    {
        //        if (j == leftElement)
        //        {
        //            Console.Write("#");
        //        }

        //        else if (j == rightElement)
        //        {
        //            Console.Write("#");
        //        }

        //        else
        //        {
        //            Console.Write(".");
        //        }
        //    }

        //    leftElement++;
        //    rightElement--;
        //    Console.WriteLine();
        //}

        //for (int i = 0; i < n; i++)
        //{
        //    Console.Write("-");
        //}
        //Console.WriteLine();

        //// bottom
        //for (int i = 0; i < n / 2; i++)
        //{
        //    Console.Write(new string('.', (i)));
        //    Console.Write(new string('\\', (n / 2 - i)));
        //    Console.Write(new string('/', (n / 2 - i)));
        //    Console.Write(new string('.', (i)));

        //    Console.WriteLine();
        //}
    }

}