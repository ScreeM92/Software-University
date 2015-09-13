/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System.Collections.Generic;

namespace NGenerics.Util
{
    /// <summary>
    /// Utility class for swapping values
    /// </summary>
    internal static class Swapper
    {

        /// <summary>
        /// Swaps items in the specified positions in the given list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="pos1">The position of the first item.</param>
        /// <param name="pos2">The position of the second item.</param>
        internal static void Swap<T>(IList<T> list, int pos1, int pos2)
        {
            var tmp = list[pos1];
            list[pos1] = list[pos2];
            list[pos2] = tmp;
        }
    }
}
