using System;


namespace BitsExchenge
{
    class Program
    {
        static void Main()
        {
            long number = uint.Parse(Console.ReadLine());
            long mask = 7;
            long thirdFourthFifthBits = ((mask << 3) & number) >> 3; 
            long otherBits = ((mask << 24) & number) >> 24;          
            number = ~(mask << 24) & number;                         
            number = ~(mask << 3) & number;                       
            number = (thirdFourthFifthBits << 24) | number;       
            number = (otherBits << 3) | number;                    
            Console.WriteLine(number);
        }
    }
}
