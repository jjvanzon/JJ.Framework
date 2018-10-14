using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;

namespace Puzzle.NAspect.Visualization.Sorting
{
    public class AssemblyComparer : IComparer
    {
        #region IComparer Members

        public int Compare(object x, object y)
        {
            Assembly a1 = x as Assembly;
            Assembly a2 = y as Assembly;
            if (x == null)
                throw new Exception("Object is not of type Assembly");
            if (y == null)
                throw new Exception("Object is not of type Assembly");

            return a1.GetName().Name.CompareTo(a2.GetName().Name);
        }

        #endregion
    }
}
