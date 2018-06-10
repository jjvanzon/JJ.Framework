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

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for ReadOnlyObjectCache.
	/// </summary>
	public class ReadOnlyObjectCache
	{
		public ReadOnlyObjectCache()
		{
		}

		#region Property  ObjectCache
		
		private Hashtable objectCache = new Hashtable() ;
		
		public Hashtable ObjectCache => this.objectCache;

	    #endregion

		#region Property  MaxSize
		
		private long maxSize = -1;
		
		public long MaxSize
		{
			get => this.maxSize;
		    set => this.maxSize = value;
		}
		
		#endregion

		#region Property  CreatedTime
		
		private DateTime createdTime = DateTime.Now;
		
		public DateTime CreatedTime
		{
			get => this.createdTime;
		    set => this.createdTime = value;
		}
		
		#endregion
	}
}
