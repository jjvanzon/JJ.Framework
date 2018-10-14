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
using System.Runtime.Serialization;

namespace Puzzle.NPersist.Framework.Exceptions
{
	public class CompositeException : NPersistException
	{
		public CompositeException() : base()
		{
		}

		public CompositeException(string message) : base(message)
		{
		}

		public CompositeException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public CompositeException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		public CompositeException(IList innerExceptions) : base("One or more exceptions were encountered during an operation that required atomicity. Please inspect the InnerExceptions property of this exception to see the exceptions that were encountered.") => this.innerExceptions = innerExceptions;

	    public CompositeException(string message, IList innerExceptions) : base(message) => this.innerExceptions = innerExceptions;

	    #region Property  InnerExceptions
		
		private IList innerExceptions = null ;
		
		public IList InnerExceptions
		{
			get => this.innerExceptions;
		    set => this.innerExceptions = value;
		}
		
		#endregion

	}
}
