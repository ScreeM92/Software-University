    using System;
    class Program
        {
        static void Main()
        {
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());
            int c = 0;
            while (b != 0)
            {
                c = b;
                b = a % b;
                a = c;
            }
            Console.WriteLine(a);
          
    } 
            
 } 

       
        

