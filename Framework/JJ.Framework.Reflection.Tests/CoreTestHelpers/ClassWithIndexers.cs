// ncrunch: no coverage start

namespace JJ.Framework.Reflection.Legacy.Tests.CoreTestHelpers;

internal class ClassWithIndexers
{
    public int this[int index] { get => default; set { } }
    public int this[int index, string text] { get => default; set { } }
}

// ncrunch: no coverage end