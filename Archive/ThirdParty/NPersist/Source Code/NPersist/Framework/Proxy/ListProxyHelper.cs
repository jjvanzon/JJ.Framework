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
using System.Collections;
using System.Reflection;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Interfaces;

namespace Puzzle.NPersist.Framework.Proxy
{
	public class ListProxyHelper
	{
		private static Hashtable IListMethods=new Hashtable();

		public static void AddMethodInfo(string key,MethodInfo methodInfo)
		{
			IListMethods [key] = methodInfo;
		}

		//called by the listproxy constructor in order to get a listinterceptor reference
		public static IListInterceptor GetNewInterceptor(IList owner)
		{
			ListInterceptor listInterceptor = new ListInterceptor ();
			listInterceptor.List = owner;

			return listInterceptor;
		}
		
		//called by explicit ilist overrides in order to getch a reference to the private base implementation
		public static MethodInfo GetIListMethodInfo(string guid)
		{
			MethodInfo methodInfo = IListMethods[guid] as MethodInfo;
			return methodInfo;
		}
	}
}