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

		public virtual IList CachedList
		{
			get { return cachedList; }
		}
	
		public virtual IList OriginalList
		{
			get { return originalList; }
		}
	
		public virtual IList FreshList
		{
			get { return freshList; }
		}

		public virtual PropertyStatus PropertyStatus
		{
			get { return propertyStatus; }
		}

		public virtual RefreshBehaviorType RefreshBehavior
		{
			get { return refreshBehavior; }
		}

		public virtual object Obj
		{
			get { return obj; }
		}

		public virtual string PropertyName
		{
			get { return propertyName; }
		}

	}
}
