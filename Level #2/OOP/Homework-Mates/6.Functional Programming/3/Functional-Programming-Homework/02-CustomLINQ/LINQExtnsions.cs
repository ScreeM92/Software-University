using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_CustomLINQ
{
    public static class LINQExtnsions
{
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.Where(c => predicate(c));
        }

        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count)
        {
            var coll = collection.ToList();
            for (int i = 0; i < count - 1; i++)
            {
                coll.AddRange(collection);
            }
            return coll;
        }

        public static IEnumerable<string> WhereEndsWith(this IEnumerable<string> collection,
            IEnumerable<string> suffixes)
        {
            var coll = new List<string>();
            foreach (var item in collection)
            {
                foreach (var suff in suffixes)
                {
                    if (item.EndsWith(suff))
                    {
                        coll.Add(item);
                    }
                }
            }
            return coll;
        }
    }
}
