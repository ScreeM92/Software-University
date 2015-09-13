namespace StringBuilderExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class SBExtensions
    {
        public static string Substring(this StringBuilder sb, int startIndex, int length)
        {
            int endIndex = length + startIndex;
            if (startIndex < 0 || endIndex > sb.ToString().Length)
            {
                throw new ArgumentOutOfRangeException("Out of Range");
            } 
            return sb.ToString().Substring(startIndex, length);
        }

        public static StringBuilder RemoveText(this StringBuilder sb, string text)
        {
            return sb.Replace(text, string.Empty);
        }

        public static StringBuilder AppendAll<T>(this StringBuilder sb, IEnumerable<T> items)
        {
            return sb.Append(string.Join(string.Empty, items));
        }
    }
}



