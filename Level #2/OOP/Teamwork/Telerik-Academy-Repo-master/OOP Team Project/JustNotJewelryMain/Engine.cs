using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace JustNotJewelryMain
{
    class Engine
    {
        private List<GameObject> allObjects;
        private List<GameObject> movableObjects;
        private List<GameObject> staticObjects;
        private List<GameObject> infoObjects;
        private GameObject[,] fallenObjectsContainerMatrix;

        public Renderer Renderer { get; set; }
        private Input movement;
        private Random randomNumberGenerator = new Random();
        private Random secondRandomNumberGenerator = new Random();
        private Random thirdRandomNumberGenerator = new Random();
        private FallingBlocksWrapper fallingBlocksWrapper;

        private int gameSpeed;
        private bool hasGameEnded = false;
        private int score = 0;

        public Engine(Renderer renderer, int gameSpeed, Input movement)
        {
            this.Renderer = renderer;
            this.movement = movement;

            this.fallenObjectsContainerMatrix = new GameObject[this.Renderer.GridMatrix.GetLength(0), this.Renderer.GridMatrix.GetLength(1)];
            this.staticObjects = new List<GameObject>();
            this.movableObjects = new List<GameObject>();
            this.allObjects = new List<GameObject>();
            this.infoObjects = new List<GameObject>();
            this.gameSpeed = gameSpeed;

            //Adding falling blocks structure
            this.fallingBlocksWrapper = new FallingBlocksWrapper(new Coordinates(6, (this.Renderer.GridMatrix.GetLength(1) / 2) - 1), new Coordinates(1, 0));
            
            foreach (var fallingBlock in this.fallingBlocksWrapper)
            {
                this.AddObject(fallingBlock);
            }
        }

        /// Add objects in the object lists
        private void AddInfoObjects(GameObject obj)
        {
            infoObjects.Add(obj);
        }
        private void AddMovableObject(GameObject obj)
        {
            movableObjects.Add(obj);
        }        

        public void AddObject(GameObject obj)
        {
            if (obj is MovableObject)
            {
                this.AddMovableObject(obj);
            }
            else if (obj is StaticObject && !(obj is Text) && !(obj is InfoWall))
            {   
                fallenObjectsContainerMatrix[obj.TopLeft.Row, obj.TopLeft.Col] = obj;
            }
            else
	        {
                AddInfoObjects(obj);
	        }
            allObjects.Add(obj);
        }

        ///Restart the falling item position
        private void InitializeFallingItemAtStartPosition(FallingBlocksWrapper obj)
        {
            int visibleCols = this.Renderer.GridMatrix.GetLength(1);
            int startRow = 5;
            int startCol = (visibleCols / 2) - 1;
            int randomColorsCounter = 0;

            ConsoleColor[] randomColors = 
            {
                (ConsoleColor)randomNumberGenerator.Next(1, 13),
                (ConsoleColor)secondRandomNumberGenerator.Next(5, 13),
                (ConsoleColor)thirdRandomNumberGenerator.Next(9, 13)
            };

            foreach (var fallingBlock in this.fallingBlocksWrapper)
            {
                fallingBlock.TopLeft = new Coordinates(startRow++, startCol);
                fallingBlock.ObjectColor = randomColors[randomColorsCounter++];
            }
        }

        /// Events implementation (move right, left, change color with the spacebar, speed up falling item, change manualy game speed)
        public void MoveLeft()
        {
            if (this.fallingBlocksWrapper.TryToMove(this.fallenObjectsContainerMatrix))
            {
                this.fallingBlocksWrapper.MoveLeft();
            }
        }
        public void MoveRight()
        {
            if (this.fallingBlocksWrapper.TryToMove(this.fallenObjectsContainerMatrix))
            {
                this.fallingBlocksWrapper.MoveRight();
            }
        }
        public void ExchangeFallingItemBlocksColors()
        {
            this.fallingBlocksWrapper.ReverseColors();
        }

        private void EnqueueMatrix()
        {
            for (int i = 0; i < this.fallenObjectsContainerMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.fallenObjectsContainerMatrix.GetLength(1); j++)
                {
                    if (fallenObjectsContainerMatrix[i, j] != null)
                    {
                        this.Renderer.EnqueueItem(fallenObjectsContainerMatrix[i, j]);
                    }
                }
            }
        }

        private void RemoveDestroyedItems(int rows, int cols)
        {
            //Set the scope to be in range of the matrix
            int endRow = rows + 5;
            if (rows + 3 >= this.Renderer.GridMatrix.GetLength(0))
            {
                endRow = rows + 3;
            }

            int startCol = cols - 4;
            int endCol = cols + 4;
            if (endCol >= this.Renderer.GridMatrix.GetLength(1) - 1)
            {
                endCol = this.Renderer.GridMatrix.GetLength(1) - 1;
            }
            if (startCol < 0)
            {
                startCol = 0;
            }

            //Traverse the matrix and remove destroyed items
            for (int row = rows; row < endRow; row++)
            {
                for (int col = startCol; col <= endCol; col++)
                {
                    if (this.fallenObjectsContainerMatrix[row, col] != null)
                    {
                        if (this.fallenObjectsContainerMatrix[row,col].isDestroyed)
                        {
                            this.fallenObjectsContainerMatrix[row, col] = null;    
                        }
                    }
                }
            }
        }

        public void Run()
        {
            while (true)
            {
                Renderer.ClearFieldGrid();

                this.movement.ProcessInput();
                
                Thread.Sleep(this.gameSpeed);

                foreach (var obj in this.allObjects)
                {
                    this.Renderer.EnqueueItem(obj);
                }
                EnqueueMatrix();
                
                foreach (var obj in this.movableObjects)
                {
                    if (obj is FallingBlock)
                    {
                        if (fallingBlocksWrapper.HasLanded(this.Renderer.GridMatrix))
                        {
                            foreach (var fallingBlock in this.fallingBlocksWrapper)
                            {
                                GameObject currentStaticObject = new StaticObject(fallingBlock.TopLeft, fallingBlock.ObjectColor);
                                this.fallenObjectsContainerMatrix[fallingBlock.TopLeft.Row, fallingBlock.TopLeft.Col] = currentStaticObject;
                            }


                            GameObject[,] tempMatrix = LineMatcher.GetEqualsInArea(this.fallenObjectsContainerMatrix, this.movableObjects[0].TopLeft.Row, this.movableObjects[0].TopLeft.Col);
                            this.fallenObjectsContainerMatrix = tempMatrix;
                            RemoveDestroyedItems(this.movableObjects[0].TopLeft.Row, this.movableObjects[0].TopLeft.Col);
                           
                            //OnExplosionActions(currentStaticObject);

                            InitializeFallingItemAtStartPosition(this.fallingBlocksWrapper);
                            if (GameOver.HasGameEnded(obj, this.Renderer))
                            {
                                hasGameEnded = true;
                                GameOver.OnGameOver("GAME OVER", ConsoleColor.Red, 10, 10);
                                Console.WriteLine("Game speed "+  this.gameSpeed);
                            }
                        }
                    }
                    obj.Update();
                }

                Renderer.RenderAll(this.allObjects, this.infoObjects, this.fallenObjectsContainerMatrix, this.movableObjects);

                if (hasGameEnded) { break; }
            }
        }
    }
}
