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
using System.Globalization;
using System.Xml.Serialization;
using Puzzle.NPersist.Framework.Enumerations;

namespace Puzzle.NPersist.Framework.Mapping.Visitor
{
	/// <summary>
	/// Summary description for MapInverseAppenderVisitor.
	/// </summary>
	public class MapInverseAppenderVisitor : IMapVisitor
	{
		public MapInverseAppenderVisitor()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void Visit(IDomainMap domainMap)
		{
			bool isFixed = domainMap.IsFixed();
			if (isFixed)
				domainMap.UnFixate();

			Hashtable newInverseProperties = new Hashtable();

			foreach (IClassMap classMap in domainMap.ClassMaps)
			{
                if (classMap.ClassType.Equals(ClassType.Class) || classMap.ClassType.Equals(ClassType.Default))
                {
                    foreach (IPropertyMap propertyMap in classMap.PropertyMaps)
                    {
                        CreateInverseProperty(propertyMap, newInverseProperties);
                    }
                }
			}

			foreach (IClassMap classMap in newInverseProperties.Keys)
			{
                if (classMap.ClassType.Equals(ClassType.Class) || classMap.ClassType.Equals(ClassType.Default))
                {
                    IList inverseProperties = (IList)newInverseProperties[classMap];
                    foreach (IPropertyMap inverseProperty in inverseProperties)
                    {
                        inverseProperty.ClassMap = classMap;
                    }
                }
			}

			if (isFixed)
				domainMap.Fixate();
		}

		public void Visit(ICodeMap codeMap)
		{
			;
		}

		public void Visit(IClassListMap classListMap)
		{
			;
		}

		public void Visit(IClassMap classMap)
		{
			;
		}

		public void Visit(IPropertyMap propertyMap)
		{
			;
		}

		public void Visit(ISourceListMap sourceListMap)
		{
			;
		}

		public void Visit(ISourceMap sourceMap)
		{
			;
		}

		public void Visit(ITableMap tableMap)
		{
			;
		}

		public void Visit(IColumnMap columnMap)
		{
			;
		}

		public void Visit(IEnumValueMap enumValueMap)
		{
			;
		}

		private void CreateInverseProperty(IPropertyMap propertyMap, Hashtable newInverseProperties)
		{
			if (propertyMap.ReferenceType.Equals(ReferenceType.None))
				return;
			if (propertyMap.GetInversePropertyMap() != null)
				return;
			if (propertyMap.NoInverseManagement)
				return;
			if (propertyMap.GetTableMap() == null)
				return;

			IClassMap refClassMap = propertyMap.MustGetReferencedClassMap();

            if (!(refClassMap.ClassType.Equals(ClassType.Class) || refClassMap.ClassType.Equals(ClassType.Default)))
                return;

			string inverseName = propertyMap.Inverse;
			if (inverseName == "")
			{
				inverseName = "NPersistInverseOf" + propertyMap.ClassMap.Name + propertyMap.Name;
				propertyMap.Inverse = inverseName;
			}
			IPropertyMap inversePropertyMap = new PropertyMap(inverseName);
			string dataType = propertyMap.ClassMap.GetFullName();
			inversePropertyMap.Inverse = propertyMap.Name;
			inversePropertyMap.InheritInverseMappings = true;
			propertyMap.InheritInverseMappings = false;

			inversePropertyMap.Accessibility = AccessibilityType.ProtectedAccess;
			inversePropertyMap.IsGenerated = true;

			switch (propertyMap.ReferenceType)
			{
				case ReferenceType.ManyToMany:
					inversePropertyMap.ReferenceType = ReferenceType.ManyToMany;
					inversePropertyMap.ItemType = dataType;
					inversePropertyMap.IsCollection = true;
					inversePropertyMap.IsSlave = !propertyMap.IsSlave;
					break;
				case ReferenceType.ManyToOne:
					inversePropertyMap.ReferenceType = ReferenceType.OneToMany;
					inversePropertyMap.DataType = dataType;
					inversePropertyMap.IsSlave = false;
					propertyMap.IsSlave = true;
					break;
				case ReferenceType.OneToMany:
					inversePropertyMap.ReferenceType = ReferenceType.ManyToOne;
					inversePropertyMap.ItemType = dataType;
					inversePropertyMap.IsCollection = true;
					inversePropertyMap.IsSlave = true;
					propertyMap.IsSlave = false;
					break;
				case ReferenceType.OneToOne:
					inversePropertyMap.ReferenceType = ReferenceType.OneToOne;
					inversePropertyMap.DataType = dataType;
					inversePropertyMap.IsSlave = !propertyMap.IsSlave;
					break;
			}

			if (!newInverseProperties.ContainsKey(refClassMap))
				newInverseProperties[refClassMap] = new ArrayList();
			IList propertiesForClass = (IList) newInverseProperties[refClassMap];
			propertiesForClass.Add(inversePropertyMap);
		}
	}
}
