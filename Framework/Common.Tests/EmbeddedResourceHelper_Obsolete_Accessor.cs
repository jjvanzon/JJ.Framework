using System;
using System.IO;
using System.Reflection;
using JJ.Framework.Reflection;
// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.Common.Tests
{
    internal static class EmbeddedResourceHelper_Obsolete_Accessor
    {
        private static readonly Accessor _accessor = new Accessor(Type.GetType("JJ.Framework.Common.EmbeddedResourceHelper, JJ.Framework.Common"));

        public static string GetEmbeddedResourceText(Assembly assembly, string fileName)
            => _accessor.InvokeMethod(() => GetEmbeddedResourceText(assembly, fileName));

        public static byte[] GetEmbeddedResourceBytes(Assembly assembly, string fileName)
            => _accessor.InvokeMethod(() => GetEmbeddedResourceBytes(assembly, fileName));

        public static Stream GetEmbeddedResourceStream(Assembly assembly, string fileName)
            => _accessor.InvokeMethod(() => GetEmbeddedResourceStream(assembly, fileName));

        public static string GetEmbeddedResourceName(Assembly assembly, string fileName)
            => _accessor.InvokeMethod(() => GetEmbeddedResourceName(assembly, fileName));

        public static string GetEmbeddedResourceText(Assembly assembly, string subNameSpace, string fileName)
            => _accessor.InvokeMethod(() => GetEmbeddedResourceText(assembly, subNameSpace, fileName));

        public static byte[] GetEmbeddedResourceBytes(Assembly assembly, string subNameSpace, string fileName)
            => _accessor.InvokeMethod(() => GetEmbeddedResourceBytes(assembly, subNameSpace, fileName));

        public static Stream GetEmbeddedResourceStream(Assembly assembly, string subNameSpace, string fileName)
            => _accessor.InvokeMethod(() => GetEmbeddedResourceStream(assembly, subNameSpace, fileName));

        public static string GetEmbeddedResourceName(Assembly assembly, string subNameSpace, string fileName)
            => _accessor.InvokeMethod(() => GetEmbeddedResourceName(assembly, subNameSpace, fileName));
    }
}
