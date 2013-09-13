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

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for ReadOnlyClone.
	/// </summary>
	public class ReadOnlyClone
	{
		public ReadOnlyClone()
		{

		}

		#region Property  Key
		
		private string key = "";
		
		public string Key
		{
			get { return this.key; }
			set { this.key = value; }
		}
		
		#endregion		

		#region Property  Identity
		
		private string identity = "";
		
		public string Identity
		{
			get { return this.identity; }
			set { this.identity = value; }
		}
		
		#endregion		

		#region Property  Type
		
		private string type = "";
		
		public string Type
		{
			get { return this.type; }
			set { this.type = value; }
		}
		
		#endregion

		#region Property  PropertyValues
		
		private Hashtable propertyValues = new Hashtable() ;
		
		public Hashtable PropertyValues
		{
			get { return this.propertyValues; }
			set { this.propertyValues = value; }
		}
		
		#endregion

		#region Property  NullValueStatuses
		
		private Hashtable nullValueStatuses = new Hashtable() ;
		
		public Hashtable NullValueStatuses
		{
			get { return this.nullValueStatuses; }
			set { this.nullValueStatuses = value; }
		}
		
		#endregion

		#region Property  LoadedTime
		
		private DateTime loadedTime = DateTime.Now ;
		
		public DateTime LoadedTime
		{
			get { return this.loadedTime; }
			set { this.loadedTime = value; }
		}
		
		#endregion

		#region Property  UseCount
		
		private long useCount = 0;
		
		public long UseCount
		{
			get { return this.useCount; }
			set { this.useCount = value; }
		}

		public void IncUseCount()
		{
			if (!this.useCount.Equals(Int64.MaxValue))
				this.useCount++;
		}
		
		#endregion
	}
}
