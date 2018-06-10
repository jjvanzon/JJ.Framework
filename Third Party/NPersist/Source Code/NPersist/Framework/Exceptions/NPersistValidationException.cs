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
	public class NPersistValidationException : NPersistException
	{
		public NPersistValidationException() : base()
		{
		}

		public NPersistValidationException(string message) : base(message)
		{
		}

		public NPersistValidationException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public NPersistValidationException(string message, Exception innerException, object obj, string propertyName) : base(message, innerException, obj, propertyName)
		{
		}

		public NPersistValidationException(Exception innerException, object obj, string propertyName) : base(innerException.Message, innerException, obj, propertyName)
		{
		}

		public NPersistValidationException(Exception innerException, object obj, string propertyName, object limit, object actual, object value) : base(innerException.Message, innerException, obj, propertyName)
		{
			this.limit = limit; 
			this.actual = actual; 
			this.value = value; 
		}

		public NPersistValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		#region Property  Limit
		
		private object limit = null;
		
		public object Limit
		{
			get => this.limit;
		    set => this.limit = value;
		}
		
		#endregion

		#region Property  Actual
		
		private object actual = null;
		
		public object Actual
		{
			get => this.actual;
		    set => this.actual = value;
		}
		
		#endregion

		#region Property  Value
		
		private object value = null;
		
		public object Value
		{
			get => this.value;
		    set => this.value = value;
		}
		
		#endregion

	}
}