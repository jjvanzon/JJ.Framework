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
using System.Data;
using System.Text;
using System.Xml;
using System.Globalization;
using Puzzle.NCore.Framework.Exceptions;
using Puzzle.NPersist.Framework.Remoting.Marshaling;

namespace Puzzle.NPersist.Framework.Remoting.Formatting
{
	/// <summary>
	/// Summary description for NPersistXmlFormatter.
	/// </summary>
	public class XmlFormatter : IFormatter
	{

		public XmlFormatter()
		{
			
		}

		
		public object Deserialize(object serialized, Type type)
		{
			if (type == typeof(MarshalObjectList))
			{
				return DeserializeMarshalObjectList(serialized);				
			}
			else if (type == typeof(MarshalObject))
			{
				return DeserializeMarshalObject(serialized);				
			}
			else if (type == typeof(MarshalUnitOfWork))
			{
				return DeserializeMarshalUnitOfWork(serialized);				
			}
			else if (type == typeof(MarshalQuery))
			{
				return DeserializeMarshalQuery(serialized);				
			}
			else if (type == typeof(MarshalReference))
			{
				return DeserializeMarshalReference(serialized);				
			}
			else if (type == typeof(MarshalProperty))
			{
				return DeserializeMarshalProperty(serialized);				
			}
			else 
				throw new IAmOpenSourcePleaseImplementMeException("");
			
		}


		public object Serialize(object obj)
		{

			XmlDocument xmlDoc = new XmlDocument() ;

			if (obj is MarshalObjectList)
			{
				xmlDoc.AppendChild(SerializeToXmlNode(xmlDoc, (MarshalObjectList) obj));				
			}
			else if (obj is MarshalObject)
			{
				xmlDoc.AppendChild(SerializeToXmlNode(xmlDoc, (MarshalObject) obj));				
			}
			else if (obj is MarshalUnitOfWork)
			{
				xmlDoc.AppendChild(SerializeToXmlNode(xmlDoc, (MarshalUnitOfWork) obj));				
			}
			else if (obj is MarshalQuery)
			{
				xmlDoc.AppendChild(SerializeToXmlNode(xmlDoc, (MarshalQuery) obj));				
			}
			else if (obj is MarshalReference)
			{
				xmlDoc.AppendChild(SerializeToXmlNode(xmlDoc, (MarshalReference) obj));				
			}
			else if (obj is MarshalProperty)
			{
				xmlDoc.AppendChild(SerializeToXmlNode(xmlDoc, (MarshalProperty) obj));				
			}
			else 
				throw new IAmOpenSourcePleaseImplementMeException("");

			return "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + xmlDoc.InnerXml ;
		}

		public XmlNode SerializeToXmlNode(XmlDocument xmlDoc, MarshalQuery marshalQuery)
		{
			XmlNode xml = xmlDoc.CreateElement("query") ;
			XmlAttribute xmlAttr ;

			xmlAttr = xmlDoc.CreateAttribute("type");
			xmlAttr.Value = marshalQuery.PrimitiveType;
			xml.Attributes.Append(xmlAttr);

			xmlAttr = xmlDoc.CreateAttribute("query-type");
			xmlAttr.Value = marshalQuery.QueryType;
			xml.Attributes.Append(xmlAttr);

			XmlNode xmlQueryString = xmlDoc.CreateElement("query-string") ;
			xmlQueryString.InnerText = marshalQuery.QueryString;
			xml.AppendChild(xmlQueryString);

			foreach (MarshalParameter mp in marshalQuery.Parameters)
			{
				xml.AppendChild(SerializeToXmlNode(xmlDoc, mp));
			}

			return xml;
		}

		public XmlNode SerializeToXmlNode(XmlDocument xmlDoc, MarshalParameter marshalParameter)
		{
			XmlNode xml = xmlDoc.CreateElement("parameter") ;
			XmlAttribute xmlAttr ;

			xmlAttr = xmlDoc.CreateAttribute("name");
			xmlAttr.Value = marshalParameter.Name;
			xml.Attributes.Append(xmlAttr);

			xmlAttr = xmlDoc.CreateAttribute("type");
			xmlAttr.Value = marshalParameter.DbType.ToString();
			xml.Attributes.Append(xmlAttr);

			//TODO: Ref values
			XmlNode xmlValue = xmlDoc.CreateElement("query-string") ;
			xmlValue.InnerText =  marshalParameter.Value;
			xml.AppendChild(xmlValue);

			return xml; 
		}

		public XmlNode SerializeToXmlNode(XmlDocument xmlDoc, MarshalObjectList marshalObjectList)
		{
			XmlNode xml = xmlDoc.CreateElement("object-list") ;

			foreach (MarshalObject mo in marshalObjectList.Objects)
			{
				xml.AppendChild(SerializeToXmlNode(xmlDoc, mo));
			}

			return xml; 
		}

		public XmlNode SerializeToXmlNode(XmlDocument xmlDoc, MarshalUnitOfWork marshalUnitOfWork)
		{
			XmlNode xml = xmlDoc.CreateElement("unit-of-work") ;
			XmlNode xmlSub ;

			xmlSub = xmlDoc.CreateElement("insert") ;
			xml.AppendChild(xmlSub);
			foreach (MarshalObject mo in marshalUnitOfWork.InsertObjects)
			{
				xmlSub.AppendChild(SerializeToXmlNode(xmlDoc, mo));
			}

			xmlSub = xmlDoc.CreateElement("update") ;
			xml.AppendChild(xmlSub);
			foreach (MarshalObject mo in marshalUnitOfWork.UpdateObjects)
			{
				xmlSub.AppendChild(SerializeToXmlNode(xmlDoc, mo));
			}

			xmlSub = xmlDoc.CreateElement("remove") ;
			xml.AppendChild(xmlSub);
			foreach (MarshalObject mo in marshalUnitOfWork.RemoveObjects)
			{
				xmlSub.AppendChild(SerializeToXmlNode(xmlDoc, mo));
			}

			return xml; 
		}

		public XmlNode SerializeToXmlNode(XmlDocument xmlDoc, MarshalObject marshalObject)
		{
			XmlNode xml = xmlDoc.CreateElement("object") ;
			XmlAttribute xmlAttr ;

			xmlAttr = xmlDoc.CreateAttribute("type");
			xmlAttr.Value = marshalObject.Type;
			xml.Attributes.Append(xmlAttr);

			xmlAttr = xmlDoc.CreateAttribute("temp-id");
			xmlAttr.Value = marshalObject.TempId;
			xml.Attributes.Append(xmlAttr);

			foreach (MarshalProperty mp in marshalObject.Properties)
			{
				xml.AppendChild(SerializeToXmlNode(xmlDoc, mp));
			}

			foreach (MarshalReference mr in marshalObject.References)
			{
				xml.AppendChild(SerializeToXmlNode(xmlDoc, mr));
			}

			return xml; 
		}

		public XmlNode SerializeToXmlNode(XmlDocument xmlDoc, MarshalProperty mp)
		{
			XmlNode xml = xmlDoc.CreateElement("property") ;
			XmlAttribute xmlAttr ;

			xmlAttr = xmlDoc.CreateAttribute("name");
			xmlAttr.Value = mp.Name;
			xml.Attributes.Append(xmlAttr);

			xmlAttr = xmlDoc.CreateAttribute("null");
			xmlAttr.Value = BoolToStr(mp.IsNull);
			xml.Attributes.Append(xmlAttr);

			xmlAttr = xmlDoc.CreateAttribute("org-null");
			xmlAttr.Value = BoolToStr(mp.WasNull) ;
			xml.Attributes.Append(xmlAttr);

			xmlAttr = xmlDoc.CreateAttribute("has-org");
			xmlAttr.Value = BoolToStr(mp.HasOriginal);
			xml.Attributes.Append(xmlAttr);

			XmlNode xmlValue = xmlDoc.CreateElement("value") ;
			xmlValue.InnerText =  mp.Value;
			xml.AppendChild(xmlValue);

			xmlValue = xmlDoc.CreateElement("org-value") ;
			xmlValue.InnerText =  mp.OriginalValue;
			xml.AppendChild(xmlValue);
			
			return xml; 
		}

		public XmlNode SerializeToXmlNode(XmlDocument xmlDoc, MarshalReference mr)
		{
			XmlNode xml = xmlDoc.CreateElement("reference") ;
			XmlAttribute xmlAttr ;

			xmlAttr = xmlDoc.CreateAttribute("name");
			xmlAttr.Value = mr.Name;
			xml.Attributes.Append(xmlAttr);

			xmlAttr = xmlDoc.CreateAttribute("type");
			xmlAttr.Value = mr.Type;
			xml.Attributes.Append(xmlAttr);

			xmlAttr = xmlDoc.CreateAttribute("org-type");
			xmlAttr.Value = mr.OriginalType ;
			xml.Attributes.Append(xmlAttr);

			xmlAttr = xmlDoc.CreateAttribute("null");
			xmlAttr.Value = BoolToStr(mr.IsNull);
			xml.Attributes.Append(xmlAttr);

			xmlAttr = xmlDoc.CreateAttribute("org-null");
			xmlAttr.Value = BoolToStr(mr.WasNull) ;
			xml.Attributes.Append(xmlAttr);

			xmlAttr = xmlDoc.CreateAttribute("has-org");
			xmlAttr.Value = BoolToStr(mr.HasOriginal);
			xml.Attributes.Append(xmlAttr);

			XmlNode xmlSub = xmlDoc.CreateElement("value") ;
			xml.AppendChild(xmlSub);
			SerializeToXmlNode(xmlDoc, mr.Value, xmlSub);

			xmlSub = xmlDoc.CreateElement("org-value") ;
			xml.AppendChild(xmlSub);
			SerializeToXmlNode(xmlDoc, mr.OriginalValue, xmlSub);
			
			return xml; 
		}

		public XmlNode SerializeToXmlNode(XmlDocument xmlDoc, MarshalReferenceValue mrv, XmlNode xmlNode)
		{
			foreach (MarshalProperty mp in mrv.ReferenceProperties)
			{
				xmlNode.AppendChild(SerializeToXmlNode(xmlDoc, mp));
			}

			foreach (MarshalReference mr in mrv.ReferenceReferences)
			{
				xmlNode.AppendChild(SerializeToXmlNode(xmlDoc, mr));
			}
			
			return xmlNode; 
		}

		public XmlNode SerializeToXmlNode(XmlDocument xmlDoc, MarshalUol muol)
		{
			XmlNode xml = xmlDoc.CreateElement("uol") ;

			XmlNode xmlValue = xmlDoc.CreateElement("url") ;
			xmlValue.InnerText =  muol.Url;
			xml.AppendChild(xmlValue);

			xmlValue = xmlDoc.CreateElement("key") ;
			xmlValue.InnerText =  muol.Key;
			xml.AppendChild(xmlValue);

			xmlValue = xmlDoc.CreateElement("id") ;
			xmlValue.InnerText =  muol.Id;
			xml.AppendChild(xmlValue);

			xmlValue = xmlDoc.CreateElement("type") ;
			xmlValue.InnerText =  muol.Type;
			xml.AppendChild(xmlValue);

			return xml; 
		}


		private string BoolToStr(bool b)
		{
			if (b)
			{
				return "true";
			}
			else
			{
				return "false";
			}
		}

		public MarshalProperty DeserializeMarshalProperty(object serialized)
		{
			XmlNode xmlProp = GetXmlNode(serialized, "property");
			return ToMarshalProperty(xmlProp);
		}

		public MarshalReference DeserializeMarshalReference(object serialized)
		{
			XmlNode xmlRef = GetXmlNode(serialized, "reference");
			return ToMarshalReference(xmlRef);
		}

		public MarshalQuery DeserializeMarshalQuery(object serialized)
		{
			XmlNode xmlQuery = GetXmlNode(serialized, "query");
			return ToMarshalQuery(xmlQuery);
		}

		public MarshalObject DeserializeMarshalObject(object serialized)
		{
			XmlNode xmlObject = GetXmlNode(serialized, "object");
			return ToMarshalObject(xmlObject);
		}		

		public MarshalUnitOfWork DeserializeMarshalUnitOfWork(object serialized)
		{
			XmlNode xmlUnitOfWork = GetXmlNode(serialized, "unit-of-work");
			return ToMarshalUnitOfWork(xmlUnitOfWork);
		}

		public MarshalObjectList DeserializeMarshalObjectList(object serialized)
		{
			XmlNode xmlUnitOfWork = GetXmlNode(serialized, "object-list");
			return ToMarshalObjectList(xmlUnitOfWork);
		}

		public XmlNode GetXmlNode(object serialized, string nodeName)
		{
			XmlDocument xmlDoc = new XmlDocument();
			XmlNode xmlNode;
			string xml = Convert.ToString(serialized);
			xmlDoc.LoadXml(xml);
			xmlNode = xmlDoc.SelectSingleNode(nodeName);
			return xmlNode;
		}

		private MarshalQuery ToMarshalQuery(XmlNode xmlQuery)
		{
			MarshalQuery mq = new MarshalQuery();

			if (!(xmlQuery.Attributes["type"] == null))
				mq.PrimitiveType = xmlQuery.Attributes["type"].Value;
			if (!(xmlQuery.Attributes["query-type"] == null))
				mq.QueryType = xmlQuery.Attributes["query-type"].Value;

			XmlNode xmlNode = xmlQuery.SelectSingleNode("query-string");
			if (xmlNode != null)
				mq.QueryString = xmlNode.InnerText;

			XmlNodeList xmlNodeList = xmlQuery.SelectNodes("parameter");
			foreach (XmlNode xmlParam in xmlNodeList)
			{
				mq.Parameters.Add(ToMarshalParameter(xmlParam));
			}				

			return mq;
		}	


		private MarshalParameter ToMarshalParameter(XmlNode xmlParam)
		{
			MarshalParameter mp = new MarshalParameter();

			if (!(xmlParam.Attributes["name"] == null))
				mp.Name = xmlParam.Attributes["name"].Value;
			if (!(xmlParam.Attributes["type"] == null))
				mp.DbType = (DbType) Enum.Parse(typeof(DbType), xmlParam.Attributes["type"].Value);

			XmlNode xmlNode = xmlParam.SelectSingleNode("value");
			if (xmlNode != null)
				mp.Value = xmlNode.InnerText;

			return mp;
		}	

		private MarshalUnitOfWork ToMarshalUnitOfWork(XmlNode xmlUnitOfWork)
		{
			MarshalUnitOfWork muow = new MarshalUnitOfWork();
			XmlNode xmlListNode; 
			XmlNodeList xmlNodeList;
			xmlListNode = xmlUnitOfWork.SelectSingleNode("insert");
			if (xmlListNode != null)
			{
				xmlNodeList = xmlListNode.SelectNodes("object");
				foreach (XmlNode xmlObj in xmlNodeList)
				{
					muow.InsertObjects.Add(ToMarshalObject(xmlObj));
				}				
			}
			xmlListNode = xmlUnitOfWork.SelectSingleNode("update");
			if (xmlListNode != null)
			{
				xmlNodeList = xmlListNode.SelectNodes("object");
				foreach (XmlNode xmlObj in xmlNodeList)
				{
					muow.UpdateObjects.Add(ToMarshalObject(xmlObj));
				}	
			}
			xmlListNode = xmlUnitOfWork.SelectSingleNode("remove");
			if (xmlListNode != null)
			{
				xmlNodeList = xmlListNode.SelectNodes("object");
				foreach (XmlNode xmlObj in xmlNodeList)
				{
					muow.RemoveObjects.Add(ToMarshalObject(xmlObj));
				}				
			}
			return muow;
		}	

		private MarshalObjectList ToMarshalObjectList(XmlNode xmlObjectList)
		{
			MarshalObjectList mol = new MarshalObjectList();
			XmlNodeList xmlNodeList = xmlObjectList.SelectNodes("object");
			foreach (XmlNode xmlObj in xmlNodeList)
			{
				mol.Objects.Add(ToMarshalObject(xmlObj));
			}				
			return mol;
		}	

		private MarshalObject ToMarshalObject(XmlNode xmlObject)
		{
			MarshalObject mo = new MarshalObject();
			XmlNodeList xmlNodeList;
			if (!(xmlObject.Attributes["type"] == null))
			{
				mo.Type = xmlObject.Attributes["type"].Value;
			}
			if (!(xmlObject.Attributes["temp-id"] == null))
			{
				mo.TempId = xmlObject.Attributes["temp-id"].Value;
			}
			xmlNodeList = xmlObject.SelectNodes("property");
			foreach (XmlNode xmlProp in xmlNodeList)
			{
				mo.Properties.Add(ToMarshalProperty(xmlProp));
			}
			xmlNodeList = xmlObject.SelectNodes("reference");
			foreach (XmlNode xmlProp in xmlNodeList)
			{
				mo.References.Add(ToMarshalReference(xmlProp));
			}
			return mo;
		}	

		private MarshalProperty ToMarshalProperty(XmlNode xmlProp)
		{
			MarshalProperty mp = new MarshalProperty();
			XmlNode xmlNode;
			if (!(xmlProp.Attributes["name"] == null))
			{
				mp.Name = xmlProp.Attributes["name"].Value;
			}
			if (!(xmlProp.Attributes["null"] == null))
			{
				mp.IsNull = ParseBool(xmlProp.Attributes["null"].Value);
			}
			if (!(xmlProp.Attributes["org-null"] == null))
			{
				mp.WasNull = ParseBool(xmlProp.Attributes["org-null"].Value);
			}
			if (!(xmlProp.Attributes["has-org"] == null))
			{
				mp.HasOriginal = ParseBool(xmlProp.Attributes["has-org"].Value);
			}
			xmlNode = xmlProp.SelectSingleNode("value");
			if (xmlNode != null)
			{
				mp.Value = xmlNode.InnerText;
			}
			xmlNode = xmlProp.SelectSingleNode("org-value");
			if (xmlNode != null)
			{
				mp.OriginalValue = xmlNode.InnerText;
			}
			return mp;
		}	

		private MarshalReference ToMarshalReference(XmlNode xmlRef)
		{
			MarshalReference mr = new MarshalReference();
			XmlNode xmlNode;
			if (!(xmlRef.Attributes["name"] == null))
			{
				mr.Name = xmlRef.Attributes["name"].Value;
			}
			if (!(xmlRef.Attributes["type"] == null))
			{
				mr.Type = xmlRef.Attributes["type"].Value;
			}
			if (!(xmlRef.Attributes["org-type"] == null))
			{
				mr.OriginalType = xmlRef.Attributes["org-type"].Value;
			}
			if (!(xmlRef.Attributes["null"] == null))
			{
				mr.IsNull = ParseBool(xmlRef.Attributes["null"].Value);
			}
			if (!(xmlRef.Attributes["org-null"] == null))
			{
				mr.WasNull = ParseBool(xmlRef.Attributes["org-null"].Value);
			}
			if (!(xmlRef.Attributes["has-org"] == null))
			{
				mr.HasOriginal = ParseBool(xmlRef.Attributes["has-org"].Value);
			}
			xmlNode = xmlRef.SelectSingleNode("value");
			if (xmlNode != null)
			{
				mr.Value = ToMarshalReferenceValue(xmlNode);
			}
			xmlNode = xmlRef.SelectSingleNode("org-value");
			if (xmlNode != null)
			{
				mr.OriginalValue = ToMarshalReferenceValue(xmlNode);
			}
			return mr;
		}	

		private MarshalReferenceValue ToMarshalReferenceValue(XmlNode xmlRef)
		{
			MarshalReferenceValue mrv = new MarshalReferenceValue();
			XmlNodeList xmlNodeList;
			xmlNodeList = xmlRef.SelectNodes("property");
			foreach (XmlNode xmlProp in xmlNodeList)
			{
				mrv.ReferenceProperties.Add(ToMarshalProperty(xmlProp));
			}
			xmlNodeList = xmlRef.SelectNodes("reference");
			foreach (XmlNode xmlProp in xmlNodeList)
			{
				mrv.ReferenceReferences.Add(ToMarshalReference(xmlProp));
			}
			return mrv;
		}	

		private MarshalUol ToMarshalUol(XmlNode xmlRef)
		{
			MarshalUol muol = new MarshalUol();
			XmlNode xmlNode;
			xmlNode = xmlRef.SelectSingleNode("url");
			if (xmlNode != null)
			{
				muol.Url = xmlNode.InnerText;
			}
			xmlNode = xmlRef.SelectSingleNode("key");
			if (xmlNode != null)
			{
				muol.Key = xmlNode.InnerText;
			}
			xmlNode = xmlRef.SelectSingleNode("id");
			if (xmlNode != null)
			{
				muol.Id = xmlNode.InnerText;
			}
			xmlNode = xmlRef.SelectSingleNode("type");
			if (xmlNode != null)
			{
				muol.Type = xmlNode.InnerText;
			}

			return muol;
		}	


		protected virtual bool ParseBool(string str)
		{
			if (str.ToLower(CultureInfo.InvariantCulture) == "false" || str.ToLower(CultureInfo.InvariantCulture) == "0" || str.ToLower(CultureInfo.InvariantCulture) == "off" || str.ToLower(CultureInfo.InvariantCulture) == "no")
			{
				return false;
			}
			else
			{
				return true;
			}
		}

	}
}
