using System;

class InsideTheBuildingTestGenerator
{
    static int size;

    static Random rnd = new Random();

    static void Main()
    {
        size = rnd.Next(100) + 1;

        Console.WriteLine(size);
        Console.WriteLine(RandomX());
        Console.WriteLine(RandomY());
        Console.WriteLine(RandomX());
        Console.WriteLine(RandomY());
        Console.WriteLine(RandomX());
        Console.WriteLine(RandomY());
        Console.WriteLine(RandomX());
        Console.WriteLine(RandomY());
        Console.WriteLine(RandomX());
        Console.WriteLine(RandomY());
    }

    private static int RandomX()
    {
        int num = rnd.Next(0, 4) * size;
        return num + rnd.Next(3) - 1;
    }

    private static int RandomY()
    {
        int num = rnd.Next(0, 5) * size;
        return num + rnd.Next(3) - 1;
    }
}
