// ReSharper disable CheckNamespace
namespace Microsoft.VisualStudio.TestTools.UnitTesting;

/// <inheritdoc cref="_testmethod" />
[AttributeUsage(AttributeTargets.Method)]
public class DataTestMethod : TestMethodAttribute
{
    /// <inheritdoc cref="_testmethod" />
    public DataTestMethod() { }
    /// <inheritdoc cref="_testmethod" />
    public DataTestMethod(string? displayName) : base(displayName) { }
}