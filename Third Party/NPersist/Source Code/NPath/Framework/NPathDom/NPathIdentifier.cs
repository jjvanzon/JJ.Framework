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
	public class NPathIdentifier : IValue
	{
		#region Property PATH

		private string path;

		public virtual string Path
		{
			get { return path; }
			set
			{
				value = value.Replace("@", ""); //ignore escape chars
				path = value;
				IsWildcard = path.EndsWith("*") || path.EndsWith("¤");
			}
		}

		#endregion

		#region Property ISNEGATIVE

		private bool isNegative;

		public virtual bool IsNegative
		{
			get { return isNegative; }
			set { isNegative = value; }
		}

		#endregion

		#region Public Property ReferenceLocation

		private NPathPropertyPathReferenceLocation referenceLocation;

		public NPathPropertyPathReferenceLocation ReferenceLocation
		{
			get { return this.referenceLocation; }
			set { this.referenceLocation = value; }
		}

		#endregion

		public bool IsWildcard = false;

	}
}