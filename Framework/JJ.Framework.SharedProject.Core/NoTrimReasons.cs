﻿namespace JJ.Framework.SharedProject.Core;

internal static class NoTrimReasons
{
    private const string WhatInstead = 
        "Alternatives: " + 
        @"* Use [UnconditionalSuppressMessage(""Trimmer"", ""IL..."", Justification = ""..."")] to ignore warning if expected types are loaded. " +
        "* Use Type parameter if available. " +
        "* Use [RequiresUnreferencedCode(...)] on your member to propagate trimmability warning. " +
        "* Use [DynamicDependency(...)] near code failing (at runtime) to retain a type after trimming.";

    public const string GetTypes = "JJ0002 - Assembly.GetTypes() called internally. Types might be removed in case of trimming. " + WhatInstead;
    public const string TypeColl = TypeCollection;
    public const string TypeCollection = "JJ0003 - TypeCollection: Limited safety for trimming because a Type collections is used. " + WhatInstead;
    public const string ObjectGetType = "JJ0004 - GetType: Limited safety for trimming because Object.GetType() is used internally. " + WhatInstead;
    public const string PropertyType = "JJ0005 - PropertyType: Limited safety for trimming because PropertyInfo.PropertyType is used internally. " + WhatInstead;
    public const string FieldType = "JJ0006 - FieldType: Limited safety for trimming because FieldInfo.FieldType is used internally. " + WhatInstead;

    public const string ExpressionsWithArrays = 
        "JJ0007 - ExpressionsWithArrays: Array.CreateInstance called internally. " +
        "Not a problem for trimmable code for .NET 9 and up, but can cause issues with lower .NET versions. " +
        "* You could pick an expression-free variant of the function if available (one without `() =>` notation). " +
        "* You can also ignore the warning if you're not using an array " +
        "* You can also propagate this warning by annotating your method with: " +
        "#if !NET9_0_OR_GREATER " +
        "[RequiresUnreferencedCode(<Reason>)] " +
        "#endif " + WhatInstead;

    public const string WhenShowIndexerValues = 
        "JJ0008 - WhenShowIndexerValues: Array.CreateInstance called if ShowIndexerValues is true. " +
        "This is not a problem for .NET 9 and up, but can cause issues with lower .NET versions. " +
        "* You can ignore the warning when you're not using an array. " +
        "* or by using ShowIndexerValues = false. " + WhatInstead;

    public const string TupleGetType = 
        "JJ0009 - Tuple is use as object, which requires the Type to be available after code trimming. " + WhatInstead;

    public const string Bases = 
        "JJ0010 - Gets base types and then reflects on its members, which can't be guaranteed to be trim-safe. " + WhatInstead;

}