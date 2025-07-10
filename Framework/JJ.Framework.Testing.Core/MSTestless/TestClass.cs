// ReSharper disable UnusedMember.Global

namespace JJ.Framework.Testing.Core.MSTestless;

/// <inheritdoc cref="_testclass" />
[AttributeUsage(AttributeTargets.Class)]
public class TestClassAttribute : Attribute
{
    /// <inheritdoc cref="_gettestmethodattribute" />
    public virtual TestMethodAttribute? GetTestMethodAttribute(TestMethodAttribute? testMethodAttribute) 
        => testMethodAttribute;
}