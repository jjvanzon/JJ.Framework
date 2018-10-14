using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;

namespace Puzzle.NAspect.Framework
{
    public delegate void FastFieldSetter(object target, object value);
    public delegate object FastFieldGetter(object target);

    public class FastFieldAccess
    {

        private static Dictionary<FieldInfo, FastFieldSetter> setterCache = new Dictionary<FieldInfo, FastFieldSetter>();
        private static Dictionary<FieldInfo, FastFieldGetter> getterCache = new Dictionary<FieldInfo, FastFieldGetter>();

        [DebuggerHidden]
        [DebuggerStepThrough]
        public static FastFieldSetter GetFieldSetter(FieldInfo fieldInfo)
        {
            FastFieldSetter res;
            setterCache.TryGetValue(fieldInfo, out res);
            if (res != null)
                return res;

            DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(void), new Type[] { typeof(object), typeof(object) }, fieldInfo.DeclaringType,true);
            ILGenerator il = dynamicMethod.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            if (fieldInfo.FieldType.IsValueType)
                il.Emit(OpCodes.Unbox_Any, fieldInfo.FieldType);
            il.Emit(OpCodes.Stfld, fieldInfo);
            il.Emit(OpCodes.Ret);
            FastFieldSetter invoker = (FastFieldSetter)dynamicMethod.CreateDelegate(typeof(FastFieldSetter));
            return invoker;
        }

        public static FastFieldGetter GetFieldGetter(FieldInfo fieldInfo)
        {
            FastFieldGetter res;
            getterCache.TryGetValue(fieldInfo, out res);
            if (res != null)
                return res;

            DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(object), new Type[] { typeof(object)}, fieldInfo.DeclaringType, true);
            ILGenerator il = dynamicMethod.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld,fieldInfo);
            if (fieldInfo.FieldType.IsValueType)
                il.Emit(OpCodes.Box,fieldInfo.FieldType);            
            il.Emit(OpCodes.Ret);
            FastFieldGetter invoker = (FastFieldGetter)dynamicMethod.CreateDelegate(typeof(FastFieldGetter));
            return invoker;
        }
    }
}
