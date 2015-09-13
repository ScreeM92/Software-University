/*A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys).
A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.
Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density.*/

using System;
using System.Collections.Generic;
using System.Threading;

struct Dwarf
{
    public int x;
    public int y;
    public char[] symbolArr;
    public ConsoleColor color;
}

struct Rock
{
    public int x1, x2, x3;
    public int y;
    public char[] symbolArr;
    public ConsoleColor color;
}
class FallingRocksGame
{
    static void PrintObject(int x, int y, char[] symbols, ConsoleColor color)
    {
        for (int i = 0; i < symbols.Length; i++)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(symbols[i]);
            x++;
        }
    }
    
    static void Main(string[] args)
    {
        // Console settings
        Console.CursorVisible = false;
        Console.BufferHeight = Console.WindowHeight = 30;
        Console.BufferWidth = Console.WindowWidth = 40;
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.Clear();
        
        //Playfield restriction
        int playFieldWidth = Console.WindowWidth - 8;

        int sleep = 150;

        Random randomGenerator = new Random();

        // Rock types
        char[] rocksArr = new char[] {
            '^', '@', '&', '+',
            '%', '$', '#', '!',
            '.', ';', '-'
        };

        // Player beginning position, color and symbols 
        Dwarf userDwarf = new Dwarf();
        userDwarf.x = (Console.WindowWidth - 8) / 2;
        userDwarf.y = Console.WindowHeight - 1;
        userDwarf.color = ConsoleColor.DarkBlue;
        userDwarf.symbolArr = new char[] {
            '(', '0', ')'
        };

        int livesCount = 5;
        int score = 0;

        // Add every new rock to a List
        List<Rock> rocks = new List<Rock>();
        
        // A warning message :)
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("Are you ready to get...\n ");
        Thread.Sleep(sleep + 1500);
        Console.ForegroundColor = ConsoleColor.Red;
        Thread.Sleep(sleep + 50);
        Console.Write("CRUSHED??\n");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("Press any key to continue...");
        Console.ReadKey();

        while (true)
        {
            // Set game speed
            Thread.Sleep(sleep + 50);

            // Rocks colors
            ConsoleColor color1 = ConsoleColor.DarkGreen;
            ConsoleColor color2 = ConsoleColor.DarkCyan;
            ConsoleColor color3 = ConsoleColor.DarkYellow;
            ConsoleColor color4 = ConsoleColor.Red;
            ConsoleColor color5 = ConsoleColor.Black;

            // Generate random rock position, color, symbol and the count of the symbol
            ConsoleColor[] rockColors = new ConsoleColor[5]{
                color1, color2, color3, color4, color5
            };

            int rockNum = randomGenerator.Next(1, 4);
            char rockSymbol = rocksArr[randomGenerator.Next(0, rocksArr.Length)];
            Rock newRock = new Rock();
            newRock.color = rockColors[randomGenerator.Next(0, 5)];
            newRock.x1 = randomGenerator.Next(0, playFieldWidth - 2);
            newRock.y = 0;
            newRock.symbolArr = new char[rockNum];

            // If the rock has more than 1 symbol, assign every next symbol with a X coordinate
            if (rockNum == 2)
            {
                newRock.x2 = newRock.x1 + 1;
            }
            else if (rockNum == 3)
            {
                newRock.x2 = newRock.x1 + 1;
                newRock.x3 = newRock.x2 + 1;
            }
            if (newRock.x2 == 0)
            {
                newRock.x2 = -1;
            }
            if (newRock.x3 == 0)
            {
                newRock.x3 = -1;
            }

            // Add the symbols to an array and add the compleated rock object to the List<rocks>
            for (int i = 0; i < newRock.symbolArr.Length; i++)
            {
                newRock.symbolArr[i] = rockSymbol;
            }
            rocks.Add(newRock);

            // Check if a key is pressed and move player
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (userDwarf.x - 1 > 0)
                    {
                        userDwarf.x--;   
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (userDwarf.x < playFieldWidth - 2)
                    {
                        userDwarf.x++;
                    }
                }
            }

            // Clear everything
            Console.Clear();

            // Print the new player position
            PrintObject(userDwarf.x - 1, userDwarf.y, userDwarf.symbolArr, userDwarf.color);

            // A new list of rocks to help with the rock positions 
            List<Rock> newListRocks = new List<Rock>();

            // Copy each rock to a new temporary rock and add it to the new list if its position is valid
            for (int i = 0; i < rocks.Count; i++)
            {
                Rock oldRock = rocks[i];
                Rock newRockMod = new Rock();
                newRockMod.x1 = oldRock.x1;
                newRockMod.x2 = oldRock.x2;
                newRockMod.x3 = oldRock.x3;
                newRockMod.y = oldRock.y + 1;
                newRockMod.color = oldRock.color;
                newRockMod.symbolArr = new char[oldRock.symbolArr.Length];
                Array.Copy(oldRock.symbolArr, newRockMod.symbolArr, oldRock.symbolArr.Length);

                // Check if the rock is hitting the player and if so, take one life 
                if (newRockMod.y == userDwarf.y &&
                    ((newRockMod.x1 == userDwarf.x - 1 || newRockMod.x1 == userDwarf.x || newRockMod.x1 == userDwarf.x + 1) ||
                    (newRockMod.x2 == userDwarf.x - 1 || newRockMod.x2 == userDwarf.x || newRockMod.x2 == userDwarf.x + 1) ||
                    (newRockMod.x3 == userDwarf.x - 1 || newRockMod.x3 == userDwarf.x || newRockMod.x3 == userDwarf.x + 1)))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(userDwarf.x - 1, Console.WindowHeight - 1);
                    Console.Write('X');
                    Console.SetCursorPosition(userDwarf.x, Console.WindowHeight - 1);
                    Console.Write('X');
                    Console.SetCursorPosition(userDwarf.x + 1, Console.WindowHeight - 1);
                    Console.Write('X');
                    livesCount--;
                }

                // Check if the rock's Y is bigger than the window height and if so, remove it and add score
                if (newRockMod.y < Console.WindowHeight)
                {
                    newListRocks.Add(newRockMod);
                }
                else
                {
                    score += 100;
                }
            }

            // Check the lives count 
            if (livesCount == 0)
            {
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2 - 8, Console.WindowHeight / 2 - 1);
                Console.Write("Game Over!");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 8, Console.WindowHeight / 2);
                Console.Write("Your score is {0}", score);
                while (true) ;
            }

            // Copy the new rocks to the array
            rocks = newListRocks;

            // Print the rocks
            foreach (Rock rock in rocks)
            {
                PrintObject(rock.x1, rock.y, rock.symbolArr, rock.color);
            }

            // Print the info
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - 8, i);
                Console.Write("|");
            }
            Console.SetCursorPosition(Console.WindowWidth - 7, 5);
            Console.Write("Lives:");
            Console.SetCursorPosition(Console.WindowWidth - 7, 6);
            Console.Write(livesCount);
            Console.SetCursorPosition(Console.WindowWidth - 7, 2);
            Console.Write("Score:");
            Console.SetCursorPosition(Console.WindowWidth - 7, 3);
            Console.Write(score);
        }
    }
}
