// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Collections;
using Puzzle.NPersist.Framework.Persistence;

namespace Puzzle.NPersist.Framework.EventArguments
{
	public class WebServiceCancelEventArgs : WebServiceEventArgs
	{
		private bool m_Cancel;

		public WebServiceCancelEventArgs() : base()
		{
		}

		public WebServiceCancelEventArgs(string url, string method, string domainKey, bool useCompression, Hashtable parameters) : base(url, method, domainKey, useCompression, parameters)
		{
		}

		public bool Cancel
		{
			get => m_Cancel;
		    set => m_Cancel = value;
		}
	}
}