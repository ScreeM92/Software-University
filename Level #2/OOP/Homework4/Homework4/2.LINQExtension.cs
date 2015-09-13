using System;
using System.Collections.Generic;
    public static class LINQExtension
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Predicate<T> predicate)
        {
            foreach (var item in collection)
            {
                if(!predicate(item))
                {
                    yield return item;
                }
            }
        }
    }

