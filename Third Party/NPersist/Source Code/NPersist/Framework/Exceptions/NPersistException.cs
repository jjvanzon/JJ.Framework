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
	public class NPersistException : Exception
	{
		public NPersistException() : base()
		{
		}

		public NPersistException(object obj) : base() => this.obj = obj;

	    public NPersistException(object obj, string propertyName) : base()
		{
			this.obj = obj;
			this.propertyName = propertyName;
		}

		public NPersistException(string message) : base(message)
		{
		}

		public NPersistException(string message, object obj) : base(message) => this.obj = obj;

	    public NPersistException(string message, object obj, string propertyName) : base(message)
		{
			this.obj = obj;
			this.propertyName = propertyName;
		}

		public NPersistException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public NPersistException(string message, Exception innerException, object obj) : base(message, innerException) => this.obj = obj;

	    public NPersistException(string message, Exception innerException, object obj, string propertyName) : base(message, innerException)
		{
			this.obj = obj;
			this.propertyName = propertyName;
		}

		public NPersistException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}


		#region Property  Obj
		
		private object obj = null;
		
		public object Obj
		{
			get => this.obj;
		    set => this.obj = value;
		}
		
		#endregion

		#region Property  PropertyName
		
		private string propertyName = "";
		
		public string PropertyName
		{
			get => this.propertyName;
		    set => this.propertyName = value;
		}
		
		#endregion
	}
}