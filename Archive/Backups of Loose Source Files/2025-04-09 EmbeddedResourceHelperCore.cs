using System.Reflection;

namespace JJ.Framework.Common.Core;

public static class EmbeddedResourceHelperCore
{
    public static string GetEmbeddedResourceName(Assembly assembly, string fileName)
        => EmbeddedResourceHelper.GetEmbeddedResourceName(assembly, null, fileName);
}