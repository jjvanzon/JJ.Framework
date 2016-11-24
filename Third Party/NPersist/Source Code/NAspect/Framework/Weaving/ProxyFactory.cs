using System;
using System.Collections;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using NAspect.AOP;

namespace NAspect
{
	public class ProxyFactory
	{

		public static Type CreateProxyType(Type baseType,IList aspects,IList mixins,Container container)
		{
			ProxyFactory factory = new ProxyFactory(container);

			return factory.CreateType(baseType,aspects,mixins) ;
		}

		private Container container;
		private ArrayList wrapperMethods = new ArrayList() ;
		public ProxyFactory(Container container)
		{
			this.container = container;
		}


		private AssemblyBuilder GetAssemblyBuilder()
		{
			AppDomain domain = Thread.GetDomain();
			AssemblyName assemblyName = new AssemblyName();
			assemblyName.Name = Guid.NewGuid().ToString();
			assemblyName.Version = new Version(1, 0, 0, 0);
			AssemblyBuilder assemblyBuilder = domain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);	
			return assemblyBuilder;
		}

		public Type CreateType(Type baseType,IList aspects , IList mixins)
		{
			

			string typeName = baseType.Name + "AOPProxy";
			string moduleName = "MatsSoft.NPersist.Runtime.Proxy";
			
			AssemblyBuilder assemblyBuilder = GetAssemblyBuilder();

			Type[] interfaces = GetInterfaces(mixins);
			TypeBuilder typeBuilder = GetTypeBuilder(assemblyBuilder, moduleName, typeName, baseType, interfaces);

			BuildMixinFields (typeBuilder,interfaces);

			BuildConstructors(baseType,typeBuilder,mixins);

			foreach (Type mixinType in interfaces)
			{
				MixinType (typeBuilder,mixinType,GetMixinField(mixinType));
			}

			BuildMethods (baseType,typeBuilder,mixins,aspects);
		
			Type proxyType = typeBuilder.CreateType();

			BuildLookupTables(baseType,proxyType,aspects,mixins);

			return proxyType;
		}

		private void BuildLookupTables(Type baseType,Type proxyType, IList aspects, IList mixins)
		{
			foreach (string wrapperMethodName in wrapperMethods)
			{
				MethodInfo wrapperMethod = proxyType.GetMethod (wrapperMethodName,BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
				MethodCache.wrapperMethodLookup [wrapperMethodName]= wrapperMethod;

				MethodInfo baseMethod = (MethodInfo)MethodCache.methodLookup[wrapperMethodName];
				//array to return
				IList methodinterceptors = new ArrayList();
				//fetch all aspects from the type-aspect lookup
				foreach (AOP.IAspect aspect in aspects)
				{
					foreach (AOP.IPointcut pointcut in aspect.Pointcuts)
					{
						if (pointcut.IsMatch(baseMethod))
						{
							foreach (AOP.IInterceptor interceptor in pointcut.Interceptors)
							{
								methodinterceptors.Add (interceptor);
							}
						}
					}
				}

				MethodCache.methodInterceptorsLookup[baseMethod]=methodinterceptors;
			}
		}

		private void BuildMethods(Type baseType, TypeBuilder typeBuilder, IList mixins,IList aspects)
		{
			
			MethodInfo[] methods = baseType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public );

			foreach (MethodInfo method in methods)
			{
				if (method.IsVirtual)
				{
					if (container.PointCutMatcher.MethodShouldBeProxied(method,aspects))
					{
						BuildMethod(baseType,typeBuilder,method,mixins);
					}
				}				
			}			
		}

		

		private long guid = 0;
		private void BuildMethod(Type baseType, TypeBuilder typeBuilder, MethodInfo method, IList mixins)
		{
			string wrapperName = "__" + method.Name + "Wrapper" + guid.ToString() ;
			wrapperMethods.Add(wrapperName);
			guid++;

			MethodCache.methodLookup [wrapperName] = method;

			ParameterInfo[] parameterInfos = method.GetParameters() ;
			Type[] parameterTypes = new Type[parameterInfos.Length] ;
			for (int i=0;i<parameterInfos.Length;i++)
				parameterTypes[i]=parameterInfos[i].ParameterType;

			MethodAttributes modifier = MethodAttributes.Public;
			if (method.IsFamily)
				modifier = MethodAttributes.Family;

			if (method.IsPublic)
				modifier = MethodAttributes.Public;

			if (method.IsFamilyOrAssembly)
				modifier = MethodAttributes.FamORAssem;

			if (method.IsFamilyAndAssembly)
				modifier = MethodAttributes.FamANDAssem;

			MethodBuilder methodBuilder = typeBuilder.DefineMethod(method.Name, modifier | MethodAttributes.Virtual, CallingConventions.Standard, method.ReturnType, parameterTypes);
			for (int i=0;i<parameterInfos.Length;i++)
			{
				ParameterBuilder parameterBuilder = methodBuilder.DefineParameter(i+1,parameterInfos[i].Attributes,parameterInfos[i].Name) ;							
			}

			ILGenerator il = methodBuilder.GetILGenerator();

			LocalBuilder paramList = il.DeclareLocal(typeof(ArrayList));

//			il.EmitWriteLine("enter "  + method.Name) ;

			
			//create param arraylist
			ConstructorInfo arrayListCtor = typeof(ArrayList).GetConstructor(new Type[0] );		
			il.Emit(OpCodes.Newobj,arrayListCtor ) ;
			il.Emit(OpCodes.Stloc,paramList) ;


			int j = 0;
			ConstructorInfo proxyParameterCtor = typeof(ProxyParameter).GetConstructors()[0];	
			MethodInfo arrayListAddMethod = typeof(ArrayList).GetMethod("Add");
			MethodInfo getTypeMethod = typeof(Type).GetMethod("GetType",new Type[1]{typeof(string)} );

			foreach (ParameterInfo parameter in parameterInfos )
			{
				il.Emit(OpCodes.Ldloc,paramList) ;
				string paramName = parameter.Name;
				if(paramName == null)
				{
					paramName = "param" + j.ToString();
				}
				il.Emit(OpCodes.Ldstr,paramName) ;
				il.Emit(OpCodes.Ldc_I4,j) ;
				il.Emit(OpCodes.Ldstr,parameter.ParameterType.FullName.Replace("&","") ) ;
				il.Emit(OpCodes.Call,getTypeMethod) ;


				il.Emit(OpCodes.Ldarg,j+1) ;
	
				if (parameter.ParameterType.FullName.IndexOf("&")>=0 )
				{
					il.Emit(OpCodes.Ldind_Ref);
					Type t = Type.GetType(parameter.ParameterType.FullName.Replace("&","") ); 
					if (t.IsValueType)
						il.Emit(OpCodes.Box, t);
				}
				if (parameter.ParameterType.IsValueType)
				{
					il.Emit(OpCodes.Box, parameter.ParameterType);		
				}
				il.Emit(OpCodes.Ldc_I4,(int)ParameterType.ByVal) ;
				il.Emit(OpCodes.Newobj,proxyParameterCtor ) ;
				il.Emit(OpCodes.Callvirt,arrayListAddMethod) ;
				il.Emit(OpCodes.Pop) ;


				
				j++;
			}
//			OutLine("			__parameters.Add( new NAspect.ProxyParameter(\"{0}\",{1},typeof({2}),{4},NAspect.ParameterType.{3}) );",parameter.Name,parameter.Position,GetTypeName(parameter.ParameterType),ParameterType.ByVal.ToString(),parameter.Name);




		//	HandleCall(IAOPProxy target,string wrappermethodname,IList parameters,Type returntype)

			MethodInfo handleCallMethod = typeof(IAOPProxy).GetMethod("HandleCall");

			il.Emit(OpCodes.Ldarg_0) ;
			il.Emit(OpCodes.Ldarg_0) ;
			il.Emit(OpCodes.Ldstr,wrapperName) ;
			il.Emit(OpCodes.Ldloc,paramList) ;
			il.Emit(OpCodes.Ldstr,method.ReturnType.FullName) ;
			il.Emit(OpCodes.Call,getTypeMethod) ;
			il.Emit(OpCodes.Callvirt,handleCallMethod ) ;
			if (method.ReturnType == typeof(void))
			{
				il.Emit(OpCodes.Pop);
			}
			else if (method.ReturnType.IsValueType)
			{
				il.Emit(OpCodes.Unbox, method.ReturnType);
				il.Emit(OpCodes.Ldobj, method.ReturnType);
			}



			j=0;
			MethodInfo get_ItemMethod = typeof(ArrayList).GetMethod("get_Item",new Type[1]{typeof(int)} );
			foreach (ParameterInfo parameter in parameterInfos )
			{
				if (parameter.ParameterType.FullName.IndexOf("&")>=0 )
				{
					il.Emit(OpCodes.Ldarg,j+1) ;
					il.Emit(OpCodes.Ldloc,paramList) ;
					il.Emit(OpCodes.Ldc_I4,j) ;
					il.Emit(OpCodes.Callvirt,get_ItemMethod) ;
					il.Emit(OpCodes.Castclass,typeof(ProxyParameter)) ;
					FieldInfo valueField= typeof(ProxyParameter).GetField("Value");
					il.Emit(OpCodes.Ldfld, valueField) ;
					Type t = Type.GetType(parameter.ParameterType.FullName.Replace("&","") ); 
					if (t.IsValueType)
					{
						il.Emit(OpCodes.Unbox,t) ;
						il.Emit(OpCodes.Ldobj,t) ;
						il.Emit(OpCodes.Stobj,t) ;
					}
					else
					{
						il.Emit(OpCodes.Castclass,t) ;	
						il.Emit(OpCodes.Stind_Ref) ;
					}

					
					
					
				}
				j++;
			}


			il.Emit(OpCodes.Ret);

			BuildWrapperMethod(wrapperName,baseType,typeBuilder,method,mixins);
		}

		private void BuildWrapperMethod (string wrapperName ,Type baseType, TypeBuilder typeBuilder, MethodInfo method, IList mixins)
		{
			ParameterInfo[] parameterInfos = method.GetParameters() ;
			Type[] parameterTypes = new Type[parameterInfos.Length] ;
			for (int i=0;i<parameterInfos.Length;i++)
				parameterTypes[i]=parameterInfos[i].ParameterType;

			MethodBuilder methodBuilder = typeBuilder.DefineMethod(wrapperName, MethodAttributes.Private , CallingConventions.Standard, method.ReturnType, parameterTypes);
			for (int i=0;i<parameterInfos.Length;i++)
			{
				methodBuilder.DefineParameter(i+1,parameterInfos[i].Attributes,parameterInfos[i].Name) ;
			}

			ILGenerator il = methodBuilder.GetILGenerator();
//			il.EmitWriteLine("enter "  + wrapperName) ;

			il.Emit(OpCodes.Ldarg_0);			
			for (int i=0;i<parameterInfos.Length;i++)
				il.Emit(OpCodes.Ldarg,i+1) ;

			il.Emit(OpCodes.Call, method);
//			il.EmitWriteLine("exit "  + wrapperName) ;
			il.Emit(OpCodes.Ret);
		}

		private FieldBuilder GetMixinField(Type mixinType)
		{
			if (!mixinType.IsInterface)
				mixinType = mixinType.GetInterfaces ()[0];

			string mixinName = mixinType.Name + "Mixin";

			return mixinFieldLookup [mixinName] as FieldBuilder;
		}

		private Hashtable mixinFieldLookup = new Hashtable();
		private void BuildMixinFields(TypeBuilder typeBuilder, Type[] interfaces)
		{
			foreach (Type mixinType in interfaces)
			{
				string mixinName = mixinType.Name + "Mixin";
				FieldBuilder mixinField = typeBuilder.DefineField (mixinName,mixinType,FieldAttributes.Private);
				mixinFieldLookup [mixinName] = mixinField;
			}
		}

		private static Type[] GetInterfaces(IList mixins)
		{
			Type[] interfaces = new Type[mixins.Count];
			for (int i=0;i<mixins.Count;i++)
			{
				Type mixin = mixins [i] as Type;
				Type mixinInterface = mixin.GetInterfaces()[0];
				interfaces[i] = mixinInterface;
			}
			return interfaces;
		}

		private static TypeBuilder GetTypeBuilder(AssemblyBuilder assemblyBuilder, string moduleName, string typeName, Type baseType, Type[] interfaces)
		{
			ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(moduleName);
			TypeAttributes typeAttributes = TypeAttributes.Class | TypeAttributes.Public;
			return moduleBuilder.DefineType(typeName, typeAttributes, baseType, interfaces);
		}

		public void MixinType (TypeBuilder typeBuilder,Type mixinInterfaceType,FieldBuilder mixinField)
		{
			MethodInfo[] methods = mixinInterfaceType.GetMethods();

			foreach (MethodInfo method in methods)
				MixinMethod(typeBuilder,method,mixinField);
		}

		private void MixinMethod(TypeBuilder typeBuilder,MethodInfo method, FieldBuilder field)
		{
			ParameterInfo[] parameterInfos = method.GetParameters() ;
			Type[] parameterTypes = new Type[parameterInfos.Length] ;
			for (int i=0;i<parameterInfos.Length;i++)
				parameterTypes[i]=parameterInfos[i].ParameterType;

			MethodBuilder methodBuilder = typeBuilder.DefineMethod(method.Name, MethodAttributes.Public | MethodAttributes.Virtual, CallingConventions.Standard, method.ReturnType, parameterTypes);

			for (int i=0;i<parameterInfos.Length;i++)
			{
				methodBuilder.DefineParameter(i+1,parameterInfos[i].Attributes,parameterInfos[i].Name) ;
			}

			ILGenerator il = methodBuilder.GetILGenerator();

			il.Emit(OpCodes.Ldarg_0);
			il.Emit(OpCodes.Ldfld, field);
			for (int i=0;i<parameterInfos.Length;i++)
				il.Emit(OpCodes.Ldarg,i+1) ;

			il.Emit(OpCodes.Callvirt, method);
			//	il.EmitWriteLine(method.Name) ;
			il.Emit(OpCodes.Ret);
		}

		public void BuildConstructors(Type baseType, TypeBuilder typeBuilder,IList mixins)
		{
			FieldBuilder proxyHostField = GetMixinField(typeof(IAOPProxy));
			ConstructorInfo[] constructors = baseType.GetConstructors();
			foreach (ConstructorInfo constructor in constructors)
			{
				ParameterInfo[] parameters = constructor.GetParameters();

				//make proxy ctor param count same as superclass + 1
				Type[] parameterTypes = new Type[parameters.Length+1];
				
				//make first param type of icontext
				parameterTypes[0] = typeof(ProxyHost); 

				//copy super ctor param types
				for (int i = 0; i <= parameters.Length-1 ; i++)
				{
					parameterTypes[i+1] = parameters[i].ParameterType;
				}

				ConstructorBuilder proxyConstructor = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, parameterTypes);
				ILGenerator il = proxyConstructor.GetILGenerator();
				
				foreach (Type mixinType in mixins)
				{
					il.Emit(OpCodes.Ldarg_0);
					ConstructorInfo mixinCtor = (mixinType).GetConstructor(new Type[]{});
					il.Emit(OpCodes.Newobj,mixinCtor ) ;
					il.Emit(OpCodes.Stfld,GetMixinField(mixinType)) ;
				}

				PropertyInfo prop = typeof(IAOPProxy).GetProperty("Host");
				MethodInfo setHostMethod = prop.GetSetMethod();

				//connect the proxyhost with the aopproxymixin
				//load this
				il.Emit(OpCodes.Ldarg_0);
				il.Emit(OpCodes.Ldfld,GetMixinField(typeof(IAOPProxy)));
				//load host
				il.Emit(OpCodes.Ldarg_1);
				il.Emit(OpCodes.Callvirt,setHostMethod);

				//associate iproxyaware mixins with this instance
				MethodInfo setProxyMethod = typeof(IProxyAware).GetMethod("SetProxy");
				foreach (Type mixinType in mixins)
				{
					if (typeof(IProxyAware).IsAssignableFrom(mixinType) )
					{
						il.Emit(OpCodes.Ldarg_0);
						il.Emit(OpCodes.Ldfld,GetMixinField(mixinType));
						il.Emit(OpCodes.Ldarg_0);
						il.Emit(OpCodes.Callvirt,setProxyMethod);
					}
				}

				//this
				il.Emit(OpCodes.Ldarg_0);

				//load the the super ctor params
				for (int i = 0; i <= parameters.Length-1 ; i++)
				{
					il.Emit(OpCodes.Ldarg , i + 2) ;
				}

				il.Emit(OpCodes.Call, constructor);

				

				il.Emit(OpCodes.Ret);
			}
		}
	}
}
