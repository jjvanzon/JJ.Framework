#pragma warning disable IDE0051 // Private member never used.

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedParameter.Local

namespace JJ.Framework.Common.Core;

/// <inheritdoc cref="_commonstringextensionscore" />
//[Obsolete(ObsoleteMessage, true)]
public static class CommonStringExtensionsCore
{
    private const string ObsoleteMessage 
        = "Use StringExtensionsCore.RemoveAccents from JJ.Framework.Text.Core instead.";
    
    /// <inheritdoc cref="_removeaccentsobsolete" />
    [Obsolete(ObsoleteMessage, true)]
    private static string RemoveAccents(this string? input) // Obsolete member made private otherwise clash.
        => throw new NotSupportedException(ObsoleteMessage);

    /// <inheritdoc cref="_removeaccentsobsolete" />
    [Obsolete(ObsoleteMessage, true)]
    public static string RemoveAccentsObsolete(this string? input) // Stand-in obsolete member for otherwise public member.
        => throw new NotSupportedException(ObsoleteMessage);
}
