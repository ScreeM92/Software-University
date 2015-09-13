using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLINQExtensionMethods
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.Where(x => !predicate(x));
        } 
   
        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count)
        {
            var enumerable = collection as IList<T> ?? collection.ToList();
            var list = enumerable.ToList();
            for (int i = 0; i < count; i++)
            {
                list.AddRange(enumerable);
            }
            return list as IEnumerable<T>;
        } 

        public static IEnumerable<string> WhereEndsWith(this IEnumerable<string> collection, IEnumerable<string> suffixes)
        {
            return collection.Where(item => suffixes.Any(item.EndsWith) );
        } 

    }
}
