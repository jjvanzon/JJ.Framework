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
	/// Summary description for MapVerificationVisitor.
	/// </summary>
	public class MapVerificationVisitor : IMapVisitor
	{
		#region Constructors

		public MapVerificationVisitor()
		{			
		}

		public MapVerificationVisitor(bool recursive)
		{		
			this.recursive = recursive;
		}

		public MapVerificationVisitor(bool recursive, bool checkOrmMappings)
		{		
			this.recursive = recursive;
			this.checkOrmMappings = checkOrmMappings;
		}

		#endregion
		
		#region Property  Exceptions
		
		private IList exceptions = new ArrayList() ;
		
		public IList Exceptions
		{
			get { return this.exceptions; }
			set { this.exceptions = value; }
		}
		
		#endregion

		#region Property  Recursive
		
		private bool recursive = true;
		
		public bool Recursive
		{
			get { return this.recursive; }
			set { this.recursive = value; }
		}
		
		#endregion

		#region Property  CheckOrmMappings
		
		private bool checkOrmMappings = true;
		
		public bool CheckOrmMappings
		{
			get { return this.checkOrmMappings; }
			set { this.checkOrmMappings = value; }
		}
		
		#endregion

		#region Method  HandleVerifyException

		public virtual void HandleVerifyException(IMap mapObject, string message, string setting)
		{
			if (this.Exceptions != null)
			{
				this.Exceptions.Add(new MappingException(message, mapObject, setting));
			}
			else
			{
				throw new MappingException(message, mapObject, setting);
			}
		}

		#endregion

		#region IMapVisitor

		public virtual void Visit(IDomainMap domainMap)
		{
			VerifyDomainMap(domainMap);
		}

		public virtual void Visit(ICodeMap codeMap)
		{
			VerifyCodeMap(codeMap);
		}

		public virtual void Visit(IClassListMap classListMap)
		{
		}

		public virtual void Visit(IClassMap classMap)
		{
			VerifyClassMap(classMap);
		}

		public virtual void Visit(IPropertyMap propertyMap)
		{
			VerifyPropertyMap(propertyMap);
		}

		public virtual void Visit(ISourceListMap sourceListMap)
		{

		}

		public virtual void Visit(ISourceMap sourceMap)
		{
			VerifySourceMap(sourceMap);
		}

		public virtual void Visit(ITableMap tableMap)
		{
			VerifyTableMap(tableMap);
		}

		public virtual void Visit(IColumnMap columnMap)
		{
			VerifyColumnMap(columnMap);
		}

		public virtual void Visit(IEnumValueMap enumValueMap)
		{
			VerifyEnumValueMap(enumValueMap);
		}

		#endregion

		#region Verification

		#region DomainMap 

		public virtual void VerifyDomainMap(IDomainMap domainMap)
		{
			Hashtable hashNames = new Hashtable();
			if (domainMap.Name.Length < 1)
			{
				HandleVerifyException(domainMap, "Domain name must not be empty!", "Name"); // do not localize
			}
			if (this.Recursive)
			{
				foreach (IClassMap classMap in domainMap.ClassMaps)
				{
					classMap.Accept(this);
				}
				foreach (ISourceMap sourceMap in domainMap.SourceMaps)
				{
					sourceMap.Accept(this);
				}
				foreach (ICodeMap codeMap in domainMap.CodeMaps)
				{
					codeMap.Accept(this);
				}
			}
			foreach (IClassMap classMap in domainMap.ClassMaps)
			{
				if (classMap.Name.Length > 0)
				{
					if (hashNames.ContainsKey(classMap.Name.ToLower(CultureInfo.InvariantCulture)))
					{
						HandleVerifyException(classMap, "Class names must not appear in duplicates! (Class name: '" + classMap.Name + "')", "ClassMaps"); // do not localize
					}
					hashNames[classMap.Name.ToLower(CultureInfo.InvariantCulture)] = "1";
				}
			}
			hashNames.Clear();
			foreach (ISourceMap sourceMap in domainMap.SourceMaps)
			{
				if (sourceMap.Name.Length > 0)
				{
					if (hashNames.ContainsKey(sourceMap.Name.ToLower(CultureInfo.InvariantCulture)))
					{
						HandleVerifyException(sourceMap, "Source names must not appear in duplicates! (Source name: '" + sourceMap.Name + "')", "SourceMaps"); // do not localize
					}
					hashNames[sourceMap.Name.ToLower(CultureInfo.InvariantCulture)] = "1";
				}
			}
			hashNames.Clear();
			foreach (ICodeMap codeMap in domainMap.CodeMaps)
			{
				if (hashNames.ContainsKey(codeMap.CodeLanguage.ToString()))
				{
					HandleVerifyException(codeMap, "Custom code panes must not appear in duplicates for a code language in a domain map! (Code language: '" + codeMap.CodeLanguage.ToString() + "')", "CodeMaps"); // do not localize
				}
				hashNames[codeMap.CodeLanguage.ToString()] = "1";
			}
			foreach (ICodeMap codeMap in domainMap.CodeMaps)
			{
				if (codeMap.Code.Length > 0)
				{
					if (domainMap.RootNamespace.Length < 1)
					{
						HandleVerifyException(domainMap, "A root namespace in your domain is required for domain level custom code!", "RootNamespace"); // do not localize						
						break;
					}
				}
			}

		}

		#endregion

		#region CodeMap

		public virtual void VerifyCodeMap(ICodeMap codeMap)
		{
			;
		}

		#endregion

		#region ClassMap

		public virtual void VerifyClassMap(IClassMap classMap)
		{
			bool failedSorting = false;
			IClassMap superClassMap = null;
			if (classMap.Name.Length < 1)
			{
				HandleVerifyException(classMap, "Class name must not be empty!", "Name"); // do not localize
			}

			if (classMap.ClassType == ClassType.Class || classMap.ClassType == ClassType.Default)
			{
				superClassMap = classMap.GetInheritedClassMap();
				if (superClassMap != null)
				{
					if (!(classMap.IsLegalAsSuperClass(superClassMap)))
					{
						HandleVerifyException(classMap, "Inherited class '" + superClassMap.Name + "' is illegal as superclass for this class! Creates cyclic inheritance graph, which is a very serious error, potentially leading to infinite loops! No more verification of this class or its properties will be made until this error is corrected! (" + GetClassType(classMap) + ": '" + classMap.Name + "')", "InheritsClass"); // do not localize
						return;
					}
				}
				bool checkMappings = this.checkOrmMappings;
				if (classMap.IsAbstract)
				{
					if (classMap.InheritanceType == InheritanceType.ConcreteTableInheritance)
					{
						checkMappings = false;
					}
				}
				if (checkMappings)
				{
					if (classMap.SourceClass.Length > 0)
					{
						if (classMap.GetSourceClassMap() == null)
						{
							HandleVerifyException(classMap, "Source class not found! (Class: '" + classMap.Name + "', Source class: '" + classMap.SourceClass + "')", "SourceClass"); // do not localize
						}					
					}
					else
					{
						if (classMap.Table.Length < 1)
						{
							HandleVerifyException(classMap, "Table name must not be empty! (" + GetClassType(classMap) + ": '" + classMap.Name + "')", "Table"); // do not localize
						}
						if (classMap.GetTableMap() == null)
						{
							HandleVerifyException(classMap, "Table not found! (" + GetClassType(classMap) + ": '" + classMap.Name + "', Table: '" + classMap.Table + "')", "Table"); // do not localize
						}
						if (classMap.TypeColumn.Length > 0)
						{
							if (classMap.GetTypeColumnMap() == null)
							{
								HandleVerifyException(classMap, "Type column not found! (" + GetClassType(classMap) + ": '" + classMap.Name + "', Type column: '" + classMap.TypeColumn + "')", "TypeColumn"); // do not localize
							}
							if (classMap.TypeValue.Length < 1)
							{
								HandleVerifyException(classMap, "Type column supplied but no type value! (" + GetClassType(classMap) + ": '" + classMap.Name + "', Type column: '" + classMap.TypeColumn + "')", "TypeColumn"); // do not localize
							}
						}					
					}
					if (classMap.TypeValue.Length > 0)
					{
						if (classMap.TypeColumn.Length < 1)
						{
							HandleVerifyException(classMap, "Type value supplied but no type column! (" + GetClassType(classMap) + ": '" + classMap.Name + "', Type value: '" + classMap.TypeValue + "')", "TypeValue"); // do not localize
						}
						VerifyUniqueTypeValue(classMap);
					}

				}
				if (classMap.InheritsClass.Length > 0)
				{
					if (superClassMap == null)
					{
						HandleVerifyException(classMap, "Inherited class not found! (" + GetClassType(classMap) + ": '" + classMap.Name + "', Inherited class: '" + classMap.InheritsClass + "')", "InheritsClass"); // do not localize
					}
				}
				if (classMap.GetSortedIdentityPropertyMaps(ref failedSorting, true).Count < 1)
				{
					HandleVerifyException(classMap, "Class must have at least one identity property! (" + GetClassType(classMap) + ": '" + classMap.Name + "')", "PropertyMaps"); // do not localize
				}
				if (failedSorting)
				{
					HandleVerifyException(classMap, "Failed sorting identity properties due to invalid indexes! (" + GetClassType(classMap) + ": '" + classMap.Name + "')", "PropertyMaps"); // do not localize
				}
				if (classMap.IsInHierarchy())
				{
					if (classMap.InheritanceType == InheritanceType.None)
					{
						HandleVerifyException(classMap, "Inheritance type must be specified for class that is part of an inheritance hierarchy! (" + GetClassType(classMap) + ": '" + classMap.Name + "')", "InheritanceType"); // do not localize
					}
					else
					{
						if (classMap.InheritanceType == InheritanceType.ConcreteTableInheritance)
						{
							if (superClassMap != null)
							{
								if (!(classMap.IsAbstract))
								{
									foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
									{
										if (classMap.IsShadowingProperty(propertyMap))
										{
											if (propertyMap.IsIdentity)
											{
												HandleVerifyException(classMap,"Identity properties should not be shadowed! (" + GetClassType(classMap) + ": '" + classMap.Name + "', property: '" + propertyMap.Name + "')", "InheritanceType"); // do not localize
											}
										}
										else
										{
											if (!(propertyMap.IsIdentity) && !(propertyMap.IsCollection))
											{
												if (classMap.IsInheritedProperty(propertyMap))
												{
													HandleVerifyException(classMap, "Non-identity, non-collection Properties should be shadowed (at least in the mapping file) in concrete classes for 'ConcreteTableInheritance' inheritance types! (" + GetClassType(classMap) + ": '" + classMap.Name + "', property: '" + propertyMap.Name + "')", "InheritanceType"); // do not localize
												}
											}
										}
									}
								}
							}
						}
						else
						{
							if (superClassMap != null)
							{
								foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
								{
									if (classMap.IsShadowingProperty(propertyMap))
									{
										if (propertyMap.IsIdentity)
										{
											HandleVerifyException(classMap, "Identity properties should not be shadowed! (" + GetClassType(classMap) + ": '" + classMap.Name + "', property: '" + propertyMap.Name + "')", "InheritanceType"); // do not localize
										}
										else
										{
											HandleVerifyException(classMap, "Properties should not be shadowed for 'SingleTableInheritance' or 'ClassTableInheritance' inheritance types! (" + GetClassType(classMap) + ": '" + classMap.Name + "', property: '" + propertyMap.Name + "')", "InheritanceType"); // do not localize
										}
									}
								}
							}
						}
					}
				}
				else
				{
				}
				if (classMap.InheritanceType != InheritanceType.None)
				{
					if (classMap.TypeValue.Length < 1)
					{
						HandleVerifyException(classMap, "Type value must not be empty for class in inheritance hierarchy! (" + GetClassType(classMap) + ": '" + classMap.Name + "', Type value: '" + classMap.TypeValue + "')", "TypeValue"); // do not localize
					}
					if (checkMappings)
					{
						if (classMap.GetTypeColumnMap() == null)
						{
							HandleVerifyException(classMap, "Type column not found! Class in inheritance hierarchy must have a type column! (" + GetClassType(classMap) + ": '" + classMap.Name + "', Type column: '" + classMap.TypeColumn + "')", "TypeColumn"); // do not localize
						}
					}
				}
				else
				{
				}

			}


			if (classMap.ClassType == ClassType.Enum)
			{
				if (classMap.InheritsClass.Length > 0)
				{
					HandleVerifyException(classMap, "Enumerations can not inherit! (Enumeration: '" + classMap.Name + "', Inherits: '" + classMap.InheritsClass + "'", "InheritsClass"); // do not localize					
				}				
				if (classMap.PropertyMaps.Count > 0)
				{
					HandleVerifyException(classMap, "Enumerations can not have properties! (Enumeration: '" + classMap.Name + "'", "PropertyMaps"); // do not localize					
				}	
				if (classMap.GetSortedEnumValueMaps(ref failedSorting).Count < 1)
				{
					HandleVerifyException(classMap, "Enumeration must have at least one enumeration value! (" + GetClassType(classMap) + ": '" + classMap.Name + "')", "PropertyMaps"); // do not localize
				}
				if (failedSorting)
				{
					HandleVerifyException(classMap, "Failed sorting enumeration values due to invalid indexes! (" + GetClassType(classMap) + ": '" + classMap.Name + "')", "PropertyMaps"); // do not localize
				}
			
			}
			else
			{
				if (classMap.EnumValueMaps.Count > 0)
				{
					HandleVerifyException(classMap, "Only enumerations can have enumeration values! (" + GetClassType(classMap) + ": '" + classMap.Name + "'", "PropertyMaps"); // do not localize					
				}								
			}

			if (classMap.ClassType == ClassType.Interface)
			{
				if (classMap.InheritsClass.Length > 0)
				{
					IClassMap super = classMap.GetInheritedClassMap() ;
					if (super != null)
					{
						if (super.ClassType != ClassType.Interface)
						{
							HandleVerifyException(classMap, "Interfaces can only inherit other interfaces! (Interface: '" + classMap.Name + "', Inherits: '" + classMap.InheritsClass + "'", "InheritsClass"); // do not localize							
						}
					}
				}				
			}

			if (classMap.ClassType != ClassType.Class && classMap.ClassType != ClassType.Default)
			{
				if (classMap.Source.Length > 0)
				{					
					HandleVerifyException(classMap, "Only classes can be mapped to a persistent data source! (" + GetClassType(classMap) + ": '" + classMap.Name + "', Source: '" + classMap.Source + "'", "Source"); // do not localize							
				}
				if (classMap.Table.Length > 0)
				{					
					HandleVerifyException(classMap, "Only classes can be mapped to a table in a persistent data source! (" + GetClassType(classMap) + ": '" + classMap.Name + "', Table: '" + classMap.Table + "'", "Table"); // do not localize							
				}
				if (classMap.TypeColumn.Length > 0)
				{					
					HandleVerifyException(classMap, "Only classes can be mapped to a type column in a persistent data source! (" + GetClassType(classMap) + ": '" + classMap.Name + "', Type column: '" + classMap.TypeColumn + "'", "TypeColumn"); // do not localize							
				}
				if (classMap.TypeValue.Length > 0)
				{					
					HandleVerifyException(classMap, "Only classes can be mapped to a type value in a persistent data source! (" + GetClassType(classMap) + ": '" + classMap.Name + "', Type value: '" + classMap.TypeValue + "'", "TypeValue"); // do not localize							
				}
				if (classMap.SourceClass.Length > 0)
				{					
					HandleVerifyException(classMap, "Only classes can be mapped to a class in a persistent data source! (" + GetClassType(classMap) + ": '" + classMap.Name + "', Source class: '" + classMap.SourceClass + "'", "SourceClass"); // do not localize							
				}
				if (classMap.DocElement.Length > 0)
				{					
					HandleVerifyException(classMap, "Only classes can be mapped to an element in a persistent data source! (" + GetClassType(classMap) + ": '" + classMap.Name + "', Document element: '" + classMap.DocElement + "'", "DocElement"); // do not localize							
				}
				if (classMap.DocParentProperty.Length > 0)
				{					
					HandleVerifyException(classMap, "Only classes can be mapped to a parent class property for mapping against a persistent data source! (" + GetClassType(classMap) + ": '" + classMap.Name + "', Document parent property: '" + classMap.DocParentProperty + "'", "DocParentProperty"); // do not localize
				}
				if (classMap.DocRoot.Length > 0)
				{					
					HandleVerifyException(classMap, "Only classes can be mapped to a document root in a persistent data source! (" + GetClassType(classMap) + ": '" + classMap.Name + "', Document root: '" + classMap.DocRoot + "'", "DocRoot"); // do not localize							
				}

			}



			if (this.Recursive)
			{
				foreach (IPropertyMap propertyMap in classMap.PropertyMaps)
				{
					propertyMap.Accept(this);
				}
				foreach (ICodeMap codeMap in classMap.CodeMaps)
				{
					codeMap.Accept(this);
				}
				foreach (IEnumValueMap enumValueMap in classMap.EnumValueMaps)
				{
					enumValueMap.Accept(this);
				}
			}
			Hashtable hashNames = new Hashtable();
			foreach (IPropertyMap propertyMap in classMap.PropertyMaps)
			{
				if (propertyMap.Name.Length > 0)
				{
					if (hashNames.ContainsKey(propertyMap.Name.ToLower(CultureInfo.InvariantCulture)))
					{
						HandleVerifyException(classMap, "Property names must not appear in duplicates! (" + GetClassType(classMap) + ": '" + classMap.Name + "', Overridable Property name: '" + propertyMap.Name + "')", "PropertyMaps"); // do not localize
					}
					hashNames[propertyMap.Name.ToLower(CultureInfo.InvariantCulture)] = "1";
				}
			}
			if (classMap.DomainMap.VerifyCSharpReservedWords)
			{
				if (MapBase.IsReservedCSharp(classMap.Name))
				{
					HandleVerifyException(classMap, "Reserved word conflict! The name of this class is a reserved word in C#! (" + GetClassType(classMap) + ": '" + classMap.Name + "')", "Name"); // do not localize
				}
			}
			if (classMap.DomainMap.VerifyVbReservedWords)
			{
				if (MapBase.IsReservedVBNet(classMap.Name))
				{
					HandleVerifyException(classMap, "Reserved word conflict! The name of this class is a reserved word in Visual Basic.NET! (" + GetClassType(classMap) + ": '" + classMap.Name + "')", "Name"); // do not localize
				}
			}
			if (classMap.DomainMap.VerifyDelphiReservedWords)
			{
				if (MapBase.IsReservedDelphi(classMap.Name))
				{
					HandleVerifyException(classMap, "Reserved word conflict! The name of this class is a reserved word in delphi for .NET! (" + GetClassType(classMap) + ": '" + classMap.Name + "')", "Name"); // do not localize
				}
			}
		}

		protected virtual void VerifyUniqueTypeValue(IClassMap classMap)
		{
			if (classMap.TypeValue.Length < 1)
			{
				return;
			}
			IClassMap rootClassMap = classMap;
			while (!(rootClassMap.GetInheritedClassMap() == null))
			{
				rootClassMap = rootClassMap.GetInheritedClassMap();
			}
			if (!(rootClassMap == classMap))
			{
				if (classMap.TypeValue.ToLower(CultureInfo.InvariantCulture) == rootClassMap.TypeValue.ToLower(CultureInfo.InvariantCulture))
				{
					HandleVerifyException(classMap, "Type value is not unique within class hierarchy! (" + GetClassType(classMap) + ": '" + classMap.Name + "', Other class: '" + rootClassMap.Name + "', Type value: '" + classMap.TypeValue + "')", "TypeValue"); // do not localize
				}
			}
			foreach (IClassMap subClassMap in rootClassMap.GetSubClassMaps())
			{
				if (!(subClassMap == classMap))
				{
					if (classMap.TypeValue.ToLower(CultureInfo.InvariantCulture) == subClassMap.TypeValue.ToLower(CultureInfo.InvariantCulture))
					{
						HandleVerifyException(classMap, "Type value is not unique within class hierarchy! (" + GetClassType(classMap) + ": '" + classMap.Name + "', Other class: '" + subClassMap.Name + "', Type value: '" + classMap.TypeValue + "')", "TypeValue"); // do not localize
					}
				}
			}
		}

		private string GetClassType(IClassMap classMap)
		{
			string typeName = classMap.ClassType.ToString();
 
			if (classMap.ClassType == ClassType.Default)
				typeName = "Class";

			return typeName;
		}

		#endregion

		#region PropertyMap

		public virtual void VerifyPropertyMap(IPropertyMap propertyMap)
		{
			VerifyName(propertyMap);
			VerifyDataType(propertyMap);

			bool checkMappings = this.checkOrmMappings;

			if (propertyMap.ClassMap.IsAbstract)
			{
				if (propertyMap.ClassMap.InheritanceType == InheritanceType.ConcreteTableInheritance)
				{
					checkMappings = false;
				}
			}

			if (checkMappings)
				VerifyColumns(propertyMap);

			VerifyIdentityLazyLoad(propertyMap);
			VerifyReference(propertyMap);

			if (checkMappings)
				VerifyTable(propertyMap);

			VerifyIsCollection(propertyMap);
			VerifyInverse(propertyMap);
			VerifyIsIdentity(propertyMap);
			VerifyCascadingCreate(propertyMap);
			VerifyCascadingDelete(propertyMap);

			if (checkMappings)
				VerifyPropertySpecialBehavior(propertyMap);

			VerifyReservedWords(propertyMap);
		}

		private void VerifyPropertySpecialBehavior(IPropertyMap propertyMap)
		{
			IColumnMap colMap;
			if (propertyMap.OnCreateBehavior == PropertySpecialBehaviorType.Increase)
			{
				colMap = propertyMap.GetColumnMap();
				if (colMap != null)
				{
					if (colMap.DataType == DbType.Byte || colMap.DataType == DbType.Decimal || colMap.DataType == DbType.Double || colMap.DataType == DbType.Int16 || colMap.DataType == DbType.Int32 || colMap.DataType == DbType.Int64 || colMap.DataType == DbType.SByte || colMap.DataType == DbType.Single || colMap.DataType == DbType.UInt16 || colMap.DataType == DbType.UInt32 || colMap.DataType == DbType.UInt64 || colMap.DataType == DbType.VarNumeric)
					{
					}
					else
					{
						HandleVerifyException(propertyMap, "Special property behavior 'Increase' may only be applied to properties mapping to numeric columns! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "')", "OnCreateBehavior"); // do not localize
					}
				}
			}
			else if (propertyMap.OnCreateBehavior == PropertySpecialBehaviorType.SetDateTime)
			{
				colMap = propertyMap.GetColumnMap();
				if (colMap != null)
				{
					if (colMap.DataType == DbType.Date || colMap.DataType == DbType.DateTime || colMap.DataType == DbType.Time)
					{
					}
					else
					{
						HandleVerifyException(propertyMap, "Special property behavior 'SetDateTime' may only be applied to properties mapping to DateTime columns! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "')", "OnCreateBehavior"); // do not localize
					}
				}
			}
		}

		private void VerifyTable(IPropertyMap propertyMap)
		{
			IColumnMap colMap;
			if (propertyMap.Table.Length > 0)
			{
				if (propertyMap.GetTableMap() == null)
				{
					HandleVerifyException(propertyMap, "Table not found! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Table: '" + propertyMap.Table + "')", "Table"); // do not localize
				}
				if (propertyMap.IdColumn.Length < 1)
				{
					HandleVerifyException(propertyMap, "Non-primary property must map to id column! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "')", "IdColumn"); // do not localize
				}
				colMap = propertyMap.GetIdColumnMap();
				if (colMap != null)
				{
					if (!(colMap.IsForeignKey))
					{
						HandleVerifyException(propertyMap, "Non-primary property id column must be marked as foreign key! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Id Column: '" + propertyMap.IdColumn + "')", "IdColumn"); // do not localize
					}
				}
			}
		}

		private void VerifyReference(IPropertyMap propertyMap)
		{
			if (propertyMap.ReferenceType != ReferenceType.None)
			{
				if (propertyMap.ReferenceType == ReferenceType.OneToOne || propertyMap.ReferenceType == ReferenceType.OneToMany)
				{
					if (propertyMap.IsCollection)
					{
						HandleVerifyException(propertyMap, "Reference type must not be set to " + propertyMap.ReferenceType.ToString() + " for a collection property! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Reference type: '" + propertyMap.ReferenceType + "')", "ReferenceType"); // do not localize
					}
					VerifyColumnIsForeignKey(propertyMap);
				}
				else if (propertyMap.ReferenceType == ReferenceType.ManyToOne)
				{
					if (!(propertyMap.IsCollection))
					{
						HandleVerifyException(propertyMap, "Reference type must not be set to " + propertyMap.ReferenceType.ToString() + " for a non-collection property! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Reference type: '" + propertyMap.ReferenceType + "')", "ReferenceType"); // do not localize
					}
					VerifyIDColumnIsForeignKey(propertyMap);
				}
				else if (propertyMap.ReferenceType == ReferenceType.ManyToMany)
				{
					if (!(propertyMap.IsCollection))
					{
						HandleVerifyException(propertyMap, "Reference type must not be set to " + propertyMap.ReferenceType.ToString() + " for a non-collection property! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Reference type: '" + propertyMap.ReferenceType + "')", "ReferenceType"); // do not localize
					}
					VerifyColumnIsForeignKey(propertyMap);
					VerifyIDColumnIsForeignKey(propertyMap);
				}
				IClassMap referencedClassMap = propertyMap.GetReferencedClassMap() ;
				if (referencedClassMap == null)
				{
					HandleVerifyException(propertyMap, "Reference type class not found! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Referenced class: '" + propertyMap.DataType + "')", "DataType"); // do not localize
				}
				else
				{
					if (referencedClassMap.ClassType == ClassType.Interface)
					{
						HandleVerifyException(propertyMap, "Persistent reference properties can not use interfaces as types! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Type: '" + propertyMap.GetDataOrItemType() + "')", "DataType"); // do not localize						
					}					
					else if (referencedClassMap.ClassType == ClassType.Struct)
					{
						HandleVerifyException(propertyMap, "Persistent reference properties can not use structs as types! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Type: '" + propertyMap.GetDataOrItemType() + "')", "DataType"); // do not localize						
					}					
					else if (referencedClassMap.ClassType == ClassType.Enum)
					{
						HandleVerifyException(propertyMap, "Reference type should be set to None for properties with enumeration types! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Type: '" + propertyMap.GetDataOrItemType() + "')", "ReferenceType"); // do not localize						
					}					
				}
			}
			else
			{
				if (!(propertyMap.ReferenceType == ReferenceType.None))
				{
					HandleVerifyException(propertyMap, "Reference type must be set None for non-reference properties! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Reference type: '" + propertyMap.ReferenceType + "')", "DataType"); // do not localize
				}					
			}
		}

		private void VerifyIdentityLazyLoad(IPropertyMap propertyMap)
		{
			if (propertyMap.LazyLoad)
			{
				if (propertyMap.IsIdentity)
				{
					HandleVerifyException(propertyMap, "Lazy load must not be set for identity property! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "')", "LazyLoad"); // do not localize
				}
			}
		}

		private void VerifyReservedWords(IPropertyMap propertyMap)
		{
			VerifyCSharpReservedWords(propertyMap);
			VerifyVbReservedWords(propertyMap);
			VerifyDelphiReservedWords(propertyMap);
		}

		private void VerifyDelphiReservedWords(IPropertyMap propertyMap)
		{
			if (propertyMap.ClassMap.DomainMap.VerifyDelphiReservedWords)
			{
				if (MapBase.IsReservedDelphi(propertyMap.Name))
				{
					HandleVerifyException(propertyMap, "Reserved word conflict! The name of this property is a reserved word in delphi for .NET! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "')", "Name"); // do not localize
				}
			}
		}

		private void VerifyVbReservedWords(IPropertyMap propertyMap)
		{
			if (propertyMap.ClassMap.DomainMap.VerifyVbReservedWords)
			{
				if (MapBase.IsReservedVBNet(propertyMap.Name))
				{
					HandleVerifyException(propertyMap, "Reserved word conflict! The name of this property is a reserved word in Visual Basic.NET! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "')", "Name"); // do not localize
				}
			}
		}

		private void VerifyCSharpReservedWords(IPropertyMap propertyMap)
		{
			if (propertyMap.ClassMap.DomainMap.VerifyCSharpReservedWords)
			{
				if (propertyMap.Name.ToLower(CultureInfo.InvariantCulture) == propertyMap.ClassMap.Name.ToLower(CultureInfo.InvariantCulture))
				{
					HandleVerifyException(propertyMap, "Name conflict! The name of this property is the same of the name as the class, which is not allowed in C#! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "')", "Name"); // do not localize
				}
				if (MapBase.IsReservedCSharp(propertyMap.Name))
				{
					HandleVerifyException(propertyMap, "Reserved word conflict! The name of this property is a reserved word in C#! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "')", "Name"); // do not localize
				}
			}
		}

		private void VerifyCascadingDelete(IPropertyMap propertyMap)
		{
			if (propertyMap.CascadingDelete)
			{
				if (propertyMap.ReferenceType == ReferenceType.None)
				{
					HandleVerifyException(propertyMap, "Cascading delete may only be set for reference properties! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "')", "CascadingDelete"); // do not localize
				}
			}
		}

		private void VerifyCascadingCreate(IPropertyMap propertyMap)
		{
			if (propertyMap.CascadingCreate)
			{
				if (propertyMap.ReferenceType == ReferenceType.None)
				{
					HandleVerifyException(propertyMap, "Cascading create may only be set for reference properties! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "')", "CascadingCreate"); // do not localize
				}
//				if (propertyMap.IsCollection)
//				{
//					HandleVerifyException(propertyMap, "Cascading create may not be set for collection properties! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "')", "CascadingCreate"); // do not localize
//				}
			}
		}

		private void VerifyIsIdentity(IPropertyMap propertyMap)
		{
			ArrayList idProps;
			if (propertyMap.IsIdentity)
			{
				if (propertyMap.IsCollection)
				{
					HandleVerifyException(propertyMap, "Collection property must not be marked as Identity! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "')", "Identity"); // do not localize
				}
				idProps = propertyMap.ClassMap.GetIdentityPropertyMaps();
				if (propertyMap.IdentityIndex < 0)
				{
					HandleVerifyException(propertyMap, "Identity index must not be smaller than 0! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Identity index: '" + propertyMap.IdentityIndex + "')", "IdentityIndex"); // do not localize
				}
				if (propertyMap.IdentityIndex > idProps.Count - 1)
				{
					HandleVerifyException(propertyMap, "Identity index must not exceed the number of identity properties in the class! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Identity index: '" + propertyMap.IdentityIndex + "', Nr of identity properties: '" + idProps.Count + "')", "IdentityIndex"); // do not localize
				}
				foreach (IPropertyMap idProp in idProps)
				{
					if (!(idProp.Name.ToLower(CultureInfo.InvariantCulture) == propertyMap.Name.ToLower(CultureInfo.InvariantCulture)))
					{
						if (idProp.IdentityIndex == propertyMap.IdentityIndex)
						{
							HandleVerifyException(propertyMap, "Two identity properties in the same class must not have the same identity index! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Identity index: '" + propertyMap.IdentityIndex + "', Second property: '" + idProp.Name + "')", "IdentityIndex"); // do not localize
							break;
						}
					}
				}
			}
		}

		private void VerifyInverse(IPropertyMap propertyMap)
		{
			IPropertyMap inv;
			if (propertyMap.Inverse.Length > 0)
			{
				if (propertyMap.ReferenceType == ReferenceType.None)
				{
					HandleVerifyException(propertyMap, "Inverse property specified for non-reference property! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Inverse: '" + propertyMap.Inverse + "')", "Inverse"); // do not localize
				}
				inv = propertyMap.GetInversePropertyMap();
				if (inv == null)
				{
					HandleVerifyException(propertyMap, "Inverse property not found in referenced class! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Inverse: '" + propertyMap.Inverse + "', Referenced class: '" + propertyMap.DataType + "')", "Inverse"); // do not localize
				}
				else
				{
					if (inv.ReferenceType == ReferenceType.None)
					{
						HandleVerifyException(propertyMap, "Inverse property is not reference property! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Inverse: '" + propertyMap.Inverse + "', Referenced class: '" + propertyMap.DataType + "')", "Inverse"); // do not localize
					}
					if (inv.GetReferencedClassMap() == null)
					{
						HandleVerifyException(propertyMap, "Inverse property is not valid reference property! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Inverse: '" + propertyMap.Inverse + "', Referenced class: '" + propertyMap.DataType + "')", "Inverse"); // do not localize
					}
					else
					{
						if (!(inv.GetReferencedClassMap().Name == propertyMap.ClassMap.Name))
						{
							HandleVerifyException(propertyMap, "Inverse property does not reference this class! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Inverse: '" + propertyMap.Inverse + "', Referenced class: '" + propertyMap.DataType + "')", "Inverse"); // do not localize
						}
						if (inv.Inverse.Length > 0)
						{
							if (inv.GetInversePropertyMap() == null)
							{
								HandleVerifyException(propertyMap, "Inverse property has invalid back-reference! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Inverse: '" + propertyMap.Inverse + "', Referenced class: '" + propertyMap.DataType + "')", "Inverse"); // do not localize
							}
							else
							{
								if (!(inv.GetInversePropertyMap().Name == propertyMap.Name))
								{
									HandleVerifyException(propertyMap, "Inverse property mismatch! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Inverse: '" + propertyMap.Inverse + "', Referenced class: '" + propertyMap.DataType + "')", "Inverse"); // do not localize
								}
							}
						}
					}
					if (propertyMap.IsSlave && inv.IsSlave)
					{
						HandleVerifyException(propertyMap, "Only one of the inverse properties can be the slave! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Inverse: '" + propertyMap.Inverse + "', Referenced class: '" + propertyMap.DataType + "')", "Inverse"); // do not localize
					}
					if (propertyMap.InheritInverseMappings && inv.InheritInverseMappings)
					{
						HandleVerifyException(propertyMap, "Only one of the inverse properties may have 'Inherit inverse mappings' set to true! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Inverse: '" + propertyMap.Inverse + "', Referenced class: '" + propertyMap.DataType + "')", "Inherit inverse mappings"); // do not localize
					}
					if (propertyMap.ReferenceType == ReferenceType.ManyToOne)
					{
						if (!(inv.ReferenceType == ReferenceType.OneToMany))
						{
							HandleVerifyException(propertyMap, "Inverse property refernce type mismatch! For a ManyToOne reference, the inverse must be OneToMany (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Inverse: '" + propertyMap.Inverse + "', Inv. reference type: '" + inv.ReferenceType.ToString() + "')", "RefenceType"); // do not localize
						}
					}
					else if (propertyMap.ReferenceType == ReferenceType.OneToMany)
					{
						if (!(inv.ReferenceType == ReferenceType.ManyToOne))
						{
							HandleVerifyException(propertyMap, "Inverse property refernce type mismatch! For a OneToMany reference, the inverse must be ManyToOne (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Inverse: '" + propertyMap.Inverse + "', Inv. reference type: '" + inv.ReferenceType.ToString() + "')", "RefenceType"); // do not localize
						}
					}
					else if (propertyMap.ReferenceType == ReferenceType.OneToOne)
					{
						if (!(inv.ReferenceType == ReferenceType.OneToOne))
						{
							HandleVerifyException(propertyMap, "Inverse property refernce type mismatch! For a OneToOne reference, the inverse must also be OneToOne (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Inverse: '" + propertyMap.Inverse + "', Inv. reference type: '" + inv.ReferenceType.ToString() + "')", "RefenceType"); // do not localize
						}
					}
					else if (propertyMap.ReferenceType == ReferenceType.ManyToMany)
					{
						if (!(inv.ReferenceType == ReferenceType.ManyToMany))
						{
							HandleVerifyException(propertyMap, "Inverse property refernce type mismatch! For a ManyToMany reference, the inverse must also be ManyToMany (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Inverse: '" + propertyMap.Inverse + "', Inv. reference type: '" + inv.ReferenceType.ToString() + "')", "RefenceType"); // do not localize
						}
					}
				}
			}
		}

		private void VerifyIsCollection(IPropertyMap propertyMap)
		{
			if (propertyMap.IsCollection)
			{
				if (propertyMap.ItemType.Length < 1)
				{
					HandleVerifyException(propertyMap, "Item type must be specified for collection property! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "')", "ItemType"); // do not localize
				}
				if (this.checkOrmMappings)
				{
					if (propertyMap.IdColumn.Length < 1)
					{
						HandleVerifyException(propertyMap, "Collection property must map to id column! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "')", "IdColumn"); // do not localize
					}
				}
			}
			else
			{
				if (propertyMap.ItemType.Length > 0)
				{
					HandleVerifyException(propertyMap, "Item type should only be specified for collection properties! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Item type: '" + propertyMap.ItemType + "')", "ItemType"); // do not localize
				}
			}
		}

		private void VerifyColumns(IPropertyMap propertyMap)
		{
			bool ok;
			if (propertyMap.SourceProperty.Length > 0)
			{
				if (propertyMap.GetSourcePropertyMap() == null)
				{
					HandleVerifyException(propertyMap, "Source property not found! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Source property: '" + propertyMap.SourceProperty + "')", "SourceProperty"); // do not localize
				}					
			}
			else
			{
				if (propertyMap.Column.Length < 1)
				{
					ok = false;
					if (propertyMap.IsCollection && !(propertyMap.ReferenceType == ReferenceType.None))
					{
						if (propertyMap.ReferenceType == ReferenceType.ManyToOne)
						{
							ok = true;
						}
					}
					if (!(ok))
					{
						HandleVerifyException(propertyMap, "Column name must not be empty! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "')", "Column"); // do not localize
					}
				}
				else
				{
					if (propertyMap.GetColumnMap() == null)
					{
						HandleVerifyException(propertyMap, "Column not found! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Column: '" + propertyMap.Column + "')", "Column"); // do not localize
					}
				}
				if (propertyMap.IdColumn.Length > 0)
				{
					if (propertyMap.GetIdColumnMap() == null)
					{
						HandleVerifyException(propertyMap, "ID Column not found! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', ID Column: '" + propertyMap.IdColumn + "')", "IdColumn"); // do not localize
					}
				}
				VerifyAdditionalColumns(propertyMap);
				VerifyAdditionalIDColumns(propertyMap);				
			}
		}

		private void VerifyDataType(IPropertyMap propertyMap)
		{
			if (propertyMap.DataType.Length < 1)
			{
				HandleVerifyException(propertyMap, "Data type name must not be empty! (Class: '" + propertyMap.ClassMap.Name + "')", "DataType"); // do not localize
			}
		}

		private void VerifyName(IPropertyMap propertyMap)
		{
			if (propertyMap.Name.Length < 1)
			{
				HandleVerifyException(propertyMap, "Property name must not be empty! (Class: '" + propertyMap.ClassMap.Name + "')", "Name"); // do not localize
			}
		}

		protected virtual void VerifyAdditionalColumns(IPropertyMap propertyMap)
		{
			IColumnMap colMap;
			ITableMap tableMap;
			if (propertyMap.AdditionalColumns.Count > 0)
			{
				if (propertyMap.ReferenceType == ReferenceType.None)
				{
					HandleVerifyException(propertyMap, "Only reference propertyies should have additional columns specified! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "')", "AdditionalColumns"); // do not localize
				}
				tableMap = propertyMap.GetTableMap();
				if (tableMap != null)
				{
					foreach (string colName in propertyMap.AdditionalColumns)
					{
						colMap = tableMap.GetColumnMap(colName);
						if (colMap == null)
						{
							HandleVerifyException(propertyMap, "Additional column not found! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Additional Column: '" + colName + "')", "AdditionalColumns"); // do not localize
						}
						else
						{
							if (!(colMap.IsForeignKey))
							{
								HandleVerifyException(propertyMap, "Additional column must be a foreign key! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Additional Column: '" + colName + "')", "AdditionalColumns"); // do not localize
							}
						}
					}
				}
			}
		}

		protected virtual void VerifyAdditionalIDColumns(IPropertyMap propertyMap)
		{
			IColumnMap colMap;
			ITableMap tableMap;
			if (propertyMap.AdditionalIdColumns.Count > 0)
			{
				if (!((propertyMap.ReferenceType != ReferenceType.None || propertyMap.IsCollection || propertyMap.Table.Length > 0)))
				{
					HandleVerifyException(propertyMap, "Only reference, collection or non-primary propertyies should have additional id columns specified! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "')", "AdditionalIdColumns"); // do not localize
				}
				tableMap = propertyMap.GetTableMap();
				if (tableMap != null)
				{
					foreach (string colName in propertyMap.AdditionalIdColumns)
					{
						colMap = tableMap.GetColumnMap(colName);
						if (colMap == null)
						{
							HandleVerifyException(propertyMap, "Additional id column not found! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Additional Id Column: '" + colName + "')", "AdditionalIdColumns"); // do not localize
						}
						else
						{
							if (!(colMap.IsForeignKey))
							{
								HandleVerifyException(propertyMap, "Additional id column must be a foreign key! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Additional Id Column: '" + colName + "')", "AdditionalIdColumns"); // do not localize
							}
						}
					}
				}
			}
		}

		protected virtual void VerifyColumnIsForeignKey(IPropertyMap propertyMap)
		{
			if (!(this.checkOrmMappings))
			{
				return;
			}
			IColumnMap colMap;
			colMap = propertyMap.GetColumnMap();
			if (colMap != null)
			{
				if (!(colMap.IsForeignKey))
				{
					if (!(propertyMap.ReferenceType == ReferenceType.OneToOne) && propertyMap.IsSlave)
					{
						HandleVerifyException(propertyMap, propertyMap.ReferenceType.ToString() + " reference property column must be marked as foreign key! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Column: '" + propertyMap.Column + "')", "Column"); // do not localize
					}
				}
			}
		}

		protected virtual void VerifyIDColumnIsForeignKey(IPropertyMap propertyMap)
		{
			if (!(this.checkOrmMappings))
			{
				return;
			}
			IColumnMap colMap;
			colMap = propertyMap.GetIdColumnMap();
			if (colMap != null)
			{
				if (!(colMap.IsForeignKey))
				{
					HandleVerifyException(propertyMap, propertyMap.ReferenceType.ToString() + " reference property id column must be marked as foreign key! (Class: '" + propertyMap.ClassMap.Name + "', Property: '" + propertyMap.Name + "', Id Column: '" + propertyMap.IdColumn + "')", "IdColumn"); // do not localize
				}
			}
		}

		#endregion

		#region SourceMap

		public virtual void VerifySourceMap(ISourceMap sourceMap)
		{
			if (sourceMap.Name.Length < 1)
			{
				HandleVerifyException(sourceMap, "Source name must not be empty!", "Name"); // do not localize
			}
			if (this.Recursive)
			{
				foreach (ITableMap tableMap in sourceMap.TableMaps)
				{
					tableMap.Accept(this);
				}
			}
			Hashtable hashNames = new Hashtable();
			foreach (ITableMap tableMap in sourceMap.TableMaps)
			{
				if (tableMap.Name.Length > 0)
				{
					if (hashNames.ContainsKey(tableMap.Name.ToLower(CultureInfo.InvariantCulture)))
					{
						HandleVerifyException(sourceMap, "Table names must not appear in duplicates! (Source: '" + sourceMap.Name + "', Table name: '" + tableMap.Name + "')", "TableMaps"); // do not localize
					}
				}
				hashNames[tableMap.Name.Length] = "1";
			}
		}

		#endregion

		#region TableMap

		public virtual void VerifyTableMap(ITableMap tableMap)
		{
			if (tableMap.Name.Length < 1)
			{
				HandleVerifyException(tableMap, "Table name must not be empty! (Source: '" + tableMap.SourceMap.Name + "')", "Name"); // do not localize
			}
			if (recursive)
			{
				foreach (IColumnMap columnMap in tableMap.ColumnMaps)
				{
					columnMap.Accept(this);
				}
			}
			Hashtable hashNames = new Hashtable();
			foreach (IColumnMap columnMap in tableMap.ColumnMaps)
			{
				if (hashNames.ContainsKey(columnMap.Name.ToLower(CultureInfo.InvariantCulture)))
				{
					HandleVerifyException(tableMap, "Column names must not appear in duplicates! (Source: '" + tableMap.SourceMap.Name + "', Table: '" + tableMap.Name + "', Column name: '" + columnMap.Name + "')", "ColumnMaps"); // do not localize
				}
				hashNames[columnMap.Name.ToLower(CultureInfo.InvariantCulture)] = "1";
			}
		}

		#endregion

		#region ColumnMap

		public virtual void VerifyColumnMap(IColumnMap columnMap)
		{
			if (columnMap.Name.Length < 1)
			{
				HandleVerifyException(columnMap, "Column name must not be empty! (Source: '" + columnMap.TableMap.SourceMap.Name + "', Table: '" + columnMap.TableMap.Name + "')", "Name"); // do not localize
			}
			if (columnMap.DataType == DbType.AnsiStringFixedLength || columnMap.DataType == DbType.StringFixedLength)
			{
				if (columnMap.Length < 1)
				{
					HandleVerifyException(columnMap, "Length for column with data type '" + columnMap.DataType.ToString() + "' must not be < 1! (Source: '" + columnMap.TableMap.SourceMap.Name + "', Table: '" + columnMap.TableMap.Name + "', column '" + columnMap.Name + "')", "DataType"); // do not localize
				}
			}
			if (columnMap.IsAutoIncrease)
			{
				if (!((columnMap.DataType == DbType.Int16 || columnMap.DataType == DbType.Int32 || columnMap.DataType == DbType.Int64)))
				{
					HandleVerifyException(columnMap, "Column is marked as auto increaser but data type is not an integer! (Source: '" + columnMap.TableMap.SourceMap.Name + "', Table: '" + columnMap.TableMap.Name + "', column '" + columnMap.Name + "')", "PrimaryKeyTable"); // do not localize
				}
			}
			if (columnMap.IsForeignKey)
			{
				if (columnMap.PrimaryKeyTable.Length < 1)
				{
					HandleVerifyException(columnMap, "Column is marked as foreign key but no primary key table for the column has been specified! (Source: '" + columnMap.TableMap.SourceMap.Name + "', Table: '" + columnMap.TableMap.Name + "', column '" + columnMap.Name + "')", "PrimaryKeyTable"); // do not localize
				}
				if (columnMap.PrimaryKeyColumn.Length < 1)
				{
					HandleVerifyException(columnMap, "Column is marked as foreign key but no primary key column for the column has been specified! (Source: '" + columnMap.TableMap.SourceMap.Name + "', Table: '" + columnMap.TableMap.Name + "', column '" + columnMap.Name + "')", "PrimaryKeyColumn"); // do not localize
				}
			}
			if (columnMap.PrimaryKeyTable.Length > 0)
			{
				if (columnMap.GetPrimaryKeyTableMap() == null)
				{
					HandleVerifyException(columnMap, "Primary key table not found! (Source: '" + columnMap.TableMap.SourceMap.Name + "', Table: '" + columnMap.TableMap.Name + "', Primary key table: '" + columnMap.PrimaryKeyTable + "', column '" + columnMap.Name + "')", "PrimaryKeyTable"); // do not localize
				}
			}
			if (columnMap.PrimaryKeyColumn.Length > 0)
			{
				if (columnMap.GetPrimaryKeyColumnMap() == null)
				{
					HandleVerifyException(columnMap, "Primary key column not found! (Source: '" + columnMap.TableMap.SourceMap.Name + "', Table: '" + columnMap.TableMap.Name + "', Primary key column: '" + columnMap.PrimaryKeyColumn + "', column '" + columnMap.Name + "')", "PrimaryKeyColumn"); // do not localize
				}
			}
		}

		#endregion

		#region EnumValueMap

		public virtual void VerifyEnumValueMap(IEnumValueMap enumValueMap)
		{
			if (enumValueMap.Name.Length < 1)
			{
				HandleVerifyException(enumValueMap, "Enum value name must not be empty! (Enum: '" + enumValueMap.ClassMap.Name + "')", "Name"); // do not localize
			}
		}

		#endregion

		#endregion

	}
}
