using System;
    class ZeroSubset
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());
            bool right = false;
            if (a + b == 0)
            {
                Console.WriteLine(a+ "+" + b +" = 0");
                right = true;
            }
            if (a + b + c == 0)
            {
                Console.WriteLine(a+ "+" + b + "+" + c +" = 0");
                right = true;
            }
            if (a + b + c + d == 0)
            {
                Console.WriteLine(a + "+" + b + "+" + c + "+" + d +" = 0");
                right = true;
            }
            if (a + b + c + d + e == 0)
            {
                Console.WriteLine(a + "+" + b + "+" + c + "+" + d + "+" + e + " = 0");
                right = true;
            }
            if (a + c == 0)
            {
                Console.WriteLine(a+ "+" + c +" = 0");
                right = true;
            }
            if (a + c + d == 0)
            {
                Console.WriteLine(a + "+" + c + "+" + d +" = 0");
                right = true;
            }
            if (a + c + d + e == 0)
            {
                Console.WriteLine(a + "+" + c + "+" + d + "+" + e + " = 0");
                right = true;
            }
            if (a + d == 0)
            {
                Console.WriteLine(a + "+" + d + " = 0");
                right = true;
            }
            if (a + d + e == 0)
            {
                Console.WriteLine(a + "+" + d + "+" + e + " = 0");
                right = true;
            }
            if (a + e == 0)
            {
                Console.WriteLine(a + "+" + e + " = 0");
                right = true;
            }
            if (b + c == 0)
            {
                Console.WriteLine(b + "+" + c + " = 0");
                right = true;
            }
            if (b + c + d == 0)
            {
                Console.WriteLine(b + "+" + c + "+" + d + " = 0");
                right = true;
            }
            if (b + c + d + e == 0)
            {
                Console.WriteLine(b + "+" + c + "+" + d + "+" + e + " = 0");
                right = true;
            }
            if (b + d == 0)
            {
                Console.WriteLine(b + "+" + d + " = 0");
                right = true;
            }
            if (b + d + e == 0)
            {
                Console.WriteLine(b + "+" + d + "+" + e + " = 0");
                right = true;
            }
            if (b + e == 0)
            {
                Console.WriteLine(b + "+" + e + " = 0");
                right = true;
            }
            if (c + d == 0)
            {
                Console.WriteLine(c + "+" + d + " = 0");
                right = true;
            }
            if (c + d + e == 0)
            {
                Console.WriteLine(c + "+" + d + "+" + e + " = 0");
                right = true;
            }
            if (c + e == 0)
            {
                Console.WriteLine(c + "+" + e + " = 0");
                right = true;
            }
            if (d + e == 0)
            {
                Console.WriteLine(d + "+" + e + " = 0");
                right = true;
            }
            if (right == false)
            {
               Console.WriteLine("no zero subset"); 
            }
        }
    }

