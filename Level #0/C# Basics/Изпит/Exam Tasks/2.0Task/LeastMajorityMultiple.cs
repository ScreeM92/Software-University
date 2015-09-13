using System;

public class LeastMajorityMultiple
{
    public static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int e = int.Parse(Console.ReadLine());

        int result = 1;
        while (true)
        {
            int counter = 0;

            if (result % a == 0)
            {
                counter++;
            }

            if (result % b == 0)
            {
                counter++;
            }

            if (result % c == 0)
            {
                counter++;
            }

            if (result % d == 0)
            {
                counter++;
            }

            if (result % e == 0)
            {
                counter++;
            }

            if (counter >= 3)
            {
                break;
            }

            result++;
        }
        Console.WriteLine(result);
    }

}