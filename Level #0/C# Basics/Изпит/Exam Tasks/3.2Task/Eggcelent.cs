using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int eggHeight = 2 * n;
        int eggWidth = 3 * n - 1;
        int totalWidth = 3 * n + 1;

        char[,] matrix = new char[eggHeight, totalWidth];

        FillMatrix(eggHeight, totalWidth, matrix);

        int topRow = 0;
        int bottomRow = eggHeight - 1;

        int leftPivot = (n + 1);
        for (int i = 0; i < n - 1; i++, leftPivot++)
        {
            matrix[topRow, leftPivot] = '*';
            matrix[bottomRow, leftPivot] = '*';
        }


        // reseting the pivot
        int rightPivot = leftPivot + 1;
        leftPivot = n - 1;
        topRow++;
        bottomRow--;
        for (int i = 0; i < n / 2; i++)
        {
            matrix[topRow, leftPivot] = '*';
            matrix[bottomRow, leftPivot] = '*';
            matrix[topRow, rightPivot] = '*';
            matrix[bottomRow, rightPivot] = '*';
            if (i != n / 2 - 1)
            {
                leftPivot -= 2;
                rightPivot += 2;
                topRow++;
                bottomRow--;
            }
        }

        topRow++;
        for (int i = 0; i < n - 2; i++)
        {
            matrix[topRow, leftPivot] = '*';
            matrix[topRow, rightPivot] = '*';
            topRow++;
        }

        // reset
        topRow = n - 1;
        bottomRow = n;
        leftPivot++;
        for (int i = 0; i < eggWidth - 2; i++)
        {
            if (i % 2 == 0)
            {
                matrix[topRow, leftPivot] = '@';
                matrix[bottomRow, leftPivot] = '.';
            }
            else
            {
                matrix[topRow, leftPivot] = '.';
                matrix[bottomRow, leftPivot] = '@';
            }
            leftPivot++;
        }

        PrintMatrix(eggHeight, totalWidth, matrix);
    }

    private static void PrintMatrix(int eggHeight, int totalWidth, char[,] matrix)
    {
        for (int row = 0; row < eggHeight; row++)
        {
            for (int col = 0; col < totalWidth; col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }

    private static void FillMatrix(int eggHeight, int totalWidth, char[,] matrix)
    {
        for (int row = 0; row < eggHeight; row++)
        {
            for (int col = 0; col < totalWidth; col++)
            {
                matrix[row, col] = '.';
            }
        }
    }
}

