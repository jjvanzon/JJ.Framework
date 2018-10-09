using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Puzzle.NAspect.Visualization.Sorting
{
    public class TypeComparer : IComparer
    {
        #region IComparer Members

        public int Compare(object x, object y)
        {
            Type t1 = x as Type;
            Type t2 = y as Type;
            if (x == null)
                throw new Exception("Object is not of type Type");
            if (y == null)
                throw new Exception("Object is not of type Type");

            return t1.FullName.CompareTo(t2.FullName);
        }

        #endregion

    }
}
