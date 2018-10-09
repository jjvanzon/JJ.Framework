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
	public class NPathPropertyPathReference
	{
		#region Public Property PropertyPath

		private string propertyPath;

		public string PropertyPath
		{
			get => this.propertyPath;
		    set => this.propertyPath = value;
		}

		#endregion

		#region Public Property ReferenceLocation

		private NPathPropertyPathReferenceLocation referenceLocation;

		public NPathPropertyPathReferenceLocation ReferenceLocation
		{
			get => this.referenceLocation;
		    set => this.referenceLocation = value;
		}

		#endregion
	}

	public enum NPathPropertyPathReferenceLocation
	{
		SelectClause,
		WhereClause,
	}
}