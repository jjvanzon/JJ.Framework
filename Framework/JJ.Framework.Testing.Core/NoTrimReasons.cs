
namespace JJ.Framework.Testing.Core;

internal static class NoTrimReasons
{
    public const string MisingTypes = "Types might be removed";
    public const string TypeArray = "Trimming not supported in case of Type arrays. Use other overloads for instance with a single Type instead.";
}