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
	public class EditException : NPersistException
	{
		public EditException() : base()
		{
		}

		public EditException(string message) : base(message)
		{
		}

		public EditException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public EditException(SerializationInfo info, StreamingContext context) : base(info, context)
		{

		}
	}
}