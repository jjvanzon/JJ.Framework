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
using Puzzle.NPersist.Framework.Interfaces;

namespace Puzzle.NPersist.Framework.Proxy.Mixins
{
	public class NullValueHelperMixin : INullValueHelper
	{
		private Hashtable status = new Hashtable();

		public NullValueHelperMixin(object target)
		{
		}

		public NullValueHelperMixin()
		{
		}

		public bool GetNullValueStatus(string propertyName)
		{
			if (status[propertyName] == null)
				return false;

			return (bool)status[propertyName];
		}

		public void SetNullValueStatus(string propertyName, bool value)
		{
			status[propertyName] = value;
		}

		//change to "ClearNullValueStatus" ?
		public void SetNullValueStatus(bool value)
		{
			status.Clear() ;
		}
	}
}
