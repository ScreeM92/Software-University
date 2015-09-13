using System;
using System.Text;

public static class SubstringExtension
{
    public static StringBuilder Substring(this StringBuilder stringBuilder, int startIndex)
    {
        ArgumentOutOfRangeException outOfRangeException = new ArgumentOutOfRangeException("No such index!", "You must enter positive number smaller than the size of the collection");
        if (startIndex < 0 || startIndex >= stringBuilder.Length)
        {
            throw outOfRangeException;
        }

        string build = stringBuilder.ToString().Substring(startIndex);

        stringBuilder.Clear();
        stringBuilder.Append(build);

        return stringBuilder;
    }
    
    public static StringBuilder Substring(this StringBuilder stringBuilder, int startIndex, int length)
    {
        ArgumentOutOfRangeException outOfRangeException = new ArgumentOutOfRangeException("No such index!", "You must enter positive number smaller than the size of the collection");
        if (startIndex < 0 || startIndex >= stringBuilder.Length)
        {
            throw outOfRangeException;
        }
        if (startIndex + length >= stringBuilder.Length)
        {
            throw outOfRangeException;
        }

        string build = stringBuilder.ToString().Substring(startIndex, length);

        stringBuilder.Clear();
        stringBuilder.Append(build);

        return stringBuilder;
    }
}

