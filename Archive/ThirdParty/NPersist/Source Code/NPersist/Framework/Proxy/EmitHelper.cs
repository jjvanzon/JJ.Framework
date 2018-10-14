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
//using System.Reflection;
//using System.Reflection.Emit;
//using Puzzle.NPersist.Framework.BaseClasses;
//using Puzzle.NPersist.Framework.Interfaces;

//namespace Puzzle.NPersist.Framework.Proxy
//{

//    public class EmitHelper
//    {
//        //IProxy methods
//        public static MethodInfo proxyHelperGetMethod = typeof (ProxyHelper).GetMethod("GetProperty");
//        public static MethodInfo getTypeFromHandleMethod = typeof (Type).GetMethod("GetTypeFromHandle");
//        public static MethodInfo getContextMethod = typeof (IInterceptable).GetMethod("GetInterceptor");
//        public static MethodInfo notifyPropertySetMethod = typeof (IInterceptor).GetMethod("NotifyPropertySet", new Type[4] {typeof (object), typeof (string), Type.GetType("System.Object&"), Type.GetType("System.Boolean&")});
//        public static MethodInfo notifyWrotePropertyMethod = typeof (IInterceptor).GetMethod("NotifyWroteProperty", new Type[3] {typeof (object), typeof (string), typeof (object)});
//        public static MethodInfo beforeCtorMethod = typeof (IInterceptor).GetMethod("NotifyInstantiatingObject", new Type[2] {typeof (object), Type.GetType("System.Boolean&")});	

//        //List proxy methods
//        public static MethodInfo afterCallMethod = typeof (ListInterceptor).GetMethod("AfterCall");
//        public static MethodInfo beforeCallMethod = typeof (ListInterceptor).GetMethod("BeforeCall");
//        public static MethodInfo getNewInterceptor = typeof (ListProxyHelper).GetMethod("GetNewInterceptor");
//        public static MethodInfo getIListMethodInfo = typeof (ListProxyHelper).GetMethod("GetIListMethodInfo");

//        public static void MixinType (TypeBuilder typeBuilder,Type mixinInterfaceType,FieldBuilder mixinField)
//        {
//            MethodInfo[] methods = mixinInterfaceType.GetMethods();

//            foreach (MethodInfo method in methods)
//                MixinMethod(typeBuilder,method,mixinField);
//        }

//        private static void MixinMethod(TypeBuilder typeBuilder,MethodInfo method, FieldBuilder field)
//        {
//            ParameterInfo[] parameterInfos = method.GetParameters() ;
//            Type[] parameterTypes = new Type[parameterInfos.Length] ;
//            for (int i=0;i<parameterInfos.Length;i++)
//                parameterTypes[i]=parameterInfos[i].ParameterType;

//            MethodBuilder methodBuilder = typeBuilder.DefineMethod(method.Name, MethodAttributes.Public | MethodAttributes.Virtual, CallingConventions.Standard, method.ReturnType, parameterTypes);
//            ILGenerator il = methodBuilder.GetILGenerator();

//            il.Emit(OpCodes.Ldarg_0);
//            il.Emit(OpCodes.Ldfld, field);
//            for (int i=0;i<parameterInfos.Length;i++)
//                il.Emit(OpCodes.Ldarg,i+1) ;

//            il.Emit(OpCodes.Callvirt, method);
//        //	il.EmitWriteLine(method.Name) ;
//            il.Emit(OpCodes.Ret);
//        }

//    }
//}
