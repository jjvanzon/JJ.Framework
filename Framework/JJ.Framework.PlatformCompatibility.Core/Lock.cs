#pragma warning disable IDE0001 // Redundant qualifier
// ReSharper disable UnusedType.Global

// ncrunch: no coverage start

#if !NET9_0_OR_GREATER

using JJ.Framework.PlatformCompatibility.Core.docs;

namespace System.Threading;

/// <inheritdoc cref="_lock" />
internal sealed class Lock
{
    public readonly ref struct Scope : System.IDisposable
    {
        public void Dispose() { }
    }

    public Scope EnterScope() => default;
}

#endif

// ncrunch: no coverage end
