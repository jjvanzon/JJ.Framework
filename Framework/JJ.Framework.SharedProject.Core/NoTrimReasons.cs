namespace JJ.Framework.SharedProject.Core;

internal static class NoTrimReasons
{
    private const string WhatInstead = "Use overload with a Type parameter if available. Or ignore the warning if you're sure the expected types are loaded.";

    public const string GetTypes = "JJ0002 - Assembly.GetTypes() called internally. Types might be removed in case of trimming. " + WhatInstead;
    public const string TypeColl = TypeCollection;
    public const string TypeCollection = "JJ0003 - TypeCollection: Limited safety for trimming because a Type collections is used. " + WhatInstead;
    public const string ObjectGetType = "JJ0004 - GetType: Limited safety for trimming because Object.GetType() is used internally. " + WhatInstead;
    public const string PropertyType = "JJ0005 - PropertyType: Limited safety for trimming because PropertyInfo.PropertyType is used internally. " + WhatInstead;
    public const string FieldType = "JJ0006 - FieldType: Limited safety for trimming because FieldInfo.FieldType is used internally. " + WhatInstead;

    public const string ExpressionsWithArrays = 
        "JJ0007 - ExpressionsWithArrays: Array.CreateInstance called internally. " +
        "Not a problem for trimmable code for .NET 9 and up, but can cause issues with lower .NET versions. " +
        "You could pick an expression-free variant of the function if available (one without `() =>` notation). " +
        "You can also ignore the warning if you're not using an array " +
        "or if you're sure the array type is loaded. " +
        "You can also propagate this warning by annotating your method with: " +
        "#if !NET9_0_OR_GREATER " +
        "[RequiresUnreferencedCode(<Reason>)] " +
        "#endif " + 
        "Another option is to use [DynamicDependency(...)] near (runtime) failing code to retain a type after trimming.";

    public const string WhenShowIndexerValues = 
        "JJ0008 - WhenShowIndexerValues: Array.CreateInstance called if ShowIndexerValues is true. " +
        "This is not a problem for .NET 9 and up, but can cause issues with lower .NET versions. " +
        "You can ignore the warning when you're not using an array, " +
        "or if you're sure your array Type is loaded, " +
        "or by using ShowIndexerValues = false .";

    public const string TupleGetType = 
        "JJ0009 - Tuple is use as object, which requires the Type to be available after code trimming. " +
        "Either propagate the trimmability annotation or ignore the warning if you know the tuple Type will be available.";

}