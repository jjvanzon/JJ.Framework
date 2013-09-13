// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;

namespace Puzzle.NPersist.Framework.EventArguments
{
	public class ObjectEventArgs : EventArgs
	{
		private object m_EventObject;

		public ObjectEventArgs() : base()
		{
		}

		public ObjectEventArgs(object obj) : base()
		{
			m_EventObject = obj;
		}

		public object EventObject
		{
			get { return m_EventObject; }
		}
	}
}