// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *
using System;
using Puzzle.NAspect.Framework;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Persistence;

namespace Puzzle.NPersist.Framework.Aop
{
	/// <summary>
	/// Summary description for ObjectFactory.
	/// </summary>
	public class AopObjectFactory : ContextChild, IObjectFactory
	{
		private IEngine aopEngine;

		public AopObjectFactory() => aopEngine = ApplicationContext.Configure();

	    public object CreateInstance(Type type, object[] ctorParams)
		{
			if (type == null)
				throw new NullReferenceException("type may not be null");

			if (ctorParams == null)
				throw new NullReferenceException("ctorParams may not be null");

		//	return Activator.CreateInstance(type,ctorParams);
			return aopEngine.CreateProxy(type,ctorParams);
		}
	}
}
