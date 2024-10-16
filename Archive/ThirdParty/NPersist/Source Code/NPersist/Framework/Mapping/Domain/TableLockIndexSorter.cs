// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Xml.Serialization;
using Puzzle.NPersist.Framework.Attributes;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping.Visitor;

namespace Puzzle.NPersist.Framework.Mapping
{
	public class TableLockIndexSorter : IComparer
	{
        #region IComparer Members

        public int Compare(object x, object y)
        {
            ITableMap tbl1 = x as ITableMap;
            if (tbl1 == null)
                throw new Exception(String.Format("Can only compare instances of ITableMap, passed in parameter was {0}!", x.GetType().ToString()));
            ITableMap tbl2 = y as ITableMap;
            if (tbl2 == null)
                throw new Exception(String.Format("Can only compare instances of ITableMap, passed in parameter was {0}!", y.GetType().ToString()));

            return tbl1.GetLockIndex().CompareTo(tbl2.GetLockIndex());
        }

        #endregion
    }
}
