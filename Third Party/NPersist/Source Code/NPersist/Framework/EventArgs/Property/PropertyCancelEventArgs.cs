using System.Diagnostics;
// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.EventArguments
{
	public class PropertyCancelEventArgs : PropertyEventArgs
	{
		private bool m_Cancel;

		public PropertyCancelEventArgs() : base()
		{
		}

		public PropertyCancelEventArgs(object obj, string propertyName) : base(obj, propertyName)
		{
		}

		//[DebuggerStepThrough()]
		public PropertyCancelEventArgs(object obj, string propertyName, object newValue, object value, bool isNull) : base(obj, propertyName, newValue, value, isNull)
		{
		}

		public bool Cancel
		{
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			get { return m_Cancel; }
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			set { m_Cancel = value; }
		}
	}
}