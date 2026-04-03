// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace JJ.Framework.Testing.Core.MSTestless;

/// <inheritdoc cref="_testmethod" />
[AttributeUsage(AttributeTargets.Method)]
public class TestMethodAttribute : Attribute
{
    /// <inheritdoc cref="_testmethod" />
    public TestMethodAttribute() : this(null) { }

    /// <inheritdoc cref="_testmethod" />
    public TestMethodAttribute(string? displayName) => DisplayName = displayName;

    /// <inheritdoc cref="_testmethod" />
    public string? DisplayName { get; }

    /// <inheritdoc cref="_testmethodexecute" />
    public virtual void Execute(object testMethod) => throw new NotSupportedException("Not supported in MSTestless.");
    //public virtual TestResult[] Execute(ITestMethod testMethod) => [testMethod.Invoke(null)];
}