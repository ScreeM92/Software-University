using System;
using System.Threading;
using System.Collections.Generic;

class FallingRocks
{
    struct objects
    {
        public int x;
        public int y;
        public char c;
    }

    static void PrintOnPosition(int x, int y, char c)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(c);
    }

    static void Main()
    {
        int width = 22;
        int height = 13;
        Console.SetWindowSize(width, height);
        Console.SetBufferSize(width, height);

        int playground = width - 1;

        List<objects> rocks = new List<objects>();
        List<objects> moreRocks = new List<objects>();
        Random rocksGenerator = new Random();
        char[] rockChars = "^@*&+%$#!.;".ToCharArray();

        objects dwarf = new objects();
        dwarf.x = playground / 2;
        dwarf.y = height - 1;
        dwarf.c = '0';


        while (true)
        {
            for (int i = 0; i < rocks.Count; i++)
            {
                objects newRock = rocks[i];
                newRock.y++;
                rocks.Remove(rocks[i]);
                moreRocks.Add(newRock);
            }

            int rocksNumber = rocksGenerator.Next(1, 8);
            for (int j = 0; j < rocksNumber; j++)
            {
                objects newRock = new objects();
                newRock.y = 0;
                newRock.x = rocksGenerator.Next(0, playground);
                int r = rocksGenerator.Next(rockChars.Length);
                newRock.c = rockChars[r];
                rocks.Add(newRock);
            }

            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if ((key.Key == ConsoleKey.LeftArrow) && (dwarf.x != 0))
                {
                    dwarf.x--;
                }
                else if ((key.Key == ConsoleKey.RightArrow) && (dwarf.x != playground - 1))
                {
                    dwarf.x++;
                }
            }
            Console.Clear();
            PrintOnPosition(dwarf.x, dwarf.y, dwarf.c);

            foreach (objects newRock in moreRocks)
            {
                PrintOnPosition(newRock.x, newRock.y, newRock.c);
            }

            moreRocks.Clear();

            Thread.Sleep(500);

            
        }









    //    // fortmat the console
        //int width = 41;
        //int height = 13;
        //Console.SetWindowSize(width, height);
        //Console.SetBufferSize(width, height + 2);
        //Console.CursorVisible = false;
        //Console.SetCursorPosition(0, 0);
    //    //-----

    //    string hero = "                    0                    ";
    //    Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n" + hero);

    //    //while (true)
    //    //{
    //    //    ConsoleKeyInfo key = Console.ReadKey(true);
    //    //    int action = (int)key.Key;
    //    //    if (action == 37)
    //    //    {
    //    //        hero = hero.Remove(0, 1);
    //    //        hero = hero + " ";
    //    //        Console.Clear();
    //    //        Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n" + hero);
    //    //    }
    //    //    if (action == 39)
    //    //    {
    //    //        hero = hero.Remove(40, 1);
    //    //        hero = " " + hero;
    //    //        Console.Clear();
    //    //        Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n" + hero);
    //    //    }
    //    //}

    //    //generator-rocks, gravity: on
    //    string[] rocks = new string[15];
    //    var chars = "^@*&+%$#!.;                                                                                                                        ";
    //    var stringChars = new char[41];
    //    var random = new Random();

    //    while (true)
    //    {
    //        for (int i = 0; i < stringChars.Length; i++)
    //        {
    //            stringChars[i] = chars[random.Next(chars.Length)];
    //        }

    //        rocks[0] = new String(stringChars);

    //        for (int i = 12; i >= 1; i--)
    //        {
    //            rocks[i] = rocks[i - 1];
    //        }
    //        for (int i = 1; i <= 12; i++)
    //        {
    //            Console.Write(rocks[i]);
    //        }
    //        Thread.Sleep(150);
    //        Console.Clear();

    //        //ConsoleKeyInfo key = Console.ReadKey(true);
    //        //int action = (int)key.Key;
    //        //if (action == 37)
    //        //{
    //        //    hero = hero.Remove(0, 1);
    //        //    hero = hero + " ";
    //        //    Console.Clear();
    //        //    Console.Write(hero);
    //        //}
    //        //if (action == 39)
    //        //{
    //        //    hero = hero.Remove(40, 1);
    //        //    hero = " " + hero;
    //        //    Console.Clear();
    //        //    Console.Write(hero);
    //        //}
    //    }
    //    //-----


    }
}