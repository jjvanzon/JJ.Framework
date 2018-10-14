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
	public class NPathSelectField
	{
		#region Property EXPRESSION

		private IValue expression;

		public virtual IValue Expression
		{
			get => expression;
		    set => expression = value;
		}

		#endregion

		#region Property ALIAS

		private string alias;

		public virtual string Alias
		{
			get => alias;
		    set => alias = value;
		}

		#endregion
	}
}