using System;

class Program
{
    static void Main()
    {
        Matrix<int> newMatrix = new Matrix<int>(4, 4);
        newMatrix.TheMatrix[0, 0] = 23;
        newMatrix[0, 1] = 13;
        newMatrix[0, 2] = 11;
        newMatrix[0, 3] = 4;

        Matrix<int> newMatrix1 = new Matrix<int>(4, 4);
        newMatrix1.TheMatrix[0, 0] = 32;
        newMatrix1[0, 1] = 31;
        newMatrix1[0, 2] = 10;
        
        Console.WriteLine(newMatrix.ToString());
        Matrix<int> newMatrix3 = (newMatrix * newMatrix1);

        Console.WriteLine();
        Console.WriteLine(newMatrix3.ToString());

    }
}

