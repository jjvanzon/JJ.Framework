using System;
using System.Collections;
using System.Data;
using Puzzle.NPersist.Framework.Enumerations;
// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for CachedListUpdate.
	/// </summary>
	public class CachedListUpdate
	{
		public CachedListUpdate()
		{
		}

		public CachedListUpdate(IList cachedList, IList originalList, object obj, string propertyName, PropertyStatus propertyStatus, RefreshBehaviorType refreshBehavior)
		{
			this.cachedList = cachedList;
			this.originalList = originalList;
			this.obj = obj;
			this.propertyName = propertyName;
			this.propertyStatus = propertyStatus;
			this.refreshBehavior = refreshBehavior;
		}

		private IList cachedList;
		private IList originalList;
		private IList freshList = new ArrayList();
		private PropertyStatus propertyStatus;
		private RefreshBehaviorType refreshBehavior;
		private object obj;
		private string propertyName;

		public virtual IList CachedList => cachedList;

	    public virtual IList OriginalList => originalList;

	    public virtual IList FreshList => freshList;

	    public virtual PropertyStatus PropertyStatus => propertyStatus;

	    public virtual RefreshBehaviorType RefreshBehavior => refreshBehavior;

	    public virtual object Obj => obj;

	    public virtual string PropertyName => propertyName;
	}
}
