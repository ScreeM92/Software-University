using System;
class BitExchange 
    {
        static void Main()
        {
            Console.Write("n = ");
            long n = long.Parse(Console.ReadLine());
            Console.Write("p = ");
            int p = int.Parse(Console.ReadLine());
            Console.Write("q = ");
            int q = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));

            if (p + k >= 32)
            {
                Console.WriteLine("Out of range");
            }
            else if (p < q && ((p + q) < k))
            {
                Console.WriteLine("Overlapping");
            }
            else
            {
                for (int i = 0; i < k; i++)
                {
                    int maskOne = (int)(n & (1 << p)) >> p;
                    int maskTwo = (int)(n & (1 << q)) >> q;

                    //mask one
                    if (maskOne == 0)
                    {
                        n = n & (~(1 << q));
                    }
                    else if (maskOne == 1)
                    {
                        n = n | (1 << q);
                    }

                    //mask two
                    if (maskTwo == 0)
                    {
                        n = n & (~(1 << p));
                    }
                    else if (maskTwo == 1)
                    {
                        n = n | (1 << p);
                    }

                    p++;
                    q++;
                }

                Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));
                Console.WriteLine(n);
            }
        }
    }

