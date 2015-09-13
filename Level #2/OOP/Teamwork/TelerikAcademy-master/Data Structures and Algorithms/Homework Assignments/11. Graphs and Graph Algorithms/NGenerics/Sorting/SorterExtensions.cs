﻿/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System;
using System.Collections.Generic;
using NGenerics.Util;

namespace NGenerics.Sorting
{
    /// <summary>
    /// Provides extensions to lists.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="sorter">The sorter.</param>
        public static void Sort<TElement>(this IList<TElement> list, ISorter<TElement> sorter)
        {
            Guard.ArgumentNotNull(sorter, "sorter");
            sorter.Sort(list);
        }

        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="sorter">The sorter.</param>
        /// <param name="sortOrder">The sort order.</param>
        public static void Sort<TElement>(this IList<TElement> list, ISorter<TElement> sorter, SortOrder sortOrder)
        {
            Guard.ArgumentNotNull(sorter, "sorter");
            sorter.Sort(list, sortOrder);
        }
        
        /// <summary>
        /// Sorts using the specified sorter.
        /// </summary>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <param name="list">The list to sort.</param>
        /// <param name="sorter">The sorter to use in the sorting process.</param>
        /// <param name="comparison">The comparison.</param>
        /// <exception cref="ArgumentNullException"><paramref name="sorter"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparison"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        public static void Sort<TElement>(this IList<TElement> list, IComparisonSorter<TElement> sorter, Comparison<TElement> comparison)
        {
            Guard.ArgumentNotNull(sorter, "sorter");
            sorter.Sort(list, comparison);
        }

        /// <summary>
        /// Sorts using the specified sorter.
        /// </summary>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="sorter">The sorter to use in the sorting process.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException"><paramref name="sorter"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        public static void Sort<TElement>(this IList<TElement> list, IComparisonSorter<TElement> sorter, IComparer<TElement> comparer)
        {
            Guard.ArgumentNotNull(sorter, "sorter");
            sorter.Sort(list, comparer);
        }
    }
}