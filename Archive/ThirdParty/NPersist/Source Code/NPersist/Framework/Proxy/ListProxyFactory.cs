//// *
//// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
//// *
//// * This library is free software; you can redistribute it and/or modify it
//// * under the terms of the GNU Lesser General Public License 2.1 or later, as
//// * published by the Free Software Foundation. See the included license.txt
//// * or http://www.gnu.org/copyleft/lesser.html for details.
//// *
//// *

//using System;
//using System.Collections;
//using System.Reflection;
//using System.Reflection.Emit;
//using System.Threading;
//using Puzzle.NPersist.Framework.BaseClasses;
//using Puzzle.NPersist.Framework.Interfaces;
//using Puzzle.NPersist.Framework.Persistence;

//namespace Puzzle.NPersist.Framework.Proxy
//{
//    public class ListProxyFactory
//    {
		
//        private static Hashtable proxyTypeLookup = new Hashtable();

//        public ListProxyFactory()
//        {
//        }

//        #region CreateProxy

//        public static IInterceptableList CreateProxy(Type baseType, IObjectFactory objectFactory,params object[] ctorArgs)
//        {
//            if (objectFactory == null)
//                throw new Exception("apa");

//            Type proxyType = GetProxyType(baseType);

//            IInterceptableList result = (IInterceptableList) objectFactory.CreateInstance(proxyType, ctorArgs);
//            if (result == null)
//                result = (IInterceptableList) Activator.CreateInstance(proxyType, ctorArgs);

//            //attach the an interceptor to the list
//            //result.SetInterceptor(new ListInterceptor());


//            return result;
//        }

//        #endregion

//        #region GetProxyType

//        private static Type GetProxyType(Type baseType)
//        {
//            Type proxyType;
//            if (!(proxyTypeLookup.Contains(baseType)))
//            {
//                ListProxyFactory factory = new ListProxyFactory();
//                proxyType = factory.CreateType(baseType);
//                proxyTypeLookup.Add(baseType, proxyType);
//            }
//            proxyType = ((Type) (proxyTypeLookup[baseType]));
//            return proxyType;
//        }

//        #endregion

//        private static long guid;

//        public static string GetGuid()
//        {
//            guid += 1;
//            return "List" + guid.ToString();
//        }

//        public Type CreateType(Type baseType)
//        {
//            string typeName = baseType.Name + "ListProxy";
//            string moduleName = "Puzzle.NPersist.Runtime.Proxy";
//            AppDomain domain = Thread.GetDomain();
//            AssemblyName assemblyName = new AssemblyName();
//            assemblyName.Name = GetGuid();
//            assemblyName.Version = new Version(1, 0, 0, 0);
//            Type[] interfaces = new Type[] {typeof (IInterceptableList),typeof(IList)};
//            AssemblyBuilder assemblyBuilder = domain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
			
//            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(moduleName);
//            TypeAttributes typeAttributes = TypeAttributes.Class | TypeAttributes.Public;
//            TypeBuilder typeBuilder = moduleBuilder.DefineType(typeName, typeAttributes, baseType, interfaces);
//            FieldBuilder interceptorField = typeBuilder.DefineField("interceptor", typeof (ListInterceptor), FieldAttributes.Private);
//            //			BuildGetInterceptor(interceptorField, typeBuilder);
//            //			BuildSetInterceptor(interceptorField, typeBuilder);
//            BuildConstructors(baseType,interceptorField, typeBuilder);
//            BuildMethods(baseType, interceptorField, typeBuilder);
//            BuildInterceptableGet(interceptorField, typeBuilder);
//            BuildInterceptableSet(interceptorField, typeBuilder);
//            BuildMuteNotifyGet(interceptorField, typeBuilder);
//            BuildMuteNotifySet(interceptorField, typeBuilder);
//            BuildPropertyNameGet(interceptorField, typeBuilder);
//            BuildPropertyNameSet(interceptorField, typeBuilder);
//            return typeBuilder.CreateType();
//        }

//        public void BuildConstructors(Type baseType,FieldBuilder interceptorField, TypeBuilder typeBuilder)
//        {
//            ConstructorInfo[] constructors = baseType.GetConstructors();
//            foreach (ConstructorInfo constructor in constructors)
//            {
//                ParameterInfo[] parameters = constructor.GetParameters();
//                Type[] parameterTypes = new Type[parameters.Length];
//                for (int i = 0; i <= parameters.Length - 1; i++)
//                {
//                    parameterTypes[i] = parameters[i].ParameterType;
//                }
//                ConstructorBuilder proxyConstructor = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, parameterTypes);
//                ILGenerator il = proxyConstructor.GetILGenerator();
//                il.Emit(OpCodes.Ldarg_0);

//                for (int i = 0; i <= parameters.Length - 1; i++)
//                {
//                    //	ParameterInfo parameter = parameters[i];
//                    il.Emit(OpCodes.Ldarg, i + 1);
//                }

//                il.Emit(OpCodes.Call, constructor);
//                il.Emit(OpCodes.Ldarg_0) ;
//                il.Emit(OpCodes.Ldarg_0) ;
//                il.Emit(OpCodes.Call,EmitHelper.getNewInterceptor);
//                il.Emit(OpCodes.Stfld, interceptorField);

//                il.Emit(OpCodes.Ret);
//            }
//        }

//        private void BuildMethods(Type listType, FieldBuilder interceptorField, TypeBuilder typeBuilder)
//        {
//            MethodInfo[] methods = listType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
//            foreach (MethodInfo method in methods)
//            {
//                BuildMethod(interceptorField, method, typeBuilder);
//            }

//            MethodInfo[] ilistMethods = listType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
//            foreach (MethodInfo method in ilistMethods)
//            {
//                if (method.Name.StartsWith("System.Collections.IList"))
//                    BuildIListMethod(interceptorField, method, typeBuilder);
//            }
//        }


//        private static void BuildMethod(FieldBuilder interceptorField, MethodInfo method, TypeBuilder typeBuilder)
//        {
//            #region Filter


//            if (!(method.IsVirtual && !method.IsSpecialName && !method.IsStatic && !method.IsFinal && method.MemberType == MemberTypes.Method))
//                    return;
	

//            if (method.Name == "ToString")
//                return;

//            if (method.Name == "Equals")
//                return;

//            if (method.Name == "GetHashCode")
//                return;

//            if (method.Name == "GetEnumerator")
//                return;

//            if (method.Name == "Clone")
//                return;

//            if (method.Name == "Contains")
//                return;

//            if (method.Name == "CopyTo")
//                return;

//            if (method.Name == "Finalize")
//                return;


//            string methodmod = "";
//            if (method.IsFamily)
//                methodmod = "protected";
//            if (method.IsFamilyAndAssembly)
//                methodmod = "protected internal"; // do not localize
//            if (method.IsPublic)
//                methodmod = "public";

//            if (methodmod == "")
//                    return;
		
//            #endregion

////			Console.WriteLine("overriding {0}",method.Name) ; // do not localize

//            ParameterInfo[] parameters = method.GetParameters();
//            Type[] parameterTypes = new Type[parameters.Length];
//            for (int i = 0; i <= parameters.Length - 1; i++)
//            {
//                parameterTypes[i] = parameters[i].ParameterType;
//            }

//            MethodBuilder methodBuilder = null;
		
//            methodBuilder = typeBuilder.DefineMethod(method.Name, MethodAttributes.Public | MethodAttributes.Virtual, CallingConventions.Standard, method.ReturnType, parameterTypes);
		
//            ILGenerator il = methodBuilder.GetILGenerator();

////			il.EmitWriteLine("enter " + method.Name) ; // do not localize

//            il.Emit(OpCodes.Ldarg_0);
//            il.Emit(OpCodes.Ldfld, interceptorField);
//            il.Emit(OpCodes.Callvirt, EmitHelper.beforeCallMethod);


////			il.EmitWriteLine("before basecall " + method.Name) ; // do not localize

//            il.Emit(OpCodes.Ldarg_0);
//            for (int i = 0; i < parameters.Length; i++)
//            {
//                il.Emit(OpCodes.Ldarg, i+1);
//            }
//            il.Emit(OpCodes.Call, method);

////			il.EmitWriteLine("after basecall " + method.Name) ; // do not localize


//            il.Emit(OpCodes.Ldarg_0);
//            il.Emit(OpCodes.Ldfld, interceptorField);
//            il.Emit(OpCodes.Callvirt, EmitHelper.afterCallMethod);

////			il.EmitWriteLine("exit " + method.Name) ; // do not localize

//            il.Emit(OpCodes.Ret);
//        }

//        private static void BuildIListMethod(FieldBuilder interceptorField, MethodInfo method, TypeBuilder typeBuilder)
//        {
//            #region Filter

//                if (method.IsSpecialName)
//                    return;

//            if (method.Name == "System.Collections.IList.Contains")
//                return;

//            if (method.Name == "System.Collections.IList.IndexOf")
//                return;

//            #endregion

//            MethodInfo invokeMethod = typeof (MethodInfo).GetMethod("Invoke",new Type[] {typeof(object),typeof(object[])});

////			Console.WriteLine("overriding {0}",method.Name) ; // do not localize

//            ParameterInfo[] parameters = method.GetParameters();
//            Type[] parameterTypes = new Type[parameters.Length];
//            for (int i = 0; i <= parameters.Length - 1; i++)
//            {
//                parameterTypes[i] = parameters[i].ParameterType;
//            }

//            MethodBuilder methodBuilder = null;

//            methodBuilder = typeBuilder.DefineMethod(method.Name.Replace("System.Collections.IList.","") , MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual| MethodAttributes.Final, CallingConventions.Standard, method.ReturnType, parameterTypes);

//            ILGenerator il = methodBuilder.GetILGenerator();

//            LocalBuilder methodLocal = il.DeclareLocal(typeof(MethodInfo));
//            LocalBuilder parametersLocal = il.DeclareLocal(typeof(object[]));
//            LocalBuilder resultLocal = il.DeclareLocal(typeof(object));

//            il.Emit(OpCodes.Ldc_I4,parameters.Length);
//            il.Emit(OpCodes.Newarr,typeof(object));
//            il.Emit(OpCodes.Stloc , parametersLocal) ;
//            il.Emit(OpCodes.Ldloc , parametersLocal) ;

////			//fill param array
//            for(int i=0;i<parameters.Length;i++)
//            {
//                il.Emit(OpCodes.Ldc_I4,i ); //load index
//                il.Emit(OpCodes.Ldarg,i+1 ); //load param i+1
//                il.Emit(OpCodes.Stelem_Ref); //store at index
//            }

////			il.EmitWriteLine("enter " + method.Name) ; // do not localize
//            il.Emit(OpCodes.Ldarg_0);
//            il.Emit(OpCodes.Ldfld, interceptorField);
//            il.Emit(OpCodes.Callvirt, EmitHelper.beforeCallMethod);
//            string methodGuid = GetGuid();

//            ListProxyHelper.AddMethodInfo(methodGuid,method) ;

//            il.Emit(OpCodes.Ldstr , methodGuid);
//            il.Emit(OpCodes.Call,EmitHelper.getIListMethodInfo) ;
//            il.Emit(OpCodes.Stloc , methodLocal) ;

////
//            il.Emit(OpCodes.Ldloc , methodLocal) ;
//            il.Emit(OpCodes.Ldarg_0);
//            il.Emit(OpCodes.Ldloc,parametersLocal);
//            il.Emit(OpCodes.Callvirt,invokeMethod) ;
//            il.Emit(OpCodes.Stloc , resultLocal) ;


//            il.Emit(OpCodes.Ldarg_0);
//            il.Emit(OpCodes.Ldfld, interceptorField);
//            il.Emit(OpCodes.Callvirt, EmitHelper.afterCallMethod);
////			il.EmitWriteLine("exit " + method.Name) ; // do not localize

//            if (method.ReturnType != Type.GetType("System.Void"))
//            {
//                il.Emit(OpCodes.Ldloc , resultLocal) ;
//                if (method.ReturnType.IsValueType)
//                {
//                    il.Emit(OpCodes.Unbox, method.ReturnType);
//                    il.Emit(OpCodes.Ldobj, method.ReturnType);
//                }
//            }

//            il.Emit(OpCodes.Ret);
//        }

//        private static void BuildInterceptableGet(FieldBuilder interceptorField, TypeBuilder typeBuilder)
//        {
//            BuildIInterceptableListGetProperty(interceptorField, typeBuilder, "Interceptable", typeof (IInterceptable));
//        }

//        private static void BuildInterceptableSet(FieldBuilder interceptorField, TypeBuilder typeBuilder)
//        {
//            BuildIInterceptableListSetProperty(interceptorField, typeBuilder, "Interceptable", typeof (IInterceptable));
//        }

//        private static void BuildPropertyNameGet(FieldBuilder interceptorField, TypeBuilder typeBuilder)
//        {
//            BuildIInterceptableListGetProperty(interceptorField, typeBuilder, "PropertyName", typeof (string));
//        }

//        private static void BuildPropertyNameSet(FieldBuilder interceptorField, TypeBuilder typeBuilder)
//        {
//            BuildIInterceptableListSetProperty(interceptorField, typeBuilder, "PropertyName", typeof (string));
//        }

//        private static void BuildMuteNotifyGet(FieldBuilder interceptorField, TypeBuilder typeBuilder)
//        {
//            BuildIInterceptableListGetProperty(interceptorField, typeBuilder, "MuteNotify", typeof (bool));
//        }

//        private static void BuildMuteNotifySet(FieldBuilder interceptorField, TypeBuilder typeBuilder)
//        {
//            BuildIInterceptableListSetProperty(interceptorField, typeBuilder, "MuteNotify", typeof (bool));
//        }

//        private static void BuildIInterceptableListGetProperty(FieldBuilder interceptorField, TypeBuilder typeBuilder, string propertyName, Type propertyType)
//        {
//            MethodInfo getproperty = typeof (IInterceptableList).GetMethod("get_" + propertyName);
//            MethodInfo getproperty2 = typeof (IListInterceptor).GetMethod("get_" + propertyName);
//            Type[] parameterTypes = new Type[0];
//            MethodBuilder methodBuilder = typeBuilder.DefineMethod(getproperty.Name, MethodAttributes.Public | MethodAttributes.Virtual, CallingConventions.Standard, propertyType, parameterTypes);
//            ILGenerator il = methodBuilder.GetILGenerator();
//            il.Emit(OpCodes.Ldarg_0);
//            il.Emit(OpCodes.Ldfld, interceptorField);
//            il.Emit(OpCodes.Callvirt, getproperty2);
//            il.Emit(OpCodes.Ret);
//        }

//        private static void BuildIInterceptableListSetProperty(FieldBuilder interceptorField, TypeBuilder typeBuilder, string propertyName, Type propertyType)
//        {
//            MethodInfo setProperty = typeof (IInterceptableList).GetMethod("set_" + propertyName);
//            MethodInfo setProperty2 = typeof (IListInterceptor).GetMethod("set_" + propertyName);
//            Type[] parameterTypes = new Type[1] {propertyType};
//            MethodBuilder methodBuilder = typeBuilder.DefineMethod(setProperty.Name, MethodAttributes.Public | MethodAttributes.Virtual, CallingConventions.Standard, null, parameterTypes);
//            ILGenerator il = methodBuilder.GetILGenerator();
//            il.Emit(OpCodes.Ldarg_0);
//            il.Emit(OpCodes.Ldfld, interceptorField);
//            il.Emit(OpCodes.Ldarg_1);
//            il.Emit(OpCodes.Callvirt, setProperty2);
//            il.Emit(OpCodes.Ret);
//        }


//    }
//}