// ReSharper disable UnusedAutoPropertyAccessor.Global

#if !NET5_0_OR_GREATER

using JJ.Framework.PlatformCompatibility.Core.docs;

namespace System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="_unconditionalsuppressmessage" />
[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
internal sealed class UnconditionalSuppressMessageAttribute(string category, string checkId) : Attribute
{
    /// <inheritdoc cref="_unconditionalsuppressmessage" />
    public string Category { get; } = category;
    /// <inheritdoc cref="_unconditionalsuppressmessage" />
    public string CheckId { get; } = checkId;
    /// <inheritdoc cref="_unconditionalsuppressmessage" />
    public string? Scope { get; set; }
    /// <inheritdoc cref="_unconditionalsuppressmessage" />
    public string? Target { get; set; }
    /// <inheritdoc cref="_unconditionalsuppressmessage" />
    public string? MessageId { get; set; }
    /// <inheritdoc cref="_unconditionalsuppressmessage" />
    public string? Justification { get; set; }
}

#endif
