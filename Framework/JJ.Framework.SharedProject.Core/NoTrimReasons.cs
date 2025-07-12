namespace JJ.Framework.SharedProject.Core;

internal static class NoTrimReasons
{
    public const string GetTypes = "JJ0002 - Assembly.GetTypes() called internally. Types might be removed in case of trimming. " + WhatInstead;
    public const string TypeCollection = "JJ0003 - Type collections: Trimming not supported in case of Type collections. " + WhatInstead;
    public const string ObjectGetType = "JJ0004 - GetType: Trimming not supported because Object.GetType() is used internally. " + WhatInstead;
    public const string PropertyType = "JJ0005 - PropertyType: Trimming not supported because PropertyInfo.PropertyType is used internally. " + WhatInstead;
    public const string ExpressionsWithArrays = 
        "JJ0006 - Expressions with Arrays: Array.CreateInstance called internally. " +
        "Not a problem for trimmable code for .NET 9 and up, but can cause issues with lower .NET versions. " +
        "You can ignore the warning if you're not using an array " +
        "or if you're sure the array type is loaded. " +
        "If you're not sure, you can also propagate this warning by annotating your method with " +
        "#if !NET9_0_OR_GREATER " +
        "[RequiresUnreferencedCode(<Reason>)] " +
        "#endif";

    public const string WhenShowIndexerValues = 
        "JJ0007 - Array.CreateInstance called if ShowIndexerValues is true. " +
        "This is not a problem for .NET 9 and up, but can cause issues with lower .NET versions. " +
        "You can ignore the warning when you're not using an array, " +
        "or if you're sure your array Type is loaded, " +
        "or by using ShowIndexerValues = false .";

    private const string WhatInstead = "Use overload with a Type parameter instead. Or ignore the warning if you're sure the types are loaded.";
}