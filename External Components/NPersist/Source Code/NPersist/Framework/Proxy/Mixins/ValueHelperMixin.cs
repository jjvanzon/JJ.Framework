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
using Puzzle.NPersist.Framework.Interfaces;

namespace Puzzle.NPersist.Framework.Proxy.Mixins
{
	public class ValueHelperMixin : IValueHelper
	{
		private Hashtable status = new Hashtable();

		public ValueHelperMixin(object target)
		{
		}

		public ValueHelperMixin()
		{
		}

		public object GetPropertyValue(string propertyName)
		{
			return status[propertyName];
		}

		public void SetPropertyValue(string propertyName, object value)
		{
			status[propertyName] = value;
		}

		public void RemovePropertyValues(string propertyName)
		{
			status.Remove(propertyName) ;
		}

		public bool HasPropertyValues()
		{
			return status.Count > 0;
		}

		public bool HasPropertyValues(string propertyName)
		{
			return status.ContainsKey(propertyName) ;
		}
	}
}
