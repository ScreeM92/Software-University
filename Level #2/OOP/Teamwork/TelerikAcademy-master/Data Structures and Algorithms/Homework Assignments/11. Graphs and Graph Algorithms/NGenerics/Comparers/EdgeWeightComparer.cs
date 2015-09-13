/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;

namespace NGenerics.Comparers
{
    /// <summary>
    /// A comparer for comparing weights on graph edges.
	/// </summary>
	/// <typeparam name="T">The type of the objects to compare.</typeparam>
    [Serializable]
    public sealed class EdgeWeightComparer<T> : IComparer<Edge<T>>
    {

        #region IComparer<Edge<T>> Members

		/// <inheritdoc />
        public int Compare(Edge<T> x, Edge<T> y)
        {
            return x.Weight.CompareTo(y.Weight);
        }

        #endregion
    }
}
