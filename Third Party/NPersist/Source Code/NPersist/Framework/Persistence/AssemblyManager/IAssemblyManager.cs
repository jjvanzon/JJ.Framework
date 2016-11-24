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
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Persistence
{
	public interface IAssemblyManager : IContextChild
	{
		void RegisterAssembly(Assembly asm);

		Assembly GetAssembly(string assemblyPath);

		Type GetTypeFromClassMap(IClassMap classMap);

		Type MustGetTypeFromClassMap(IClassMap classMap);

		Type GetTypeFromPropertyMap(IPropertyMap propertyMap);

		Type MustGetTypeFromPropertyMap(IPropertyMap propertyMap);

		object CreateInstance(Type type, params object[] ctorParams);

		Type GetType(Type type);

	}
}