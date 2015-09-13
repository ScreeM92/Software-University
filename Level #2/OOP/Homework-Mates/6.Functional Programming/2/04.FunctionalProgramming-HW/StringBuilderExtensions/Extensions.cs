namespace StringBuilderExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Extensions
    {
        public static String Substring(this StringBuilder stringBuilder, int startIndex, int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", "Length should be positive.");
            }

            if (startIndex >= stringBuilder.Length || startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("startIndex", "Start index should be in the range [0,stringBuilder.Length - 1].");
            }

            if ((startIndex + length) > stringBuilder.Length)
            {
                throw new ArgumentOutOfRangeException("length", "Sum of length and startIndex should not be greater than stringBuilder.Length.");
            }

            String result = String.Empty;
            for (int i = startIndex; i < startIndex + length; i++)
            {
                result += stringBuilder[i];
            }

            return result;
        }

        public static StringBuilder RemoveText(this StringBuilder stringBuilder, string text)
        {
            while (true)
            {
                int index = stringBuilder.ToString().IndexOf(text, System.StringComparison.CurrentCultureIgnoreCase);
                if (index == -1)
                {
                    return stringBuilder;
                }

                stringBuilder.Remove(index, text.Length);
            }
        }

        public static void AppendAll<T>(this StringBuilder stringBuilder, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                stringBuilder.Append(item.ToString());
            }
        }
    }
}
