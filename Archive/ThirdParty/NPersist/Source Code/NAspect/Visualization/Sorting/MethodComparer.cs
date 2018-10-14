using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;

namespace Puzzle.NAspect.Visualization.Sorting
{
    public class MethodComparer : IComparer
    {
        #region IComparer Members

        public int Compare(object x, object y)
        {
            MethodBase m1 = x as MethodBase;
            MethodBase m2 = y as MethodBase;
            if (x == null)
                throw new Exception("Object is not of type MethodBase");
            if (y == null)
                throw new Exception("Object is not of type MethodBase");

            return m1.Name.CompareTo(m2.Name);
        }

        #endregion
    }
}
