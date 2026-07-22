namespace JJ.Framework.Common.Core.Tests.Helpers;

[Suppress("Trimmer", "IL2026", Justification = GenericMethodAnd + GetTypesAnd + Bases)]
[Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
internal class CommonStringExtensionsCore_Obsolete_Accessor
{
    private readonly AccessorCore _accessor 
        = new("CommonStringExtensionsCore");

    public string ObsoleteMessage => (string)_accessor.Get()!;
    public string RemoveAccents(string? input) => (string)_accessor.Call([ input ])!;
    public string RemoveAccentsObsolete(string? input) => (string)_accessor.Call([ input ])!;
}