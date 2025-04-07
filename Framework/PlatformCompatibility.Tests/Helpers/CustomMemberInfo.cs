using System;
using System.Reflection;

// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.PlatformCompatibility.Tests.Helpers
{
    // ncrunch: no coverage start
    internal class CustomMemberInfo : MemberInfo
    {
        public override object[] GetCustomAttributes(bool inherit) => throw new NotImplementedException();
        public override bool IsDefined(Type attributeType, bool inherit) => throw new NotImplementedException();
        public override MemberTypes MemberType { get; } = MemberTypes.Custom;
        public override string Name { get; }
        public override Type DeclaringType { get; }
        public override Type ReflectedType { get; }
        public override object[] GetCustomAttributes(Type attributeType, bool inherit) => throw new NotImplementedException();
    }
    // ncrunch: no coverage end
}
