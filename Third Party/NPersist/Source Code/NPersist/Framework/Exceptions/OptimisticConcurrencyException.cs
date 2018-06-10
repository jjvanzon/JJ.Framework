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
	public class OptimisticConcurrencyException : ConcurrencyException
	{
		public OptimisticConcurrencyException() : base()
		{
		}

		public OptimisticConcurrencyException(string message, object obj) : base(message, obj, "")
		{
		}

		public OptimisticConcurrencyException(string message, object obj, string propertyName) : base(message, obj, propertyName)
		{
		}

//		public OptimisticConcurrencyException(string message, Exception innerException) : base(message, innerException)
//		{
//		}

		public OptimisticConcurrencyException(string message, Exception innerException, object obj) : base(message, innerException, obj, "")
		{
		}

		public OptimisticConcurrencyException(string message, Exception innerException, object obj, string propertyName) : base(message, innerException, obj, propertyName)
		{
		}

		public OptimisticConcurrencyException(string message, object cachedValue, object freshValue, object obj, string propertyName) : base(message, obj, propertyName)
		{
			this.cachedValue = cachedValue;
			this.freshValue = freshValue;
		}

		public OptimisticConcurrencyException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
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
