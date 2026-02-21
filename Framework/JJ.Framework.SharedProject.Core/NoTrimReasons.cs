// ReSharper disable UnusedType.Global
#pragma warning disable IDE0051 // Member never used

namespace JJ.Framework.SharedProject.Core;

internal static class NoTrimReasons
{
    private const string DoWhatInstead = 
        "Alternatives: " + 
        @"* Use [UnconditionalSuppressMessage(""Trimmer"", ""IL..."", Justification = ""..."")] to ignore warning if expected types are loaded. " +
        "* Use Type parameter if available. " +
        "* Use [RequiresUnreferencedCode(...)] on your member to propagate trimmability warning. " +
        "* Use [DynamicDependency(...)] near code failing (at runtime) to retain a type after trimming.";

    public const string GetTypes = "JJ0002 - Assembly.GetTypes() called internally. Types might be removed in case of trimming. " + DoWhatInstead;
    public const string TypeColl =  "JJ0003 - TypeCollection: Limited safety for trimming because a Type collections is used. " + DoWhatInstead;
    public const string TypeCollection = "JJ0003 - TypeCollection: Limited safety for trimming because a Type collections is used. " + DoWhatInstead;
    public const string ObjectGetType = "JJ0004 - GetType: Limited safety for trimming because Object.GetType() is used internally. " + DoWhatInstead;
    public const string PropertyType = "JJ0005 - PropertyType: Limited safety for trimming because PropertyInfo.PropertyType is used internally. " + DoWhatInstead;
    public const string FieldType = "JJ0006 - FieldType: Limited safety for trimming because FieldInfo.FieldType is used internally. " + DoWhatInstead;

    public const string ArrayInit = 
        "JJ0007 - ArrayInit: Array.CreateInstance called internally. " +
        "Not a problem for trimmable code for .NET 9 and up, but can cause issues with lower .NET versions. " +
        "* You could pick an expression-free variant of the function if available (one without `() =>` notation). " +
        "* You can also ignore the warning if your (lambda) expression does have array initialization in it." +
        "* NOTE: Your lambda expression can also have an array init unnoticed," +
        "  if you call anything with a variadic amount of arguments (`params`)." +
        "* You could also propagate this warning by annotating your method with: " +
        "#if !NET9_0_OR_GREATER " +
        "[RequiresUnreferencedCode(<Reason>)] " +
        "#endif " + DoWhatInstead;

    public const string WhenShowIndexerValues = 
        "JJ0008 - WhenShowIndexerValues: Array.CreateInstance called if ShowIndexerValues is true. " +
        "This is not a problem for .NET 9 and up, but can cause issues with lower .NET versions. " +
        "* You can ignore the warning when you're not using an array. " +
        "* or by using ShowIndexerValues = false. " + DoWhatInstead;

    public const string TupleGetType = 
        "JJ0009 - Tuple is used as object, which requires the Type to be available after code trimming. " + DoWhatInstead;

    public const string Bases = 
        "JJ0010 - Gets base types and then reflects on its members, which can't be guaranteed to be trim-safe. " + DoWhatInstead;

    public const string Lambda = "JJ0011 - Lambda: Trimmer complains, because of usage in a lamda expression, not actual use of reflection." + DoWhatInstead;
}