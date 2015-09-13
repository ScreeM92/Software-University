using System;
class Pyramid
{
    static void Main()
    {
        //BatBoikoTower
        char slash = '/';
        char backslash = '\\';
        char dot = ',';
        char dash = '-';
        int dashRowIndex = 1;
        int dashRowIncrement = 1;

        int height = int.Parse(Console.ReadLine());

        for (int i = 0; i < height; i++)
        {
            Console.Write(new string('.', height - i));
            Console.Write(slash);
            if (i == dashRowIndex)
            {
                dashRowIndex = dashRowIndex + dashRowIncrement;
                dashRowIncrement++;
                Console.Write(new string (dash, i * 2));
            }
            else
            {
                Console.Write(new string(dot, i * 2));
            }
            Console.Write(backslash);
            Console.WriteLine(new string(dot, height - i));
        }
    }
}

