using System;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;
// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.Interfaces
{
	/// <summary>
	/// Summary description for IInterceptor.
	/// </summary>
	public interface IInterceptor : IContextChild, IDisposable
	{

		Notification Notification { get; set; }

		void NotifyPropertyGet(object obj, string propertyName);

		void NotifyPropertyGet(object obj, string propertyName, ref object value, ref bool Cancel);

		void NotifyReadProperty(object obj, string propertyName, ref object value);

		void NotifyPropertySet(object obj, string propertyName, ref object value);

		void NotifyPropertySet(object obj, string propertyName, ref object value, ref bool Cancel);

		void NotifyPropertySet(object obj, string propertyName, ref object value, object oldValue, ref bool Cancel);

		void NotifyWroteProperty(object obj, string propertyName, object value);

		void NotifyWroteProperty(object obj, string propertyName, object value, object oldValue);

		void NotifyInstantiatingObject(object obj);

		void NotifyInstantiatingObject(object obj, ref bool cancel);

		void NotifyInstantiatedObject(object obj);

		bool IsDisposed { get; }

	}
}
