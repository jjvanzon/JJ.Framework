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
using System.Diagnostics;

namespace Puzzle.NPersist.Framework.EventArguments
{
	public class PropertyEventArgs : EventArgs
	{
		private object m_EventObject;
		private string m_PropertyName;
		private object m_Value;
		private object m_NewValue;
		private bool m_IsNull;

		public PropertyEventArgs() : base()
		{
		}

		public PropertyEventArgs(object obj, string propertyName) : base()
		{
			m_EventObject = obj;
			m_PropertyName = propertyName;
		}

		//[DebuggerStepThrough()]
		public PropertyEventArgs(object obj, string propertyName, object newValue, object value, bool isNull) : base()
		{
			m_EventObject = obj;
			m_PropertyName = propertyName;
			m_Value = value;
			m_NewValue = newValue;
			m_IsNull = isNull;
		}

		public object EventObject
		{
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			get { return m_EventObject; }
		}

		public string PropertyName
		{
			get { return m_PropertyName; }
		}

		public object NewValue
		{
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			get { return m_NewValue; }
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			set { m_NewValue = value; }
		}

		public object Value
		{
			get { return m_Value; }
			set { m_Value = value; }
		}

		public bool IsNull
		{
			get { return m_IsNull; }
		}
	}
}