using System;


namespace PrimeNumberCheck
{
    class Program
    {
        static void Main()
        {

            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());

           
            bool isPrime = ((num % 2 != 0) && (num % 3 != 0) && (num % 5 != 0) && (num % 7 != 0) && (num != 1));
            bool prime = ((num == 2) || (num == 3) || (num == 5) || (num == 7));
            Console.WriteLine((isPrime || prime == true) ? "{0} is prime." : "{0} is not prime.", num);

          
                
         }
    }
}
