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
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Puzzle.NPersist.Framework.Attributes;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping.Transformation;
using Puzzle.NPersist.Framework.Mapping.Visitor;
using Puzzle.NPersist.Framework.Mapping.Serialization;
using Puzzle.NPersist.Framework.Persistence;

namespace Puzzle.NPersist.Framework.Mapping
{
	public class DomainMap : MapBase, IDomainMap
	{
		
		public override void Accept(IMapVisitor visitor)
		{
			visitor.Visit(this);
		}

		#region Private Member Variables

		private ArrayList m_ClassMaps = new ArrayList();
		private ArrayList m_SourceMaps = new ArrayList();
		private ArrayList m_CodeMaps = new ArrayList();
		private ArrayList m_SourceListMapPaths = new ArrayList();
		private ArrayList m_ClassListMapPaths = new ArrayList();
		private string m_name = "";
		private string m_Source = "";
		private MergeBehaviorType m_MergeBehavior = MergeBehaviorType.DefaultBehavior;
		private RefreshBehaviorType m_RefreshBehavior = RefreshBehaviorType.DefaultBehavior;
		private LoadBehavior m_ListCountLoadBehavior = LoadBehavior.Default;
		private string m_LoadedFromPath = "";
		private string m_LastSavedToPath = "";
		private bool m_IsReadOnly = false;
		private string m_RootNamespace = "";
		private bool m_Dirty = false;
		private string m_FieldPrefix = "m_";
		private FieldNameStrategyType m_FieldNameStrategy = FieldNameStrategyType.None;
		private string m_InheritsTransientClass = "";
		private ArrayList m_ImplementsInterfaces = new ArrayList();
		private ArrayList m_ImportsNamespaces = new ArrayList();
		private bool m_VerifyCSharpReservedWords = false;
		private bool m_VerifyVbReservedWords = false;
		private bool m_VerifyDelphiReservedWords = false;
		private OptimisticConcurrencyBehaviorType m_UpdateOptimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.DefaultBehavior;
		private OptimisticConcurrencyBehaviorType m_DeleteOptimisticConcurrencyBehavior = OptimisticConcurrencyBehaviorType.DefaultBehavior;
		private MapSerializer m_MapSerializer = MapSerializer.DefaultSerializer;
		private string m_AssemblyName = "";
		private LoadBehavior m_LoadBehavior = LoadBehavior.Default;
		private CodeLanguage m_CodeLanguage = CodeLanguage.CSharp;
		private ValidationMode m_ValidationMode = ValidationMode.Default ;
		private long m_TimeToLive = -1;
		private TimeToLiveBehavior m_TimeToLiveBehavior = TimeToLiveBehavior.Default ;
        private DeadlockStrategy m_DeadlockStrategy = DeadlockStrategy.Default;

		//O/D Mapping
		private string m_DocSource = "";

		//misc
		private bool isFixed = false;

		#endregion

		#region Constructors

		public DomainMap() : base()
		{
		}

		public DomainMap(string name) : base()
		{
			m_name = name;
		}

		#endregion

		#region Serialization

//		public static DomainMap Load(string path)
//		{
//			return (DomainMap) Load(path, null);
//		}

		public static IDomainMap Load(string path)
		{
			return Load(path, null);
		}
		
		public static IDomainMap Load(Assembly asm, string name, IMapSerializer mapSerializer)
		{
			IDomainMap domainMap;

			StreamReader reader = null;
			String xml = "";
			string key = string.Format("assembly://{0}:{1}",asm.GetName().FullName,name);

			if (DomainMapCache.ContainsKey(key))
				return DomainMapCache.GetMap(key);
			
			using (Stream stream = asm.GetManifestResourceStream(name))
			{
				if (stream == null)
				{
					string errorMessage = string.Format("Assembly resource '{0}' not found",name);
					throw new Exception(errorMessage);
				}
				else
				{

					try
					{
						reader = new StreamReader(stream);
						xml = reader.ReadToEnd(); 			
						reader.Close() ;
						reader = null;					
					}
					catch (Exception ex)
					{
						if (reader != null)
						{
							try
							{
								reader.Close();
							}
							catch
							{
							}
							throw new IOException("Could not load file from embedded resource: " + name + "! " + ex.Message, ex); // do not localize
						}
					}
				}
			}			
			
			domainMap = LoadFromXml(xml, mapSerializer);
			DomainMapCache.AddMap(key,domainMap) ;
			return domainMap;
		}

		public static IDomainMap Load(string path, IMapSerializer mapSerializer)
		{
			return Load(path, mapSerializer, true,true);
		}

		public static IDomainMap Load(string path, IMapSerializer mapSerializer, bool useCache,bool validate)
		{
			IDomainMap domainMap;
			StreamReader reader = null;
			String xml = "";
			string key = "";

			if (useCache)
			{
				key = string.Format("path://{0}:{1}",path,mapSerializer);
				if (DomainMapCache.ContainsKey(key))
					return DomainMapCache.GetMap(key);				
			}


			try
			{
				reader = File.OpenText(path);
				xml = reader.ReadToEnd() ;				
				reader.Close() ;
				reader = null;
			}
			catch (Exception ex)
			{
				if (reader != null)
				{
					try
					{
						reader.Close();
					}
					catch
					{
					}
				}
                throw new IOException("Could not load file from path: " + path + "! " + ex.Message, ex); // do not localize
            }
			domainMap = LoadFromXml(xml, mapSerializer,useCache,validate);
			domainMap.SetLoadedFromPath(path);

			if (useCache)
				DomainMapCache.AddMap(key,domainMap) ;

			return domainMap;
		}

		public static IDomainMap Load(Assembly asm)
		{
			IDomainMap domainMap;

			string key = string.Format("assembly://{0}:{1}",asm.GetName().FullName, "[AttributeBasedConfiguration]");

			if (DomainMapCache.ContainsKey(key))
				return DomainMapCache.GetMap(key);
						
			domainMap = LoadFromAttributes(asm);
			
			DomainMapCache.AddMap(key,domainMap) ;
			return domainMap;
		}

		public static IDomainMap LoadFromAttributes(Assembly asm)
		{
			return LoadFromAttributes(asm, true, true);
		}

		public static IDomainMap LoadFromAttributes(Assembly asm, bool useCache,bool validate)
		{
			IDomainMap domainMap = new DomainMap();

			foreach (DomainMapAttribute domainMapAttribute in asm.GetCustomAttributes(typeof(DomainMapAttribute), false))
			{
				DomainMap.FromDomainMapAttribute(domainMapAttribute, asm, domainMap);
				break;
			}

			foreach (SourceMapAttribute sourceMapAttribute in asm.GetCustomAttributes(typeof(SourceMapAttribute), false))
			{
				ISourceMap sourceMap = new SourceMap();
				sourceMap.DomainMap = domainMap;

				SourceMap.FromSourceMapAttribute(sourceMapAttribute, sourceMap);
				break;
			}

			//Make this 2-pass so that mapped inheritance hierarchies can be found.

			foreach (Type type in asm.GetTypes())
			{
				foreach (ClassMapAttribute classMapAttribute in type.GetCustomAttributes(typeof(ClassMapAttribute), false))
				{
					IClassMap classMap = new ClassMap();
					classMap.DomainMap = domainMap;
					classMap.Name = type.Name;
					string waste = classMapAttribute.DocElement ; // The idiot compiler won't compile unless I use the stinkin' classMapAttribute somehow...
					break;
				}				
			}

			foreach (Type type in asm.GetTypes())
			{
				foreach (ClassMapAttribute classMapAttribute in type.GetCustomAttributes(typeof(ClassMapAttribute), false))
				{					
					IClassMap classMap = domainMap.MustGetClassMap(type);
					ClassMap.FromClassMapAttribute(classMapAttribute, type, classMap);

					foreach (PropertyInfo propInfo in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
					{
						foreach (PropertyMapAttribute propertyMapAttribute in propInfo.GetCustomAttributes(typeof(PropertyMapAttribute), false))
						{
							IPropertyMap propertyMap = new PropertyMap();
							propertyMap.ClassMap = classMap;
							PropertyMap.FromPropertyMapAttribute(propertyMapAttribute, propInfo, propertyMap);
							
							break;
						}
					}

					break;
				}
			}

            RecalculateModel(domainMap);

			domainMap.Dirty = false;

			if (validate)
				((DomainMap)domainMap).Validate();

			return domainMap;
		}

		public static IDomainMap LoadFromXml(string xml, IMapSerializer mapSerializer,bool useCache,bool validate)
		{
			IDomainMap domainMap;

			if (mapSerializer == null)
			{
				mapSerializer = new DefaultMapSerializer(); // GetMapSerializerFromXml(xml);
			}
			if (mapSerializer != null)
			{
				try
				{
					domainMap = mapSerializer.LoadFromXml(xml);
				}
				catch (Exception ex)
				{
					throw new MappingException("Failed loading NPersist XML mapping file! " + ex.Message, ex); // do not localize
				}
			}
			else
			{
				try
				{
					Stream xmlStream = new MemoryStream(ASCIIEncoding.Default.GetBytes(xml));
					XmlSerializer mySerializer = new XmlSerializer(typeof (DomainMap));
					domainMap = ((DomainMap) (mySerializer.Deserialize(xmlStream)));
					domainMap.MapSerializer = MapSerializer.DotNetSerializer;
					Init(domainMap);
				}
				catch (Exception ex)
				{
					throw new MappingException("Failed loading NPersist XML mapping file! " + ex.Message, ex); // do not localize
				}
			}

            RecalculateModel(domainMap);

			domainMap.Dirty = false;

			if (validate)
				((DomainMap)domainMap).Validate();

			return domainMap;
		}

		public static IDomainMap LoadFromXml(string xml, IMapSerializer mapSerializer)
		{
			return DomainMap.LoadFromXml(xml,mapSerializer,true,true);
		}

        public static void RecalculateModel(IDomainMap domainMap)
        {
            GenerateInversePropeties(domainMap);
            CalculateTableModel(domainMap);
        }

		public static void CalculateTableModel(IDomainMap domainMap)
		{
			ClassesToTablesTransformer classesToTablesTransformer = new ClassesToTablesTransformer();
			classesToTablesTransformer.GenerateTablesForClasses(domainMap, domainMap, true, true);					
		}

        public static void GenerateInversePropeties(IDomainMap domainMap)
        {
            //Add inverse properties where missing
            MapInverseAppenderVisitor inverseAppenderVisitor = new MapInverseAppenderVisitor();
            domainMap.Accept(inverseAppenderVisitor);
        }

		protected virtual void Validate()
		{
            Assembly assembly = null;

            string assemblyName = this.GetAssemblyName();


            assembly = System.Reflection.Assembly.Load(assemblyName);
            if (assembly == null)
                throw new NPersistException(string.Format("Could not find Domain Model assembly '{0}'", assemblyName));

            foreach (IClassMap classMap in this.ClassMaps)
            {
                if (classMap.GetAssemblyName() == null || classMap.GetAssemblyName() == "")
                    assembly = System.Reflection.Assembly.Load(assemblyName);
                else
                {
                    assembly = System.Reflection.Assembly.Load(classMap.GetAssemblyName());
                    if (assembly == null)
                        throw new NPersistException(string.Format("Could not find Domain Model assembly '{0}'", classMap.AssemblyName));
                }


                Type type = assembly.GetType(classMap.GetFullName());
                if (type == null)
                {
                    if (assembly.GetType(classMap.GetFullName(), false, true) != null)
                        throw new NPersistException(string.Format("Type '{0}' found, but type name casing does not match in mapping file and assembly.", classMap.GetFullName()));
                    else
                        throw new NPersistException(string.Format("Could not find type '{0}'", classMap.GetFullName()));
                }

                foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
                {
					if (!propertyMap.IsGenerated)
					{
						PropertyInfo propertyInfo = type.GetProperty(propertyMap.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
						if (propertyInfo == null)
							throw new NPersistException(string.Format("Could not find property '{0}' in type '{1}'", propertyMap.Name, classMap.GetFullName()));

						MethodInfo getMethod = propertyInfo.GetGetMethod(true);

						if (getMethod == null)
							throw new NPersistException(string.Format("Could not find getter method for property '{0}' in type '{1}'", propertyMap.Name, classMap.GetFullName()));

						if (!getMethod.IsVirtual)
							throw new NPersistException(string.Format("Property '{0}' in type '{1}' is not marked as 'virtual'", propertyInfo.Name, classMap.GetFullName()));

						if (getMethod.IsFinal)
							throw new NPersistException(string.Format("Property '{0}' in type '{1}' is marked as 'final'", propertyInfo.Name, classMap.GetFullName()));

						string fieldName = propertyMap.GetFieldName();
						FieldInfo fieldInfo = ReflectionHelper.GetFieldInfo(propertyMap, type, fieldName);

						if (fieldInfo == null)
							throw new NPersistException(string.Format("Could not find field '{0}' in type '{1}'", fieldName, classMap.GetFullName()));

						//validate list properties
						if (propertyMap.ReferenceType == ReferenceType.ManyToMany || propertyMap.ReferenceType == ReferenceType.ManyToOne)
						{
							Type listType = getMethod.ReturnType;

#if NET2
                        if (listType.IsGenericType && listType.IsInterface && listType.Name.Contains("IList"))
                        {

                        }
                        else
#endif
							if (!typeof(IList).IsAssignableFrom(listType))
								throw new NPersistException(string.Format("Property '{0}' in type '{1}' has type '{2}' which is not an IList or IList implementing class", propertyInfo.Name, classMap.GetFullName(), listType.FullName));

							if (listType.IsClass)
							{
								if (listType.IsSealed)
									throw new NPersistException(string.Format("Property '{0}' in type '{1}' has type '{2}' which is marked with 'sealed'", propertyInfo.Name, classMap.GetFullName(), listType.FullName));
							}
						}

						if (propertyMap.ReferenceType != ReferenceType.None)
						{
							if (!propertyMap.IsSlave)
							{
								foreach (IColumnMap columnMap in propertyMap.GetAllColumnMaps())
								{
									if (columnMap.IsForeignKey)
									{
										//It is not strictly required that foreign keys are named, that is only if they are part of multiple column foreign keys...
										//                                    if (columnMap.ForeignKeyName == null || columnMap.ForeignKeyName == "")
										//                                    {
										//                                        throw new NPersistException(string.Format("Column '{0}' for reference property '{1}' in type '{2}' is missing a foreignkey name", columnMap.Name, propertyInfo.Name, classMap.GetFullName()));
										//                                    }
									}
								}
							}
						}

						if (propertyMap.ReferenceType == ReferenceType.None)
						{
							ISourceMap sourceMap = propertyMap.GetSourceMap();
							if (sourceMap != null)
							{
								if (sourceMap.PersistenceType == PersistenceType.Default || sourceMap.PersistenceType == PersistenceType.ObjectRelational)
								{
									IColumnMap columnMap = propertyMap.GetColumnMap();
									if (columnMap == null)
									{
										throw new NPersistException(string.Format("No column was found for property '{0}' in type '{1}' ", propertyInfo.Name, classMap.GetFullName()));
									}								
								}
							}
						}
						
					}
                }

				IColumnMap typeColMap = classMap.GetTypeColumnMap();
				if (typeColMap != null)
				{
					IPropertyMap typeMap = classMap.GetPropertyMapForColumnMap(typeColMap);
					if (typeMap != null)
					{
						PropertyInfo propertyInfo = type.GetProperty(typeMap.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

						if (propertyInfo == null) //Should not happen, checked earlier
							throw new NPersistException("Failed - internal error");	

						if (propertyInfo.CanWrite)
							throw new NPersistException(string.Format("The property '{0}' in class '{1}' is mapped to the database Type column '{2}'. When mapping to the type column, the property must be ReadOnly.", typeMap.Name, classMap.GetFullName(), typeColMap.Name ));
					}
				}
            }	
		}

//		protected static IMapSerializer GetMapSerializerFromXml(string xml)
//		{
//			IMapSerializer mapSerializer = null;
//			XmlDocument xmlDoc = new XmlDocument();
//			XmlNode xmlDom;
//			if (xml.Length > 0)
//			{
//				xmlDoc.LoadXml(xml);
//				xmlDom = xmlDoc.SelectSingleNode("domain");
//				if (xmlDom != null)
//				{
//					if (!(xmlDom.Attributes["serializer"] == null))
//					{
//						if (xmlDom.Attributes["serializer"].Value.ToLower(CultureInfo.InvariantCulture) == "dotnet")
//						{
//							mapSerializer = null;
//						}
//						else
//						{
//						}
//					}
//					else
//					{
//						mapSerializer = new DefaultMapSerializer();
//					}
//				}
//				else
//				{
//					xmlDom = xmlDoc.SelectSingleNode("DomainMap");
//					if (xmlDom != null)
//					{
//						mapSerializer = null;
//					}
//					else
//					{
//						mapSerializer = null;
//					}
//				}
//			}
//			return mapSerializer;
//		}


		public virtual void Save()
		{
			Save("", null);
		}

		public virtual void Save(string path)
		{
			Save(path, null);
		}

		public virtual void Save(string path, IMapSerializer mapSerializer)
		{
			if (path == "")
			{
				path = m_LastSavedToPath;
			}
			if (path == "")
			{
				path = m_LoadedFromPath;
			}
			if (path == "")
			{
				throw new NPersistException("A path must be specified for the file that the domain map should be serialized to!"); // do not localize
			}
			if (mapSerializer != null)
			{
				try
				{
					mapSerializer.Save(this, path);
					m_Dirty = false;
				}
				catch (Exception ex)
				{
					throw new NPersistException("Could not serialize Domain Map! " + ex.Message, ex); // do not localize
				}
			}
			else
			{
				try
				{
					XmlSerializer mySerializer = new XmlSerializer(this.GetType());
					StreamWriter myWriter = new StreamWriter(path);
					mySerializer.Serialize(myWriter, this);
					myWriter.Close();
					m_Dirty = false;
				}
				catch (Exception ex)
				{
					throw new NPersistException("Could not serialize Domain Map! " + ex.Message, ex); // do not localize
				}
			}
			m_LastSavedToPath = path;
		}

		public virtual void Setup()
		{
			SetupBiDirectionalRelationships();
		}

		private void SetupBiDirectionalRelationships()
		{
			foreach (IClassMap classMap in m_ClassMaps)
			{
				classMap.SetDomainMap(this);
			}
			foreach (ISourceMap sourceMap in m_SourceMaps)
			{
				sourceMap.SetDomainMap(this);
			}
		}

		protected static void Init(IDomainMap domainMap)
		{
			ISourceListMap srcListMap;
			IClassListMap clsListMap;
			if (domainMap.SourceListMapPaths.Count > 0)
			{
				foreach (string filePath in domainMap.SourceListMapPaths)
				{
					srcListMap = SourceListMap.Load(filePath);
					foreach (ISourceMap sourceMap in srcListMap.SourceMaps)
					{
						domainMap.SourceMaps.Add(sourceMap);
					}
				}
			}
			if (domainMap.ClassListMapPaths.Count > 0)
			{
				foreach (string filePath in domainMap.ClassListMapPaths)
				{
					clsListMap = ClassListMap.Load(filePath);
					foreach (IClassMap classMap in clsListMap.ClassMaps)
					{
						domainMap.ClassMaps.Add(classMap);
					}
				}
			}
			domainMap.Setup();
		}

		#endregion

		#region Object/Relational Mapping

		[XmlArrayItem(typeof (ClassMap))]
		public virtual ArrayList ClassMaps
		{
			get { return m_ClassMaps; }
			set { m_ClassMaps = value; }
		}

		public IList GetPersistentClassMaps()
		{
			IList result = new ArrayList() ;
			foreach (IClassMap classMap in m_ClassMaps)
			{
				if (classMap.ClassType == ClassType.Default || classMap.ClassType == ClassType.Class)
				{
					result.Add(classMap);
				}
			}
			return result;
		}

		
		public IList GetClassMaps(ClassType classType)
		{
			if (classType.Equals(ClassType.Default))
				classType = ClassType.Class ;

			IList result = new ArrayList() ;
			foreach (IClassMap classMap in m_ClassMaps)
			{
				ClassType checkType = classMap.ClassType;
				if (checkType.Equals(ClassType.Default))
					checkType = ClassType.Class ;

				if (checkType.Equals(classType))
				{
					result.Add(classMap);
				}
			}
			return result;
		}

		public virtual IClassMap MustGetClassMap(Type type)
		{
			IClassMap classMap = GetClassMap(type);

			if (classMap == null)
				throw new MappingException("Could not find type " + AssemblyManager.GetBaseType(type).ToString() + " in map file!");

			return classMap;
		}
		
		private Hashtable fixedValueGetClassMapByType = new Hashtable();
		private Hashtable fixedValueGetClassMapByTypeNull = new Hashtable();
 
//		//[DebuggerStepThrough()]
		public virtual IClassMap GetClassMap(Type type)
		{
			IClassMap classMap = (IClassMap) fixedValueGetClassMapByType[type];
			if (classMap != null)
				return classMap;

			if (fixedValueGetClassMapByTypeNull.ContainsKey(type))
				return null;

			string className;
			string ns = "";

			Type tmp = type;

			while (tmp.Assembly is AssemblyBuilder)
				tmp = tmp.BaseType;

			classMap = (IClassMap) fixedValueGetClassMapByType[tmp];
			if (classMap != null)
			{
				if (type != tmp)
					fixedValueGetClassMapByType[type] = classMap;
				return classMap;
			}

			if (fixedValueGetClassMapByTypeNull.ContainsKey(tmp))
			{
				if (type != tmp)
					fixedValueGetClassMapByTypeNull[type] = true;
				return null;
			}

			className = tmp.Name;
			ns = tmp.Namespace;

			classMap = GetClassMap(className);
			if (classMap == null)
			{
                // Jan-Joost van Zon, 2013-09-16: Fixed bug. Namespace could be null.
				//if (ns.Length > 0)
                if (!String.IsNullOrEmpty(ns))
                {
					classMap = GetClassMap(ns + "." + className);
				}
			}

			if (isFixed)
			{
				if (classMap == null)
					fixedValueGetClassMapByTypeNull[tmp] = true;
				else
					fixedValueGetClassMapByType[tmp] = classMap;
				if (tmp != type)
				{
					if (classMap == null)
						fixedValueGetClassMapByTypeNull[type] = true;
					else
						fixedValueGetClassMapByType[type] = classMap;
				}
			}

			return classMap;
		}

//		public virtual IClassMap GetClassMap(Type type)
//		{
//			string className;
//			string ns = "";
//
//			Type tmp = type;
//
//			while (tmp.Assembly is AssemblyBuilder)
//				tmp = tmp.BaseType;
//
//			className = tmp.Name;
//			ns = tmp.Namespace;
//
//			IClassMap classMap = GetClassMap(className);
//			if (classMap == null)
//			{
//				if (ns.Length > 0)
//				{
//					classMap = GetClassMap(ns + "." + className);
//				}
//			}
//
//			return classMap;
//		}
		
		public virtual IClassMap MustGetClassMap(string findName)
		{
			IClassMap classMap = GetClassMap(findName);

			if (classMap == null)
				throw new MappingException("Could not find type " + findName + " in map file!");

			return classMap;
		}

		private bool fixedGetClassMap = false;
		private Hashtable fixedValueGetClassMap = new Hashtable();

		//Mats : Added case insensitivity
		//[DebuggerStepThrough()]
		public virtual IClassMap GetClassMap(string findName)
		{
			if (findName == null) { return null; }
			if (findName == "") { return null; }
			findName = findName.ToLower(CultureInfo.InvariantCulture);
			if (fixedGetClassMap)
			{
				return (IClassMap) fixedValueGetClassMap[findName];
			}
			if (isFixed)
			{
				IClassMap result = null;
				foreach (IClassMap classMap in m_ClassMaps)
				{
					string low = classMap.Name.ToLower(CultureInfo.InvariantCulture);
					fixedValueGetClassMap[low] = classMap; 
					if (low == findName)
						result = classMap;
					
					if (RootNamespace.Length > 0)
					{
						low = (RootNamespace + "." + classMap.Name).ToLower(CultureInfo.InvariantCulture);
						fixedValueGetClassMap[low] = classMap; 
						if (low == findName)
							result = classMap;
					}
				}
				fixedGetClassMap = true;
				return result;
			}
			else
			{
				foreach (IClassMap classMap in m_ClassMaps)
					if (classMap.Name.ToLower(CultureInfo.InvariantCulture) == findName)
						return classMap;

				if (RootNamespace.Length > 0)
				{
					foreach (IClassMap classMap in m_ClassMaps)
						if ((RootNamespace + "." + classMap.Name).ToLower(CultureInfo.InvariantCulture) == findName)
							return classMap;
				}
			}
			return null;
		}

		[XmlArrayItem(typeof (SourceMap))]
		public virtual ArrayList SourceMaps
		{
			get { return m_SourceMaps; }
			set { m_SourceMaps = value; }
		}

		public virtual ISourceMap GetSourceMap()
		{
			return GetSourceMap(m_Source);
		}

		public virtual void SetSourceMap(ISourceMap SourceMap)
		{
			m_Source = SourceMap.Name;
		}

		public virtual ISourceMap GetSourceMap(string findName)
		{
			if (findName == null) { return null; }
			if (findName == "") { return null; }
			findName = findName.ToLower(CultureInfo.InvariantCulture);
			foreach (ISourceMap sourceMap in m_SourceMaps)
			{
				if (sourceMap.Name.ToLower(CultureInfo.InvariantCulture) == findName)
				{
					return sourceMap;
				}
			}
			return null;
		}

		[XmlArrayItem(typeof (CodeMap))]
		public virtual ArrayList CodeMaps
		{
			get { return m_CodeMaps; }
			set { m_CodeMaps = value; }
		}

		public virtual ICodeMap GetCodeMap(CodeLanguage codeLanguage)
		{
			if (IsFixed("GetCodeMap_" + codeLanguage.ToString() ))
			{
				return (ICodeMap) GetFixedValue("GetCodeMap_" + codeLanguage.ToString());
			}
			foreach (ICodeMap codeMap in this.m_CodeMaps)
			{
				if (codeMap.CodeLanguage.Equals(codeLanguage))
				{
					if (IsFixed())
					{
						SetFixedValue("GetCodeMap_" + codeLanguage.ToString(), codeMap);
					}
					return codeMap;
				}
			}
			return null;
		}

		public virtual ICodeMap EnsuredGetCodeMap(CodeLanguage codeLanguage)
		{
			ICodeMap codeMap = GetCodeMap(codeLanguage);
			if (codeMap == null)
			{
				codeMap = new CodeMap() ;
				codeMap.CodeLanguage = codeLanguage;
				this.m_CodeMaps.Add(codeMap);
			}				
			return codeMap;	
		}


		public override string Name
		{
			get { return m_name; }
			set { m_name = value; }
		}

		[XmlArrayItem(typeof (string))]
		public virtual ArrayList SourceListMapPaths
		{
			get { return m_SourceListMapPaths; }
			set { m_SourceListMapPaths = value; }
		}

		public virtual ArrayList ClassListMapPaths
		{
			get { return m_ClassListMapPaths; }
			set { m_ClassListMapPaths = value; }
		}

		public virtual string Source
		{
			get { return m_Source; }
			set { m_Source = value; }
		}


		public virtual MergeBehaviorType MergeBehavior
		{
			get { return m_MergeBehavior; }
			set { m_MergeBehavior = value; }
		}

		public virtual RefreshBehaviorType RefreshBehavior
		{
			get { return m_RefreshBehavior; }
			set { m_RefreshBehavior = value; }
		}

		public virtual LoadBehavior ListCountLoadBehavior
		{
			get { return m_ListCountLoadBehavior; }
			set { m_ListCountLoadBehavior = value; }
		}

		public virtual string GetLastSavedToPath()
		{
			return m_LastSavedToPath;
		}

		public virtual void SetLastSavedToPath(string value)
		{
			m_LastSavedToPath = value;
		}

		public virtual string GetLoadedFromPath()
		{
			return m_LoadedFromPath;
		}

		public virtual void SetLoadedFromPath(string value)
		{
			m_LoadedFromPath = value;
		}

		public virtual ArrayList GetNamespaceClassMaps(string name)
		{
			ArrayList classMaps = new ArrayList();
			string ns;
			name = name.ToLower(CultureInfo.InvariantCulture);
			foreach (IClassMap classMap in m_ClassMaps)
			{
				ns = classMap.GetNamespace();
				if (ns.ToLower(CultureInfo.InvariantCulture) == name)
				{
					classMaps.Add(classMap);
				}
			}
			return classMaps;
		}

		public virtual ArrayList GetNamespaces()
		{
			Hashtable hashNames = new Hashtable();
			string ns;
			ArrayList listNs = new ArrayList();
			foreach (IClassMap classMap in m_ClassMaps)
			{
				ns = classMap.GetNamespace();
				if (ns.Length > 0)
				{
					if (!(hashNames.ContainsKey(ns.ToLower(CultureInfo.InvariantCulture))))
					{
						hashNames[ns.ToLower(CultureInfo.InvariantCulture)] = ns;
					}
				}
			}
			foreach (string iNs in hashNames.Values)
			{
				listNs.Add(iNs);
			}
			return listNs;
		}

		public virtual bool IsReadOnly
		{
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			get { return m_IsReadOnly; }
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			set { m_IsReadOnly = value; }
		}

		public virtual string RootNamespace
		{
			get { return m_RootNamespace; }
			set { m_RootNamespace = value; }
		}


		public virtual string FieldPrefix
		{
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			get { return m_FieldPrefix; }
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			set { m_FieldPrefix = value; }
		}

		public virtual FieldNameStrategyType FieldNameStrategy
		{
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			get { return m_FieldNameStrategy; }
			//[DebuggerHidden()]
			//[DebuggerStepThrough()]
			set { m_FieldNameStrategy = value; }
		}

		public virtual string InheritsTransientClass
		{
			get { return m_InheritsTransientClass; }
			set { m_InheritsTransientClass = value; }
		}

		[XmlArrayItem(typeof (string))]
		public virtual ArrayList ImplementsInterfaces
		{
			get { return m_ImplementsInterfaces; }
			set { m_ImplementsInterfaces = value; }
		}

		[XmlArrayItem(typeof (string))]
		public virtual ArrayList ImportsNamespaces
		{
			get { return m_ImportsNamespaces; }
			set { m_ImportsNamespaces = value; }
		}

		public virtual bool VerifyCSharpReservedWords
		{
			get { return m_VerifyCSharpReservedWords; }
			set { m_VerifyCSharpReservedWords = value; }
		}

		public virtual bool VerifyVbReservedWords
		{
			get { return m_VerifyVbReservedWords; }
			set { m_VerifyVbReservedWords = value; }
		}

		public virtual bool VerifyDelphiReservedWords
		{
			get { return m_VerifyDelphiReservedWords; }
			set { m_VerifyDelphiReservedWords = value; }
		}

		public virtual OptimisticConcurrencyBehaviorType UpdateOptimisticConcurrencyBehavior
		{
			get { return m_UpdateOptimisticConcurrencyBehavior; }
			set { m_UpdateOptimisticConcurrencyBehavior = value; }
		}

		public virtual OptimisticConcurrencyBehaviorType DeleteOptimisticConcurrencyBehavior
		{
			get { return m_DeleteOptimisticConcurrencyBehavior; }
			set { m_DeleteOptimisticConcurrencyBehavior = value; }
		}

		public MapSerializer MapSerializer
		{
			get { return m_MapSerializer; }
			set { m_MapSerializer = value; }
		}

		public virtual string AssemblyName
		{
			get { return m_AssemblyName; }
			set { m_AssemblyName = value; }
		}

		public virtual LoadBehavior LoadBehavior
		{
			get { return m_LoadBehavior; }
			set { m_LoadBehavior = value; }
		}

		
		public virtual CodeLanguage CodeLanguage
		{
			get { return m_CodeLanguage; }
			set { m_CodeLanguage = value; }
		}

		public virtual string GetAssemblyName()
		{
			if (m_AssemblyName.Length > 0)
			{
				return m_AssemblyName;
			}
			else
			{
				return this.Name;
			}
		}

		public virtual ArrayList GetClassMapsForTable(ITableMap tableMap)
		{
			ArrayList listClassMaps = new ArrayList();
			foreach (IClassMap classMap in m_ClassMaps)
			{
				if (classMap.GetTableMap() == tableMap)
				{
					listClassMaps.Add(classMap);
				}
			}
			return listClassMaps;
		}

		public virtual ArrayList GetPropertyMapsForTable(ITableMap tableMap)
		{
			ArrayList listPropertyMaps = new ArrayList();
			foreach (IClassMap classMap in m_ClassMaps)
			{
				foreach (IPropertyMap propertyMap in classMap.GetNonInheritedPropertyMaps())
				{
					if (propertyMap.Table.Length > 0)
					{
						if (propertyMap.GetTableMap() == tableMap)
						{
							listPropertyMaps.Add(propertyMap);
						}
					}
				}
			}
			return listPropertyMaps;
		}

		public virtual ArrayList GetPropertyMapsForColumn(IColumnMap columnMap)
		{
			return GetPropertyMapsForColumn(columnMap, false);
		}

		public virtual ArrayList GetPropertyMapsForColumn(IColumnMap columnMap, bool noIdColumns)
		{
			ArrayList listPropertyMaps = new ArrayList();
			bool found = false;
			foreach (IClassMap classMap in m_ClassMaps)
			{
				foreach (IPropertyMap propertyMap in classMap.GetNonInheritedPropertyMaps())
				{
					if (propertyMap.GetColumnMap() == columnMap)
					{
						listPropertyMaps.Add(propertyMap);
					}
					else if (propertyMap.GetIdColumnMap() == columnMap)
					{
						if (!(noIdColumns))
						{
							listPropertyMaps.Add(propertyMap);
						}
					}
					else
					{
						foreach (IColumnMap testColumnMap in propertyMap.GetAdditionalColumnMaps())
						{
							if (testColumnMap == columnMap)
							{
								listPropertyMaps.Add(propertyMap);
								found = true;
								break;
							}
						}
						if (!(noIdColumns))
						{
							if (!(found))
							{
								foreach (IColumnMap testColumnMap in propertyMap.GetAdditionalIdColumnMaps())
								{
									if (testColumnMap == columnMap)
									{
										listPropertyMaps.Add(propertyMap);
										break;
									}
								}
							}
						}
					}
				}
			}
			return listPropertyMaps;
		}

		public ValidationMode ValidationMode
		{
			get { return this.m_ValidationMode; }
			set { this.m_ValidationMode = value; }
		}

		
		public long TimeToLive
		{
			get { return this.m_TimeToLive; }
			set { this.m_TimeToLive = value; }
		}
		
		public TimeToLiveBehavior TimeToLiveBehavior
		{
			get { return this.m_TimeToLiveBehavior; }
			set { this.m_TimeToLiveBehavior = value; }
		}

        public DeadlockStrategy DeadlockStrategy
        {
            get { return m_DeadlockStrategy; }
            set { m_DeadlockStrategy = value; }
        }

		#endregion

		#region Object/Object Mapping

		#endregion

		#region Object/Document Mapping

		public virtual string DocSource
		{
			get { return m_DocSource; }
			set { m_DocSource = value; }
		}
		
		public virtual ISourceMap GetDocSourceMap()
		{
			if (m_DocSource.Length > 0)
				return GetSourceMap(m_DocSource);

			return GetSourceMap(m_Source);
		}

		public virtual void SetDocSourceMap(ISourceMap SourceMap)
		{
			m_DocSource = SourceMap.Name;
		}

		#endregion

		#region Cloning

		public override IMap Clone()
		{
			IDomainMap domainMap = new DomainMap();
			Copy(domainMap);
			return domainMap;
		}

		public override IMap DeepClone()
		{
			IDomainMap domainMap = new DomainMap();
			DeepCopy(domainMap);
			return domainMap;
		}

		protected virtual void DoDeepCopy(IDomainMap domainMap)
		{
			IClassMap cloneClassMap;
			ISourceMap cloneSourceMap;
			ICodeMap cloneCodeMap;
			foreach (IClassMap classMap in this.ClassMaps)
			{
				cloneClassMap = (IClassMap) classMap.DeepClone();
				cloneClassMap.DomainMap = domainMap;
			}
			foreach (ISourceMap sourceMap in this.SourceMaps)
			{
				cloneSourceMap = (ISourceMap) sourceMap.DeepClone();
				cloneSourceMap.DomainMap = domainMap;
			}
			foreach (ICodeMap codeMap in this.CodeMaps)
			{
				cloneCodeMap = (ICodeMap) codeMap.DeepClone();
				domainMap.CodeMaps.Add(cloneCodeMap);
				//cloneCodeMap.DomainMap = domainMap;
			}
		}

		public override void DeepCopy(IMap mapObject)
		{
			IDomainMap domainMap = (IDomainMap) mapObject;
			domainMap.ClassMaps.Clear();
			domainMap.SourceMaps.Clear();
			domainMap.CodeMaps.Clear();
			Copy(domainMap);
			DoDeepCopy(domainMap);
		}

		public override bool DeepCompare(IMap compareTo)
		{
			if (!(Compare(compareTo)))
			{
				return false;
			}
			IDomainMap domainMap = (IDomainMap) compareTo;
			IClassMap checkClassMap;
			ISourceMap checkSourceMap;
			ICodeMap checkCodeMap;
			if (!(this.ClassMaps.Count == domainMap.ClassMaps.Count))
			{
				return false;
			}
			if (!(this.SourceMaps.Count == domainMap.SourceMaps.Count))
			{
				return false;
			}
			if (!(this.CodeMaps.Count == domainMap.CodeMaps.Count))
			{
				return false;
			}
			foreach (IClassMap classMap in this.ClassMaps)
			{
				checkClassMap = domainMap.GetClassMap(classMap.Name);
				if (checkClassMap == null)
				{
					return false;
				}
				else
				{
					if (!(classMap.DeepCompare(checkClassMap)))
					{
						return false;
					}
				}
			}
			foreach (ISourceMap sourceMap in this.SourceMaps)
			{
				checkSourceMap = domainMap.GetSourceMap(sourceMap.Name);
				if (checkSourceMap == null)
				{
					return false;
				}
				else
				{
					if (!(sourceMap.DeepCompare(checkSourceMap)))
					{
						return false;
					}
				}
			}
			foreach (ICodeMap codeMap in this.CodeMaps)
			{
				checkCodeMap = domainMap.GetCodeMap(codeMap.CodeLanguage);
				if (checkCodeMap == null)
				{
					return false;
				}
				else
				{
					if (!(codeMap.DeepCompare(checkCodeMap)))
					{
						return false;
					}
				}
			}
			return true;
		}

		public override void DeepMerge(IMap mapObject)
		{
			Copy(mapObject);
			IDomainMap domainMap = (IDomainMap) mapObject;
			IClassMap classMap;
			IClassMap checkClassMap;
			ISourceMap sourceMap;
			ISourceMap checkSourceMap;
			ICodeMap codeMap;
			ICodeMap checkCodeMap;
			ArrayList remove = new ArrayList();
			foreach (IClassMap iClassMap in this.ClassMaps)
			{
				checkClassMap = domainMap.GetClassMap(iClassMap.Name);
				if (checkClassMap == null)
				{
					checkClassMap = (IClassMap) iClassMap.DeepClone();
					checkClassMap.DomainMap = domainMap;
				}
				else
				{
					iClassMap.DeepMerge(checkClassMap);
				}
			}
			foreach (IClassMap iClassMap in domainMap.ClassMaps)
			{
				classMap = this.GetClassMap(iClassMap.Name);
				if (classMap == null)
				{
					remove.Add(iClassMap);
				}
			}
			foreach (IClassMap iClassMap in remove)
			{
				domainMap.ClassMaps.Remove(iClassMap);
			}

			remove.Clear();
			foreach (ISourceMap iSourceMap in this.SourceMaps)
			{
				checkSourceMap = domainMap.GetSourceMap(iSourceMap.Name);
				if (checkSourceMap == null)
				{
					checkSourceMap = (ISourceMap) iSourceMap.DeepClone();
					checkSourceMap.DomainMap = domainMap;
				}
				else
				{
					iSourceMap.DeepMerge(checkSourceMap);
				}
			}
			foreach (ISourceMap iSourceMap in domainMap.SourceMaps)
			{
				sourceMap = this.GetSourceMap(iSourceMap.Name);
				if (sourceMap == null)
				{
					remove.Add(iSourceMap);
				}
			}
			foreach (ISourceMap iSourceMap in remove)
			{
				domainMap.SourceMaps.Remove(iSourceMap);
			}

			remove.Clear();
			foreach (ICodeMap iCodeMap in this.CodeMaps)
			{
				checkCodeMap = domainMap.GetCodeMap(iCodeMap.CodeLanguage);
				if (checkCodeMap == null)
				{
					checkCodeMap = (ICodeMap) iCodeMap.DeepClone();
					//checkCodeMap.DomainMap = domainMap;
				}
				else
				{
					iCodeMap.DeepMerge(checkCodeMap);
				}
			}
			foreach (ICodeMap iCodeMap in domainMap.CodeMaps)
			{
				codeMap = this.GetCodeMap(iCodeMap.CodeLanguage);
				if (codeMap == null)
				{
					remove.Add(iCodeMap);
				}
			}
			foreach (ICodeMap iCodeMap in remove)
			{
				domainMap.CodeMaps.Remove(iCodeMap);
			}

		}

		public override void Copy(IMap mapObject)
		{
			IDomainMap domainMap = (IDomainMap) mapObject;
			domainMap.MergeBehavior = this.MergeBehavior;
			domainMap.RefreshBehavior = this.RefreshBehavior;
			domainMap.ListCountLoadBehavior = this.ListCountLoadBehavior;
			domainMap.Name = this.Name;
			domainMap.Source = this.Source;
			domainMap.IsReadOnly = this.IsReadOnly;
			domainMap.RootNamespace = this.RootNamespace;
			domainMap.FieldPrefix = this.FieldPrefix;
			domainMap.FieldNameStrategy = this.FieldNameStrategy;
			domainMap.InheritsTransientClass = this.InheritsTransientClass;
			domainMap.ImplementsInterfaces = (ArrayList) this.ImplementsInterfaces.Clone();
			domainMap.ImportsNamespaces = (ArrayList) this.ImportsNamespaces.Clone();
			domainMap.DeleteOptimisticConcurrencyBehavior = this.DeleteOptimisticConcurrencyBehavior;
			domainMap.UpdateOptimisticConcurrencyBehavior = this.UpdateOptimisticConcurrencyBehavior;
			domainMap.VerifyCSharpReservedWords = this.VerifyCSharpReservedWords;
			domainMap.VerifyVbReservedWords = this.VerifyVbReservedWords;
			domainMap.VerifyDelphiReservedWords = this.VerifyDelphiReservedWords;
			domainMap.MapSerializer = this.MapSerializer;
			domainMap.AssemblyName = this.AssemblyName;
			domainMap.ValidationMode = this.ValidationMode;
			domainMap.TimeToLive = this.TimeToLive;
			domainMap.TimeToLiveBehavior = this.TimeToLiveBehavior;
			domainMap.LoadBehavior = this.LoadBehavior;
			domainMap.CodeLanguage = this.CodeLanguage;
			domainMap.DocSource = this.DocSource;
            domainMap.DeadlockStrategy = this.DeadlockStrategy;
        }

		public override bool Compare(IMap compareTo)
		{
			if (compareTo == null)
			{
				return false;
			}
			IDomainMap domainMap = (IDomainMap) compareTo;
			if (!(domainMap.MergeBehavior == this.MergeBehavior))
			{
				return false;
			}
			if (!(domainMap.RefreshBehavior == this.RefreshBehavior))
			{
				return false;
			}
			if (!(domainMap.ListCountLoadBehavior == this.ListCountLoadBehavior))
			{
				return false;
			}
			if (!(domainMap.Name == this.Name))
			{
				return false;
			}
			if (!(domainMap.Source == this.Source))
			{
				return false;
			}
			if (!(domainMap.IsReadOnly == this.IsReadOnly))
			{
				return false;
			}
			if (!(domainMap.RootNamespace == this.RootNamespace))
			{
				return false;
			}
			if (!(domainMap.FieldPrefix == this.FieldPrefix))
			{
				return false;
			}
			if (!(domainMap.FieldNameStrategy == this.FieldNameStrategy))
			{
				return false;
			}
			if (!(domainMap.InheritsTransientClass == this.InheritsTransientClass))
			{
				return false;
			}
			if (!(domainMap.DeleteOptimisticConcurrencyBehavior == this.DeleteOptimisticConcurrencyBehavior))
			{
				return false;
			}
			if (!(domainMap.UpdateOptimisticConcurrencyBehavior == this.UpdateOptimisticConcurrencyBehavior))
			{
				return false;
			}
			if (!(domainMap.VerifyCSharpReservedWords == this.VerifyCSharpReservedWords))
			{
				return false;
			}
			if (!(domainMap.VerifyVbReservedWords == this.VerifyVbReservedWords))
			{
				return false;
			}
			if (!(domainMap.VerifyDelphiReservedWords == this.VerifyDelphiReservedWords))
			{
				return false;
			}
			if (!(domainMap.MapSerializer == this.MapSerializer))
			{
				return false;
			}
			if (!(domainMap.AssemblyName == this.AssemblyName))
			{
				return false;
			}
			if (!(domainMap.CodeLanguage == this.CodeLanguage))
			{
				return false;
			}
			if (!(domainMap.ValidationMode == this.ValidationMode))
			{
				return false;
			}
			if (!(domainMap.TimeToLive == this.TimeToLive))
			{
				return false;
			}
			if (!(domainMap.TimeToLiveBehavior == this.TimeToLiveBehavior))
			{
				return false;
			}
			if (!(domainMap.LoadBehavior == this.LoadBehavior))
			{
				return false;
			}
			if (!(domainMap.DocSource == this.DocSource))
			{
				return false;
			}
			if (!(CompareArrayLists(domainMap.ImplementsInterfaces, this.ImplementsInterfaces)))
			{
				return false;
			}
			if (!(CompareArrayLists(domainMap.ImportsNamespaces, this.ImportsNamespaces)))
			{
				return false;
			}
            if (!(domainMap.DeadlockStrategy == this.DeadlockStrategy))
            {
                return false;
            }
            return true;
		}

		#endregion

		#region Dirty

		[XmlIgnore()]
		public virtual bool Dirty
		{
			get { return m_Dirty; }
			set
			{
				m_Dirty = value;
			}
		}

		#endregion

		#region IMap

		public override string GetKey()
		{
			return this.Name;
		}

		#endregion

		#region IFixate

		public override void Fixate()
		{
			base.Fixate();
			foreach (IClassMap classMap in m_ClassMaps)
			{
				classMap.Fixate();
			}
			foreach (ISourceMap sourceMap in m_SourceMaps)
			{
				sourceMap.Fixate();
			}
			this.isFixed = true; 
		}

		public override void UnFixate()
		{
			base.UnFixate();
			foreach (IClassMap classMap in m_ClassMaps)
			{
				classMap.UnFixate();
			}
			foreach (ISourceMap sourceMap in m_SourceMaps)
			{
				sourceMap.UnFixate();
			}
			this.isFixed = false;
			this.fixedGetClassMap = false;
			this.fixedValueGetClassMap.Clear();
			this.fixedValueGetClassMapByType.Clear();
		}

		#endregion

		#region FromDomainMapAttribute

		public static void FromDomainMapAttribute(DomainMapAttribute attrib, Assembly asm, IDomainMap domainMap)
		{
			string name = asm.GetName().Name;

			domainMap.Name = name;
			domainMap.AssemblyName = name;
			domainMap.RootNamespace = name;

			domainMap.DeleteOptimisticConcurrencyBehavior = attrib.DeleteOptimisticConcurrencyBehavior;
			domainMap.DocSource = attrib.DocSource;
			domainMap.FieldNameStrategy = attrib.FieldNameStrategy;
			domainMap.FieldPrefix = attrib.FieldPrefix;
			domainMap.IsReadOnly = attrib.IsReadOnly;
			domainMap.LoadBehavior = attrib.LoadBehavior;
			domainMap.MergeBehavior = attrib.MergeBehavior;
			domainMap.RefreshBehavior = attrib.RefreshBehavior;
			domainMap.ListCountLoadBehavior = attrib.ListCountLoadBehavior;
			if (attrib.RootNamespace != "")
				domainMap.RootNamespace = attrib.RootNamespace ;
			domainMap.Source = attrib.Source ;
			domainMap.TimeToLive = attrib.TimeToLive;
			domainMap.TimeToLiveBehavior = attrib.TimeToLiveBehavior;
			domainMap.UpdateOptimisticConcurrencyBehavior = attrib.UpdateOptimisticConcurrencyBehavior;
			domainMap.ValidationMode = attrib.ValidationMode;
			domainMap.DeadlockStrategy = attrib.DeadlockStrategy;
		}

		#endregion

		//Returns all classMaps with one or more uni-directional (lacking inverse property) 
		//reference properties to the specified class or any of its superclasses
		public virtual IList GetClassMapsWithUniDirectionalReferenceTo(IClassMap classMap, bool nullableOnly)
		{
			IList result = new ArrayList() ;
			foreach (IClassMap testClassMap in this.ClassMaps)
			{
				if (testClassMap.HasUniDirectionalReferenceTo(classMap, nullableOnly))
				{
					result.Add(testClassMap);
				}			
			}
			return result ;			
		}
	}
}
