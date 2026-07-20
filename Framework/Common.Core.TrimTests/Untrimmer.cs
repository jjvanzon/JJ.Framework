// ReSharper disable UnusedType.Global

namespace JJ.Framework.Common.Core.TrimTests;

internal static class Untrimmer
{
    [NoTrim(All, "JJ.Framework.Common.Core.CommonStringExtensionsCore", "JJ.Framework.Common.Core")]
    //[NoTrim("ObsoleteMessage", "JJ.Framework.Common.Core.CommonStringExtensionsCore", "JJ.Framework.Common.Core")]
    //[NoTrim("RemoveAccents", "JJ.Framework.Common.Core.CommonStringExtensionsCore", "JJ.Framework.Common.Core")]
    //[NoTrim("RemoveAccentsObsolete", "JJ.Framework.Common.Core.CommonStringExtensionsCore", "JJ.Framework.Common.Core")]
    public static void Untrim() { }
}