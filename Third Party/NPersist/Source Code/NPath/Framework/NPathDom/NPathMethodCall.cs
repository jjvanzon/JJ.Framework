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
	public class NPathMethodCall : IValue
	{
		#region Public Property PropertyPath

		private NPathIdentifier propertyPath;

		public NPathIdentifier PropertyPath
		{
			get { return this.propertyPath; }
			set { this.propertyPath = value; }
		}

		#endregion

		#region Public Property MethodName

		private string methodName;

		public string MethodName
		{
			get { return this.methodName; }
			set { this.methodName = value; }
		}

		#endregion

		#region Public Property Parameters

		private IList parameters = new ArrayList();

		public IList Parameters
		{
			get { return this.parameters; }
		}

		#endregion
	}
}