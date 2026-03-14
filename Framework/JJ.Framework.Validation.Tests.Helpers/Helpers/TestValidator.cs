// ReSharper disable VirtualMemberCallInConstructor

namespace JJ.Framework.Validation.Legacy.Tests.Helpers;

/// <summary>
/// Allows injecting the Execute method implementation.
/// </summary>
public class TestValidator : FluentValidator<object>
{
    private readonly Action<TestValidator> _impl;

    public TestValidator(Action<TestValidator>? impl = null)
        : base(null, postponeExecute: true)
    {
        impl ??= _ => { };
        _impl = impl;
        Execute();
    }

    protected override void Execute() => _impl(this);
}
