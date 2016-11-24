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
using Puzzle.NPersist.Framework.Persistence;

namespace Puzzle.NPersist.Framework.EventArguments
{
	public class ExceptionCancelEventArgs : EventArgs
	{
		private bool m_Cancel = false;
		private Exception m_Exception;

		public ExceptionCancelEventArgs() : base()
		{
		}

		public ExceptionCancelEventArgs(Exception exception) : base()
		{
			m_Exception = exception;
		}

		public Exception Exception
		{
			get { return m_Exception; }
			set { m_Exception = value; }
		}

		
		public bool Cancel
		{
			get { return m_Cancel; }
			set { m_Cancel = value; }
		}

	}
}