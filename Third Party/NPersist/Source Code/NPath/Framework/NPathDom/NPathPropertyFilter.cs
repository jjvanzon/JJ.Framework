// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPath.Framework.CodeDom
{
	public class NPathPropertyFilter : IValue
	{
		#region Property PATH

		private string path;

		public virtual string Path
		{
			get => path;
		    set => path = value;
		}

		#endregion

		#region Property FILTER

		private NPathBracketGroup filter;

		public virtual NPathBracketGroup Filter
		{
			get => filter;
		    set => filter = value;
		}

		#endregion
	}
}