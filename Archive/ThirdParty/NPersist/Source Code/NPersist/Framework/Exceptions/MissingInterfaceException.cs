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
	public class MissingInterfaceException : NPersistException
	{
		public MissingInterfaceException() : base()
		{
		}

		public MissingInterfaceException(string message) : base(message)
		{
		}

		public MissingInterfaceException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public MissingInterfaceException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}