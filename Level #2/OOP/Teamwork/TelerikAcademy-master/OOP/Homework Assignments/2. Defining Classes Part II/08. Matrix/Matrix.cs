﻿using System;
using System.Text;

public class Matrix<T>
    where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
{
    #region Fields & Properties

    private int rows;
    private int cols;
    private T[,] data;

    public int Rows
    {
        get
        {
            return rows;
        }
    }

    public int Cols
    {
        get
        {
            return cols;
        }
    }

    // indexer - use it to access this matrix as a 2D array
    public T this[int row, int col]
    {
        get
        {
            if (row >= 0 && row < rows && col >= 0 && col < cols)
            {
                return data[row, col];
            }
            else
            {
                throw new MatrixException(String.Format("Cell ({0}, {1}) is invalid.", row, col));
            }
        }
        set
        {
            if (row >= 0 && row < rows && col >= 0 && col < cols)
            {
                data[row, col] = value;
            }
            else
            {
                throw new MatrixException(String.Format("Cell ({0}, {1}) is invalid.", row, col));
            }
        }
    }

    #endregion

    #region Constructors

    public Matrix(int rows, int cols)
    {
        if (rows <= 0 || cols <= 0)
        {
            throw new MatrixException("Matrix dimensions must be positive integers.");
        }

        this.rows = rows;
        this.cols = cols;
        this.data = new T[rows, cols];
    }

    public Matrix(T[,] value)
    {
        if (value == null || value.GetLength(0) == 0 || value.GetLength(1) == 0)
        {
            throw new MatrixException("The two-dimensional initialization array must contain at least one item.");
        }

        this.rows = value.GetLength(0);
        this.cols = value.GetLength(1);
        data = (T[,])value.Clone();
    }

    #endregion

    #region Operators

    public static Matrix<T> operator -(Matrix<T> m)
    {
        return Multiply(-1, m);
    }

    public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
    {
        return Add(m1, m2);
    }

    public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
    {
        return Add(m1, -m2);
    }

    public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
    {
        return Multiply(m1, m2);
    }

    public static Matrix<T> operator *(int c, Matrix<T> m)
    {
        return Multiply(c, m);
    }

    public static Matrix<T> operator *(Matrix<T> m, int c)
    {
        return Multiply(c, m);
    }

    public static bool operator true(Matrix<T> m)
    {
        if (m == null || m.rows == 0 || m.cols == 0)
        {
            return false;
        }

        for (int row = 0; row < m.rows; row++)
        {
            for (int col = 0; col < m.cols; col++)
            {
                if (!m[row, col].Equals(default(T)))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static bool operator false(Matrix<T> m)
    {
        if (m == null || m.rows == 0 || m.cols == 0)
        {
            return true;
        }

        for (int row = 0; row < m.rows; row++)
        {
            for (int col = 0; col < m.cols; col++)
            {
                if (!m[row, col].Equals(default(T)))
                {
                    return false;
                }
            }
        }

        return true;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Transposes a matrix, i.e.
    /// turns the rows of a matrix A into columns of A-transposed,
    /// or equivalently turns the columns of A into rows of A-transposed.
    /// </summary>
    /// <returns></returns>
    public Matrix<T> Transpose()
    {
        Matrix<T> transposed = new Matrix<T>(cols, rows);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                transposed[col, row] = data[row, col];
            }
        }

        return transposed;
    }

    /// <summary>
    /// Returns a copy of this matrix.
    /// </summary>
    /// <returns></returns>
    public Matrix<T> Duplicate()
    {
        Matrix<T> copy = new Matrix<T>(rows, cols);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                copy[row, col] = data[row, col];
            }
        }

        return copy;
    }

    /// <summary>
    /// Returns the matrix contents as a two-dimensional array of T.
    /// </summary>
    /// <returns></returns>
    public T[,] GetData()
    {
        T[,] dataCopied = new T[rows, cols];
        Array.Copy(this.data, 0, dataCopied, 0, this.data.Length);

        return dataCopied;
    }

    /// <summary>
    /// Returns the matrix as a string.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return MatrixToString();
    }

    #endregion

    #region Private Methods

    private static Matrix<T> Multiply(Matrix<T> m1, Matrix<T> m2)
    {
        if (m1 == null || m2 == null)
        {
            throw new MatrixException("Matrices are not initialized.");
        }

        if (m1.cols != m2.rows)
        {
            throw new MatrixException("Invalid dimensions of matrices!");
        }

        try
        {
            Matrix<T> result = new Matrix<T>(m1.rows, m2.cols);

            for (int row = 0; row < result.rows; row++)
            {
                for (int col = 0; col < result.cols; col++)
                {
                    result[row, col] = default(T);
                    for (int i = 0; i < m1.cols; i++)
                    {
                        checked
                        {
                            result[row, col] += (dynamic)m1[row, i] * m2[i, col];
                        }
                    }
                }
            }

            return result;
        }
        catch (OverflowException ex)
        {
            throw new MatrixException("Multiplication resulted in an overflow.", ex);
        }
    }

    /// <summary>
    /// Multiplies the matrix by a constant.
    /// </summary>
    /// <param name="c"></param>
    /// <param name="m"></param>
    /// <returns></returns>
    private static Matrix<T> Multiply(int c, Matrix<T> m)
    {
        if (m == null)
        {
            throw new MatrixException("Matrix is not initialized.");
        }

        try
        {
            Matrix<T> result = new Matrix<T>(m.rows, m.cols);

            for (int row = 0; row < m.rows; row++)
            {
                for (int col = 0; col < m.cols; col++)
                {
                    checked
                    {
                        result[row, col] = (dynamic)m[row, col] * c;
                    }
                }
            }

            return result;
        }
        catch (OverflowException ex)
        {
            throw new MatrixException("Multiplication resulted in an overflow.", ex);
        }
    }

    private static Matrix<T> Add(Matrix<T> m1, Matrix<T> m2)
    {
        if (m1 == null || m2 == null)
        {
            throw new MatrixException("Matrices are not initialized.");
        }

        if (m1.rows != m2.rows || m1.cols != m2.cols)
        {
            throw new MatrixException("Matrices must have the same dimensions.");
        }

        try
        {
            Matrix<T> result = new Matrix<T>(m1.rows, m1.cols);

            for (int row = 0; row < result.rows; row++)
            {
                for (int col = 0; col < result.cols; col++)
                {
                    checked
                    {
                        result[row, col] = (dynamic)m1[row, col] + m2[row, col];
                    }
                }
            }

            return result;
        }
        catch (OverflowException ex)
        {
            throw new MatrixException("Addition resulted in an overflow.", ex);
        }
    }

    private string MatrixToStringSpecial()
    {
        int row;
        int col;
        int maxLength = Int32.MinValue;
        for (row = 0; row < rows; row++)
        {
            for (col = 0; col < cols; col++)
            {
                int length = data[row, col].ToString().Length;
                if (maxLength < length)
                {
                    maxLength = length;
                }
            }
        }

        StringBuilder stringBuilder = new StringBuilder();

        for (row = 0; row < rows; row++)
        {
            if (row == 0)
            {
                stringBuilder.Append("\n\t\u250C");
            }
            else if (row == rows - 1)
            {
                stringBuilder.Append("\t\u2514");
            }
            else
            {
                stringBuilder.Append("\t|");
            }

            for (col = 0; col < cols; col++)
            {
                stringBuilder.Append(data[row, col].ToString().PadLeft(maxLength + 1, ' '));
            }

            if (row == 0)
            {
                stringBuilder.AppendFormat("{0,2}\n", '\u2510');
            }
            else if (row == rows - 1)
            {
                stringBuilder.AppendFormat("{0,2}\n", '\u2518');
            }
            else
            {
                stringBuilder.AppendFormat("{0,2}\n", '|');
            }
        }

        return stringBuilder.ToString();
    }

    private string MatrixToString()
    {
        int row;
        int col;
        int maxLength = Int32.MinValue;
        for (row = 0; row < rows; row++)
        {
            for (col = 0; col < cols; col++)
            {
                int length = data[row, col].ToString().Length;
                if (maxLength < length)
                {
                    maxLength = length;
                }
            }
        }

        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append("\r\n");

        for (row = 0; row < rows; row++)
        {
            stringBuilder.Append("\t|");

            for (col = 0; col < cols; col++)
            {
                stringBuilder.Append(data[row, col].ToString().PadLeft(maxLength + 1, ' '));
            }

            stringBuilder.AppendFormat("{0,2}\r\n", '|');
        }

        return stringBuilder.ToString();
    }

    #endregion
}