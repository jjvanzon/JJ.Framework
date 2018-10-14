// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *
using System;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.BaseClasses;
using System.Collections;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Persistence;

namespace Puzzle.NPersist.Framework.Aop
{
	/// <summary>
	/// Summary description for AopProxyFactory.
	/// </summary>
	public class AopProxyFactory : IProxyFactory , IContextChild
	{
		private Engine aopEngine;
		private IContext context;

		public AopProxyFactory() => aopEngine = new Engine("Puzzle.NPersist.Framework");

	    public Puzzle.NPersist.Framework.Interfaces.IInterceptableList CreateListProxy(Type baseType, Puzzle.NPersist.Framework.Persistence.IObjectFactory objectFactory, params object[] ctorArgs)
		{
		//	return Puzzle.NPersist.Framework.Proxy.ListProxyFactory.CreateProxy(baseType,objectFactory,ctorArgs) ;

            if (baseType == typeof(IInterceptableList) || baseType == typeof(InterceptableList) || baseType == typeof(IList))
			{
                baseType = typeof(InterceptableList);
				return (Puzzle.NPersist.Framework.Interfaces.IInterceptableList) context.ObjectFactory.CreateInstance(baseType,ctorArgs);
			}
#if NET2
            else if (baseType.IsGenericType && baseType.IsInterface)
			{
                Type subType = baseType.GetGenericArguments ()[0];
                Type genericType = typeof(InterceptableGenericsList<>).MakeGenericType(subType);
	
                return (Puzzle.NPersist.Framework.Interfaces.IInterceptableList) context.ObjectFactory.CreateInstance(genericType,ctorArgs);				
			}
#endif
			else
			{
				Type proxyType = aopEngine.CreateProxyType(baseType) ;
				object[] proxyArgs = aopEngine.AddStateToCtorParams(context,ctorArgs);

				return (Puzzle.NPersist.Framework.Interfaces.IInterceptableList) context.ObjectFactory.CreateInstance(proxyType,proxyArgs);
				//return Puzzle.NPersist.Framework.Proxy.ListProxyFactory.CreateProxy(baseType,objectFactory,ctorArgs) ;
			}
		}

		public object CreateEntityProxy(Type baseType, Puzzle.NPersist.Framework.Persistence.IObjectFactory objectFactory, Puzzle.NPersist.Framework.Mapping.IClassMap classMap, object[] ctorArgs)
		{
            
			Type proxyType = aopEngine.CreateProxyType(baseType) ;

			object[] proxyArgs = aopEngine.AddStateToCtorParams(context,ctorArgs);

			return context.ObjectFactory.CreateInstance(proxyType,proxyArgs);
		}

		public Type GetEntityProxyType(Type baseType, Puzzle.NPersist.Framework.Mapping.IClassMap classMap) => aopEngine.CreateProxyType(baseType);

	    public IContext Context
		{
			get { return context; }
			set 
			{ 
				context = value;
				aopEngine.Configuration.Aspects.Clear() ;
#if NET2
				aopEngine.Configuration.Aspects.Add(new DatabindingAspect(Context));		
#endif
                aopEngine.Configuration.Aspects.Add(new EntityAspect(Context));		


				foreach (SignatureAspect extensionAspect in GetExtensionAspects())
					aopEngine.Configuration.Aspects.Add(extensionAspect);
				aopEngine.LogManager = context.LogManager;
			}
		}

		private IList GetExtensionAspects()
		{
			IList extensionAspects = new ArrayList();
			foreach (IClassMap classMap in this.Context.DomainMap.ClassMaps)
			{
				IList generatedPropertyMaps = classMap.GetGeneratedPropertyMaps();
				if (generatedPropertyMaps.Count > 0)
				{
					Type targetType = AssemblyManager.GetBaseType(
						this.context.AssemblyManager.MustGetTypeFromClassMap(classMap));

					TypeExtender extender = new TypeExtender();
					SignatureAspect aspect = new SignatureAspect(classMap.Name + "GeneratedPropertiesExtender", targetType, 
						new Type[] { }, new IPointcut[] { });

					foreach (IPropertyMap generatedPropertyMap in generatedPropertyMaps)
					{
						ExtendedProperty property = new ExtendedProperty();
						property.Name = generatedPropertyMap.Name;
						property.FieldName = generatedPropertyMap.GetFieldName();
						if (generatedPropertyMap.IsCollection)
							property.Type = typeof(IList);
						else
						{
							if (generatedPropertyMap.ReferenceType != ReferenceType.None)
							{
								IClassMap refClassMap = generatedPropertyMap.MustGetReferencedClassMap();
								property.Type = AssemblyManager.GetBaseType(
									this.context.AssemblyManager.MustGetTypeFromClassMap(refClassMap));
							}							
							else
							{
								property.Type = Type.GetType(generatedPropertyMap.DataType);
							}
						}
						extender.Members.Add(property);
					}

					aspect.TypeExtenders.Add(extender);
					extensionAspects.Add(aspect);
				}
			}
			return extensionAspects;
		}
	}
}
