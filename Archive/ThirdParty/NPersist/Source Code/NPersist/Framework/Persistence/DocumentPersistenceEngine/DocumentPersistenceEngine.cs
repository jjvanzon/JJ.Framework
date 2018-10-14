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
using System.IO;
using System.Text;
using System.Xml;
using Puzzle.NCore.Framework.Exceptions;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NCore.Framework.Logging;

namespace Puzzle.NPersist.Framework.Persistence
{
	/// <summary>
	/// Summary description for ObjectPersistenceEngine.
	/// </summary>
	public class DocumentPersistenceEngine : ContextChild, IPersistenceEngine
	{

		#region Private Variables

		private Hashtable cachedXmlDocuments = new Hashtable() ;

		#endregion

		#region Constructors

		public DocumentPersistenceEngine() : base()
		{
		}

		#endregion

		#region Xml Document Cache

		//non-cached
		protected virtual string LoadFile(object obj, string fileName) => LoadFile(obj.GetType(), fileName);

	    //non-cached
        protected virtual string LoadFile(Type type, string fileName)
        {
            LogMessage message = new LogMessage("Loading objects from file");
            LogMessage verbose = new LogMessage("File: {0}, Object Type: {1}", fileName, type);
            this.Context.LogManager.Debug(this, message, verbose); // do not localize

            if (!(File.Exists(fileName)))
                return "";
            else
            {
                StreamReader fileReader = File.OpenText(fileName);
                string xml = fileReader.ReadToEnd();
                fileReader.Close();

                return xml;
            }
        }

		protected virtual bool HasXmlDocument(string fileName)
		{
			CachedXmlDocument cachedXmlDocument = (CachedXmlDocument) cachedXmlDocuments[fileName];
			if (cachedXmlDocument != null)
				return true;

			return false;
		}

		protected virtual XmlDocument GetXmlDocument(string fileName)
		{
			CachedXmlDocument cachedXmlDocument = (CachedXmlDocument) cachedXmlDocuments[fileName];
			if (cachedXmlDocument == null)
			{
				cachedXmlDocument = GetCachedXmlDocument(fileName);
				cachedXmlDocuments[fileName] = cachedXmlDocument;
			}
			return cachedXmlDocument.XmlDocument ;			
		}

		protected virtual CachedXmlDocument GetCachedXmlDocument(string fileName)
		{
			XmlDocument xmlDocument = LoadXmlDocument(fileName);
			CachedXmlDocument cachedXmlDocument = new CachedXmlDocument(xmlDocument, fileName, File.GetLastWriteTime(fileName)) ;
			return cachedXmlDocument;
		}

		protected virtual XmlDocument LoadXmlDocument(string fileName)
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(fileName);
			return xmlDoc;
		}

		#endregion
		
		#region Xml Document Manipulation

		protected virtual void RemoveAllChildNodes(XmlNode xmlRoot)
		{
			while (xmlRoot.ChildNodes.Count > 0)
				xmlRoot.RemoveChild(xmlRoot.FirstChild);
		}

		protected virtual void RemoveNode(XmlNode xmlRoot, string element)
		{
			XmlNode xmlNode = xmlRoot.SelectSingleNode(element);

			if (xmlNode != null)
				xmlRoot.RemoveChild(xmlNode);
		}

		protected virtual void RemoveAttribute(XmlNode xmlRoot, string attribute)
		{
			if (xmlRoot.Attributes[attribute] != null)
				xmlRoot.Attributes.Remove(xmlRoot.Attributes[attribute]);
		}

		protected virtual XmlNode AddNode(XmlNode xmlRoot, string element)
		{
			XmlNode xmlNode = xmlRoot.OwnerDocument.CreateElement(element) ;
			xmlRoot.AppendChild(xmlNode);

			return xmlNode;
		}

		protected virtual XmlNode GetNode(XmlNode xmlRoot, string element)
		{
			XmlNode xmlNode = xmlRoot.SelectSingleNode(element);

			//If the element doesn't exist, create it
			if (xmlNode == null)
			{
				xmlNode = xmlRoot.OwnerDocument.CreateElement(element) ;
				xmlRoot.AppendChild(xmlNode);
			}

			return xmlNode;
		}

		protected virtual XmlAttribute GetAttribute(XmlNode xmlRoot, string attribute)
		{
			XmlAttribute xmlAttribute = xmlRoot.Attributes[attribute];

			//If the attribute doesn't exist, create it
			if (xmlAttribute == null)
			{
				xmlAttribute = xmlRoot.OwnerDocument.CreateAttribute(attribute);
				xmlRoot.Attributes.Append(xmlAttribute);
			}

			return xmlAttribute;
		}

		protected virtual void SetNodeValue(XmlNode xmlRoot, string element, object value)
		{
			XmlNode xmlNode = GetNode(xmlRoot, element);
			xmlNode.InnerText = value.ToString() ;
		}

		protected virtual void SetAttributeValue(XmlNode xmlRoot, string attribute, object value)
		{
			XmlAttribute xmlAttribute = GetAttribute(xmlRoot, attribute);
			xmlAttribute.Value = value.ToString() ;
		}

		protected virtual XmlNode GetNodeForObject(XmlNode xmlRoot, object obj, IClassMap classMap)
		{
			string element = classMap.GetDocElement();

			XmlNode xmlNode = FindNodeForObject(xmlRoot, obj, classMap);

			//If the element doesn't exist, add it
			if (xmlNode == null)
			{
				xmlNode = xmlRoot.OwnerDocument.CreateElement(element) ;
				xmlRoot.AppendChild(xmlNode);
			}

			return xmlNode;
		}

		protected virtual XmlNode FindNodeForObject(XmlNode xmlRoot, object obj, IClassMap classMap)
		{
			IObjectManager om = this.Context.ObjectManager;
			string element = classMap.GetDocElement();

			string xpath = "";

			foreach (IPropertyMap idPropertyMap in classMap.GetIdentityPropertyMaps() )
			{
				if (xpath.Length > 0 )
					xpath += " and "; // do not localize

				if (idPropertyMap.DocElement.Length > 0)
					xpath += idPropertyMap.GetDocElement() + " = \"" + om.GetPropertyValue(obj, idPropertyMap.Name).ToString() + "\""; // do not localize
				else
					xpath += "@" + idPropertyMap.GetDocAttribute() + " = \"" + om.GetPropertyValue(obj, idPropertyMap.Name).ToString() + "\""; // do not localize
			}

			xpath = element + "[" + xpath + "]";

			return xmlRoot.SelectSingleNode(xpath);
		}

        protected virtual XmlNodeList FindNodesForObjects(XmlNode xmlRoot, IClassMap classMap)
        {
            IObjectManager om = this.Context.ObjectManager;
            string element = classMap.GetDocElement();

            return xmlRoot.SelectNodes(element);
        }

		protected virtual XmlNode LoadObjectNodeFromDomainFile(object obj, IClassMap classMap)
		{
			string fileName = GetFileNamePerDomain(classMap);
            LogMessage message = new LogMessage("Saving object to file", "File: {0}, Object Type: {1}" , fileName , obj.GetType());
			this.Context.LogManager.Debug(this, message); // do not localize
	
			XmlDocument xmlDoc;
			if (File.Exists(fileName))
				xmlDoc = GetXmlDocument(fileName);
			else
				if (HasXmlDocument(fileName))
					xmlDoc = GetXmlDocument(fileName);
				else
					xmlDoc = CreateDomainXmlDocument(classMap, fileName);

			XmlNode xmlRoot = xmlDoc.SelectSingleNode(classMap.GetDocSourceMap().GetDocRoot() );
			XmlNode xmlClass = GetNode(xmlRoot, classMap.GetDocRoot() );
			XmlNode xmlObject = GetNodeForObject(xmlClass, obj, classMap );

			return xmlObject;
		}

		protected virtual XmlNode LoadObjectNodeFromClassFile(object obj, IClassMap classMap)
		{
			string fileName = GetFileNamePerClass(classMap);
            LogMessage message = new LogMessage("Removing object from file");
            LogMessage verbose = new LogMessage("File: {0}, Object Type: {1}",fileName , obj.GetType());
			this.Context.LogManager.Debug(this, message,verbose); // do not localize
//			
//			if (!(File.Exists(fileName)))
//				throw new NPersistException("The file '" + fileName + "' could not be found!"); // do not localize

			XmlDocument xmlDoc;
			if (File.Exists(fileName))
				xmlDoc = GetXmlDocument(fileName);
			else
				if (HasXmlDocument(fileName))
				xmlDoc = GetXmlDocument(fileName);
			else
				xmlDoc = CreateClassXmlDocument(classMap, fileName);


			XmlNode xmlRoot = xmlDoc.SelectSingleNode(classMap.GetDocRoot() );
			XmlNode xmlObject = GetNodeForObject(xmlRoot, obj, classMap );

			return xmlObject;			
		}


		#endregion

		#region IPersistenceEngine

		
		public void Begin() => cachedXmlDocuments.Clear();

	    public void Commit()
		{
            //TODO
			//lock all files

			foreach (CachedXmlDocument cachedXmlDocument in cachedXmlDocuments.Values)
			{
				if (cachedXmlDocument.NewFile)
				{
					//Check that the file does not exist
					;					
				}
				else
				{
					//Check lastUpdated date
					;
				}

				cachedXmlDocument.XmlDocument.Save(cachedXmlDocument.FileName) ;
			}

			//un-lock all files
		}

		public void Abort() => cachedXmlDocuments.Clear();

	    public virtual void LoadObject(ref object obj)
		{
            LogMessage message = new LogMessage("Loading object by id");
            LogMessage verbose = new LogMessage ("Type: {0}" , obj.GetType());
            this.Context.LogManager.Info(this, message, verbose); // do not localize

			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType() );


			if (classMap.DocClassMapMode == DocClassMapMode.PerDomain)
			{
				LoadPerDomain(ref obj, classMap);
			}
			else if (classMap.DocClassMapMode == DocClassMapMode.PerClass)
			{
				LoadPerClass(ref obj, classMap);									
			}
			else if (classMap.DocClassMapMode == DocClassMapMode.Default || classMap.DocClassMapMode == DocClassMapMode.PerObject)
			{
				LoadPerObject(ref obj, classMap);				
			}

			if (obj != null)
				this.Context.IdentityMap.RegisterLoadedObject(obj);
		}

		public virtual void LoadObjectByKey(ref object obj, string keyPropertyName, object keyValue) => throw new NPersistException("Can't load objects by key using DocumentPersistenceEngine!");

	    public virtual void InsertObject(object obj, IList stillDirty)
		{
            LogMessage message = new LogMessage("Inserting object");
            LogMessage verbose = new LogMessage("Type: {0}" , obj.GetType());
            this.Context.LogManager.Info(this, message, verbose); // do not localize

			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType() );

			if (classMap.DocClassMapMode == DocClassMapMode.PerDomain)
			{
				SavePerDomain(obj, classMap, true);								
			}
			else if (classMap.DocClassMapMode == DocClassMapMode.PerClass)
			{
				SavePerClass(obj, classMap, true);				
			}
			else if (classMap.DocClassMapMode == DocClassMapMode.Default || classMap.DocClassMapMode == DocClassMapMode.PerObject)
			{
				SavePerObject(obj, classMap, true);				
			}
		}

		public virtual void RemoveObject(object obj)
		{
            LogMessage message = new LogMessage("Removing object");
            LogMessage verbose = new LogMessage("Type: {0}", obj.GetType());
			this.Context.LogManager.Info(this, message, verbose); // do not localize

			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType() );

			if (classMap.DocClassMapMode == DocClassMapMode.PerDomain)
			{
				RemovePerDomain(obj, classMap);										
			}
			else if (classMap.DocClassMapMode == DocClassMapMode.PerClass)
			{
				RemovePerClass(obj, classMap);						
			}
			else if (classMap.DocClassMapMode == DocClassMapMode.Default || classMap.DocClassMapMode == DocClassMapMode.PerObject)
			{
				RemovePerObject(obj, classMap);				
			}
		}

		public virtual void UpdateObject(object obj, IList stillDirty)
		{
            LogMessage message = new LogMessage("Updating object");
            LogMessage verbose = new LogMessage("Type: {0}" , obj.GetType());

			this.Context.LogManager.Info(this,message ,verbose); // do not localize

			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType() );

			if (classMap.DocClassMapMode == DocClassMapMode.PerDomain)
			{
				SavePerDomain(obj, classMap, false);				
			}
			else if (classMap.DocClassMapMode == DocClassMapMode.PerClass)
			{
				SavePerClass(obj, classMap, false);				
			}
			else if (classMap.DocClassMapMode == DocClassMapMode.Default || classMap.DocClassMapMode == DocClassMapMode.PerObject)
			{
				SavePerObject(obj, classMap, false);				
			}
		}

		public virtual void LoadProperty(object obj, string propertyName)
		{
            LogMessage message = new LogMessage("Loading property");
            LogMessage verbose = new LogMessage("Property: {0}, Object Type: {1}" , propertyName , obj.GetType());
			this.Context.LogManager.Info(this, message, verbose); // do not localize

			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(obj.GetType() );
			IPropertyMap propertyMap = classMap.MustGetPropertyMap(propertyName);

			//if (propertyMap.DocPropertyMapMode == DocPropertyMapMode.Default || propertyMap.DocPropertyMapMode == DocPropertyMapMode.Inline)
			if (propertyMap.DocPropertyMapMode == DocPropertyMapMode.Inline)
				LoadObject(ref obj);
		}

		public virtual IList LoadObjects(IQuery query, IList listToFill)
		{
			NPathQuery npath = query as NPathQuery;
			if (npath == null)
				throw new NPersistException("Only NPath query capabilities are supported by DocumentPersistenceEngine!");

			IList allObjects = LoadObjects(query.PrimaryType,  query.RefreshBehavior, null);
			IList result = this.Context.FilterObjects(allObjects, npath);
			if (listToFill != null)
			{
				foreach (object obj in result)
					listToFill.Add(obj);

				return listToFill;
			}
			return result;
		}

        public virtual IList LoadObjects(Type type, RefreshBehaviorType refreshBehavior, IList listToFill)
        {
            LogMessage message = new LogMessage("Loading all objects of type");
            LogMessage verbose = new LogMessage("Type: {0}", type);
            this.Context.LogManager.Info(this, message, verbose); // do not localize

			if (listToFill == null)
				listToFill = new ArrayList();

            IClassMap classMap = this.Context.DomainMap.MustGetClassMap(type);

            if (classMap.DocClassMapMode == DocClassMapMode.PerDomain)
            {
                LoadObjectsPerDomain(type, refreshBehavior, listToFill, classMap);
            }
            else if (classMap.DocClassMapMode == DocClassMapMode.PerClass)
            {
                LoadObjectsPerClass(type, refreshBehavior, listToFill, classMap);
            }
            else if (classMap.DocClassMapMode == DocClassMapMode.Default || classMap.DocClassMapMode == DocClassMapMode.PerObject)
            {
                LoadObjectsPerObject(type, refreshBehavior, listToFill, classMap);
            }

			foreach (IClassMap subClassMap in classMap.GetSubClassMaps())
			{
				Type subType = this.Context.AssemblyManager.GetTypeFromClassMap(subClassMap);	
				LoadObjects(subType, refreshBehavior, listToFill);
			}

            return listToFill;
        }

		public virtual DataTable LoadDataTable(IQuery query)
		{
			NPathQuery npath = query as NPathQuery;
			if (npath == null)
				throw new NPersistException("Only NPath query capabilities are supported by DocumentPersistenceEngine!");

			IList allObjects = LoadObjects(query.PrimaryType,  query.RefreshBehavior, null);
			return this.Context.FilterIntoDataTable(allObjects, npath);
		}

		public virtual IList GetObjectsBySql(string sqlQuery, Type type, IList idColumns, IList typeColumns, Hashtable propertyColumnMap, IList parameters, RefreshBehaviorType refreshBehavior, IList listToFill) => throw new NPersistException("Sql query capabilities not implemented in DocumentPersistenceEngine! Please use NPath queries instead.");

	    public virtual IList GetObjectsOfClassWithUniReferencesToObject(Type type, object obj) => throw new IAmOpenSourcePleaseImplementMeException("");

	    public virtual void TouchTable(ITableMap tableMap, int exceptionLimit) { ; }

		#endregion

		#region IPersistenceEngine Helpers

		protected virtual void LoadPerDomain(ref object obj, IClassMap classMap)
		{
			string fileName = GetFileNamePerDomain(classMap);
			string xml = LoadFile(obj, fileName);
			if (xml == "")
				obj = null;
			else
				DeserializeDomain(ref obj, classMap, xml);
		}

		protected virtual void LoadPerClass(ref object obj, IClassMap classMap)
		{
			string fileName = GetFileNamePerClass(classMap);
			string xml = LoadFile(obj, fileName);
			if (xml == "")
				obj = null;
			else
				DeserializeClass(ref obj, classMap, xml);
		}

		protected virtual void LoadPerObject(ref object obj, IClassMap classMap)
		{
			string fileName = GetFileNamePerObject(obj, classMap);
			string xml = LoadFile(obj, fileName);
			if (xml == "")
				obj = null;
			else
				DeserializeObject(obj, classMap, xml);				
		}

        protected virtual void LoadObjectsPerDomain(Type type, RefreshBehaviorType refreshBehavior, IList listToFill, IClassMap classMap)
        {
            string fileName = GetFileNamePerDomain(classMap);
            string xml = LoadFile(type, fileName);
            if (xml != "")
                DeserializeDomain(type, listToFill, classMap, xml);
        }

        protected virtual void LoadObjectsPerClass(Type type, RefreshBehaviorType refreshBehavior, IList listToFill, IClassMap classMap)
        {
            string fileName = GetFileNamePerClass(classMap);
            string xml = LoadFile(type, fileName);
            if (xml != "")
                DeserializeClass(type, listToFill, classMap, xml);
        }

        protected virtual void LoadObjectsPerObject(Type type, RefreshBehaviorType refreshBehavior, IList listToFill, IClassMap classMap)
        {
			string directory = GetDirectoryForClass(classMap);
			string className = classMap.GetFullName().ToLower();
			foreach (string fileName in Directory.GetFiles(directory))
			{
				FileInfo file = new FileInfo(fileName);
				if (file.Extension.ToLower() == ".xml")
				{
					if (file.Name.Length > className.Length)
					{
						if (file.Name.Substring(0, className.Length).ToLower() == className)
						{
							string xml = LoadFile(type, fileName);
							if (xml != "")
								DeserializeObject(type, listToFill, classMap, xml);							
						}
					}
				}
			}
        }

		protected virtual void SavePerDomain(object obj, IClassMap classMap, bool creating)
		{
			XmlNode xmlObject = LoadObjectNodeFromDomainFile(obj, classMap );
			SerializeObject(xmlObject, obj, classMap, creating);
		}

		protected virtual void SavePerClass(object obj, IClassMap classMap, bool creating)
		{
			XmlNode xmlObject = LoadObjectNodeFromClassFile(obj, classMap );
			SerializeObject(xmlObject, obj, classMap, creating);
		}

		
		protected virtual void SavePerObject(object obj, IClassMap classMap, bool creating)
		{
			string fileName = GetFileNamePerObject(obj, classMap);
            LogMessage message = new LogMessage("Saving object to file");
            LogMessage verbose = new LogMessage("File: {0},, Object Type: {1}" , fileName , obj.GetType());
			this.Context.LogManager.Debug(this, message, verbose); // do not localize

			XmlDocument xmlDoc;

			if (creating)
			{
				if (File.Exists(fileName))
					throw new NPersistException("The file '" + fileName + "' already exists!"); // do not localize

				xmlDoc = CreateObjectXmlDocument(classMap, fileName);

			}
			else
			{
				if (!(File.Exists(fileName)))
					throw new NPersistException("The file '" + fileName + "' could not be found!"); // do not localize

				xmlDoc = GetXmlDocument(fileName);
			}

			XmlNode xmlObject = xmlDoc.SelectSingleNode(classMap.GetDocElement() );

			SerializeObject(xmlObject, obj, classMap, creating);
		}


		protected virtual void RemovePerDomain(object obj, IClassMap classMap)
		{
			XmlNode xmlObject = LoadObjectNodeFromDomainFile(obj, classMap );
			xmlObject.ParentNode.RemoveChild(xmlObject);
		}


		protected virtual void RemovePerClass(object obj, IClassMap classMap)
		{
			XmlNode xmlObject = LoadObjectNodeFromClassFile(obj, classMap );
			xmlObject.ParentNode.RemoveChild(xmlObject);
		}

		protected virtual void RemovePerObject(object obj, IClassMap classMap)
		{
			string fileName = GetFileNamePerObject(obj, classMap);
            LogMessage message = new LogMessage("Removing file for object");
            LogMessage verbose = new LogMessage("File: {0},, Object Type: {1}" , fileName , obj.GetType());
			this.Context.LogManager.Debug(this, message,verbose); // do not localize
			
			if (!(File.Exists(fileName)))
				throw new NPersistException("The file '" + fileName + "' could not be found!"); // do not localize

			File.Delete(fileName);
		}

		#endregion

		#region Xml Document Creation

		protected virtual XmlDocument CreateDomainXmlDocument(IClassMap classMap, string fileName)
		{
			ISourceMap sourceMap = classMap.GetDocSourceMap();

			MemoryStream ms = new MemoryStream() ;
			XmlTextWriter xmlWriter = new XmlTextWriter(
				ms,
				Encoding.GetEncoding( sourceMap.GetDocEncoding() ));

			xmlWriter.Formatting = Formatting.Indented;

			xmlWriter.WriteStartDocument(false);

			xmlWriter.WriteDocType("Domain",null,null,null);
			xmlWriter.WriteComment("Serialized domain objects"); // do not localize

			xmlWriter.WriteStartElement(sourceMap.GetDocRoot() , null);	

			xmlWriter.WriteEndElement();
			xmlWriter.WriteEndDocument();

			//Write the XML to file and close the writer
			xmlWriter.Flush();
			string xml = Encoding.GetEncoding( "utf-8" ).GetString(ms.ToArray(),0,(int)ms.Length);
			xmlWriter.Close();

			//TODO: ugly hack!! Do this right way to avoid extra char in the beginning!!
			xml = xml.Substring(1);

			XmlDocument xmlDocument = new XmlDocument() ;
			xmlDocument.LoadXml(xml);

			CachedXmlDocument cachedXmlDocument = new CachedXmlDocument(xmlDocument, fileName) ;
			cachedXmlDocuments[fileName] = cachedXmlDocument;

			return xmlDocument;		
		}
		protected virtual XmlDocument CreateClassXmlDocument(IClassMap classMap, string fileName)
		{
			ISourceMap sourceMap = classMap.GetDocSourceMap();

			MemoryStream ms = new MemoryStream() ;
			XmlTextWriter xmlWriter = new XmlTextWriter(
				ms,
				Encoding.GetEncoding( sourceMap.GetDocEncoding() ));

			xmlWriter.Formatting = Formatting.Indented;

			xmlWriter.WriteStartDocument(false);

			xmlWriter.WriteDocType("ObjectList",null,null,null);
			xmlWriter.WriteComment("Serialized object list"); // do not localize

			xmlWriter.WriteStartElement(classMap.GetDocRoot() , null);	

			xmlWriter.WriteEndElement();
			xmlWriter.WriteEndDocument();

			//Write the XML to file and close the writer
			xmlWriter.Flush();
			string xml = Encoding.GetEncoding( "utf-8" ).GetString(ms.ToArray(),0,(int)ms.Length);
			xmlWriter.Close();

			//Obs fulhack!! Jag får ett konstigt skräptecken i början!!
			xml = xml.Substring(1);

			XmlDocument xmlDocument = new XmlDocument() ;
			xmlDocument.LoadXml(xml);

			CachedXmlDocument cachedXmlDocument = new CachedXmlDocument(xmlDocument, fileName) ;
			cachedXmlDocuments[fileName] = cachedXmlDocument;

			return xmlDocument;		
		}

		protected virtual XmlDocument CreateObjectXmlDocument(IClassMap classMap, string fileName)
		{
			ISourceMap sourceMap = classMap.GetDocSourceMap();

			MemoryStream ms = new MemoryStream() ;
			XmlTextWriter xmlWriter = new XmlTextWriter(
				ms,
				Encoding.GetEncoding( sourceMap.GetDocEncoding() ));

			xmlWriter.Formatting = Formatting.Indented;

			xmlWriter.WriteStartDocument(false);

			xmlWriter.WriteDocType("Object",null,null,null);
			xmlWriter.WriteComment("Serialized object"); // do not localize

			xmlWriter.WriteStartElement(classMap.GetDocElement(), null);	

			xmlWriter.WriteEndElement();
			xmlWriter.WriteEndDocument();

			//Write the XML to file and close the writer
			xmlWriter.Flush();
			string xml = Encoding.GetEncoding( "utf-8" ).GetString(ms.ToArray(),0,(int)ms.Length);
			xmlWriter.Close();

			//Obs fulhack!! Jag får ett konstigt skräptecken i början!!
			xml = xml.Substring(1);

			XmlDocument xmlDocument = new XmlDocument() ;
			xmlDocument.LoadXml(xml);

			CachedXmlDocument cachedXmlDocument = new CachedXmlDocument(xmlDocument, fileName) ;
			cachedXmlDocuments[fileName] = cachedXmlDocument;

			return xmlDocument;
		}

		#endregion

		#region File Naming Strategies

		protected virtual string GetFileNamePerDomain(IClassMap classMap)
		{
			IObjectManager om = this.Context.ObjectManager;

			string directory = GetDirectoryForDomain(classMap);

			string fileName = directory + @"\" + classMap.DomainMap.Name + ".xml";

			return fileName;
		}

		protected virtual string GetFileNamePerClass(IClassMap classMap)
		{
			IObjectManager om = this.Context.ObjectManager;

			string directory = GetDirectoryForClass(classMap);

			string fileName = directory + @"\" + classMap.GetFullName() + ".xml";

			return fileName;
		}

		protected virtual string GetFileNamePerObject(object obj, IClassMap classMap)
		{
			IObjectManager om = this.Context.ObjectManager;

			string directory = GetDirectoryForClass(classMap);

			string fileName = directory + @"\" + classMap.GetFullName() + "." + om.GetObjectIdentity(obj) + ".xml";

			return fileName;
		}

		protected virtual string GetDirectoryForDomain(IClassMap classMap)
		{
			ISourceMap sourceMap = classMap.GetDocSourceMap();

			if (sourceMap == null)
				throw new MappingException("Can't find Document Source Map for '" + classMap.GetFullName() + "' in the npersist xml mapping file!"); // do not localize

			string directory = sourceMap.DocPath;

			if (!(Directory.Exists(directory)))
				throw new NPersistException("Can't find directory: " + directory); // do not localize

			return directory;
		}

		protected virtual string GetDirectoryForClass(IClassMap classMap)
		{
			ISourceMap sourceMap = classMap.GetDocSourceMap();

			if (sourceMap == null)
				throw new MappingException("Can't find Document Source Map for '" + classMap.GetFullName() + "' in the npersist xml mapping file!"); // do not localize

			string directory = sourceMap.DocPath;

			if (!(Directory.Exists(directory)))
				throw new NPersistException("Can't find directory: " + directory); // do not localize

			directory += @"\" + classMap.GetFullName();

			if (!(Directory.Exists(directory)))
			{
				try
				{
					Directory.CreateDirectory(directory);
				}
				catch (Exception ex)
				{
					throw new NPersistException("Could not create directory '" + directory + "': " + ex.Message, ex); // do not localize
				}
			}

			return directory;
		}

		#endregion

		#region Serialization

		protected virtual void SerializeObject(XmlNode xmlObject, object obj, IClassMap classMap, bool creating) => SerializeObject(xmlObject, obj, classMap, creating, false);

	    protected virtual void SerializeObject(XmlNode xmlObject, object obj, IClassMap classMap, bool creating, bool specifyClass)
		{
			if (specifyClass)
				SetAttributeValue(xmlObject, "class", classMap.GetFullName() );

			foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
			{
				if (propertyMap.ReferenceType == ReferenceType.None)
				{
					if (propertyMap.IsCollection)
					{
						;
					}
					else
					{
						SerializeInlineProperty(xmlObject, obj, classMap, propertyMap, creating);
					}
				}
				else
				{
					//if (propertyMap.DocPropertyMapMode == DocPropertyMapMode.Default || propertyMap.DocPropertyMapMode == DocPropertyMapMode.Inline)
					if (propertyMap.DocPropertyMapMode == DocPropertyMapMode.Inline)
					{
						if (propertyMap.IsCollection)
						{
							SerializeInlineObjectList(xmlObject, obj, classMap, propertyMap, creating);
						}
						else
						{
							SerializeInlineObject(xmlObject, obj, classMap, propertyMap, creating);
						}						
					}
					else
					{
						if (propertyMap.IsCollection)
						{
							SerializeInlineReferenceList(xmlObject, obj, classMap, propertyMap, creating);
						}
						else
						{
							SerializeInlineReference(xmlObject, obj, classMap, propertyMap, creating);
						}												
					}
				}
				
			}
		}


		protected virtual void SerializeInlineProperty(XmlNode xmlObject, object obj, IClassMap classMap, IPropertyMap propertyMap, bool creating)
		{
			IObjectManager om = this.Context.ObjectManager;
			string element = propertyMap.DocElement;
			object value = null ;
			bool isNull = om.GetNullValueStatus(obj, propertyMap.Name);

			//Optimistic concurrency
			if (!(creating))
			{
				//Check value in xmlDoc against property original value, make sure they match
				
			}

			if (isNull)
			{
				om.SetOriginalPropertyValue(obj, propertyMap.Name, System.DBNull.Value);	
				
				//if the attribute/element exists, remove it
				if (element.Length > 0)
				{
					RemoveNode(xmlObject, element);
				}
				else
				{
					RemoveAttribute(xmlObject, propertyMap.GetDocAttribute());
				}

			}
			else
			{						
				value = om.GetPropertyValue(obj, propertyMap.Name) ;				
				om.SetOriginalPropertyValue(obj, propertyMap.Name, value);

				if (element.Length > 0)
				{
					SetNodeValue(xmlObject, element, value);
				}
				else
				{
					SetAttributeValue(xmlObject, propertyMap.GetDocAttribute(), value);					
				}
			}
		}

		protected virtual void SerializeInlineReference(XmlNode xmlObject, object obj, IClassMap classMap, IPropertyMap propertyMap, bool creating)
		{
			IObjectManager om = this.Context.ObjectManager;
			object value = null ;
			bool isNull = om.GetNullValueStatus(obj, propertyMap.Name);

			if (!(isNull))
			{
				value = om.GetPropertyValue(obj, propertyMap.Name) ;				
				if (value == null)
					isNull = true;
			}

			//Optimistic concurrency
			if (!(creating))
			{
				//Check value in xmlDoc against property original value, make sure they match
				
			}

			if (isNull)
			{
				om.SetOriginalPropertyValue(obj, propertyMap.Name, System.DBNull.Value);						
				RemoveNode(xmlObject, propertyMap.GetDocElement() );
			}
			else
			{						
				om.SetOriginalPropertyValue(obj, propertyMap.Name, value);
				SerializeInlineReferenceElement(obj, GetNode(xmlObject, propertyMap.GetDocElement()), value);
			}
		}

		protected virtual void SerializeInlineReferenceElement(object obj, XmlNode xmlElement, object value)
		{
			IObjectManager om = this.Context.ObjectManager;
			IDomainMap domainMap = this.Context.DomainMap;
			IClassMap classMap = domainMap.MustGetClassMap(value.GetType());

			SetAttributeValue(xmlElement, "id", om.GetObjectIdentity(value) );
			SetAttributeValue(xmlElement, "class", classMap.Name);

			IPropertyMap parent = classMap.GetDocParentPropertyMap() ;
			if (parent != null)
			{
				object rootObject = GetRootObject(value, parent);

				if (rootObject == null)
					throw new NPersistException("Could not find root object!"); // do not localize

				SetAttributeValue(xmlElement, "root-id", om.GetObjectIdentity(rootObject) );
				SetAttributeValue(xmlElement, "root-class", domainMap.MustGetClassMap(rootObject.GetType()).Name);
			}
		}

		protected virtual object GetRootObject(object obj, IPropertyMap parent)
		{
			object rootObject = this.Context.ObjectManager.GetPropertyValue(obj, parent.Name);

			if (rootObject == null)
				throw new NPathException("Can't serialize reference to inlined object with null reference in parent path!"); // do not localize
			
			IClassMap classMap = this.Context.DomainMap.MustGetClassMap(rootObject.GetType());

			parent = classMap.GetDocParentPropertyMap() ;

			if (parent != null)
			{
				rootObject = GetRootObject(rootObject,
					parent);
			}
			
			return rootObject;
		}

		protected virtual void SerializeInlineReferenceList(XmlNode xmlObject, object obj, IClassMap classMap, IPropertyMap propertyMap, bool creating)
		{
			IObjectManager om = this.Context.ObjectManager;
			IListManager lm = this.Context.ListManager;

			IList list = (IList) om.GetPropertyValue(obj, propertyMap.Name) ;

			//Optimistic concurrency
			if (!(creating))
			{
				//Check value in xmlDoc against property original value, make sure they match
				
			}
		
			XmlNode xmlList = GetNode(xmlObject, propertyMap.GetDocElement());

			RemoveAllChildNodes(xmlList);

			foreach (object value in list)
			{
				XmlNode xmlElement = AddNode(xmlList, "item");
				SerializeInlineReferenceElement(obj, xmlElement, value);
			}

			//IList orgList =   lm.CloneList(obj, propertyMap, ((IList) (om.GetPropertyValue(obj, propertyMap.Name))));
			IList orgList =   new ArrayList( ((IList) (om.GetPropertyValue(obj, propertyMap.Name))));
			om.SetOriginalPropertyValue(obj, propertyMap.Name, orgList);

		}

		
		protected virtual void SerializeInlineObject(XmlNode xmlObject, object obj, IClassMap classMap, IPropertyMap propertyMap, bool creating)
		{
			IObjectManager om = this.Context.ObjectManager;
			object value = null ;
			bool isNull = om.GetNullValueStatus(obj, propertyMap.Name);

			if (!(isNull))
			{
				value = om.GetPropertyValue(obj, propertyMap.Name) ;				
				if (value == null)
					isNull = true;
			}

			//Optimistic concurrency
			if (!(creating))
			{
				//Check value in xmlDoc against property original value, make sure they match
				
			}

			if (isNull)
			{
				om.SetOriginalPropertyValue(obj, propertyMap.Name, System.DBNull.Value);
				RemoveNode(xmlObject, propertyMap.GetDocElement());
			}
			else
			{
				om.SetOriginalPropertyValue(obj, propertyMap.Name, value);
				XmlNode xmlInline = GetNode(xmlObject, propertyMap.GetDocElement());
				SerializeInlineObjectElement(xmlObject, obj, xmlInline, value, creating);
			}
		}

		protected virtual void SerializeInlineObjectList(XmlNode xmlObject, object obj, IClassMap classMap, IPropertyMap propertyMap, bool creating)
		{
			IObjectManager om = this.Context.ObjectManager;
			IListManager lm = this.Context.ListManager;

			IList list = (IList) om.GetPropertyValue(obj, propertyMap.Name) ;

			XmlNode xmlList = GetNode(xmlObject, propertyMap.GetDocElement());
			RemoveAllChildNodes(xmlList);

			foreach (object value in list)
			{
				XmlNode xmlInline = AddNode(xmlObject, "item");
				SerializeInlineObjectElement(xmlObject, obj, xmlInline , value, creating);
			}

			//IList orgList =   lm.CloneList(obj, propertyMap, ((IList) (om.GetPropertyValue(obj, propertyMap.Name))));
			IList orgList =   new ArrayList( ((IList) (om.GetPropertyValue(obj, propertyMap.Name))));
			om.SetOriginalPropertyValue(obj, propertyMap.Name, orgList);

		}

		protected virtual void SerializeInlineObjectElement(XmlNode xmlObject, object obj, XmlNode xmlInline, object value, bool creating)
		{
			IDomainMap domainMap = this.Context.DomainMap;
			IClassMap classMap = domainMap.MustGetClassMap(value.GetType());

			SerializeObject(xmlInline, value, classMap, creating, true);

			//hmmmmmmmmmmmmm...................
			this.Context.UnitOfWork.RegisterClean(value);
		}

		protected virtual string SerializeProperty(object obj) => "";

	    protected virtual string SerializeValue(object obj) => "";

	    #endregion

		#region Deserialization

		private object InstantiateObject(Type type, IClassMap classMap, XmlNode xmlObject)
		{
			IObjectManager om = this.Context.ObjectManager;
			string element = classMap.GetDocElement();

			string identity = "";
			string separator = classMap.GetIdentitySeparator();

			foreach (IPropertyMap idPropertyMap in classMap.GetIdentityPropertyMaps())
			{
				if (identity.Length > 0)
					identity += separator;

				if (idPropertyMap.DocElement.Length > 0)
				{
					XmlNode idNode = xmlObject.SelectSingleNode(idPropertyMap.GetDocElement());
					if (idNode != null)
						identity += idNode.InnerText;
					else
						throw new NPersistException(String.Format("Could not find id element {0} for property {1} of class {2} in element {3}", idPropertyMap.GetDocElement(), idPropertyMap.Name, type.ToString(), xmlObject.Name));
				}
				else
				{
					string attribName = idPropertyMap.GetDocAttribute();
					if (xmlObject.Attributes[attribName] != null)
						identity += xmlObject.Attributes[attribName].Value;
					else
						throw new NPersistException(String.Format("Could not find id attribute {0} for property {1} of class {2} in element {3}", attribName, idPropertyMap.Name, type.ToString(), xmlObject.Name));
				}
			}

			return this.Context.GetObjectById(identity, type, true);
		}
								
		protected virtual void DeserializeDomain(ref object obj, IClassMap classMap, string xml)
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(xml);
			XmlNode xmlRoot = xmlDoc.SelectSingleNode(classMap.GetDocSourceMap().GetDocRoot());
			XmlNode xmlClass = xmlRoot.SelectSingleNode(classMap.GetDocRoot());
			XmlNode xmlObject = FindNodeForObject(xmlClass, obj, classMap);
			if (xmlObject == null)
				obj = null;
			else
				DeserializeObject(obj, classMap, xmlObject);
		}

        protected virtual void DeserializeDomain(Type type, IList listToFill, IClassMap classMap, string xml)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNode xmlRoot = xmlDoc.SelectSingleNode(classMap.GetDocSourceMap().GetDocRoot());
            XmlNode xmlClass = xmlRoot.SelectSingleNode(classMap.GetDocRoot());
            XmlNodeList xmlObjects = FindNodesForObjects(xmlClass, classMap);
            if (xmlObjects != null)
            {
                foreach (XmlNode xmlObject in xmlObjects)
                {
                    object obj = InstantiateObject(type, classMap, xmlObject);
                    DeserializeObject(obj, classMap, xmlObject);
                    listToFill.Add(obj);
                }
            }
        }

		protected virtual void DeserializeClass(ref object obj, IClassMap classMap, string xml)
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(xml);
			XmlNode xmlRoot = xmlDoc.SelectSingleNode(classMap.GetDocRoot());
			XmlNode xmlObject = FindNodeForObject(xmlRoot, obj, classMap);
			if (xmlObject == null)
				obj = null;
			else
				DeserializeObject(obj, classMap, xmlObject);
		}

		protected virtual void DeserializeClass(Type type, IList listToFill, IClassMap classMap, string xml)
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(xml);
			XmlNode xmlRoot = xmlDoc.SelectSingleNode(classMap.GetDocRoot());
			XmlNodeList xmlObjects = FindNodesForObjects(xmlRoot, classMap);
			if (xmlObjects != null)
			{
				foreach (XmlNode xmlObject in xmlObjects)
				{
					object obj = InstantiateObject(type, classMap, xmlObject);
					DeserializeObject(obj, classMap, xmlObject);
					listToFill.Add(obj);
				}
			}
		}
				
		protected virtual void DeserializeObject(object obj, IClassMap classMap, string xml)
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(xml);
			XmlNode xmlRoot = xmlDoc.SelectSingleNode(classMap.GetDocElement());
			DeserializeObject(obj, classMap, xmlRoot);
		}

		protected virtual void DeserializeObject(Type type, IList listToFill, IClassMap classMap, string xml)
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(xml);
			XmlNode xmlRoot = xmlDoc.SelectSingleNode(classMap.GetDocElement());
			object obj = InstantiateObject(type, classMap, xmlRoot);
			DeserializeObject(obj, classMap, xmlRoot);
			listToFill.Add(obj);
		}

		protected virtual void DeserializeObject(object obj, IClassMap classMap, XmlNode xmlObject) => DeserializeObject(obj, classMap, xmlObject, false);

	    protected virtual void DeserializeObject(object obj, IClassMap classMap, XmlNode xmlObject, bool idOnly)
		{
			foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps())
			{
				if (idOnly == false || propertyMap.IsIdentity )
				{
					if (propertyMap.ReferenceType == ReferenceType.None)
					{
						if (propertyMap.IsCollection)
						{
							;						
						}
						else
						{
							DeserializeInlineProperty(obj, classMap, propertyMap, xmlObject);
						}
					}
					else
					{
						//if (propertyMap.DocPropertyMapMode == DocPropertyMapMode.Default || propertyMap.DocPropertyMapMode == DocPropertyMapMode.Inline)
						if (propertyMap.DocPropertyMapMode == DocPropertyMapMode.Inline)
						{
							if (propertyMap.IsCollection)
							{
								//DeserializeInlineReferenceList(obj, classMap, propertyMap, xmlObject);
							}
							else
							{
								DeserializeInlineObject(obj, classMap, propertyMap, xmlObject);
							}
						}
						else
						{
							if (propertyMap.IsCollection)
							{
								DeserializeInlineReferenceList(obj, classMap, propertyMap, xmlObject);
							}
							else
							{
								DeserializeInlineReference(obj, classMap, propertyMap, xmlObject);
							}
						}
					}					
				}				
			}
		}

		protected virtual void DeserializeInlineProperty(object obj, IClassMap classMap, IPropertyMap propertyMap, XmlNode xmlObject)
		{
			IObjectManager om = this.Context.ObjectManager;
			IPersistenceManager pm = this.Context.PersistenceManager;
			string element = propertyMap.DocElement;
			object xmlValue = null;
			bool isNull = true;
			if (element.Length > 0)
			{
				
			}
			else
			{
				string attribute = propertyMap.GetDocAttribute();

				if (!(xmlObject.Attributes[attribute] == null))
				{
					xmlValue = xmlObject.Attributes[attribute].Value;
					isNull = false;
				}
				else
				{
					xmlValue = DBNull.Value;
					isNull = true;
				}
			}

			object orgValue = FromString(obj, classMap, propertyMap, xmlValue);
			object value = pm.ManageLoadedValue(obj, propertyMap, orgValue);
			om.SetNullValueStatus(obj, propertyMap.Name, isNull);
			om.SetPropertyValue(obj, propertyMap.Name, value);
			om.SetOriginalPropertyValue(obj, propertyMap.Name, orgValue);				
		}
		
		protected virtual void DeserializeInlineObject(object obj, IClassMap classMap, IPropertyMap propertyMap, XmlNode xmlObject)
		{
			IObjectManager om = this.Context.ObjectManager;
			bool isNull = false;

			XmlNode xmlChild = xmlObject.SelectSingleNode(propertyMap.GetDocElement());

			object value = ManageInlineObject(xmlChild, obj, propertyMap);

			if (value == null)
				isNull = true;

			om.SetNullValueStatus(obj, propertyMap.Name, isNull);
			om.SetPropertyValue(obj, propertyMap.Name, value);
			om.SetOriginalPropertyValue(obj, propertyMap.Name, value);				
		}

		protected virtual void DeserializeInlineReference(object obj, IClassMap classMap, IPropertyMap propertyMap, XmlNode xmlObject)
		{
			IObjectManager om = this.Context.ObjectManager;
			bool isNull = false;

			XmlNode xmlRef = xmlObject.SelectSingleNode(propertyMap.GetDocElement());

			object value = ManageInlineReference(xmlObject, obj, xmlRef);;

			if (value == null)
				isNull = true;

			om.SetNullValueStatus(obj, propertyMap.Name, isNull);
			om.SetPropertyValue(obj, propertyMap.Name, value);
			om.SetOriginalPropertyValue(obj, propertyMap.Name, value);				
		}

		protected virtual void DeserializeInlineReferenceList(object obj, IClassMap classMap, IPropertyMap propertyMap, XmlNode xmlObject)
		{
			IObjectManager om = this.Context.ObjectManager;
			IListManager lm = this.Context.ListManager ;
			XmlNode xmlList = xmlObject.SelectSingleNode(propertyMap.GetDocElement());

			IList list = (IList) om.GetPropertyValue(obj, propertyMap.Name);

			if (list == null)
			{				
				list = lm.CreateList(obj, propertyMap) ;
				om.SetPropertyValue(obj,propertyMap.Name,list) ;								
				//IList cloneList = lm.CloneList(obj, propertyMap, list);
				IList cloneList = new ArrayList( list);
				om.SetOriginalPropertyValue(obj, propertyMap.Name, cloneList);
			}
						
			IInterceptableList mList;
			bool stackMute = false;

			mList = list as IInterceptableList;
			if (mList != null)
			{
				stackMute = mList.MuteNotify;
				mList.MuteNotify = true;
			}

			foreach(XmlNode xmlItem in xmlList.SelectNodes("item"))
			{
				object value = ManageInlineReference(xmlObject, obj, xmlItem);;

				if (value != null)
					list.Add(value);
			}

			IList clone = new ArrayList( list);

			if (mList != null)
				mList.MuteNotify = stackMute ;

			om.SetNullValueStatus(obj, propertyMap.Name, false);
			//IList clone = lm.CloneList(obj, propertyMap, list);
			om.SetOriginalPropertyValue(obj, propertyMap.Name, clone);		
		}


		protected virtual object ManageInlineObject(XmlNode xmlItem, object obj, IPropertyMap propertyMap)
		{
			IDomainMap domainMap = this.Context.DomainMap;

			if (xmlItem == null)
				return null;

			string className = xmlItem.Attributes["class"].Value;
			IClassMap classMap = domainMap.MustGetClassMap(className);
			Type type = this.Context.AssemblyManager.MustGetTypeFromClassMap(classMap);

			DeserializeObject(obj, classMap, xmlItem, true);

			string identity = this.Context.ObjectManager.GetObjectIdentity(obj);
			object value = this.Context.GetObjectById(identity, type, true);

			//DeserializeObject(obj, classMap, xmlItem);
			DeserializeObject(value, classMap, xmlItem);

			return value;
		}

		protected virtual object ManageInlineReference(XmlNode xmlNode, object obj, XmlNode xmlItem)
		{
			IDomainMap domainMap = this.Context.DomainMap;

			if (xmlItem == null)
				return null;

			string identity = xmlItem.Attributes["id"].Value;
			string className = xmlItem.Attributes["class"].Value;
			IClassMap classMap = domainMap.MustGetClassMap(className);
			Type type = this.Context.AssemblyManager.MustGetTypeFromClassMap(classMap);

			object value = this.Context.GetObjectById(identity, type, true);

			return value;
		}

		protected virtual object FromString(object obj, IClassMap classMap, IPropertyMap propertyMap, object xmlValue)
		{
			if (DBNull.Value.Equals(xmlValue))
				return xmlValue;

			Type propType = obj.GetType().GetProperty(propertyMap.Name).PropertyType ;
			
			if (propType.IsAssignableFrom(typeof(System.Int16)))
				return System.Int16.Parse((string) xmlValue);
			
			if (propType.IsAssignableFrom(typeof(System.Int32)))
				return System.Int32.Parse((string) xmlValue);
			
			if (propType.IsAssignableFrom(typeof(System.Int64)))
				return System.Int64.Parse((string) xmlValue);
			
			if (propType.IsAssignableFrom(typeof(System.Guid)))
				return new System.Guid((string) xmlValue);
			
			if (propType.IsAssignableFrom(typeof(System.DateTime)))
				return System.DateTime.Parse((string) xmlValue);

			return xmlValue.ToString();
		}

		#endregion


	}
}
