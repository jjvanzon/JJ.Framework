using System;
using System.Collections;
using System.Data;
using Puzzle.NCore.Framework.Compression;
using Puzzle.NCore.Framework.Exceptions;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Mapping.Serialization;
using Puzzle.NPersist.Framework.Persistence;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Framework.Remoting;
using Puzzle.NPersist.Framework.Remoting.Formatting;
using Puzzle.NPersist.Framework.Remoting.Marshaling;
using Puzzle.NPersist.Framework.Remoting.WebService.Client.RemotingWebServiceProxy;
using IFormatter = Puzzle.NPersist.Framework.Remoting.Formatting.IFormatter;
// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.Remoting.WebService.Client
{
	/// <summary>
	/// Summary description for WebServiceRemotingEngine.
	/// </summary>
	public class WebServiceRemotingEngine : RemotingEngineBase
	{
		public WebServiceRemotingEngine() : base(new XmlFormatter())
		{
		}

		public WebServiceRemotingEngine(IFormatter formatter) : base(formatter)
		{
		}

		public WebServiceRemotingEngine(string url) : base(new XmlFormatter())
		{
			this.url = url;
		}
		
		public WebServiceRemotingEngine(IFormatter formatter, string url) : base(formatter)
		{
			this.url = url;
		}
		
		public WebServiceRemotingEngine(IFormatter formatter, string url, string domainKey) : base(formatter)
		{
			this.url = url;
			this.domainKey = domainKey;
		}
				
		public WebServiceRemotingEngine(IFormatter formatter, string url, string domainKey, IWebServiceCompressor compressor) : base(formatter)
		{
			this.url = url;
			this.domainKey = domainKey;
			this.compressor = compressor;
		}

		public WebServiceRemotingEngine(IFormatter formatter, string url, string domainKey, IWebServiceCompressor compressor, bool useCompression) : base(formatter)
		{
			this.url = url;
			this.domainKey = domainKey;
			this.compressor = compressor;
			this.useCompression = useCompression;
		}


		private IWebServiceCompressor compressor = new DefaultWebServiceCompressor()  ;
 
		public IWebServiceCompressor Compressor
		{
			get { return this.compressor; }
			set { this.compressor = value; }
		}

		private string url = "";

		public virtual string Url
		{
			get { return this.url; }
			set { this.url = value; }
		}

		private string domainKey = "";

		public virtual string DomainKey
		{
			get { return this.domainKey; }
			set { this.domainKey = value; }
		}

		private bool useCompression = true;

		public virtual bool UseCompression
		{
			get { return this.useCompression; }
			set { this.useCompression = value; }
		}

		public IDomainMap GetMap()
		{
			if (this.url.Length < 1)
				throw new NPersistException("You must specify an url to your NPersist Web Service in your WebServiceRemotingEngine!");

			RemotingService rs = new RemotingService(this.Context, url);
			
			bool doUseCompression = this.useCompression ;
			if (this.compressor == null)
				doUseCompression = false;

			string result = rs.GetMap(this.domainKey, doUseCompression);
			
			if (useCompression && this.compressor != null)
				result = this.compressor.Decompress(result);

			return DomainMap.LoadFromXml(result, new DefaultMapSerializer());			
		}



		public override void Begin()
		{
			
		}

		public override void Commit()
		{
			if (this.url.Length < 1)
				throw new NPersistException("You must specify an url to your NPersist Web Service in your WebServiceRemotingEngine!");
			MarshalUnitOfWork muow = GetUnitOfWork();
			RemotingService rs = new RemotingService(this.Context, url);
			string xmlUoW = (string) Formatter.Serialize(muow);

			if (useCompression && this.compressor != null)
				xmlUoW = this.compressor.Compress(xmlUoW);

			bool doUseCompression = this.useCompression ;
			if (this.compressor == null)
				doUseCompression = false;

			string result = rs.CommitUnitOfWork(xmlUoW, this.domainKey, doUseCompression);
			
			if (useCompression && this.compressor != null)
				result = this.compressor.Decompress(result);

			MarshalObjectList mol = (MarshalObjectList) Formatter.Deserialize(result, typeof(MarshalObjectList));
			UpdateSourceAssigned(mol);
			ClearUnitOfWork();
		}
		public override void Abort()
		{
			
		}

		//Should have no refresh issues
		public override void LoadObject(ref object obj)
		{
			if (this.url.Length < 1)
				throw new NPersistException("You must specify an url to your NPersist Web Service in your WebServiceRemotingEngine!");
			RemotingService rs = new RemotingService(this.Context, url);
			IClassMap classMap = Context.DomainMap.MustGetClassMap(obj.GetType());
			string id = Context.ObjectManager.GetObjectIdentity(obj);

			bool doUseCompression = this.useCompression ;
			if (this.compressor == null)
				doUseCompression = false;

			string result = rs.LoadObject(classMap.GetName(), id, this.domainKey, doUseCompression);
			
			if (useCompression && this.compressor != null)
				result = this.compressor.Decompress(result);

			MarshalObject mo = (MarshalObject) Formatter.Deserialize(result, typeof(MarshalObject));
			IMarshalingTransformer transformer = new MarshalingTransformer(Context);
			Context.IdentityMap.RegisterLoadedObject(obj);
			transformer.ToObject(mo, ref obj);
		}

		//Should have no refresh issues
		public override void LoadObjectByKey(ref object obj, string keyPropertyName, object keyValue)
		{
//			if (this.url.Length < 1)
//				throw new NPersistException("You must specify an url to your NPersist Web Service in your WebServiceRemotingEngine!");
//			RemotingService rs = new RemotingService();
//			rs.Url = url; 
			
		}

		public override void LoadProperty(object obj, string propertyName)
		{
			if (this.url.Length < 1)
				throw new NPersistException("You must specify an url to your NPersist Web Service in your WebServiceRemotingEngine!");
			RemotingService rs = new RemotingService(this.Context, url);
			IMarshalingTransformer transformer = new MarshalingTransformer(Context);
			IObjectManager om = Context.ObjectManager ;

			IClassMap classMap = Context.DomainMap.MustGetClassMap(obj.GetType());
			IPropertyMap propertyMap = classMap.MustGetPropertyMap(propertyName);
			MarshalReference mr = transformer.FromObjectAsReference(obj);
			string xmlObject = (string) Formatter.Serialize(mr);

			if (useCompression && this.compressor != null) 
				xmlObject = this.compressor.Compress(xmlObject);

			bool doUseCompression = this.useCompression ;
			if (this.compressor == null)
				doUseCompression = false;

			string result = rs.LoadProperty(xmlObject, propertyName, this.domainKey, doUseCompression);
			
			if (useCompression && this.compressor != null)
				result = this.compressor.Decompress(result);

			if (propertyMap.IsCollection)
			{
				if (propertyMap.ReferenceType == ReferenceType.None)
				{
				
				}
				else
				{
					//Refresh issues!!! (the objects in the list being deserialized may exist in the cache!!)
					MarshalObjectList mol = (MarshalObjectList) Formatter.Deserialize(result, typeof(MarshalObjectList));
					IList freshList = transformer.ToObjectList(mol, RefreshBehaviorType.DefaultBehavior, new ArrayList());
					//Context.IdentityMap.RegisterLoadedObject(obj);
					IList orgList = (IList) om.GetPropertyValue(obj, propertyName);

					LoadReferenceList(freshList, orgList, om, obj, propertyMap);
					this.Context.InverseManager.NotifyPropertyLoad(obj, propertyMap, orgList);
				}				
			}
			else
			{
				if (propertyMap.ReferenceType == ReferenceType.None)
				{
					MarshalProperty mp = (MarshalProperty) Formatter.Deserialize(result, typeof(MarshalProperty));
					transformer.ToProperty(obj, mp, propertyMap, RefreshBehaviorType.DefaultBehavior );
				}
				else
				{
					if (result.Length > 0)
					{
						MarshalObject mo = (MarshalObject) Formatter.Deserialize(result, typeof(MarshalObject));
						string identity = transformer.GetIdentity(mo);
						IClassMap refClassMap = Context.DomainMap.MustGetClassMap(mo.Type);
						Type refType = Context.AssemblyManager.MustGetTypeFromClassMap(refClassMap);

						object refObject = Context.GetObjectById(identity, refType, true);
						if (om.GetObjectStatus(refObject) == ObjectStatus.NotLoaded)
						{
							transformer.ToObject(mo, ref refObject);							
						}

//						object refObject = Context.TryGetObjectById(identity, refType, true);
//						if (refObject == null)
//						{
//							refObject = Context.GetObjectById(identity, refType, true);
//							transformer.ToObject(mo, ref refObject);							
//						}
						om.SetPropertyValue(obj, propertyName, refObject);						
						om.SetOriginalPropertyValue(obj, propertyName, refObject);						
						om.SetNullValueStatus(obj, propertyName, false);
						this.Context.InverseManager.NotifyPropertyLoad(obj, propertyMap, refObject);
					}
					else
					{
						om.SetPropertyValue(obj, propertyName, null);						
						om.SetOriginalPropertyValue(obj, propertyName, null);						
						om.SetNullValueStatus(obj, propertyName, true);						
					}				
				}				
			}
		}

		private void LoadReferenceList(IList list, IList orgList, IObjectManager om, object obj, IPropertyMap propertyMap)
		{
			IList objectsToRemove = new ArrayList(); 
			IList objectsToAdd = new ArrayList();
			foreach (object itemOrgObj in orgList)
			{
				string itemOrgObjId = om.GetObjectIdentity(itemOrgObj);
				bool found = false;
				foreach (object itemObj in list)
				{
					string itemObjId = om.GetObjectIdentity(itemObj);
					if (itemObjId == itemOrgObjId)
					{
						found = true;
						break;
					}								
				}
				if (!found)
					objectsToRemove.Add(itemOrgObj);
			}
			foreach (object itemObj in list)
			{
				string itemObjId = om.GetObjectIdentity(itemObj);
				bool found = false;
				foreach (object itemOrgObj in orgList)
				{
					string itemOrgObjId = om.GetObjectIdentity(itemOrgObj);
					if (itemObjId == itemOrgObjId)
					{
						found = true;
						break;
					}								
				}
				if (!found)
				{
					object itemOrgObj = this.Context.GetObjectById(itemObjId, itemObj.GetType(), true);
					objectsToAdd.Add(itemOrgObj);
				}
			}
	
			if (objectsToRemove.Count > 0 || objectsToAdd.Count > 0)
			{
				bool stackMute = false;
				IInterceptableList mList = orgList as IInterceptableList;					
				if (mList != null)
				{
					stackMute = mList.MuteNotify;
					mList.MuteNotify = true;
				}
				foreach (object itemOrgObj in objectsToRemove)
					orgList.Remove(itemOrgObj);
				foreach (object itemOrgObj in objectsToAdd)
					orgList.Add(itemOrgObj);	

				if (mList != null) { mList.MuteNotify = stackMute; }
			}

			bool iStackMute = false;
			IInterceptableList iList = orgList as IInterceptableList;					
			if (iList != null)
			{
				iStackMute = iList.MuteNotify;
				iList.MuteNotify = true;
			}

			IList listClone = new ArrayList( orgList);

			if (iList != null) { iList.MuteNotify = iStackMute; }

			om.SetOriginalPropertyValue(obj, propertyMap.Name, listClone);
		}

		//Refresh issues!!
		public override IList LoadObjects(IQuery query, IList listToFill)
		{
			if (this.url.Length < 1)
				throw new NPersistException("You must specify an url to your NPersist Web Service in your WebServiceRemotingEngine!");
			RemotingService rs = new RemotingService(this.Context, url);
			IMarshalingTransformer transformer = new MarshalingTransformer(Context);
			MarshalQuery mq = transformer.FromQuery(query);
			string xmlQuery = (string) Formatter.Serialize(mq);

			if (useCompression && this.compressor != null)
				xmlQuery = this.compressor.Compress(xmlQuery);

			bool doUseCompression = this.useCompression ;
			if (this.compressor == null)
				doUseCompression = false;

			string result = rs.LoadObjects(xmlQuery, this.domainKey, doUseCompression);

			if (useCompression && this.compressor != null)
				result = this.compressor.Decompress(result);

			MarshalObjectList mol = (MarshalObjectList) Formatter.Deserialize(result, typeof(MarshalObjectList));
			transformer.ToObjectList(mol, query.RefreshBehavior, listToFill);
			return listToFill;
		}

		public override DataTable LoadDataTable(IQuery query)
		{
			return null;
//			if (this.url.Length < 1)
//				throw new NPersistException("You must specify an url to your NPersist Web Service in your WebServiceRemotingEngine!");
//			RemotingService rs = new RemotingService(this.Context, url);
//			IMarshalingTransformer transformer = new MarshalingTransformer(Context);
//			MarshalQuery mq = transformer.FromQuery(query);
//			string xmlQuery = (string) Formatter.Serialize(mq);
//
//			if (useCompression && this.compressor != null)
//				xmlQuery = this.compressor.Compress(xmlQuery);
//
//			bool doUseCompression = this.useCompression ;
//			if (this.compressor == null)
//				doUseCompression = false;
//
//			string result = rs.LoadObjects(xmlQuery, this.domainKey, doUseCompression);
//
//			if (useCompression && this.compressor != null)
//				result = this.compressor.Decompress(result);
//
//			MarshalObjectList mol = (MarshalObjectList) Formatter.Deserialize(result, typeof(MarshalObjectList));
//			IList resultList = transformer.ToObjectList(mol, query.RefreshBehavior);
//			return resultList;
		}

		
		public override IList GetObjectsBySql(string sqlQuery, Type type, IList idColumns, IList typeColumns, Hashtable propertyColumnMap, IList parameters, RefreshBehaviorType refreshBehavior, IList listToFill)
		{
			throw new IAmOpenSourcePleaseImplementMeException("Query capabilities not implemented in DocumentPersistenceEngine! Please load the entire set that you need to search into memory and use the IContext.FilterObjects() method instead.");			
			//return null;
		}


		public override IList GetObjectsOfClassWithUniReferencesToObject(Type type, object obj)
		{
			throw new IAmOpenSourcePleaseImplementMeException("");			
		}

	}
}
