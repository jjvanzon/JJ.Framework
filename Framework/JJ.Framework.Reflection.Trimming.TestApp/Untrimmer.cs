// ReSharper disable UnusedType.Global

namespace JJ.Framework.Reflection.Legacy.Trimming.TestApp;

internal static class Untrimmer
{
    public static void Untrim()
    {
        Tests.CoreTestHelpers.Namespace1.DuplicateClass_13017ef1 _dup1 = new();
        Tests.CoreTestHelpers.Namespace2.DuplicateClass_13017ef1 _dup2 = new();
        ReflectionCache_Method_CoreTests_GenericOverload.Untrim();
    }
}
