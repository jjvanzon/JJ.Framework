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
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Serialization;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Mapping.Visitor;

namespace Puzzle.NPersist.Framework.Mapping
{
	/// <summary>
	/// Summary description for EnumValueMap.
	/// </summary>
	public class EnumValueMap : MapBase, IEnumValueMap
	{
		public EnumValueMap()
		{			
		}

		private IClassMap m_ClassMap = null;

		[XmlIgnore()]
		public virtual IClassMap ClassMap
		{
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			get => m_ClassMap;
		    //[DebuggerHidden()]
			//[DebuggerStepThrough()]
			set
			{
				if (m_ClassMap != null)
				{
					m_ClassMap.EnumValueMaps.Remove(this);
				}
				m_ClassMap = value;
				if (m_ClassMap != null)
				{
					m_ClassMap.EnumValueMaps.Add(this);
				}
			}
		}

		#region Property  Index
		
		private int index = 0;
		
		public int Index
		{
			get => this.index;
		    set => this.index = value;
		}
		
		#endregion

		public override void Accept(IMapVisitor mapVisitor) => mapVisitor.Visit(this);

	    #region Cloning

		public override IMap Clone()
		{
			IEnumValueMap enumValueMap = new EnumValueMap();
			Copy(enumValueMap);
			return enumValueMap;
		}

		public override IMap DeepClone()
		{
			IEnumValueMap enumValueMap = new EnumValueMap();
			DeepCopy(enumValueMap);
			return enumValueMap;
		}

		protected virtual void DoDeepCopy(IEnumValueMap enumValueMap)
		{
		}

		public override void DeepCopy(IMap mapObject)
		{
			IEnumValueMap enumValueMap = (IEnumValueMap) mapObject;
			Copy(enumValueMap);
			DoDeepCopy(enumValueMap);
		}

		public override bool DeepCompare(IMap compareTo)
		{
			if (!(Compare(compareTo)))
			{
				return false;
			}
			return true;
		}

		public override void DeepMerge(IMap mapObject) => Copy(mapObject);

	    public override void Copy(IMap mapObject)
		{
			IEnumValueMap enumValueMap = (IEnumValueMap) mapObject;
			enumValueMap.Name = this.Name;
			enumValueMap.Index = this.Index;
		}

		public override bool Compare(IMap compareTo)
		{
			if (compareTo == null)
			{
				return false;
			}
			IEnumValueMap enumValueMap = (IEnumValueMap) compareTo;
			if (!(enumValueMap.Index == this.Index))
			{
				return false;
			}
			return true;
		}

		#endregion
	}
}
