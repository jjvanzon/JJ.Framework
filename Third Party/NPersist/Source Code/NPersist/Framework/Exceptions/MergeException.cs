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
using System.Runtime.Serialization;

namespace Puzzle.NPersist.Framework.Exceptions
{
	public class MergeException : ConcurrencyException
	{
		public MergeException() : base()
		{
		}

		public MergeException(string message, object obj, string propertyName) : base(message, obj, propertyName)
		{
		}

		public MergeException(string message, Exception innerException, object obj, string propertyName) : base(message, innerException, obj, propertyName)
		{
		}

		public MergeException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		public MergeException(string message, object cachedValue, object mergeValue, object cached, object merge, string propertyName, bool isOriginal) : base(message, merge, propertyName)
		{
			this.cachedValue = cachedValue;
			this.cachedObject = cached;
			this.mergeValue = mergeValue;
			this.mergeObject = merge;
			this.isOriginalValue = isOriginal;
		}		


		#region Property  CachedValue
		
		private object cachedValue;
		
		public object CachedValue
		{
			get => this.cachedValue;
		    set => this.cachedValue = value;
		}
		
		#endregion

		#region Property  MergeValue
		
		private object mergeValue;
		
		public object MergeValue
		{
			get => this.mergeValue;
		    set => this.mergeValue = value;
		}
		
		#endregion

		#region Property  CachedObject
		
		private object cachedObject;
		
		public object CachedObject
		{
			get => this.cachedObject;
		    set => this.cachedObject = value;
		}
		
		#endregion

		#region Property  CachedObject
		
		private object mergeObject;
		
		public object MergeObject
		{
			get => this.mergeObject;
		    set => this.mergeObject = value;
		}
		
		#endregion

		#region Property  IsOriginalValue
		
		private bool isOriginalValue;
		
		public bool IsOriginalValue
		{
			get => this.isOriginalValue;
		    set => this.isOriginalValue = value;
		}
		
		#endregion

	}
}

