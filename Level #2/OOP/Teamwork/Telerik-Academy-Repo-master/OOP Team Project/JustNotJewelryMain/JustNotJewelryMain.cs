using System;
using System.Linq;

namespace JustNotJewelryMain
{
    class JustNotJewelryMain
    {
        public static readonly int gameSpeed = 50;//(int)LevelSpeed.Normal;
        static void Main(string[] args)
        {   
            Renderer renderer = new Renderer(30, 30);
            Input movement = new Input();
            Engine engine = new Engine(renderer, gameSpeed, movement);
            
            Intialize(engine);
            Events(engine, movement);
            
            engine.Run();
        }


        public static void Intialize(Engine engine)
        {  
            Console.CursorVisible = false;
            Console.WindowHeight = 35;
            int visibleRows = engine.Renderer.GridMatrix.GetLength(0);
            int visibleCols = engine.Renderer.GridMatrix.GetLength(1);

            char[,] wallBrick = new char[,] { { '║' } };
            char[,] ceilingBrick = new char[,] { { '═' } };
            char[,] scoreTextArray = new char[,] { { 'S', 'c', 'o', 'r', 'e', ':' } };
            char[,] timeTextArray = new char[,] { { 'T', 'i', 'm', 'e', ':' } };

            for (int i = 1; i < 4; i++)
            {
                GameObject leftWall = new InfoWall(new Coordinates(i, 0), wallBrick);
                engine.AddObject(leftWall);
                GameObject rightWall = new InfoWall(new Coordinates(i, visibleCols - 1), wallBrick);
                engine.AddObject(rightWall);
            }

            for (int i = 0; i < visibleCols; i++)
            {
                GameObject floor = new InfoWall(new Coordinates(4, i), ceilingBrick);
                engine.AddObject(floor);

                GameObject ceiling = new InfoWall(new Coordinates(0, i), ceilingBrick);
                engine.AddObject(ceiling);
            }

            GameObject scoreText = new Text(new Coordinates(1, 1), scoreTextArray);
            engine.AddObject(scoreText);

            GameObject timeText = new Text(new Coordinates(2, 1), timeTextArray);
            engine.AddObject(timeText);

            GameObject timePlayed = new TimeText(new Coordinates(2, timeTextArray.GetLength(1) + 2));
            engine.AddObject(timePlayed);
            GameObject score = new Scores(new Coordinates(1, scoreTextArray.GetLength(1) + 2));
            engine.AddObject(score);
        }

        public static void Events(Engine engine, Input movement)
        {
            movement.OnLeftArrowPress += (sender, eventInfo) =>
            {
                engine.MoveLeft();
            };

            movement.OnRightArrowPress += (sender, eventInfo) =>
            {
                engine.MoveRight();
            };

            movement.OnSpacebarPress += (sender, eventInfo) =>
            {
                engine.ExchangeFallingItemBlocksColors();
            };
        }
    }
}
