using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustNotJewelryMain
{
    class FallingBlocksWrapper : IReversable, IEnumerable<GameObject>
    {
        private GameObject FirstBlock { get; set; }
        private GameObject SecondBlock { get; set; }
        private GameObject ThirdBlock { get; set; }
        private int ActionKeyPressedCounter { get; set; }

        public FallingBlocksWrapper(Coordinates topLeft, Coordinates speed)
        {
            this.ActionKeyPressedCounter = 1;
            
            this.FirstBlock = new FallingBlock(topLeft, speed, new char[,] { { '#' } });
            this.SecondBlock = new FallingBlock(new Coordinates(topLeft.Row + 1, topLeft.Col), speed, new char[,] { { '#' } });
            this.ThirdBlock = new FallingBlock(new Coordinates(topLeft.Row + 2, topLeft.Col), speed, new char[,] { { '#' } });
        }

        public void MoveLeft()
        {
            this.FirstBlock.TopLeft = new Coordinates(this.FirstBlock.TopLeft.Row, this.FirstBlock.TopLeft.Col - 1);
            this.SecondBlock.TopLeft = new Coordinates(this.SecondBlock.TopLeft.Row, this.SecondBlock.TopLeft.Col - 1);
            this.ThirdBlock.TopLeft = new Coordinates(this.ThirdBlock.TopLeft.Row, this.ThirdBlock.TopLeft.Col - 1);
        }

        public void MoveRight()
        {
            this.FirstBlock.TopLeft = new Coordinates(this.FirstBlock.TopLeft.Row, this.FirstBlock.TopLeft.Col + 1);
            this.SecondBlock.TopLeft = new Coordinates(this.SecondBlock.TopLeft.Row, this.SecondBlock.TopLeft.Col + 1);
            this.ThirdBlock.TopLeft = new Coordinates(this.ThirdBlock.TopLeft.Row, this.ThirdBlock.TopLeft.Col + 1);
        }

        //public void SpeedUp()
        //{
        //    this.TopLeft = new Coordinates(this.TopLeft.Row + 1, this.TopLeft.Col);
        //}

        public void ReverseColors()
        {
            if (this.ActionKeyPressedCounter == 1)
            {
                ConsoleColor tempColor = this.FirstBlock.ObjectColor;
                this.FirstBlock.ObjectColor = this.SecondBlock.ObjectColor;
                this.SecondBlock.ObjectColor = tempColor;

                this.ActionKeyPressedCounter++;
            }
            else if (this.ActionKeyPressedCounter == 2)
            {
                ConsoleColor tempColor = this.SecondBlock.ObjectColor;
                this.SecondBlock.ObjectColor = this.ThirdBlock.ObjectColor;
                this.ThirdBlock.ObjectColor = tempColor;

                this.ActionKeyPressedCounter++;
            }
            else if (this.ActionKeyPressedCounter == 3)
            {
                ConsoleColor tempColor = this.ThirdBlock.ObjectColor;
                this.ThirdBlock.ObjectColor = this.FirstBlock.ObjectColor;
                this.FirstBlock.ObjectColor = tempColor;

                this.ActionKeyPressedCounter = 1;
            }
        }

        public bool HasLanded(char[,] matrixGrid)
        {
            bool hasLanded =  this.ThirdBlock.TopLeft.Row + this.ThirdBlock.GetImage().GetLength(1) >= matrixGrid.GetLength(1) ||
            !matrixGrid[this.ThirdBlock.TopLeft.Row + this.ThirdBlock.GetImage().GetLength(1), this.ThirdBlock.TopLeft.Col].Equals(' ');
            if (hasLanded)
            {
                this.ActionKeyPressedCounter = 1;
            }
            return hasLanded;
        }

        public bool TryToMove(GameObject[,] matrixGrid)
        {
            return IsInMatrixRangeOnMove(matrixGrid);
        }

        private bool IsInMatrixRangeOnMove(GameObject[,] matrixGrid)
        {
            return this.FirstBlock.TopLeft.Col - 1 >= 0 &&
                this.FirstBlock.TopLeft.Col + 1 < matrixGrid.GetLength(0);
        }

        private bool HasNeighbour(GameObject[,] matrixGrid) 
        {
            //bool hasFirstBlockNeighbour = matrixGrid[this.FirstBlock.TopLeft.Row, this.FirstBlock.TopLeft.Col - 1] != ' ' ||
            //    matrixGrid[this.FirstBlock.TopLeft.Row, this.FirstBlock.TopLeft.Col + 1] != ' ';
            bool hasSecondBlockNeighbour = this.SecondBlock.TopLeft.Col - 1 != ' ' || this.SecondBlock.TopLeft.Col + 1 != ' ';
            bool hasThirdBlockNeighbour = this.ThirdBlock.TopLeft.Col - 1 != ' ' || this.ThirdBlock.TopLeft.Col + 1 != ' ';  
           
            //return this.FirstBlock.TopLeft.Col - 1 >= 0 &&
            //    this.FirstBlock.TopLeft.Col + 1 < matrixGrid.GetLength(0);
            return false;
        }

        //Implement Enumerator and Enumerable methods
        IEnumerator IEnumerable.GetEnumerator()
        {
            // Call the generic version of the method
            return this.GetEnumerator();
        }


        public IEnumerator<GameObject> GetEnumerator()
        {
            yield return FirstBlock;
            yield return SecondBlock;
            yield return ThirdBlock; 
        }
    }
}
