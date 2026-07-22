#pragma warning disable IDE0051 // Private member never used.

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedParameter.Local

namespace JJ.Framework.Common.Core;

/// <inheritdoc cref="_commonstringextensionscore" />
[Obsolete(ObsoleteMessage, true)]
public static class CommonStringExtensionsCore
{
    private const string ObsoleteMessage 
        = "Use StringExtensionsCore.RemoveAccents from JJ.Framework.Text.Core instead.";
    
    /// <inheritdoc cref="_removeaccentsobsolete" />
    [Obsolete(ObsoleteMessage, true)]
    public static string RemoveAccents(string? input) // Obsolete member no longer extension, just static otherwise clash.
        => throw new NotSupportedException(ObsoleteMessage);

    /// <inheritdoc cref="_removeaccentsobsolete" />
    [Obsolete(ObsoleteMessage, true)]
    public static string RemoveAccentsObsolete(this string? input) // Stand-in obsolete member for otherwise public member.
        => throw new NotSupportedException(ObsoleteMessage);
}
