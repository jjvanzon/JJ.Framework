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
using System.Reflection;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Aop;

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for ObjectFactory.
	/// </summary>
	public class ObjectFactory : ContextChild, IObjectFactory
	{
		public ObjectFactory() 
		{
		}

		public object CreateInstance(Type type, params object[] ctorParams)
		{
			if (type == null)
				throw new NullReferenceException("type may not be null");

			if (ctorParams == null)
				throw new NullReferenceException("ctorParams may not be null");

			return Activator.CreateInstance(type, ctorParams);
		}
	}
}
