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
	public class NPathFunction : IValue
	{
		#region Property DISTINCT

		private bool distinct;

		public virtual bool Distinct
		{
			get => distinct;
		    set => distinct = value;
		}

		#endregion

		#region Property EXPRESSION

		private IValue expression;

		public virtual IValue Expression
		{
			get => expression;
		    set => expression = value;
		}

		#endregion

		#region Property ISNEGATIVE

		private bool isNegative;

		public virtual bool IsNegative
		{
			get => isNegative;
		    set => isNegative = value;
		}

		#endregion
	}
}