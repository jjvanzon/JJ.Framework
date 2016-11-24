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
using System.EnterpriseServices;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Persistence;

namespace Puzzle.NPersist.Framework.TransactionalCache
{
	/// <summary>
	/// Summary description for TransactionalObjectCacheManager.
	/// </summary>
	public class TransactionalObjectCacheManager : ContextChild, IObjectCacheManager
	{
		public TransactionalObjectCacheManager()
		{
		}

		public static TransactionalObjectCacheList objectCacheList = new TransactionalObjectCacheList() ;

		protected IObjectCache nonTransactionalObjectCache = null;

		public IObjectCache GetObjectCache()
		{
			if (nonTransactionalObjectCache == null)
			{
				if (ContextUtil.IsInTransaction)
				{
					return objectCacheList.GetObjectCache(); 							
				}
				else
				{
					return GetNonTransactionalCache(); 				
				}				
			}
			else
			{
				return GetNonTransactionalCache(); 				
			}
		}

		protected IObjectCache GetNonTransactionalCache()
		{
			if (nonTransactionalObjectCache == null)
				nonTransactionalObjectCache = new ObjectCache(); 
			return nonTransactionalObjectCache;
		}
	}
}
