using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

    public static class StringBuilder
    {
        public static string Substring(this StringBuilder stringBuilder, int startIndex, int length)
        {
            return stringBuilder.ToString().Substring(startIndex, length);
        }

        //public static StringBuilder RemoveText(this StringBuilder sb, string text)
        //{
        //    return sb.Replace(text, string.Empty);
        //}

        public static StringBuilder RemoveText(this StringBuilder sb, string text)
        {
            return sb.Replace(text, string.Empty);
        }

        public static StringBuilder AppendAll<T>(this StringBuilder stringBuilder, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                stringBuilder.Append(item);
            }
            return stringBuilder;
        }   
}
