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

namespace Puzzle.NPersist.Framework.Aop.Mixins
{
	public class OriginalValueHelperMixin : IOriginalValueHelper
	{
		private Hashtable status = new Hashtable();

		public OriginalValueHelperMixin(object target)
		{
		}

		public OriginalValueHelperMixin()
		{
		}

		public object GetOriginalPropertyValue(string propertyName) => status[propertyName];

	    public void SetOriginalPropertyValue(string propertyName, object value) => status[propertyName] = value;

	    public void RemoveOriginalValues(string propertyName) => status.Remove(propertyName);

	    public bool HasOriginalValues() => status.Count > 0;

	    public bool HasOriginalValues(string propertyName) => status.ContainsKey(propertyName);
	}
}
