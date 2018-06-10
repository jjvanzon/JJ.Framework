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
	public class RefreshException : ConcurrencyException
	{
		public RefreshException() : base()
		{
		}

		public RefreshException(string message, object obj, string propertyName) : base(message, obj, propertyName)
		{
		}

		public RefreshException(string message, Exception innerException, object obj, string propertyName) : base(message, innerException, obj, propertyName)
		{
		}

		public RefreshException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		
		public RefreshException(string message, object cachedValue, object freshValue, object obj, string propertyName) : base(message, obj, propertyName)
		{
			this.cachedValue = cachedValue;
			this.freshValue = freshValue;
		}

		#region Property  CachedValue
		
		private object cachedValue;
		
		public object CachedValue
		{
			get => this.cachedValue;
		    set => this.cachedValue = value;
		}
		
		#endregion

		#region Property  FreshValue
		
		private object freshValue;
		
		public object FreshValue
		{
			get => this.freshValue;
		    set => this.freshValue = value;
		}
		
		#endregion

	}
}

