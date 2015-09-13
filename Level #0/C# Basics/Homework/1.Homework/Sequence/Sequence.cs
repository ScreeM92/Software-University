using System;
class Sequence
{
    static void Main()
    {
        for (int index = 2; index <= 11; index++)
        {
            if (index % 2 == 0)
            {
                Console.Write(index);
            }
            else
            {
                Console.Write(-index);
            }
            
                Console.Write(" ");
            
        }
    }
}

