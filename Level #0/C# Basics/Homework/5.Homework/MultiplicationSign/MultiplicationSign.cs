using System;
    class MultiplicationSign
    {
        static void Main()
        {
            Console.WriteLine("Please enteer a:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enteer b:");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enteer c:");
            double c = double.Parse(Console.ReadLine());
            Console.Write(a+" "+b+ " " +c);
            if (a == 0 || b == 0 || c == 0)
            {
                Console.Write(" 0");
            }
            else if (a > 0)
            {
                if (b > 0)
                {
                    if (c > 0)
                    {
                        Console.Write(" +");
                    }
                    else
                    {
                        Console.Write(" -");
                    }
                }
                else
                {
                    if (c > 0)
                    {
                        Console.Write(" -");
                    }
                    else
                    {
                        Console.Write(" +");
                    }
                }

            }
            else
            {
                if (b > 0)
                {
                    if (c > 0)
                    {
                        Console.Write(" -");
                    }
                    else
                    {
                        Console.Write(" +");
                    }
                }
                else
                {
                    if (c > 0)
                    {
                       Console.Write(" +"); 
                    }
                    else
                    {
                        Console.Write(" -");
                    }
                }
            }
        }
    }

