namespace JJ.Framework.Compilation.Core.Tests.Accessors;

[Suppress("Trimmer", "IL2026", Justification = BasesAnd + GenericMethod)]
[Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
internal static class DotNetResultFormatterExtensionsAccessor
{
    private static readonly AccessorCore _accessor = new ("DotNetResultFormatterExtensions");

    extension(DotNetResult? result)
    {
        public string Stringify() 
            => (string)_accessor.Call(Name(), result)!;

        public string DebuggerDisplay() 
            => (string)_accessor.Call(Name(), result)!;

        public string ExceptionMessage()
            => (string)_accessor.Call(Name(), result)!;

        public string Descriptor(bool singleLine = false)
            => (string)_accessor.Call(Name(), result, singleLine)!;
    }
}
