using System;
using System.Reflection;
using JJ.Framework.Reflection;

#pragma warning disable 649
#pragma warning disable IDE0044 // Add readonly modifier

namespace JJ.Framework.PlatformCompatibility.Tests
{
    internal class TestHelper
    {
        private static int Property { get; set; }
        private static int _field;
        private static void Method() { }
        private event EventHandler Event;

        public static PropertyInfo PropertyInfo { get; }
            = typeof(TestHelper).GetProperty(nameof(Property), ReflectionHelper.BINDING_FLAGS_ALL);

        public static FieldInfo FieldInfo { get; }
            = typeof(TestHelper).GetField(nameof(_field), ReflectionHelper.BINDING_FLAGS_ALL);

        public static MethodInfo MethodInfo { get; }
            = typeof(TestHelper).GetMethod(nameof(Method), ReflectionHelper.BINDING_FLAGS_ALL);

        public static ConstructorInfo ConstructorInfo { get; }
            = typeof(TestHelper).GetConstructor(Array.Empty<Type>());

        public static EventInfo EventInfo { get; }
            = typeof(TestHelper).GetEvent(nameof(Event), ReflectionHelper.BINDING_FLAGS_ALL);

        public static Type Type { get; }  = typeof(TestHelper);

        public static CustomMemberInfo CustomMemberInfo { get; } = new CustomMemberInfo();
    }
}
