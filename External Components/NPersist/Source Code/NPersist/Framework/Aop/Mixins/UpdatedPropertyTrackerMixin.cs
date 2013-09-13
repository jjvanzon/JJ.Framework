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
	public class UpdatedPropertyTrackerMixin : IUpdatedPropertyTracker
	{
		private Hashtable status = new Hashtable();

		public UpdatedPropertyTrackerMixin(object target)
		{
		}

		public UpdatedPropertyTrackerMixin()
		{
		}

		public bool GetUpdatedStatus(string propertyName)
		{
			if (status[propertyName] == null)
				return false;

			return (bool)status[propertyName];
		}

		public void SetUpdatedStatus(string propertyName, bool value)
		{
			status[propertyName] = value;
		}

		public void ClearUpdatedStatuses()
		{		
			status.Clear() ;
		}
	}
}
