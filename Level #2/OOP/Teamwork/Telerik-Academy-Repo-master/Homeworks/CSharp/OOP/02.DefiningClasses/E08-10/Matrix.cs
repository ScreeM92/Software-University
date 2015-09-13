using System;
using System.Text;

public class Matrix<T>
{
    private T[,] theMatrix;

    //Constructor which takes the size of the matrix
    public Matrix(int rows, int cols)
    {
        if (rows < 0 || cols < 0)
        {
            throw new IndexOutOfRangeException("Cannot have negative indexes");
        }
        this.theMatrix = new T[rows, cols];
    }

    //Propertie for the matrix field
    public T[,] TheMatrix
    {
        set
        {
            this.theMatrix = value;
        }
        get
        {
            return this.theMatrix;
        }
    }

    //Indexer for easy accessing the elements in the matrix
    public T this[int row, int col]
    {
        set
        {
            if (!InRange(row, col))
            {
                throw new IndexOutOfRangeException("Outside the array");
            }
            this.theMatrix[row, col] = value;
        }
        get
        {
            return this.theMatrix[row, col];
        }
    }

    //Overload + operator
    public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
    {
        if (!AreLengthEquals(firstMatrix, secondMatrix))
        {
            throw new ArgumentException("Difference in size!");
        }

        int row = firstMatrix.TheMatrix.GetLength(0);
        int col = firstMatrix.TheMatrix.GetLength(1);
        
        Matrix<T> outputMatrix = new Matrix<T>(row, col);
       
        for (int i = 0; i < firstMatrix.TheMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < firstMatrix.TheMatrix.GetLength(1); j++)
            {
                outputMatrix[i,j] = firstMatrix[i, j] + (dynamic)secondMatrix[i, j];
            }
        }

        return outputMatrix;
    }

    //Overload - operator
    public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
    {
        if (!AreLengthEquals(firstMatrix, secondMatrix))
        {
            throw new ArgumentException("Difference in size!");
        }

        int row = firstMatrix.TheMatrix.GetLength(0);
        int col = firstMatrix.TheMatrix.GetLength(1);

        Matrix<T> outputMatrix = new Matrix<T>(row, col);

        for (int i = 0; i < firstMatrix.TheMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < firstMatrix.TheMatrix.GetLength(1); j++)
            {
                outputMatrix[i, j] = firstMatrix[i, j] - (dynamic)secondMatrix[i, j];
            }
        }

        return outputMatrix;
    }

    ////Overload * operator
    public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
    {
        if (!AreLengthEquals(firstMatrix, secondMatrix))
        {
            throw new ArgumentException("Difference in size!");
        }

        int row = firstMatrix.TheMatrix.GetLength(0);
        int col = firstMatrix.TheMatrix.GetLength(1);

        Matrix<T> outputMatrix = new Matrix<T>(row, col);

        for (int i = 0; i < firstMatrix.TheMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < firstMatrix.TheMatrix.GetLength(1); j++)
            {
                outputMatrix[i, j] = firstMatrix[i, j] * (dynamic)secondMatrix[i, j];
            }
        }

        return outputMatrix;
    }

    //Override ToString()
    public override string ToString()
    {
        StringBuilder toStringer = new StringBuilder();
        for (int i = 0; i < this.TheMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < this.TheMatrix.GetLength(1); j++)
            {
                toStringer.Append(this[i, j] + " ");
            }
            toStringer.AppendLine();
        }

        return toStringer.ToString();
    }

    //Check if the wanted indexers exist
    public bool InRange(int row, int col)
    {
        bool inRangeRow = row >= 0 && row < this.TheMatrix.GetLength(0);
        bool inRangeCol = col >= 0 && col < this.TheMatrix.GetLength(1);
        
        return inRangeRow && inRangeCol;
    }

    //Check if the matrixes are equal
    public static bool AreLengthEquals(Matrix<T> first, Matrix<T> second)
    {
        bool areEqualRows = first.TheMatrix.GetLongLength(0) == second.TheMatrix.GetLongLength(0);
        bool areEqualCols = first.TheMatrix.GetLongLength(1) == second.TheMatrix.GetLongLength(1);

        return areEqualRows && areEqualCols;
    }

    public static bool operator true(Matrix<T> matrix)
    {
        for (int i = 0; i < matrix.TheMatrix.GetLongLength(0); i++)
        {
            for (int j = 0; j < matrix.TheMatrix.GetLongLength(1); j++)
            {
                //matr[i, j] == 0
                int zero = 0;
                if (matrix[i, j] == (dynamic)0)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator false(Matrix<T> matrix)
    {
        for (int i = 0; i < matrix.TheMatrix.GetLongLength(0); i++)
        {
            for (int j = 0; j < matrix.TheMatrix.GetLongLength(1); j++)
            {                
                int zero = 0;
                if (matrix[i, j] == (dynamic)0)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
