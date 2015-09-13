using System;
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int eggHeight = n * 2;
            int eggWidth = (3 * n) - 1;
            int totalWidth = (3 * n) + 1;

            char[,] matrix = new char[eggHeight, totalWidth];

            FillMatrix(eggHeight, totalWidth, matrix);
            PrintMatrix(eggHeight, totalWidth, matrix);

            int topRow = 0;
            int bottomRow = eggHeight - 1;
            int leftPivot = (n + 1);
            for (int i = leftPivot; i < n - 1; i++, leftPivot++)
            {
                matrix[topRow, i] = '*';
                matrix[bottomRow, i] = '*';
            }

            //reseting the pivot
            int rightPivot = leftPivot + 1;
            leftPivot = n;
            topRow++;
            bottomRow--;
            for (int i = 0; i < n / 2; i++)
            {
                matrix[topRow, leftPivot] = '*';
                matrix[bottomRow, leftPivot] = '*';
                matrix[topRow, rightPivot] = '*';
                matrix[bottomRow, rightPivot] = '*';
                leftPivot -= 2;
                rightPivot += 2;
                topRow++;
                bottomRow--;
            }

            for (int row = 0; row < eggHeight; row++)
            {
                for (int col = 0; col < totalWidth; col++)
                {
                    matrix[row, col] = '.';
                }
            }
            for (int row = 0; row < eggHeight; row++)
            {
                for (int col = 0; col < totalWidth; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintMatrix(int eggHeight, int totalWidth, char[,] matrix)
        {
            throw new NotImplementedException();
        }

        private static void FillMatrix(int eggHeight, int totalWidth, char[,] matrix)
        {
            throw new NotImplementedException();
        }
    }

