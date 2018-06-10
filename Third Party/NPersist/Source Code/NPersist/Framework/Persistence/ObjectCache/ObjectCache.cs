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
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Interfaces;

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for ObjectCache.
	/// </summary>
	public class ObjectCache : IObjectCache
	{
		public ObjectCache()
		{
		}

		#region Property  LoadedObjects
		
		private Hashtable loadedObjects = new Hashtable() ;
		
		public Hashtable LoadedObjects
		{
			get => this.loadedObjects;
		    set => this.loadedObjects = value;
		}
		
		#endregion

		#region Property  UnLoadedObjects
		
		private Hashtable unLoadedObjects = new Hashtable() ;
		
		public Hashtable UnloadedObjects
		{
			get => this.unLoadedObjects;
		    set => this.unLoadedObjects = value;
		}
		
		#endregion

		#region Property  AllObjects
		
		private IList allObjects = new ArrayList() ;
		
		public IList AllObjects
		{
			get => this.allObjects;
		    set => this.allObjects = value;
		}
		
		#endregion

        public void Clear()
        {
            ClearContextChildren();
            this.loadedObjects.Clear();
            this.unLoadedObjects.Clear();
            this.allObjects.Clear();
        }

        private void ClearContextChildren()
        {
            foreach (IInterceptable interceptable in allObjects)
                interceptable.SetInterceptor(null);
        }
    }
}
