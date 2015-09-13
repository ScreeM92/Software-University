using System;

class MatrixOfStrings
{
    static void Main()
    {
        int width = 4;
        int height = 6;
        string[,] matrix = new string[height, width];
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                matrix[row, col] = 
                    "" + (char)('a' + row) + (char)('a' + col);
            }
        }

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
}
