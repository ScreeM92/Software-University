using System;
class BatGoikoTower
{
    static void Main()
    {
        char slash = '/';
        char backslash = '\\';
        char dot = '.';
        char dash = '-';
        int dashRowIndex = 1;
        int dashRowIncrement = 1;

        //read the input height
        int height = int.Parse(Console.ReadLine());

        for (int row = 0; row < height; row++)
        {
            Console.Write(new string(dot, height - row - 1));
            Console.Write(slash);

            if (row == dashRowIndex)
            {
                Console.Write(new string(dash, row * 2));
                dashRowIncrement++;
                dashRowIndex += dashRowIncrement;
            }
            else
            {
                Console.Write(new string(dot, row * 2));
            }

            Console.Write(backslash);
            Console.WriteLine(new string(dot, height - row - 1));
            
        }







        //for (int i = 0; i < height; i++)
        //{
        //    //print the initial dots (starting from Height-1 and decreasing by 1 each row) + a single slash
        //    Console.Write(new string(dot, height - i - 1));
        //    Console.Write(slash);

        //    //if the current row is a dash row print dashes and evaluate which the next dash row is
        //    if (i == dashRowIndex)
        //    {
        //        Console.Write(new string(dash, i * 2));
        //        dashRowIncrement++;
        //        dashRowIndex += dashRowIncrement;
        //    }
        //    //if the row isn't a dash row, simply print dots.
        //    else
        //    {
        //        Console.Write(new string(dot, i * 2));
        //    }
        //    //print a single backslash + the final dots (calculated using the same formula as the initial dots(see above))
        //    Console.Write(backslash);
        //    Console.WriteLine(new string(dot, height - i - 1));
        //}
    }
}