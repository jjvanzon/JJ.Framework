// ReSharper disable CheckNamespace

namespace Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Reflection;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class DataRowAttribute : Attribute
{
    public DataRowAttribute() : this([]) { }
    public DataRowAttribute(object? data) => Data = data is not null ? [data] : [null];
    public DataRowAttribute(string?[]? stringArrayData) : this([stringArrayData]) { }
    public DataRowAttribute(params object?[]? data) => Data = data ?? [null];
    public object?[] Data { get; }
    public string? DisplayName { get; set; }
    public IEnumerable<object?[]> GetData(MethodInfo methodInfo) => [Data];
    public virtual string? GetDisplayName(MethodInfo methodInfo, object?[]? data) => DisplayName ?? "";
}
