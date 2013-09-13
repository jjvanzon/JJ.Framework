// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Collections;
using Puzzle.NCore.Framework.Collections;
using Puzzle.NPath.Framework.CodeDom;

namespace Puzzle.NPath.Framework
{
	public class SortOrderComparer : IComparer
	{
		private IObjectQueryEngine engine = null;
		private NPathOrderByClause orderBy = null;

		public SortOrderComparer(NPathOrderByClause orderBy, IObjectQueryEngine engine)
		{
			this.orderBy = orderBy;
			this.engine = engine;
		}

		#region IComparer Members

		private MultiHashtable lookup = new MultiHashtable();

		private object GetObjectValue(object item, IValue expression)
		{
			object value = lookup[item, expression];
			if (value == null)
			{
				value = engine.EvalValue(item, expression);
				lookup[item, expression] = value;
			}

			return value;
		}

		public int Compare(object x, object y)
		{
			if (x == y)
				return 0;

			if (x == null || y == null)
				throw new Exception("Values may not be null"); // do not localize

			foreach (SortProperty property in orderBy.SortProperties)
			{
				object xv = GetObjectValue(x, property.Expression);

				if (xv == null)
					return -1;

				object yv = GetObjectValue(y, property.Expression);

				if (yv == null)
					return 1;

				int res = Comparer.Default.Compare(xv, yv);

				//values are equal , compare the next property in the order by clause
				if (res == 0)
					continue;

				if (property.Direction == SortDirection.Desc)
					res = -res;

				return res;
			}

			return 0;
		}

		#endregion
	}
}