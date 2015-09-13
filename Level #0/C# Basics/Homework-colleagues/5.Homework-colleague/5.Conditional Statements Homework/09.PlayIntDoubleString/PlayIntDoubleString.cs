using System;
class PlayIntDoubleString
{
    static void Main()
    {
        Console.WriteLine("1 --> int ");
        Console.WriteLine("2 --> double ");
        Console.WriteLine("3 --> string ");
        Console.Write("Please choose a type: ");
        string input = Console.ReadLine();
        int choose;
        if (int.TryParse(input, out choose))
        {
            switch (choose)
            {
                case 1:
                    Console.Write("Please enter a int: ");
                    int first = int.Parse(Console.ReadLine());
                    Console.WriteLine(first+1);
                    break;
                case 2:
                    Console.Write("Please enter a double: ");
                    double second = double.Parse(Console.ReadLine());
                    Console.WriteLine(second+1);
                    break;
                case 3:
                    Console.Write("Please enter a string: ");
                    string third = Console.ReadLine();
                    Console.WriteLine(third+"*");
                    break;
                default:
                    Console.WriteLine("Invalid choose!");
                    break;
            }
        }
        else
	    {
            Console.WriteLine("Invalid choose!", input);
	    }
    }
}