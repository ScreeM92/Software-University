using System;

namespace PlayWithIntDoubleAndString
{
    class PlayWithIntDoubleAndString
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 for int, 2 for double, and 3 for string");
            sbyte choice = sbyte.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: int firstCohise = int.Parse(Console.ReadLine());
                    Console.WriteLine(firstCohise + 1);
                    break;
                case 2: double secondCohise = double.Parse(Console.ReadLine());
                    Console.WriteLine(secondCohise + 1);
                    break;
                case 3: string thirdCohise = Console.ReadLine();
                    Console.WriteLine(thirdCohise + "*");
                    break;
                default: Console.WriteLine("Problem, problem");
                    break;
            }
        }
    }
}
