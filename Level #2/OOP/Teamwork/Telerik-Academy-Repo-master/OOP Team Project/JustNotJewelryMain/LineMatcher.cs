using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustNotJewelryMain
{
    static class LineMatcher
    {
        public static void FillFallenObjects(GameObject obj, IList<GameObject> dynamicObjects)
        {
            dynamicObjects.Add(obj);
        }

        public static GameObject[,] GetEqualsInArea(GameObject[,] matrix, int row, int col)
        {   
            int objectHeight = 3;
            for (int index = 0; index < objectHeight; index++)
            {
                //Destroy left to right
                if (CheckLeftToRightFirstElements(matrix, row + index, col))
                {
                    matrix[row + index, col].isDestroyed = true;
                    matrix[row + index, col + 1].isDestroyed = true;
                    matrix[row + index, col + 2].isDestroyed = true;
                }
                //Destroy right to left
                if (CheckRightToLeftFirstElements(matrix, row + index, col))
                {
                    matrix[row + index, col].isDestroyed = true;
                    matrix[row + index, col - 1].isDestroyed = true;
                    matrix[row + index, col - 2].isDestroyed = true;

                    //TODO: Repear
                    //if (CheckLeftToRightNextElements(matrix, row, col - 3))
                    //{
                    //    matrix[row + index, col - 3].isDestroyed = true;
                    //}
                }
                //Destroy in down direction
                if (CheckDownDirection(matrix, row + index, col))
                {
                    matrix[row, col].isDestroyed = true;
                    matrix[row + index + 1, col].isDestroyed = true;
                    matrix[row + index + 2, col].isDestroyed = true;
                }
            }

            return matrix;
        }

        //Booleans
        private static bool CheckLeftToRightFirstElements(GameObject[,] matrix, int row, int col)
        {
            return col + 1 < matrix.GetLength(1) && //Checks if is in range
                col + 2 < matrix.GetLength(1) &&  //---same as above---
                matrix[row, col + 1] != null &&  //Checks if is null
                matrix[row, col + 2] != null && //--same as above---
                matrix[row, col].ObjectColor == matrix[row, col + 1].ObjectColor && //Checks if colors match
                matrix[row, col].ObjectColor == matrix[row, col + 2].ObjectColor;//--same as above----
        }
        private static bool CheckLeftToRightNextElements(GameObject[,] matrix, int row, int col)
        {
            return col < matrix.GetLength(1) &&
                    matrix[row, col + 3] != null &&
                    matrix[row, col].ObjectColor == matrix[row, col].ObjectColor;
        }
        private static bool CheckRightToLeftFirstElements(GameObject[,] matrix, int row, int col)
        {
            return col - 1 > 0 && //Checks if is in range
               col - 2 > 0 &&  //---same as above---
               matrix[row, col - 1] != null &&  //Checks if is null
               matrix[row, col - 2] != null && //--same as above---
               matrix[row, col].ObjectColor == matrix[row, col - 1].ObjectColor && //Checks if colors match
               matrix[row, col].ObjectColor == matrix[row, col - 2].ObjectColor; //-- same as above --
        }

        private static bool CheckDownDirection(GameObject[,] matrix, int row, int col)
        {
            return row + 1 < matrix.GetLength(0) && //Checks if is in range
                row + 2 < matrix.GetLength(0) &&  //---same as above---
                matrix[row + 1, col] != null &&  //Checks if is null
                matrix[row + 2, col] != null && //--same as above---
                matrix[row, col].ObjectColor == matrix[row + 1, col].ObjectColor && //Checks if colors match
                matrix[row, col].ObjectColor == matrix[row + 2, col].ObjectColor;//--same as above--
        }
    }
}
