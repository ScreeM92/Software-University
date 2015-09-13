using System;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose wisely: \n [1 - Int] \n [2 - Double] \n [3 - String]");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.Clear();
                Console.WriteLine("Enter an integer");
                int enteredInt = int.Parse(Console.ReadLine());
                enteredInt++;
                Console.WriteLine("The result is : {0}", enteredInt);
                Console.ReadKey();
            }
            else if (choice == 2)
            {
                Console.Clear();
                Console.WriteLine("Enter a double value");
                double enteredDouble = double.Parse(Console.ReadLine());
                enteredDouble++;
                Console.WriteLine("The result is : {0}", enteredDouble);
                Console.ReadKey();
            }
            else if (choice == 3)
            {
                Console.Clear();
                Console.WriteLine("Enter a string");
                string stringToAppend = Console.ReadLine();
                StringBuilder enteredString = new StringBuilder();
                enteredString.Append(stringToAppend);
                enteredString.Append("*");
                Console.WriteLine("The result is : {0}", enteredString);
                Console.ReadKey();
            }
        }
    }
}
