using System;


namespace OperatorsExpressionsAndStatementsHomework
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter you weight and you will see your weight on the moon.");

            Console.WriteLine(new string ('*',70));
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine(new string('*', 70));
            Console.WriteLine("Your weight on the moon will be {0}", a*17/100 );
            
            

            Console.WriteLine(new string('*', 70));
            
        }
    }
}
