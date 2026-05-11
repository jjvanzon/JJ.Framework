// ReSharper disable CheckNamespace
namespace Microsoft.VisualStudio.TestTools.UnitTesting;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method)]
public class DoNotParallelizeAttribute : Attribute;
