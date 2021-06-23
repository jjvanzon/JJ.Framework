using System;
using System.Reflection;

namespace JJ.Framework.PlatformCompatibility.Tests.Helpers
{
    internal class CustomMemberInfo : MemberInfo
    {
        public override object[] GetCustomAttributes(bool inherit) => throw new NotImplementedException();

        public override bool IsDefined(Type attributeType, bool inherit) => throw new NotImplementedException();

        public override MemberTypes MemberType => MemberTypes.Custom;
        public override string Name { get; }
        public override Type DeclaringType { get; }
        public override Type ReflectedType { get; }

        public override object[] GetCustomAttributes(Type attributeType, bool inherit) => throw new NotImplementedException();
    }
}
