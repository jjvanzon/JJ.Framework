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
using System.Diagnostics;
using System.Reflection;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Persistence
{
	public class ReflectionHelper
	{
		private static Hashtable typeLookup = new Hashtable();
		private static volatile object syncRoot = new object() ;

		/// <summary>
		/// Fetches a FieldInfo lookup Hashtable for a specific Type
		/// </summary>
		/// <param name="type">The Type to get the lookup from</param>
		/// <returns>FieldInfo lookup Hashtable</returns>
		//[DebuggerStepThrough()]
		private static Hashtable FieldLookup(Type type)
		{
			if (type == null)
				return null;

			lock(syncRoot)
			{
				if (!typeLookup.ContainsKey(type))
					typeLookup[type] = new Hashtable();
			}

			Hashtable fieldLookup = typeLookup[type] as Hashtable;
			return fieldLookup;
		}

		/// <summary>
		/// Fetches a FieldInfo for a specific property in a given type
		/// </summary>
		/// <param name="propertyMap"></param>
		/// <param name="type"></param>
		/// <param name="propertyName"></param>
		/// <returns></returns>
		//[DebuggerStepThrough()]
		public static FieldInfo GetFieldInfo(IPropertyMap propertyMap, Type type, string propertyName)
		{
			Hashtable fieldLookup = FieldLookup(type);
			if (fieldLookup != null)
			{
				if (!fieldLookup.ContainsKey(propertyName))
				{
					FieldInfo fieldInfo = type.GetField(propertyMap.GetFieldName(), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
				
					if (fieldInfo == null) //field was not found in this type
						fieldInfo = GetFieldInfo(propertyMap, type.BaseType, propertyName); //fetch the field from the base class

					lock(syncRoot)
					{
						if (!fieldLookup.ContainsKey(propertyName))
						{
							fieldLookup.Add(propertyName, fieldInfo); //cache the field info with this type , even if the field was found in a super class
						}
					}
				}				
				return fieldLookup[propertyName] as FieldInfo;
			}
			return null;
		}

		public static MethodInfo GetMethodInfo(Type type, string methodName)
		{
			Hashtable fieldLookup = FieldLookup(type);
			if (fieldLookup != null)
			{
				if (!fieldLookup.ContainsKey(methodName))
				{
					MethodInfo methodInfo = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
				
					if (methodInfo == null) //method was not found in this type
						methodInfo = GetMethodInfo(type.BaseType, methodName); //fetch the method from the base class

					lock(syncRoot)
					{
						if (!fieldLookup.ContainsKey(methodName))
						{
							fieldLookup.Add(methodName, methodInfo); //cache the method info with this type , even if the method was found in a super class
						}
					}
				}

				return fieldLookup[methodName] as MethodInfo;
			}
			return null;
		}
	
	}
}