#if !NET9_0_OR_GREATER

namespace System.Threading;

internal sealed class Lock
{
    public readonly ref struct Scope : System.IDisposable
    {
        public void Dispose() { }
    }

    public Scope EnterScope() => default;
}

#endif