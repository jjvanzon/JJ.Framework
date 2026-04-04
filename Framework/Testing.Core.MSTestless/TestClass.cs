// ReSharper disable UnusedMember.Global

namespace Microsoft.VisualStudio.TestTools.UnitTesting;

/// <inheritdoc cref="_testclass" />
[AttributeUsage(AttributeTargets.Class)]
public class TestClassAttribute : Attribute
{
    /// <summary>
    /// Gets the test method attribute for the specified test method.
    /// </summary>
    public virtual TestMethodAttribute? GetTestMethodAttribute(TestMethodAttribute? testMethodAttribute) 
        => testMethodAttribute;
}