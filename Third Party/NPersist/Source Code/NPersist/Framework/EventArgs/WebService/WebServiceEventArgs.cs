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
using System.Collections;
using Puzzle.NPersist.Framework.Persistence;

namespace Puzzle.NPersist.Framework.EventArguments
{
	public class WebServiceEventArgs : EventArgs
	{
		private string m_Url;
		private string m_Method;
		private string m_DomainKey;
		private bool m_UseCompression;
		private Hashtable m_Parameters;

		public WebServiceEventArgs() : base()
		{
		}

		public WebServiceEventArgs(string url, string method, string domainKey, bool useCompression, Hashtable parameters) : base()
		{
			m_Url = url;
			m_Method = method;
			m_DomainKey = domainKey;
			m_UseCompression = useCompression;
			m_Parameters = parameters;
		}

		public string Url
		{
			get => m_Url;
		    set => m_Url = value;
		}

		public string Method
		{
			get => m_Method;
		    set => m_Method = value;
		}

		public string DomainKey
		{
			get => m_DomainKey;
		    set => m_DomainKey = value;
		}

		public bool UseCompression
		{
			get => m_UseCompression;
		    set => m_UseCompression = value;
		}

		public Hashtable Parameters
		{
			get => m_Parameters;
		    set => m_Parameters = value;
		}
	}
}