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
using System.Collections;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework.Utils;

namespace Puzzle.NAspect.Framework
{
    /// <summary>
    /// Factory that produces interface proxy types
    /// </summary>
    public class InterfaceProxyFactory
    {
        /// <summary>
        /// Creates a proxy type of a given type.
        /// </summary>
        /// <param name="baseType">Type to proxyfy</param>
        /// <param name="aspects">Untyped list of <c>IAspects</c> to apply to the proxy.</param>
        /// <param name="mixins">Untyped list of <c>System.Type</c>s that will be mixed in.</param>
        /// <param name="engine">The AopEngine requesting the proxy type</param>
        /// <returns></returns>
        public static Type CreateProxyType(Type baseType, IList aspects, IList mixins, Engine engine)
        {
            if (aspects.Count == 0 && mixins.Count == 1 && !AopTools.HasFixedAttributes(baseType))
                return baseType;

            InterfaceProxyFactory factory = new InterfaceProxyFactory(engine);

            return factory.CreateType(baseType, aspects, mixins);
        }

        private static long guid = 0;

        private static string GetMethodId(string methodName)
        {
            string methodId = "__" + methodName + "Wrapper" + guid.ToString();
            guid++;

            if (guid == long.MaxValue)
                guid = long.MinValue;

            if (guid == 0)
                throw new Exception("tough luch , youve proxied long.max methods");

            return methodId;
        }

        private Engine engine;
        private ArrayList wrapperMethods = new ArrayList();

        private InterfaceProxyFactory(Engine engine)
        {
            this.engine = engine;
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

        private Type CreateType(Type baseType, IList aspects, IList mixins)
        {
            string typeName = baseType.Name + "AopWrapper";
            string moduleName = "Puzzle.NAspect.Runtime.Proxy";

            AssemblyBuilder assemblyBuilder = GetAssemblyBuilder();

            Type[] interfaces = GetInterfaces(baseType, mixins);


            TypeBuilder typeBuilder =
                GetTypeBuilder(assemblyBuilder, moduleName, typeName, typeof (InterfaceProxyBase), interfaces);

            BuildWrappedInstanceField(typeBuilder, baseType);
            BuildMixinFields(typeBuilder, mixins);

            BuildConstructors(baseType, typeBuilder, mixins);

            foreach (Type mixinType in mixins)
            {
                if (mixinType.IsInterface)
                {
                    //ignore pure interfaces
                }
                else
                {
                    Type mixinInterfaceType = mixinType.GetInterfaces()[0];
                    MixinType(typeBuilder, mixinInterfaceType, GetMixinField(mixinInterfaceType), aspects);
                }
            }

            BuildMethods(baseType.GetInterfaces(), typeBuilder, aspects);

            Type proxyType = typeBuilder.CreateType();

            BuildLookupTables(proxyType, aspects);

            return proxyType;
        }

        private FieldBuilder that;

        private void BuildWrappedInstanceField(TypeBuilder typeBuilder, Type basetype)
        {
            that = typeBuilder.DefineField("__wrappedInstanceField", basetype, FieldAttributes.Private);
        }

        private void BuildLookupTables(Type proxyType, IList aspects)
        {
            foreach (string methodId in wrapperMethods)
            {
                MethodInfo wrapperMethod =
                    proxyType.GetMethod(methodId,
                                        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                                        BindingFlags.DeclaredOnly);
                MethodCache.wrapperMethodLookup[methodId] = wrapperMethod;

                MethodBase baseMethod = (MethodBase) MethodCache.methodLookup[methodId];
                //array to return
                IList methodinterceptors = new ArrayList();
                //fetch all aspects from the type-aspect lookup
                foreach (IGenericAspect aspect in aspects)
                {
                    foreach (IPointcut pointcut in aspect.Pointcuts)
                    {
                        if (pointcut.IsMatch(baseMethod, proxyType))
                        {
                            foreach (object interceptor in pointcut.Interceptors)
                            {
                                methodinterceptors.Add(interceptor);
                            }
                        }
                    }
                }
                foreach (FixedInterceptorAttribute fixedInterceptorAttribute in baseMethod.GetCustomAttributes(typeof(FixedInterceptorAttribute), true))
                    foreach (Type type in fixedInterceptorAttribute.Types)
                        methodinterceptors.Add(Activator.CreateInstance(type));
                foreach (FixedInterceptorAttribute fixedInterceptorAttribute in baseMethod.DeclaringType.GetCustomAttributes(typeof(FixedInterceptorAttribute), true))
                    foreach (Type type in fixedInterceptorAttribute.Types)
                        methodinterceptors.Add(Activator.CreateInstance(type));

                MethodCache.methodInterceptorsLookup[methodId] = methodinterceptors;
                CallInfo callInfo = MethodCache.GetCallInfo(methodId);
                callInfo.Interceptors = methodinterceptors;
            }
        }

        private void BuildMethods(Type[] interfaces, TypeBuilder typeBuilder, IList aspects)
        {
            //	MethodInfo[] methods = baseType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

            foreach (Type iface in interfaces)
            {
                MethodInfo[] methods =
                    iface.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                foreach (MethodInfo method in methods)
                {
                    string methodName = iface.FullName.ToString() + "." + method.Name;

                    if (engine.PointCutMatcher.MethodShouldBeProxied(method, aspects))
                    {
                        BuildMethod(methodName, typeBuilder, method);
                    }
                    else
                    {
                        BuildUnproxiedMethod(methodName, typeBuilder, method);
                    }
                }
            }
        }


        private void BuildMethod(string methodName, TypeBuilder typeBuilder, MethodInfo method)
        {
            string wrapperName = GetMethodId(method.Name);
            wrapperMethods.Add(wrapperName);

            MethodCache.methodLookup[wrapperName] = method;

            ParameterInfo[] parameterInfos = method.GetParameters();
            Type[] parameterTypes = new Type[parameterInfos.Length];
            for (int i = 0; i < parameterInfos.Length; i++)
                parameterTypes[i] = parameterInfos[i].ParameterType;


            MethodBuilder methodBuilder =
                typeBuilder.DefineMethod(methodName,
                                         MethodAttributes.NewSlot | MethodAttributes.Private | MethodAttributes.Virtual |
                                         MethodAttributes.Final | MethodAttributes.HideBySig,
                                         CallingConventions.Standard, method.ReturnType, parameterTypes);
            for (int i = 0; i < parameterInfos.Length; i++)
            {
            }
            typeBuilder.DefineMethodOverride(methodBuilder, method);

            ILGenerator il = methodBuilder.GetILGenerator();

            //--------------------------
            LocalBuilder paramList = il.DeclareLocal(typeof(object[]));
            //create param object[]
            il.Emit(OpCodes.Ldc_I4_S, parameterInfos.Length + 1);
            il.Emit(OpCodes.Newarr, typeof(object));
            il.Emit(OpCodes.Stloc, paramList);
            //-----------------------------------
            int j = 0;

            foreach (Type parameterType in parameterTypes)
            {
                //load arr
                il.Emit(OpCodes.Ldloc, paramList);
                //load index
                il.Emit(OpCodes.Ldc_I4, j);
                //load arg
                il.Emit(OpCodes.Ldarg, j + 1);
                //box if needed
                if (parameterType.IsByRef)
                {
                    il.Emit(OpCodes.Ldind_Ref);
                    Type t = parameterType.GetElementType();
                    if (t.IsValueType)
                        il.Emit(OpCodes.Box, t);
                }
                else if (parameterType.IsValueType)
                {
                    il.Emit(OpCodes.Box, parameterType);
                }
                il.Emit(OpCodes.Stelem_Ref);
                j++;
            }
            //-----------------------------------

            CallInfo callInfo = MethodCache.CreateCallInfo(method, parameterInfos, wrapperName);
            
            MethodInfo handleCallMethod = typeof(IAopProxy).GetMethod("HandleFastCall");
            int methodNr = MethodCache.AddCallInfo(callInfo, wrapperName);
            //il.Emit(OpCodes.Ldc_I4 ,methodNr);

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, that); // load the execution target
            il.Emit(OpCodes.Ldc_I4, methodNr);
            il.Emit(OpCodes.Ldloc, paramList);
            il.Emit(OpCodes.Ldstr, method.ReturnType.FullName);
            MethodInfo getTypeMethod = typeof(Type).GetMethod("GetType", new Type[1] { typeof(string) });
            il.Emit(OpCodes.Call, getTypeMethod);
            il.Emit(OpCodes.Callvirt, handleCallMethod);
            if (method.ReturnType == typeof (void))
            {
                il.Emit(OpCodes.Pop);
            }
            else if (method.ReturnType.IsValueType)
            {
                il.Emit(OpCodes.Unbox, method.ReturnType);
                il.Emit(OpCodes.Ldobj, method.ReturnType);
            }


            MethodCache.CopyBackRefParams(il, parameterInfos, paramList);


            il.Emit(OpCodes.Ret);

            BuildWrapperMethod(wrapperName, typeBuilder, method);
        }

        private void BuildUnproxiedMethod(string wrapperName, TypeBuilder typeBuilder, MethodInfo method)
        {
            wrapperName = method.Name;

            ParameterInfo[] parameterInfos = method.GetParameters();
            Type[] parameterTypes = new Type[parameterInfos.Length];
            for (int i = 0; i < parameterInfos.Length; i++)
                parameterTypes[i] = parameterInfos[i].ParameterType;

            Type returnType = method.ReturnType;

            MethodBuilder methodBuilder =
                typeBuilder.DefineMethod(wrapperName,
                                         MethodAttributes.NewSlot | MethodAttributes.Private | MethodAttributes.Virtual |
                                         MethodAttributes.Final | MethodAttributes.HideBySig,
                                         CallingConventions.Standard, returnType, parameterTypes);
            typeBuilder.DefineMethodOverride(methodBuilder, method);

            for (int i = 0; i < parameterInfos.Length; i++)
            {
                methodBuilder.DefineParameter(i + 1, parameterInfos[i].Attributes, parameterInfos[i].Name);
            }

            ILGenerator il = methodBuilder.GetILGenerator();

            //			il.EmitWriteLine("enter "  + wrapperName) ;

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, that);
            for (int i = 0; i < parameterInfos.Length; i++)
                il.Emit(OpCodes.Ldarg, i + 1);

            il.Emit(OpCodes.Callvirt, method);

            il.Emit(OpCodes.Ret);
        }

        private void BuildWrapperMethod(string wrapperName, TypeBuilder typeBuilder, MethodInfo method)
        {
            ParameterInfo[] parameterInfos = method.GetParameters();
            Type[] parameterTypes = new Type[parameterInfos.Length];
            for (int i = 0; i < parameterInfos.Length; i++)
                parameterTypes[i] = parameterInfos[i].ParameterType;

            Type returnType = method.ReturnType;

            MethodBuilder methodBuilder =
                typeBuilder.DefineMethod(wrapperName,
                                         MethodAttributes.NewSlot | MethodAttributes.Private | MethodAttributes.Virtual |
                                         MethodAttributes.Final | MethodAttributes.HideBySig,
                                         CallingConventions.Standard, returnType, parameterTypes);

            ILGenerator il = methodBuilder.GetILGenerator();
            //			il.EmitWriteLine("enter "  + wrapperName) ;

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, that);
            for (int i = 0; i < parameterInfos.Length; i++)
                il.Emit(OpCodes.Ldarg, i + 1);

            il.Emit(OpCodes.Callvirt, method);

            il.Emit(OpCodes.Ret);
        }

        private FieldBuilder GetMixinField(Type mixinType)
        {
            if (!mixinType.IsInterface)
                mixinType = mixinType.GetInterfaces()[0];

            string mixinName = mixinType.Name + "Mixin";

            return mixinFieldLookup[mixinName] as FieldBuilder;
        }

        private Hashtable mixinFieldLookup = new Hashtable();

        private void BuildMixinFields(TypeBuilder typeBuilder, IList mixins)
        {
            foreach (Type mixinType in mixins)
            {
                if (mixinType.IsInterface)
                {
                }
                else
                {
                    Type mixinInterface = mixinType.GetInterfaces()[0];

                    string mixinName = mixinInterface.Name + "Mixin";
                    FieldBuilder mixinField =
                        typeBuilder.DefineField(mixinName, mixinInterface, FieldAttributes.Private);
                    mixinFieldLookup[mixinName] = mixinField;
                }
            }
        }

        private static Type[] GetInterfaces(Type baseType, IList mixins)
        {
            Type[] mixinInterfaces = GetMixinInterfaces(mixins);
            Type[] baseInterfaces = baseType.GetInterfaces();

            Type[] interfaces = new Type[mixinInterfaces.Length + baseInterfaces.Length];
            Array.Copy(mixinInterfaces, 0, interfaces, 0, mixinInterfaces.Length);
            Array.Copy(baseInterfaces, 0, interfaces, mixinInterfaces.Length, baseInterfaces.Length);

            return interfaces;
        }

        private static Type[] GetMixinInterfaces(IList mixins)
        {
            Type[] mixinInterfaces = new Type[mixins.Count];
            for (int i = 0; i < mixins.Count; i++)
            {
                Type mixin = mixins[i] as Type;
                if (mixin.IsInterface)
                {
                    mixinInterfaces[i] = mixin;
                }
                else
                {
                    Type mixinInterface = mixin.GetInterfaces()[0];
                    mixinInterfaces[i] = mixinInterface;
                }
            }

            return mixinInterfaces;
        }

        private static TypeBuilder GetTypeBuilder(AssemblyBuilder assemblyBuilder, string moduleName, string typeName,
                                                  Type baseType, Type[] interfaces)
        {
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(moduleName);
            TypeAttributes typeAttributes = TypeAttributes.Class | TypeAttributes.Public;
            return moduleBuilder.DefineType(typeName, typeAttributes, baseType, interfaces);
        }

        private void MixinType(TypeBuilder typeBuilder, Type mixinInterfaceType, FieldBuilder mixinField, IList aspects)
        {
            MethodInfo[] methods = mixinInterfaceType.GetMethods();


            BuildMixinMethods(methods, typeBuilder, mixinField);

            Type[] inheritedInterfaces = mixinInterfaceType.GetInterfaces();
            foreach (Type inheritedInterface in  inheritedInterfaces)
            {
                MixinType(typeBuilder, inheritedInterface, mixinField, aspects);
            }
        }

        private void BuildMixinMethods(MethodInfo[] methods, TypeBuilder typeBuilder, FieldBuilder mixinField)
        {
            foreach (MethodInfo method in methods)
            {
//				if (method.IsVirtual && !method.IsFinal && engine.PointCutMatcher.MethodShouldBeProxied(method, aspects))
//				{
//					BuildMixinMethod(typeBuilder, method, mixinField);
//				}
//				else
//				{
                BuildMixinUnproxiedMethod(method.Name, typeBuilder, method, mixinField);
//				}
            }
        }

        private void BuildMixinUnproxiedMethod(string wrapperName, TypeBuilder typeBuilder, MethodInfo method,
                                               FieldBuilder field)
        {
            BuildMixinWrapperMethod(wrapperName, typeBuilder, method, field);
        }

        private void BuildMixinWrapperMethod(string wrapperName, TypeBuilder typeBuilder, MethodInfo method,
                                             FieldBuilder field)
        {
            ParameterInfo[] parameterInfos = method.GetParameters();
            Type[] parameterTypes = new Type[parameterInfos.Length];
            for (int i = 0; i < parameterInfos.Length; i++)
                parameterTypes[i] = parameterInfos[i].ParameterType;

            MethodBuilder methodBuilder =
                typeBuilder.DefineMethod(wrapperName, MethodAttributes.Public | MethodAttributes.Virtual,
                                         CallingConventions.Standard, method.ReturnType, parameterTypes);

            for (int i = 0; i < parameterInfos.Length; i++)
            {
                methodBuilder.DefineParameter(i + 1, parameterInfos[i].Attributes, parameterInfos[i].Name);
            }

            ILGenerator il = methodBuilder.GetILGenerator();

            il.EmitWriteLine("hej hopp");

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, field);
            for (int i = 0; i < parameterInfos.Length; i++)
                il.Emit(OpCodes.Ldarg, i + 1);

            il.Emit(OpCodes.Callvirt, method);
            //	il.EmitWriteLine(method.Name) ;
            il.Emit(OpCodes.Ret);
        }

        private void BuildConstructors(Type baseType, TypeBuilder typeBuilder, IList mixins)
        {
            ConstructorInfo constructor = typeof (object).GetConstructor(new Type[] {});
            BuildConstructor(baseType, constructor, typeBuilder, mixins);
        }

        private void BuildConstructor(Type baseType, ConstructorInfo constructor, TypeBuilder typeBuilder, IList mixins)
        {
            //make proxy ctor param count same as superclass
            Type[] parameterTypes = new Type[1];

            parameterTypes[0] = baseType;


            ConstructorBuilder proxyConstructor =
                typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, parameterTypes);
            ILGenerator il = proxyConstructor.GetILGenerator();

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Call, constructor);

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Stfld, that);


            foreach (Type mixinType in mixins)
            {
                if (mixinType.IsInterface)
                {
                    //ignore interface type mixins , they do not have an impelemntation
                }
                else
                {
                    //				il.EmitWriteLine("setting mixin instance " + mixinType.FullName) ;
                    il.Emit(OpCodes.Ldarg_0);
                    ConstructorInfo mixinCtor = (mixinType).GetConstructor(new Type[] {});
                    il.Emit(OpCodes.Newobj, mixinCtor);
                    il.Emit(OpCodes.Stfld, GetMixinField(mixinType));
                }
            }

            //associate iproxyaware mixins with this instance
            MethodInfo setProxyMethod = typeof (IProxyAware).GetMethod("SetProxy");
            foreach (Type mixinType in mixins)
            {
                if (mixinType.IsInterface)
                {
                    //ignore interface type mixins , they do not have an impelemntation
                }
                else
                {
                    if (typeof (IProxyAware).IsAssignableFrom(mixinType))
                    {
                        il.Emit(OpCodes.Ldarg_0);
                        il.Emit(OpCodes.Ldfld, GetMixinField(mixinType));
                        il.Emit(OpCodes.Ldarg_0);
                        il.Emit(OpCodes.Callvirt, setProxyMethod);
                    }
                }
            }
            il.Emit(OpCodes.Ret);
        }
    }
}