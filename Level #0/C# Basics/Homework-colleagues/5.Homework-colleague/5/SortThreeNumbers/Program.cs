using System;
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Enter your first number: \t");
            double first = double.Parse(Console.ReadLine());
            Console.Write("Enter your second number: \t");
            double second = double.Parse(Console.ReadLine());
            Console.Write("Enter your third number: \t");
            double third = double.Parse(Console.ReadLine());

            Console.Write("Sorted numbers:\n");
            while (true)
            {
                if (first > second && first > third)
                {
                    Console.WriteLine(first);
                    if (second > third)
                    {
                        Console.WriteLine(second);
                        Console.WriteLine(third);
                        break;
                    }
                    else
                    {
                        Console.WriteLine(third);
                        Console.WriteLine(second);
                        break;
                    }
                }
                else if (second > first && second > third)
                {
                    Console.WriteLine(second);
                    if (first > third)
                    {
                        Console.WriteLine(first);
                        Console.WriteLine(third);
                        break;
                    }
                    else
                    {
                        Console.WriteLine(third);
                        Console.WriteLine(first);
                        break;
                    }
                }
                else if (third > first && third > second)
                {
                    Console.WriteLine(third);
                    if (first > second)
                    {
                        Console.WriteLine(first);
                        Console.WriteLine(second);
                        break;
                    }
                    else
                    {
                        Console.WriteLine(second);
                        Console.WriteLine(first);
                        break;
                    }
                }

                else if (first == second || first == third || second == third)
                {
                    if (first == second && first == third)
                    {
                        Console.WriteLine(first);
                        Console.WriteLine(second);
                        Console.WriteLine(third);
                        break;
                    }
                    if (first == second)
                    {
                        if (second > third)
                        {
                            Console.WriteLine(first);
                            Console.WriteLine(second);
                            Console.WriteLine(third);
                            break;
                        }
                        else if (third > second)
                        {

                            Console.WriteLine(third);
                            Console.WriteLine(first);
                            Console.WriteLine(second);
                            break;
                        }
                    }
                    else if (second == third)
                    {
                        if (first > third)
                        {
                            Console.WriteLine(first);
                            Console.WriteLine(third);
                            Console.WriteLine(second);
                            break;
                        }
                        else if (third > first)
                        {
                            Console.WriteLine(third);
                            Console.WriteLine(second);
                            Console.WriteLine(first);
                            break;
                        }
                    }
                    else if (first == third)
                    {
                        if (second > first)
                        {
                            Console.WriteLine(second);
                            Console.WriteLine(first);
                            Console.WriteLine(third);
                            break;
                        }
                        else if (first > second)
                        {
                            Console.WriteLine(first);
                            Console.WriteLine(third);
                            Console.WriteLine(second);
                            break;
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}