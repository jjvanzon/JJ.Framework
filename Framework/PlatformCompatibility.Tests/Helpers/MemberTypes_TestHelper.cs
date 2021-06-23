using System;
using System.Reflection;
using JJ.Framework.Reflection;

#pragma warning disable IDE0044 // Add readonly modifier

namespace JJ.Framework.PlatformCompatibility.Tests.Helpers
{
    internal class MemberTypes_TestHelper
    {
        private static int Property { get; set; } = 1;
        private static double _field = 2;
        private static void Method() { }
        private static event EventHandler Event;

        public static PropertyInfo PropertyInfo { get; }
            = typeof(MemberTypes_TestHelper).GetProperty(nameof(Property), ReflectionHelper.BINDING_FLAGS_ALL);

        public static FieldInfo FieldInfo { get; }
            = typeof(MemberTypes_TestHelper).GetField(nameof(_field), ReflectionHelper.BINDING_FLAGS_ALL);

        public static MethodInfo MethodInfo { get; }
            = typeof(MemberTypes_TestHelper).GetMethod(nameof(Method), ReflectionHelper.BINDING_FLAGS_ALL);

        public static ConstructorInfo ConstructorInfo { get; }
            = typeof(MemberTypes_TestHelper).GetConstructor(Array.Empty<Type>());

        public static EventInfo EventInfo { get; }
            = typeof(MemberTypes_TestHelper).GetEvent(nameof(Event), ReflectionHelper.BINDING_FLAGS_ALL);

        public static Type Type { get; } = typeof(MemberTypes_TestHelper);

        public static CustomMemberInfo CustomMemberInfo { get; } = new CustomMemberInfo();
    }
}
