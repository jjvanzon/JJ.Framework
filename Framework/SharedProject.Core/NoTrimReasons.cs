// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
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

    public const string GetTypesAnd = "JJ0002 - ASSEMBLY GET TYPES called internally. Types might be removed in case of trimming. ";
    public const string GetTypes = GetTypesAnd + DoWhatInstead;
    public const string TypeCollAnd =  "JJ0003 - TYPE COLLECTION: Limited safety for trimming because a Type collections is used. ";
    public const string TypeColl =  TypeCollAnd + DoWhatInstead;
    public const string TypeCollectionAnd = "JJ0003 - TYPE COLLECTION: Limited safety for trimming because a Type collections is used. ";
    public const string TypeCollection = TypeCollectionAnd + DoWhatInstead;
    public const string ObjectGetTypeAnd = "JJ0004 - GET TYPE: Limited safety for trimming because Object.GetType() is used internally. ";
    public const string ObjectGetType = ObjectGetTypeAnd + DoWhatInstead;
    public const string PropertyTypeAnd = "JJ0005 - PROPERTY TYPE: Limited safety for trimming because PropertyInfo.PropertyType is used internally. ";
    public const string PropertyType = PropertyTypeAnd + DoWhatInstead;
    public const string FieldTypeAnd = "JJ0006 - FIELD TYPE: Limited safety for trimming because FieldInfo.FieldType is used internally. ";
    public const string FieldType = FieldTypeAnd + DoWhatInstead;

    public const string ArrayInitAnd = 
        "JJ0007 - ARRAY INIT: Array.CreateInstance called internally. " +
        "Not a problem for trimmable code for .NET 9 and up, but can cause issues with lower .NET versions. " +
        "* You could pick an expression-free variant of the function if available (one without `() =>` notation). " +
        "* You can also Suppress the warning if your (lambda) expression does have array initialization in it." +
        "* NOTE: Your lambda expression can also have an array init unnoticed," +
        "  if you call anything with a variadic amount of arguments (`params`)." +
        "* You could also propagate this warning by annotating your method with: " +
        "#if !NET9_0_OR_GREATER " +
        "[RequiresUnreferencedCode(<Reason>)] " +
        "#endif " ;
    public const string ArrayInit = ArrayInitAnd + DoWhatInstead;

    public const string WhenShowIndexerValuesAnd = 
        "JJ0008 - SHOW WHEN INDEXER VALUES: Array.CreateInstance called if ShowIndexerValues is true. " +
        "This is not a problem for .NET 9 and up, but can cause issues with lower .NET versions. " +
        "* You can ignore the warning when you're not using an array. " +
        "* or by using ShowIndexerValues = false. ";
    public const string WhenShowIndexerValues = WhenShowIndexerValuesAnd + DoWhatInstead;

    public const string TupleGetTypeAnd = "JJ0009 - TUPLE is used as object, which requires the Type to be available after code trimming. ";
    public const string TupleGetType = TupleGetTypeAnd + DoWhatInstead;

    public const string BasesAnd = "JJ0010 - BASE TYPES and their members reflected, which can't be guaranteed to be trim-safe. ";
    public const string Bases = BasesAnd + DoWhatInstead;

    public const string LambdaAnd = "JJ0011 - LAMBDA: Trimmer complains, because of usage in a lamda expression, not actual use of reflection.";
    public const string Lambda = LambdaAnd + DoWhatInstead;

    public const string TypeLoadedAnd = "JJ0012 - TYPE LOADED: Trimming issue can be ignored, when Type loaded.";
    public const string TypeLoaded = TypeLoadedAnd + DoWhatInstead;

    public const string GenericMethodAnd = 
        "JJ0013 - GENERIC METHOD: Reflection could attempt to construct a generic method, that should exist at compile-time instead. " +
        "Compile it in by referencing your method like: " +
        "var func = MyMethod<int, string>; That way it can be found with reflection at run-time. " +
        "Each combination with type arguments that is used, needs an explicit reference. ";
    public const string GenericMethod = GenericMethodAnd + DoWhatInstead;
}