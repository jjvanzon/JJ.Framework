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
	public class NPathSelectClause
	{
		#region Property SELECTFIELDS

		private IList selectFields;

		public virtual IList SelectFields
		{
			get => selectFields;
		    set => selectFields = value;
		}

		#endregion

		private bool distinct;

		public bool Distinct
		{
			get => this.distinct;
		    set => this.distinct = value;
		}

		private bool hasTop;

		public bool HasTop
		{
			get => this.hasTop;
		    set => this.hasTop = value;
		}

		private long top;

		public long Top
		{
			get => this.top;
		    set => this.top = value;
		}

		private bool percent;

		public bool Percent
		{
			get => this.percent;
		    set => this.percent = value;
		}

		private bool withTies;

		public bool WithTies
		{
			get => this.withTies;
		    set => this.withTies = value;
		}

		public NPathSelectClause() => selectFields = new ArrayList();
	}
}