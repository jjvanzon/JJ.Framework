// *
// * Copyright (C) 2005 Luyan : http://www.codeproject.com/useritems/FastMethodInvoker.asp
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;

namespace Puzzle.NAspect.Framework
{
    public delegate object FastInvokeHandler(object target, object[] paramters);

    public static class FastCall
    {

        private static Dictionary<MethodBase, FastInvokeHandler> delegateCache =
            new Dictionary<MethodBase, FastInvokeHandler>();

        [DebuggerHidden]
        [DebuggerStepThrough]
        public static FastInvokeHandler GetMethodInvoker(MethodBase methodBase)
        {
            FastInvokeHandler res;
            delegateCache.TryGetValue(methodBase, out res);
            if (res != null)
                return res;

            DynamicMethod dynamicMethod =
                new DynamicMethod(string.Empty, typeof(object), new Type[] { typeof(object), typeof(object[]) },
                                  methodBase.DeclaringType.Module, true);
            ILGenerator il = dynamicMethod.GetILGenerator();
            ParameterInfo[] ps = methodBase.GetParameters();
            Type[] paramTypes = new Type[ps.Length];
            for (int i = 0; i < paramTypes.Length; i++)
            {
                if (ps[i].ParameterType.IsByRef)
                    paramTypes[i] = ps[i].ParameterType.GetElementType();
                else
                    paramTypes[i] = ps[i].ParameterType;
            }
            LocalBuilder[] locals = new LocalBuilder[paramTypes.Length];

            for (int i = 0; i < paramTypes.Length; i++)
            {
                locals[i] = il.DeclareLocal(paramTypes[i], true);
            }

            for (int i = 0; i < paramTypes.Length; i++)
            {
                il.Emit(OpCodes.Ldarg_1);
                EmitFastInt(il, i);
                il.Emit(OpCodes.Ldelem_Ref);
                EmitCastToReference(il, paramTypes[i]);
                il.Emit(OpCodes.Stloc, locals[i]);
            }
            il.Emit(OpCodes.Ldarg_0);
            for (int i = 0; i < paramTypes.Length; i++)
            {
                if (ps[i].ParameterType.IsByRef)
                    il.Emit(OpCodes.Ldloca_S, locals[i]);
                else
                    il.Emit(OpCodes.Ldloc, locals[i]);
            }

            if (methodBase is ConstructorInfo)
            {
                ConstructorInfo ctorInfo = (ConstructorInfo)methodBase;
                il.Emit(OpCodes.Call, ctorInfo);
                il.Emit(OpCodes.Ldnull);
            }
            else
            {
                MethodInfo methodInfo = (MethodInfo)methodBase;
                il.Emit(OpCodes.Call, methodInfo);
                if (methodInfo.ReturnType == typeof(void))
                    il.Emit(OpCodes.Ldnull);
                else
                    EmitBoxIfNeeded(il, methodInfo.ReturnType);
            }

            for (int i = 0; i < paramTypes.Length; i++)
            {
                if (ps[i].ParameterType.IsByRef)
                {
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Ldc_I4, i);
                    il.Emit(OpCodes.Ldloc, locals[i]);
                    if (locals[i].LocalType.IsValueType)
                        il.Emit(OpCodes.Box, locals[i].LocalType);

                    il.Emit(OpCodes.Stelem_Ref);
                }
            }

            il.Emit(OpCodes.Ret);
            FastInvokeHandler invoder = (FastInvokeHandler)dynamicMethod.CreateDelegate(typeof(FastInvokeHandler));

            delegateCache[methodBase] = invoder;

            return invoder;
        }

        [DebuggerHidden]
        [DebuggerStepThrough]
        private static void EmitCastToReference(ILGenerator il, Type type)
        {
            if (type.IsValueType)
            {
                il.Emit(OpCodes.Unbox_Any, type);
            }
            else
            {
                il.Emit(OpCodes.Castclass, type);
            }
        }

        [DebuggerHidden]
        [DebuggerStepThrough]
        private static void EmitBoxIfNeeded(ILGenerator il, Type type)
        {
            if (type.IsValueType)
            {
                il.Emit(OpCodes.Box, type);
            }
        }

        [DebuggerHidden]
        [DebuggerStepThrough]
        private static void EmitFastInt(ILGenerator il, int value)
        {
            switch (value)
            {
                case -1:
                    il.Emit(OpCodes.Ldc_I4_M1);
                    return;
                case 0:
                    il.Emit(OpCodes.Ldc_I4_0);
                    return;
                case 1:
                    il.Emit(OpCodes.Ldc_I4_1);
                    return;
                case 2:
                    il.Emit(OpCodes.Ldc_I4_2);
                    return;
                case 3:
                    il.Emit(OpCodes.Ldc_I4_3);
                    return;
                case 4:
                    il.Emit(OpCodes.Ldc_I4_4);
                    return;
                case 5:
                    il.Emit(OpCodes.Ldc_I4_5);
                    return;
                case 6:
                    il.Emit(OpCodes.Ldc_I4_6);
                    return;
                case 7:
                    il.Emit(OpCodes.Ldc_I4_7);
                    return;
                case 8:
                    il.Emit(OpCodes.Ldc_I4_8);
                    return;
            }

            if (value > -129 && value < 128)
            {
                il.Emit(OpCodes.Ldc_I4_S, (SByte)value);
            }
            else
            {
                il.Emit(OpCodes.Ldc_I4, value);
            }
        }
    }
}