using System;
using System.Collections;
using System.IO;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Mapping.Serialization;
using Puzzle.NPersist.Framework.Persistence;
using Puzzle.NPersist.Framework.Querying;
using Puzzle.NPersist.Framework.Remoting.Marshaling;
using Puzzle.NPersist.Framework.Remoting.Formatting;
using Puzzle.NCore.Framework.Compression;
// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.Remoting
{
	/// <summary>
	/// Summary description for RemotingServer.
	/// </summary>
	public class RemotingServer : IRemotingServer
	{
		public RemotingServer()
		{
		}

		public RemotingServer(IContextFactory contextFactory) => this.contextFactory = contextFactory;

	    public RemotingServer(IFormatter formater) => this.formater = formater;

	    public RemotingServer(IContextFactory contextFactory, IFormatter formater)
		{
			this.contextFactory = contextFactory;
			this.formater = formater;
		}

		public RemotingServer(IContextFactory contextFactory, IFormatter formater, IWebServiceCompressor compressor)
		{
			this.contextFactory = contextFactory;
			this.formater = formater;
			this.compressor = compressor;
		}

		public RemotingServer(IContextFactory contextFactory, IFormatter formater, IWebServiceCompressor compressor, bool useCompression)
		{
			this.contextFactory = contextFactory;
			this.formater = formater;
			this.compressor = compressor;
			this.useCompression = useCompression;
		}


		private IContextFactory contextFactory = null;
		
		public IContextFactory ContextFactory
		{
			get => this.contextFactory;
		    set => this.contextFactory = value;
		}

		private IFormatter formater = null;
		
		public IFormatter Formatter
		{
			get => this.formater;
		    set => this.formater = value;
		}

		#region Property  Compressor 
		
		private IWebServiceCompressor compressor = null;
		
		public IWebServiceCompressor Compressor 
		{
			get => this.compressor;
		    set => this.compressor  = value;
		}
		
		#endregion
	
		#region Property  UseCompression
		
		private bool useCompression = true;
		
		public bool UseCompression
		{
			get => this.useCompression;
		    set => this.useCompression = value;
		}
		
		#endregion

		public string GetMap(string domainKey)
		{
			IContext ctx = contextFactory.GetContext(domainKey);
			IDomainMap domainMap = ctx.DomainMap;
			IDomainMap stripped = DomainMapStripper.StripDomainMap(domainMap);
			IMapSerializer serializer = new DefaultMapSerializer();
			return serializer.Serialize(stripped);
		}

		public object LoadObject(string type, object identity, string domainKey)
		{
//			if (useCompression &&  this.compressor != null)
//			{
//				type = this.compressor.Decompress(type);							
//				identity = this.compressor.Decompress((string) identity);			
//				domainKey = this.compressor.Decompress(domainKey);							
//			}

			IContext ctx = contextFactory.GetContext(domainKey);
			IClassMap classMap = ctx.DomainMap.MustGetClassMap(type);
			Type realType = ctx.AssemblyManager.MustGetTypeFromClassMap(classMap);
			object obj = ctx.GetObjectById(identity, realType);
			IMarshalingTransformer transformer = new MarshalingTransformer(ctx);
			MarshalObject mo = transformer.FromObject(obj);
			object serialized = formater.Serialize(mo);
			ctx.Dispose();

			if (useCompression &&  this.compressor != null)
				return this.compressor.Compress((string) serialized);			
			else
				return serialized;			}

		public object LoadObjectByKey(string type, string keyPropertyName, object keyValue, string domainKey) => null;

	    public object CommitUnitOfWork(object obj, string domainKey)
		{
			if (useCompression &&  this.compressor != null)
			{
				obj = this.compressor.Decompress((string) obj);			
				//domainKey = this.compressor.Decompress(domainKey);							
			}

			IContext ctx = contextFactory.GetContext(domainKey);
			MarshalingTransformer transformer = new MarshalingTransformer(ctx);
			//Deserialize the uow
			MarshalUnitOfWork muow = (MarshalUnitOfWork) formater.Deserialize(obj, typeof(MarshalUnitOfWork));

			string identity; 
			string serialized = "";
			IClassMap classMap; 
			Type realType; 
			object ro; 
			MarshalObjectList mol = new MarshalObjectList();
			Hashtable insertedRealObjects = new Hashtable() ;

			ITransaction tx = null;

			try
			{
				tx = ctx.BeginTransaction();

				foreach (MarshalObject mo in muow.RemoveObjects)
				{
					identity = transformer.GetIdentity(mo);
					classMap = ctx.DomainMap.MustGetClassMap(mo.Type);
					realType = ctx.AssemblyManager.MustGetTypeFromClassMap(classMap);
					ro = ctx.GetObjectById(identity, realType);
					transformer.ToObject(mo, ref ro, 0, RefreshBehaviorType.OverwriteLoaded);
					ctx.UnitOfWork.RegisterDeleted(ro);
				}

				foreach (MarshalObject mo in muow.UpdateObjects)
				{
					identity = transformer.GetIdentity(mo);
					classMap = ctx.DomainMap.MustGetClassMap(mo.Type);
					realType = ctx.AssemblyManager.MustGetTypeFromClassMap(classMap);
					ro = ctx.GetObjectById(identity, realType);
					transformer.ToObject(mo, ref ro, 0, RefreshBehaviorType.OverwriteLoaded);
					ctx.UnitOfWork.RegisterDirty(ro);
				}

				foreach (MarshalObject mo in muow.InsertObjects)
				{
					classMap = ctx.DomainMap.MustGetClassMap(mo.Type);
					realType = ctx.AssemblyManager.MustGetTypeFromClassMap(classMap);
					if (mo.TempId.Length > 0)
					{
						ro = ctx.CreateObject(realType);						
					} 
					else
					{
						identity = transformer.GetIdentity(mo);
						ro = ctx.CreateObject(identity, realType);						
					}
					insertedRealObjects[mo] = ro;
					transformer.ToObject(mo, ref ro, 0, RefreshBehaviorType.OverwriteDirty);
				}

				//Commit transaction
				tx.Commit();							
			}
			catch (Exception ex)
			{
				if (tx != null)
				{
					tx.Rollback();									
				}
				ctx.Dispose();
				throw ex;
			}

			foreach (MarshalObject mo in muow.InsertObjects)
			{
				classMap = ctx.DomainMap.MustGetClassMap(mo.Type);
				if (classMap.HasAssignedBySource() )
				{
					foreach (IPropertyMap propertyMap in classMap.GetAllPropertyMaps() )
					{
						if (propertyMap.GetIsAssignedBySource() )
						{
							MarshalProperty mp = mo.GetProperty(propertyMap.Name);
							if (mp == null)
							{
								mp = new MarshalProperty();
								mp.Name = propertyMap.Name;
								mo.Properties.Add(mp);
							}							
							ro = insertedRealObjects[mo];
							mp.Value = transformer.FromPropertyValue(ro, ctx.ObjectManager.GetPropertyValue(ro, propertyMap.Name), propertyMap);
							mol.Objects.Add(mo);							
						}	
					}					
				}
			}

			ctx.Dispose();

			serialized = (string) formater.Serialize(mol);
			
			if (useCompression &&  this.compressor != null)
				return this.compressor.Compress(serialized);			
			else
				return serialized;			
		}

		public object LoadProperty(object obj, string propertyName, string domainKey)
		{
			if (useCompression &&  this.compressor != null)
			{
				obj = this.compressor.Decompress((string) obj);			
				//propertyName = this.compressor.Decompress(propertyName);							
				//domainKey = this.compressor.Decompress(domainKey);							
			}

			IContext ctx = contextFactory.GetContext(domainKey);
			IObjectManager om = ctx.ObjectManager;
			IMarshalingTransformer transformer = new MarshalingTransformer(ctx);
			MarshalReference mr = (MarshalReference) formater.Deserialize(obj, typeof(MarshalReference));
			string identity = transformer.GetIdentity(mr, mr.Value);
			IClassMap classMap = ctx.DomainMap.MustGetClassMap(mr.Type);
			IPropertyMap propertyMap = classMap.MustGetPropertyMap(propertyName);
			Type realType = ctx.AssemblyManager.MustGetTypeFromClassMap(classMap);
			//object realObj = ctx.GetObjectById(identity, realType);
			object realObj = ctx.GetObjectById(identity, realType, true);

			ctx.LoadProperty(realObj, propertyName);
			object serialized = null;

			if (propertyMap.IsCollection)
			{
				if (propertyMap.ReferenceType == ReferenceType.None)
				{
//					IList list = (IList) om.GetPropertyValue(realObj, propertyName); 
//					MarshalList ml = transformer.FromList(list) ;
//					serialized = formater.Serialize(ml);																	
				} 
				else
				{
					//TODO: fix transformer.FromReferenceList
					//Even better: Add MarshalProperty.Object, OriginalObject, List, OriginalList, ReferenceList and OriginalReferenceList!
					IList list = (IList) om.GetPropertyValue(realObj, propertyName); 
					MarshalObjectList mol = transformer.FromObjectList(list) ;
					serialized = formater.Serialize(mol);																	
				}				
			} 
			else
			{
				if (propertyMap.ReferenceType == ReferenceType.None)
				{
					MarshalProperty mp = transformer.FromProperty(obj, propertyMap);
					serialized = formater.Serialize(mp);
				} 
				else
				{
					object value = om.GetPropertyValue(realObj, propertyName);
					if (value != null)
					{
						ObjectStatus objectStatus = ctx.GetObjectStatus(value);
						if (objectStatus == ObjectStatus.NotLoaded)
						{
							ctx.PersistenceEngine.LoadObject(ref value);
						}

						if (value != null)
						{
							MarshalObject mo = transformer.FromObject(value);
							serialized = formater.Serialize(mo);													
						}
					}
				}				
			}
			if (serialized == null)
				serialized = "";

			ctx.Dispose();
			if (useCompression &&  this.compressor != null)
				return this.compressor.Compress((string) serialized);			
			else
				return serialized;			
		}

		public object LoadObjects(object query, string domainKey)
		{
			if (useCompression &&  this.compressor != null)
			{
				query = this.compressor.Decompress((string) query);			
				//domainKey = this.compressor.Decompress(domainKey);							
			}

			IContext ctx = contextFactory.GetContext(domainKey);
			IMarshalingTransformer transformer = new MarshalingTransformer(ctx);
			MarshalQuery mq = (MarshalQuery) formater.Deserialize(query, typeof(MarshalQuery));
			IQuery queryObject = transformer.ToQuery(mq);
			IList objects = ctx.GetObjectsByQuery(queryObject);
			MarshalObjectList mol = transformer.FromObjectList(objects);
			string serialized = (string) formater.Serialize(mol);
			ctx.Dispose();
			if (useCompression &&  this.compressor != null)
				return this.compressor.Compress(serialized);			
			else
				return serialized;			
		}

	}
}
