using System;
using System.IO;
using System.Reflection;
// ReSharper disable CheckNamespace
// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace JJ.Framework.Common
{
    [Obsolete("Use EmbeddedResourceReader instead.", true)]
    public static class EmbeddedResourceHelper
    {
        [Obsolete("Use EmbeddedResourceReader.GetText instead.", true)]
        public static string GetEmbeddedResourceText(Assembly assembly, string fileName)
            => throw new NotSupportedException("Use EmbeddedResourceReader.GetText instead.");

        [Obsolete("Use EmbeddedResourceReader.GetBytes instead.", true)]
        public static byte[] GetEmbeddedResourceBytes(Assembly assembly, string fileName)
            => throw new NotSupportedException("Use EmbeddedResourceReader.GetBytes instead.");

        [Obsolete("Use EmbeddedResourceReader.GetStream instead.", true)]
        public static Stream GetEmbeddedResourceStream(Assembly assembly, string fileName)
            => throw new NotSupportedException("Use EmbeddedResourceReader.GetStream instead.");

        [Obsolete("Use EmbeddedResourceReader.GetName instead.", true)]
        public static string GetEmbeddedResourceName(Assembly assembly, string fileName)
            => throw new NotSupportedException("Use EmbeddedResourceReader.GetName instead.");

        [Obsolete("Use EmbeddedResourceReader.GetText instead.", true)]
        public static string GetEmbeddedResourceText(Assembly assembly, string subNameSpace, string fileName)
            => throw new NotSupportedException("Use EmbeddedResourceReader.GetText instead.");

        [Obsolete("Use EmbeddedResourceReader.GetBytes instead.", true)]
        public static byte[] GetEmbeddedResourceBytes(Assembly assembly, string subNameSpace, string fileName)
            => throw new NotSupportedException("Use EmbeddedResourceReader.GetBytes instead.");

        [Obsolete("Use EmbeddedResourceReader.GetStream instead.", true)]
        public static Stream GetEmbeddedResourceStream(Assembly assembly, string subNameSpace, string fileName)
            => throw new NotSupportedException("Use EmbeddedResourceReader.GetStream instead.");

        [Obsolete("Use EmbeddedResourceReader.GetName instead.", true)]
        public static string GetEmbeddedResourceName(Assembly assembly, string subNameSpace, string fileName)
            => throw new NotSupportedException("Use EmbeddedResourceReader.GetName instead.");
    }
}