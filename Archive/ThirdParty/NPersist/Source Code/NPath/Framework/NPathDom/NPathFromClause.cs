// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Collections;

namespace Puzzle.NPath.Framework.CodeDom
{
	public class NPathFromClause
	{
		#region Property CLASSES

		private IList classes;

		public virtual IList Classes
		{
			get => classes;
		    set => classes = value;
		}

		#endregion

		public NPathFromClause() => classes = new ArrayList();
	}
}