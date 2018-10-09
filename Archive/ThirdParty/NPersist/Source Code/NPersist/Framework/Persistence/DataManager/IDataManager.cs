//using System;
//using Puzzle.NPersist.Framework.Interfaces;
//// *
//// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
//// *
//// * This library is free software; you can redistribute it and/or modify it
//// * under the terms of the GNU Lesser General Public License 2.1 or later, as
//// * published by the Free Software Foundation. See the included license.txt
//// * or http://www.gnu.org/copyleft/lesser.html for details.
//// *
//// *
//
//namespace Puzzle.NPersist.Framework.Persistence
//{
//	public interface IDataManager : IContextChild
//	{
//		object GetOriginalPropertyValue(object obj, string propertyName);
//
//		void SetOriginalPropertyValue(object obj, string propertyName, object value);
//
//		bool HasOriginalValues(object obj);
//
//		bool HasOriginalValues(object obj, string propertyName);
//
//		void RemoveOriginalValues(object obj, string propertyName);
//
////		DateTime GetLastRefreshedAt(object obj);
////
////		DateTime GetLastRefreshedAt(object obj, string propertyName);
//
//		bool GetNullValueStatus(object obj, string propertyName);
//
//		void SetNullValueStatus(object obj, string propertyName, bool value);
//
//		void SetNullValueStatus(object obj, bool value);
//
//		bool GetUpdatedStatus(object obj, string propertyName);
//
//		void SetUpdatedStatus(object obj, string propertyName, bool value);
//
//		void ClearUpdatedStatuses(object obj);
//
//
//	}
//}