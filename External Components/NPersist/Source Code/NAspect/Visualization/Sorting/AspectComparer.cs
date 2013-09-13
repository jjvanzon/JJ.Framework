using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Puzzle.NAspect.Framework.Aop;

namespace Puzzle.NAspect.Visualization.Sorting
{
    public class AspectComparer : IComparer
    {
        #region IComparer Members

        public int Compare(object x, object y)
        {
            IGenericAspect a1 = x as IGenericAspect;
            IGenericAspect a2 = y as IGenericAspect;
            if (x == null)
                throw new Exception("Object is not of type IGenericAspect");
            if (y == null)
                throw new Exception("Object is not of type IGenericAspect");

            return a1.Name.CompareTo(a2.Name);
        }

        #endregion
    }
}
