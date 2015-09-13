using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace JustNotJewelryMain
{
    class Renderer
    {
        private int visibleRows { get; set; }
        private int visibleCols { get; set; }
        public char[,] GridMatrix { get; set; }
        private static readonly char[] leftBorder = new char[] { '▓', '▓', 'M', 'A', 'G', 'I', 'C'};
        private static readonly char[] rightBorder = new char[] { '▓', '▓', 'J', 'E', 'W', 'E', 'L', 'R', 'Y'};

        private int WindowWidth { get; set; }
        private int MiddleOfTheWindow { get; set; }
        private int GridMatrixMiddleCol { get; set; }
                
        public Renderer(int rows, int cols)
        {
            this.visibleRows = rows;
            this.visibleCols = cols;
            this.GridMatrix = new char[rows, cols];
            
            this.WindowWidth = Console.WindowWidth;
            this.MiddleOfTheWindow = this.WindowWidth / 2;
            this.GridMatrixMiddleCol = cols / 2;
        }

        public void EnqueueItem(GameObject obj)
        {
            char[,] image = obj.GetImage();
            Coordinates topLeft = obj.GetTopLeftCorner();

            int sizeInRows = image.GetLength(0); //End row 
            int sizeInCols = image.GetLength(1); //End col

            int startRow = topLeft.Row;
            int startCol = topLeft.Col;

            for (int row = startRow; row < startRow + sizeInRows; row++)
            {
                for (int col = startCol; col < startCol + sizeInCols; col++)
                {
                    GridMatrix[row, col] = image[(row - startRow), (col - startCol)];
                }
            }
        }

        public void RenderAll(List<GameObject> objects, List<GameObject> tableInfo, GameObject[,] staticsFallenItems, List<GameObject> movable)
        {
            int counter = 0;
            //Console.SetCursorPosition(0, 0);
            Console.SetCursorPosition(this.MiddleOfTheWindow - this.GridMatrixMiddleCol, 0);

            RenderInfoTable(tableInfo);

            //Adjust top border position
            Console.SetCursorPosition(this.MiddleOfTheWindow - this.GridMatrixMiddleCol, 5);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(new string('═', this.GridMatrix.GetLength(1)));

            for (int row = 6; row < this.visibleRows; row++)
            {
                //Adjust left border position
                Console.SetCursorPosition(this.MiddleOfTheWindow - this.GridMatrixMiddleCol - 1, row);
                CreateBordersLeftAndRight(row, Renderer.leftBorder, ConsoleColor.DarkCyan);
                Console.WriteLine();

                for (int col = 0; col < this.visibleCols; col++)
                {
                    ConsoleColor currentColor = ConsoleColor.White;
                    
                    if (this.GridMatrix[row, col] != ' ')
                    {
                        //Set the falling items colors
                        if (counter > 2)
                        {
                            counter = 0;
                        }
                        currentColor = movable[counter].ObjectColor;
                        counter++;

                        //Set the fallen items colors
                        if (staticsFallenItems[row,col] != null)
                        {
                            currentColor = staticsFallenItems[row, col].ObjectColor;
                        }
                        
                    }
                    
                    //Adjust game items - blocks position
                    Console.SetCursorPosition(this.MiddleOfTheWindow - this.GridMatrixMiddleCol + col, row);
                    Console.ForegroundColor = currentColor;
                    Console.Write(this.GridMatrix[row, col]);
                    
                }
               
                CreateBordersLeftAndRight(row, Renderer.rightBorder, ConsoleColor.DarkCyan);
                Console.WriteLine();
                
            }

            //Adjust down border position
            Console.SetCursorPosition(this.MiddleOfTheWindow - this.GridMatrixMiddleCol, this.GridMatrix.GetLength(0));
            Console.WriteLine(new string('═', this.GridMatrix.GetLength(1)));
        }

        //Method for printing only the informational table
        public void RenderInfoTable(List<GameObject> obj)
        {
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < visibleCols; col++)
                {
                    Console.SetCursorPosition(this.MiddleOfTheWindow - this.GridMatrixMiddleCol + col, row);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(this.GridMatrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        //Fills the grid with empty characters to simulate space and clear the grid
        public void ClearFieldGrid()
        {   
            for (int row = 0; row < this.visibleRows; row++)
            {
                for (int col = 0; col < this.visibleCols; col++)
                {
                    this.GridMatrix[row, col] = ' ';
                }
            }
        }

        //Create the side borders
        private void CreateBordersLeftAndRight(int startRow,  char[] border, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            if (startRow - border.Length - 1 < 5)
            {
                if (border[startRow - 6] >= 'A' && border[startRow - 6] <= 'Z')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = color;
                }
                Console.Write(border[startRow - 6]);
            }
            else
            {
                Console.Write('▓');
            }
        }
    }
}
